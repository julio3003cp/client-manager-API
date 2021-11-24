using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using cli_manager_API.Services.Company;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cli_manager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompany _company;
        public CompaniesController(ICompany company)
        {
            _company = company;
        }

        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await _company.Get();
                return Ok(companies);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var company = await _company.Get(id);
                return Ok(company);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.DTOs.Company newCompany)
        {
            try
            {
                var createdCompany = await _company.Create(newCompany);
                return Created($"api/Companies/{createdCompany.Id}",createdCompany);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.DTOs.Company updatedCompany)
        {
            try
            {
                await _company.Update(id, updatedCompany);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _company.Remove(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
