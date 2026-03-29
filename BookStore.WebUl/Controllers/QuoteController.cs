using BookStore.WebUI.Dtos.QuoteDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.Controllers
{
    public class QuoteController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> QuoteList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7228/api/Quotes");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultQuoteDto>>(jsonData);
                return Ok(values);
            }
            return View();
        }
    }
}
