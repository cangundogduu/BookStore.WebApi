using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.Category;
using BookStore.WebApi.Dtos.Quote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController(IQuoteService _quoteService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult QuoteList()
        {
            var values = _quoteService.TGetAll();
            var mapping = _mapper.Map<List<QuoteResultDto>>(values);

            return Ok(mapping);
            
        }



        [HttpPost]
        public IActionResult CreateQuote(QuoteCreateDto quoteCreateDto )
        {
            var value = _mapper.Map<Quote>(quoteCreateDto);
            _quoteService.TAdd(value);
            return Ok("Ekleme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _quoteService.TDelete(id);
            return Ok("Silme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(QuoteUpdateDto quoteUpdateDto)
        {
            var value = _mapper.Map<Quote>(quoteUpdateDto);
            _quoteService.TUpdate(value);
            return Ok("Güncelleme işlemi başarı ile gerçekleştirildi.");
        }

        [HttpGet("GetByIdCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _quoteService.TGetById(id);
            var result = _mapper.Map<QuoteGetByIdDto>(value);

            return Ok(result);
        }
    }
}
