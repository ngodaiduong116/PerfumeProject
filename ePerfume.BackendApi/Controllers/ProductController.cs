using ePerfume.Application.Catalog.Products;
using ePerfume.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ePerfume.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicproductservice, IManageProductService manageproductservice)
        {
            _manageProductService = manageproductservice;
            _publicProductService = publicproductservice;
        }

        //http://localhost:port/product
        [HttpGet("{languaId}")]
        public async Task<IActionResult> Get(string languaId)
        {
            var products = await _publicProductService.GetAll(languaId);
            return Ok(products);
        }

        //http://localhost:port/product/public-paging
        [HttpGet("public-paging/{languaId}")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var product = await _manageProductService.GetById(id, languageId);
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedResult = await _manageProductService.Delete(id);
            if (deletedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("Price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(id,newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
