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
        public void GetCustomers()
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                //ctx.Customer.
            }
        }


    }
}
