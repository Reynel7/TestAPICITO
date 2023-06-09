using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace TestAPI
{
    [Binding]
    public class CreateProductStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/api/product");
        RestRequest request;
        RestResponse response;

        [Given(@"I have a product with the following details:")]
        public void GivenIHaveAProductWithTheFollowingDetails(Table table)
        {
            var productDetails = table.Rows[0];

            var product = new
            {
                name = productDetails["name"],
                description = productDetails["description"],
                image = productDetails["image"],
                price = productDetails["price"],
                categoryId = productDetails["categoryId"]
            };

            string jsonBody = JsonConvert.SerializeObject(product);
            Console.WriteLine(jsonBody);

            request = new RestRequest("/api/products", Method.Post);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        }

        [When(@"I send a POST request to ""(.*)"" with the product details")]
        public void WhenISendAPOSTRequestToWithTheProductDetails(string resource)
        {
            request.Resource = resource;
            response = client.Execute(request);
        }

        [Then(@"the response status code should be for the create (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}