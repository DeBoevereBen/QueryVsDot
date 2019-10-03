using Microsoft.AspNetCore.Mvc;
using QueryVsDot.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryVsDot.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // get all customers 
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCustomers()
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var result = from c in ctx.Customer
                             select c;

                return Ok(result.ToList());
            }
        }

        // get customer by id
        [HttpGet]
        [Route("{CustomerId}")]
        public async Task<IActionResult> GetCustomerById(int CustomerId)
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var res = from c in ctx.Customer
                          where c.CustomerId == CustomerId
                          select c;
                return Ok(res);
            }
        }

        // search customer by name (contains)
        [HttpGet]
        [Route("search/{Name}")]
        public async Task<IActionResult> SearchCustomerByName(string Name)
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var res = from c in ctx.Customer
                          where c.FirstName.Contains(Name)
                          select c;
                
                return Ok(res.ToList());
            }
        }

    }
}
