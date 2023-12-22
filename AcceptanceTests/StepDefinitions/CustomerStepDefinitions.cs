using AcceptanceTests.Dto;
using AcceptanceTests.Utility;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class CustomerStepDefinitions
    {
        private readonly ScenarioContext context;
        private readonly RestClientOptions options;
        private readonly RestClient client;

        public CustomerStepDefinitions(ScenarioContext context)
        {
            this.context = context;

            options = new RestClientOptions("http://localhost:5260/");

            client = new RestClient(options);
        }


        [Given(@"Customer Has been defined")]
        public void GivenCustomerHasBeenDefined(Table table)
        {
            context.Add("customer", table.CreateInstance<CustomerTest>());
        }

        [When(@"I Register the Customer")]
        public void WhenIRegisterTheCustomer()
        {
            var customer = context.Get<CustomerTest>("customer");

            customer.FirstName = customer.FirstName + RandomGenerator.GenerateRandomString();
            customer.Email = customer.Email + RandomGenerator.GenerateRandomString();

            var request = new RestRequest("api/Customer")
                .AddJsonBody(JsonConvert.SerializeObject(customer));

            var response = client.Post<CustomerTest>(request);

            context.Add("addResponse", response);
        }

        [Then(@"The customer should be created")]
        public void ThenTheCustomerShouldBeCreated()
        {
            var response = context.Get<CustomerTest>("addResponse");
            var request = new RestRequest($"api/Customer/{response.Id}");

            var findCustomer = client.Get<CustomerTest>(request);

            findCustomer.Should().NotBeNull();
        }
    }
}
