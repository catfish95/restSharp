using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using RestSharpTest.utils;
using RestSharpTest.model;
using Newtonsoft.Json;
using System.Collections.Generic;
using RestSharpTest.extensionMethods;

namespace RestSharpTest.APITests
{
    public class NameAPITest
    { 
        private const string URI = "https://api.agify.io/";
        private RestClient restClient;
        private GetJsonSchema getSchema = new GetJsonSchema();

        [OneTimeSetUp]
        public void Setup()
        {
            restClient = new RestClient(URI);
        }

        [Test]
        [TestCase("name", "Jason", "responseSchema/NameAPISchema.json")]
        public async Task GetNameToAge_VerifySchema_ShouldBeOK(string name, string value, string validationPath) 
        {
            JsonSchema schema = getSchema.GetSchemaFromProject(validationPath);
            NameAPI nameAPI;
            RestRequest request = new RestRequest().AddParameter(name, value);

            (RestResponse r, TimeSpan t) response = await restClient.GetClientResponseWithTimeSpan(request);

            //-- validate response code
            Console.WriteLine("Validating Response code = 200");
            Assert.That(response.r.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            // -- Response Time
            Console.WriteLine("Response time: " + response.t.Milliseconds + " < 5000");
            Assert.That(response.t.Milliseconds, Is.LessThan(5000)); 

            //-- validate headers
            Console.WriteLine("Get Headers from response > 0");
            List<HeaderParameter> headers = new List<HeaderParameter>(response.r.Headers);
            Assert.That(headers.Count, Is.GreaterThan(0));

            //-- validate schema
            Console.WriteLine("Validating Schema = " + schema.Title);
            Assert.True(JObject.Parse(response.r.Content).IsValid(schema));

            // -- deserialize into object after validation of schema;
            Console.WriteLine("Validating name = " + value);
            nameAPI = JsonConvert.DeserializeObject<NameAPI>(response.r.Content);
            Assert.That(nameAPI.Name, Is.EqualTo(value));
        }

    }
}