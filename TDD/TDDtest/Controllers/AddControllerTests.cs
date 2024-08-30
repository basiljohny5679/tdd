using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TDDtest.Fixtures;
using test.NewFolder;

namespace TDDtest.Controllers
{
    public class AddControllerTests: IClassFixture<ApiWebApplicationFactory>
    {
        HttpClient _httpClient = new HttpClient();

        public AddControllerTests()
        {
           ApiWebApplicationFactory factory= new ApiWebApplicationFactory();
            _httpClient = factory.CreateClient();

        }
        [Fact]
        public async Task Post_Add_return_Sucess()
        {
            Data ob = new Data()
            {
                a = 10,
                b = 12
        };
            //Arrange
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ob), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/add", httpContent);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var resultString = await response.Content.ReadAsStringAsync();
            int result = int.Parse(resultString);

            // Verify the result matches the expected value
            Assert.Equal(22, result); // 10 + 12 = 22
        }

    }
}
