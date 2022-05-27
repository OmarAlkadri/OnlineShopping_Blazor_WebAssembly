namespace OnlineShoppingCenterproject.Client.Services
{
    public class ProductCountState
    {
        public int Count { get; private set; }
        public event Action onChange;

        public void SetProductCount(int count)
        {
            Count = count;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => onChange?.Invoke();
    }
}
