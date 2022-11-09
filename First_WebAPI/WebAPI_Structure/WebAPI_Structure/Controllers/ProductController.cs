using Microsoft.AspNetCore.Authorization; // added  Authorize
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Structure.Infra.Services.Products;

namespace WebAPI_Structure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsServices _productServices;
        public ProductController(IProductsServices productServices)
        {
            _productServices = productServices;
        }
        [Authorize]
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var data = await _productServices.GetAllProduct();
                if (data.Count != 0)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok("null");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
