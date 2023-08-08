
using ApiTest.DataBase;
using ApiTest.Models;
using ApiTest.Models.ErrorModel;
using ApiTest.Repository;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;

 
namespace ApiTest.Controllers
{

    [Route("api/CustomerApi")]
    [ApiController]
    
     
    public class CustomerApi : ControllerBase
    {

        private bool checking(string name,  string expression)
        {
            
            string namePattern = expression;
 
            if (Regex.IsMatch(name, namePattern))
            {
                return true;
            }
             
            return false;
        }



        RepositoryModel db ;
        public CustomerApi() {
            db = new RepositoryModel();
        }
         
        // GET: api/CustomerApi
        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> Get()
        {
            return await db.GetAllAsync();
        }

        // GET api/CustomerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> Get(int id)
        {
            var customer = await db.GetById(id);
            if (customer is null)
            {
                ErrorClass er = new ErrorClass(403 ,"Record Not Found");
                return NotFound(er);
            }

            return Ok(customer);
        }

        // POST api/CustomerApi
        [HttpPost]
        public async Task<ActionResult<List<CustomerModel>>> Add(CustomerModel customer)
        {
            var result = await db.Add(customer);
            return Ok(result);
        }

        // PUT api/CustomerApi/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CustomerModel request)
        {

            if (request.Name != null)
            {
                string exp = "^[A-Za-z ]+$";
                if (request.Name.Length < 3)
                {
                    ErrorClass er = new ErrorClass(400, "Name has at least 3 Length.");

                    return BadRequest(er);
                    }
                
                     if (!checking(request.Name, exp))
                    {
                        ErrorClass er = new ErrorClass(400, "Insert Valid Name.");

                        return BadRequest(er);
                    }
            }
           
            if (request.Country != null)
            {
                   string exp = "^[A-Za-z]+$";
                
                     if (!checking(request.Country, exp))
                    {
                        ErrorClass er = new ErrorClass(400, "Insert Valid Country Name.");

                        return BadRequest(er);
                    }
            }

            if (request.Phone != null)
            {   

                string exp = "^[0-9]+$";
               
                if (!checking(request.Phone, exp))
                {
                    ErrorClass er = new ErrorClass(400, "Insert Valid Phone Number.");

                    return BadRequest(er);
                }
                if (request.Phone.Length != 11)
                {
                    ErrorClass er = new ErrorClass(400, "Phone Number must have 11 digit.");

                    return BadRequest(er);
                }
            }
            if (request.City != null)
            {
                string exp = "^[A-Za-z ]+$";

                if (!checking(request.City, exp))
                {
                    ErrorClass er = new ErrorClass(400, "Insert Valid City Name.");

                    return BadRequest(er);
                }

            }
            if (request.Region != null)
            {
                string exp = "^[A-Za-z ]+$";

                if (!checking(request.Region, exp))
                {
                    ErrorClass er = new ErrorClass(400, "Insert Valid Region Name.");

                    return BadRequest(er);
                }

            }
            if (request.PostalCode != null)
            {
                string exp = "^[0-9]+$";

                if (!checking(request.PostalCode, exp))
                {
                    ErrorClass er = new ErrorClass(400, "Insert Valid PostalCode.");

                    return BadRequest(er);
                }
            }

            
            var result = await db.Update(id, request);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        // DELETE api/CustomerApi/5
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
