using BookStore.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IHttpClientFactory _httpCilentFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpCilentFactory = httpClientFactory;
        }


        public async Task<IActionResult> CategoryList()
        {

            var client = _httpCilentFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7228/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryAddDto)
        {
            var client = _httpCilentFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryAddDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7228/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpCilentFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7228/api/Categories?id=" + id);
            return RedirectToAction("CategoryList");


        }
    }
}
