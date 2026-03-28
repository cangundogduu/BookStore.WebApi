namespace BookStore.WebApi.Dtos.Quote
{
    public class QuoteUpdateDto
    {
        public int QuoteId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
