using Api.Server.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;

namespace Api.Server.Integration.Test
{
    public class ServerControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient? client;
        public ServerControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            client = _factory.CreateClient();
        }
        [Fact]
        public async Task TestIfGetUserIsReturningUserAsync()
        {
            // Substitua "http://localhost:5000" pelo URL da sua API.
            //httpClient.BaseAddress = new System.Uri("http://localhost:5000");
            client = _factory.CreateClient();
            // Faz a requisição para o endpoint
            var response = await client.GetAsync("/server/user");


            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            // Verifica se o status code é 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Lê o corpo da resposta como string
            var responseString = await response.Content.ReadAsStringAsync();

            // Deserializa o JSON da resposta
            var user = JsonConvert.DeserializeObject<User>(responseString); // Use JsonDocument.Parse(responseString) se estiver usando System.Text.Json

            // Verifica se os valores deserializados correspondem ao esperado
            Assert.Equal("Eduardo", user.Name);
            Assert.Equal(19, user.Age);
        }

        [Fact]
        public async Task TestIfGetUserIsReturningUserAsync2()
        {
            // Substitua "http://localhost:5000" pelo URL da sua API.
            //httpClient.BaseAddress = new System.Uri("http://localhost:5000");

            // Faz a requisição para o endpoint
            var response = await client.GetAsync("/server/user");

            // Verifica se o status code é 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Lê o corpo da resposta como string
            var responseString = await response.Content.ReadAsStringAsync();

            // Deserializa o JSON da resposta
            var user = JsonConvert.DeserializeObject<User>(responseString); // Use JsonDocument.Parse(responseString) se estiver usando System.Text.Json

            // Verifica se os valores deserializados correspondem ao esperado
            Assert.Equal("Eduardo", user.Name+"a");
            Assert.Equal(19, user.Age);
        }
    }

    internal class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}