using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace TestAPI
{
    [Binding]
    public class GetIdProducts
    {
        RestClient client = new RestClient("http://demostore.gatling.io/api/product");

        RestRequest request = new RestRequest("posts/{postid}", Method.Get);

        RestResponse response;

        [Given(@"I have an id with value (.*)")]
        public void GivenIHaveAnIdWithValue(int p0)
        {
            request.AddUrlSegment("postid", p0.ToString());
        }

        [When(@"I send a get request")]
        public void WhenISendIGetRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"I expected a valid code response")]
        public void ThenIExpectedAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
