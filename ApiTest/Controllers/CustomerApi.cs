
using ApiTest.DataBase;
using ApiTest.Models;
using ApiTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTest.Controllers
{
    [Route("api/CustomerApi")]
    [ApiController]
    
     
    public class CustomerApi : ControllerBase
    {
        RepositoryModel db ;
        public CustomerApi() {
            db = new RepositoryModel();
        }
         
        // GET: api/<CustomerApi>
        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> Get()
        {
            return await db.GetAllAsync();
        }

        // GET api/<CustomerApi>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> Get(int id)
        {
            var customer = await db.GetById(id);
            if (customer is null)
                return NotFound("Customer not found.");

            return Ok(customer);
        }

        // POST api/<CustomerApi>
        [HttpPost]
        public async Task<ActionResult<List<CustomerModel>>> Add(CustomerModel customer)
        {
            var result = await db.Add(customer);
            return Ok(result);
        }

        // PUT api/<CustomerApi>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<CustomerModel>>> Update(int id, CustomerModel customer)
        {
            //return Ok(customer);
            Console.WriteLine("this is put funciton");
            var result = await db.Update(id, customer);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        // DELETE api/<CustomerApi>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CustomerModel>>> Delete(int id)
        {
            var result = await db.Delete(id);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }
    }
}
