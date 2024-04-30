using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CricketStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService service;

        public CartsController(ICartService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartRequestDTO Cart)
        {
            var res = await service.Add(Cart);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CartRequestDTO Cart)
        {
            var res = await service.Update(id, Cart);
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
