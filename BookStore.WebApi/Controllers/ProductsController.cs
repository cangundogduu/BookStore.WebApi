using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.Category;
using BookStore.WebApi.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productService.TGetAll();
            var values = _mapper.Map<List<ProductResultDto>>(products);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto product)
        {
            var value = _mapper.Map<Product>(product);
            _productService.TAdd(value);
            return Ok("Ekleme işlemi başarı ile gerçekleştirildi.");
        }


        [HttpPut]
        public IActionResult UpdateProduct(ProductUpdateDto product)
        {
            var value = _mapper.Map<Product>(product);
            _productService.TUpdate(value);
            return Ok("Güncelleme işlemi başarı ile gerçekleştirildi.");
        }


        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            var result = _mapper.Map<ProductGetByIdDto>(value);
            return Ok(result);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _productService.TGetProductCount();
            return Ok(value);
        }

    }
}
