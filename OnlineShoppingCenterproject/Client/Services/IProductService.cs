using Blazored.Toast.Services;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;
using System.Net.Http.Json;

namespace OnlineShoppingCenterproject.Client.Services
{
    public interface IProductService
    {
        PagedResult<Product> PagedProducts { get; set; }
        Task<List<Product>> OnlyThree();
        Task GetPageSize();
        Task PagerPageChanged(int page, string? sortOrder = "", string? searchString = "");
        Task<List<ProductDto>> PagerPageChangedForCompany(int page);
        Task<string> UploadProductImage(MultipartFormDataContent content);
        Task<HttpResponseMessage> AddProduct(ProductCompanyForCreationDto product);
        Task UpdateProduct(Guid Id,ProductForUpdateDto product);
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public PagedResult<Product> PagedProducts { get; set; } = new PagedResult<Product>();
        private readonly IToastService _toastService;

        public ProductService(HttpClient http, IToastService toastService)
        {
            _http = http;
            _toastService = toastService;
        }
        public async Task GetPageSize()
        {
            PagedProducts = new PagedResult<Product>();
            PagedProducts.PageCount = await _http.GetFromJsonAsync<int>("api/Product/GetPageSize");
        }
        public async Task PagerPageChanged(int page, string? sortOrder="", string? searchString = "")
        {
            PagedProducts.Results.Clear();
            var a = $"api/Product/Page?sortOrder={sortOrder}&&searchString={searchString}&&page={page}";
            var result = await _http.GetFromJsonAsync<List<Product>>(a);
            for (int i = 0; i < (result.Count); i++)
            {

                    PagedProducts.Results.Add(result[i]);
            }
        }      
        public async Task<List<ProductDto>> PagerPageChangedForCompany(int page)
        {
            var a = $"api/Product/PageForCompany?page={page}";
            return await _http.GetFromJsonAsync<List<ProductDto>>(a);
        }

        public async Task<List<Product>> OnlyThree()
        {
            var a = $"api/Product/Page?page={1}";
            var result = await _http.GetFromJsonAsync<List<Product>>(a);
            if (result == null)
                return null;
            return result.Skip(2).Take(3).ToList();
        }

		public async Task<string> UploadProductImage(MultipartFormDataContent content)
		{
            var postResult = await _http.PostAsync("api/ProductCompany/Upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                //var imgUrl = Path.Combine("https://localhost:7042/", postContent);
                var imgUrl = postContent;
                return imgUrl;
            }
        }

        public async Task<HttpResponseMessage> AddProduct(ProductCompanyForCreationDto product)
        {
            var a = await _http.PostAsJsonAsync($"api/ProductCompany/CreateProduct", product);
            if (a.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return a;
            }
            else
            {
                _toastService.ShowSuccess(product.Product.Name.ToString(), "Added to Products:");
                return a;
            }
        }

		public async Task UpdateProduct(Guid Id,ProductForUpdateDto product)
		{
            await _http.PutAsJsonAsync<ProductForUpdateDto>($"api/Product/UpdateProduct/{Id}", product);
            _toastService.ShowSuccess(product.Name.ToString(), "Product Has Been Updated:");
        }
	}
}
