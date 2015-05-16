using System.Collections.Generic;
using AspNet5IntegrationTesting.Entities;
using Microsoft.AspNet.Mvc;

namespace AspNet5IntegrationTesting.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(
                new List<Customer>()
                {
                    new Customer
                    {
                        CompanyName = "PDMLab",
                        AddressLine = "Ludwig-Erhard-Allee 10",
                        ZipCode = "76131",
                        City = "Karlsruhe",
                        Website = "https://pdmlab.com"
                    }
                });
        }
    }
}