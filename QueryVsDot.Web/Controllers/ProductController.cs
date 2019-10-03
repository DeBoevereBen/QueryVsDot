using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryVsDot.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryVsDot.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        // get all products
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProducts()
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var categories = ctx.Product.ToList();
                return Ok(categories);
            }
        }


        // get all categories
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var categories = ctx.ProductCategory
                    .Where(p => p.ParentProductCategoryId != null)
                    .Select(p => new { p.ProductCategoryId, p.Name, Count = p.Product.Count})
                    .ToList();

                return Ok(categories);
            }
        }


        // get products in category
        [HttpGet]
        [Route("categories/{CategoryId}")]
        public async Task<IActionResult> GetProductsInCategory(int CategoryId)
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                return Ok(
                    ctx.Product.Where(p => p.ProductCategory.ProductCategoryId == CategoryId).ToList()
                  );
            }
        }

        // get product
        [HttpGet]
        [Route("{ProductId}")]
        public async Task<IActionResult> GetProductById(int ProductId)
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var p = ctx.Product.Find(ProductId);
                if (p == null)
                {
                    return NotFound(ProductId);
                }
                else
                {
                    return Ok(p);
                }
            }
        }

        [HttpGet]
        [Route("categories/avgprice")]
        public async Task<IActionResult> GetAveragePricePerCategory()
        {
            using (var ctx = new AdventureWorksLT2017Context())
            {
                var res = ctx.AveragePriceCategories.FromSqlRaw("select pc.Name, avg(p.ListPrice) as avg from SalesLT.Product p join SalesLT.ProductCategory pc on p.ProductCategoryID = pc.ProductCategoryID group by pc.ProductCategoryID, pc.Name order by avg")
                    .ToList();
                return Ok(res);
            }

        }

    }
}
