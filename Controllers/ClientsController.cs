using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using cli_manager_API.Services.Client;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cli_manager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClient _client;
        public ClientsController(IClient client)
        {
            _client = client;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var clients = await _client.Get();

                return Ok(clients);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var client = await _client.Get(id);

                return Ok(client);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.DTOs.Cli.Client newClient)
        {
            try
            {
                var client = await _client.Create(newClient);
                return Created($"api/Clients/{client.ClientId}", client);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.DTOs.Cli.Client updatedClient)
        {
            try
            {
                await _client.Update(id, updatedClient);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _client.Remove(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
