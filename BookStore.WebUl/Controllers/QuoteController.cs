using BookStore.WebUI.Dtos.QuoteDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

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
                return View(values);
            }
            return View(new List<ResultQuoteDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuote(CreateQuoteDto quoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(quoteDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7228/api/Quotes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(QuoteList));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7228/api/Quotes/GetByIdCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdQuoteDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuote(UpdateQuoteDto quoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(quoteDto);
            var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7228/api/Quotes", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(QuoteList));

            }
            return View();
        }

        public async Task<IActionResult> DeleteQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7228/api/Quotes?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(QuoteList));
            }
            return View();
        }
    }
}
