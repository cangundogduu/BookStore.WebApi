namespace BookStore.WebApi.Dtos.Product
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
