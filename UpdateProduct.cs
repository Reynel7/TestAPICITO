using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace TestAPI
{
    [Binding]
    public class UpdateProductStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/api/product");
        RestRequest request;
        RestResponse response;

        [Given(@"I have the following product ID: (.*)")]
        public void GivenIHaveTheFollowingProductId(int productId)
        {
            request = new RestRequest("/api/products/{productId}", Method.Put);

            // Agregar el parámetro del ID del producto a la URL
            request.AddUrlSegment("productId", productId.ToString());
        }

        [Given(@"I have a product with the following details for update:")]
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

            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
        }

        [When(@"I send a PUT request to ""(.*)"" with the product details")]
        public void WhenISendAPutRequestToWithTheProductDetails(string resource)
        {
            request.Resource = resource;
            response = client.Execute(request);
        }

        [Then(@"the response status code can be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}
