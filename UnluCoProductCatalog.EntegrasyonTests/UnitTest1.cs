using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.EntegrasyonTests.Common;
using Xunit;

namespace UnluCoProductCatalog.EntegrasyonTests
{
    public class CategoryControllerTests : IClassFixture<ManagerApplicationFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public CategoryControllerTests(ManagerApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Categories()
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act 
            var response = await client.GetAsync("http://localhost:3000/api/Categories");
            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryViewModel>>(json);


            //Assert
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
