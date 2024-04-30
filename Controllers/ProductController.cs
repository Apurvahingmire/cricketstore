using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CricketStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await service.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var res = await service.GetById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbyBrandId/{byBrandId}")]
        public async Task<IActionResult> GetByBrandId(int byBrandId)
        {   
            var result = await this.service.GetByBrandId(byBrandId);

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequestDTO Product)
        {
            var res = await service.Add(Product);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductRequestDTO Product)
        {
            var res = await service.Update(id, Product);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await service.Delete(id);
            if (res) return Ok("Deleted Successfully");
            return BadRequest("Id not found");
        }
    }
}