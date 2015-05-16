using System.Collections.Generic;
using System.Net.Http;
using AspNet5IntegrationTesting.Entities;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Hosting.Startup;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Xunit;

namespace AspNet5IntegrationTesting.Tests
{
    public class CustomerControllerIntegrationTest
    {
        [Fact]
        public void ShouldReturnCustomer()
        {
            var config = new Configuration();
            config.AddCommandLine(new[] { "--server.urls", "http://localhost:5001" });
            var context = new HostingContext()
            {
                Configuration = config,
                ServerFactoryLocation = "Microsoft.AspNet.Server.WebListener",
                ApplicationName = "AspNet5IntegrationTesting",
                StartupMethods = new StartupMethods(builder => builder.UseMvc(), services =>
                {
                    services.AddMvc();
                    return services.BuildServiceProvider();
                })
            };


            using (new HostingEngine().Start(context))
            {
                var client = new HttpClient();
                var customers = client.GetAsync("http://localhost:5001/api/customers").Result
                    .Content.ReadAsAsync<List<Customer>>().Result;

                Assert.Equal(customers[0].CompanyName,"PDMLab");
            }
        } 
    }
}