using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace TestAPI
{
    [Binding]
    public class GetAllProducts
    {
        RestClient client = new RestClient("http://demostore.gatling.io/api/product");

        RestRequest request = new RestRequest();

        RestResponse response;

        [Given(@"I send a get request for all products")]
        public void WhenISendAGetRequestForAllProducts()
        {
            response = client.Execute(request);
        }

        [Then(@"I expected a valid code response is correct")]
        public void ThenIExpectedAValidCodeResponseIsCorrect()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
