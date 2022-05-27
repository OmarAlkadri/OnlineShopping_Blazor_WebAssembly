using AutoMapper;
using OnlineShoppingCenterproject.Core.Dto.AddresssDto;
using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Dto.PaymentsDto;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Dto.FavoriteForProductsDto;
using OnlineShoppingCenterproject.Core.Dto.QuestionssDto;
using OnlineShoppingCenterproject.Core.Dto.AnswerssDto;

namespace OnlineShoppingCenterproject.Core.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FavoriteForProduct, FavoriteForProductDto>();
            CreateMap<FavoriteForProductForCreationDto, FavoriteForProduct>();

            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<CompanyForUpdateToActivationDto, User>();

            CreateMap<Payment, PaymentDto> ();
            CreateMap<PaymentForCreationDto, Payment>();

            CreateMap<Questions, QuestionsDto>();
            CreateMap<QuestionsForCreationDto, Questions>();

            CreateMap<Answers, AnswersDto>();
            CreateMap<AnswersForCreationDto, Answers>();

            CreateMap<Castomer, CastomerDto>();
            CreateMap<CastomerForCreationDto, Castomer>();
            CreateMap<CastomerForUpdateDto, Castomer>();

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyForCreationDto, Company>();  
            CreateMap<CompanyForUpdateDto, Company>();
          
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();

            CreateMap<ProductCompany, ProductCompanyDto>();
            CreateMap<ProductCompanyForCreationDto, ProductCompany>();
            CreateMap<ProductCompanyForUpdateDto, ProductCompany>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<OrderAddress, OrderAddressDto>();
            CreateMap<OrderAddressForCreationDto, OrderAddress>();
            CreateMap<OrderAddressForUpdateDto, OrderAddress>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemForCreationDto, OrderItem>();

            CreateMap<Address, AddressDto>();
            CreateMap<AddressForCreationDto, Address>();

            CreateMap<CastomerAddress, CastomerAddressDto>();
            CreateMap<CastomerAddressForCreationDto, CastomerAddress>();
        }
    }
}