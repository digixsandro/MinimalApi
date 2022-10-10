using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject
{
    public class PartApiTest
    {
        [Fact]
        public async void GetAllPartsTest()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/parts");
            var data = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void GetMostCommonWords()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetAsync("/part/mostcommon");
            var data = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}