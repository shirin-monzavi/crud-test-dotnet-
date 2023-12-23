using AcceptanceTests.Dto;
using AcceptanceTests.Utility;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UpdateCustomerStepDefinitions : Steps
    {
        private readonly ScenarioContext context;
        private readonly RestClientOptions options;
        private readonly RestClient client;

        public UpdateCustomerStepDefinitions(ScenarioContext context)
        {
            this.context = context;

            options = new RestClientOptions("http://localhost:5260/");

            client = new RestClient(options);
        }

        [Given(@"Customer has been created")]
        public void GivenCustomerHasBeenCreated(Table table)
        {
            var customerTable = new Table("FirstName",
                "LastName",
                "DateOfBirth",
                "PhoneNumber",
                "Email",
                "BankAccountNumber");

            foreach (var row in table.Rows)
            {
                customerTable.AddRow(row[0], row[1], row[2], row[3], row[4], row[5]);
            }

            Given("Customer Has been defined", customerTable);
            When("I Register the Customer");
            Then("The customer should be created");
        }

        [When(@"I modify the Customer")]
        public void WhenIModifyTheCustomer(Table table)
        {
            var addResponse = context.Get<CustomerTest>("addResponse");

            var updatedCustomer = table.CreateInstance<CustomerTest>();

            updatedCustomer.FirstName = updatedCustomer.FirstName + RandomGenerator.GenerateRandomString();

            updatedCustomer.Email = updatedCustomer.Email + RandomGenerator.GenerateRandomString();

            context.Add("updatedCustomer", updatedCustomer);

            var request = new RestRequest($"api/Customer/{addResponse.Id}", Method.Put)
                .AddJsonBody(JsonConvert.SerializeObject(updatedCustomer));

             client.ExecutePut<CustomerTest>(request);
        }

        [Then(@"the customer should be updated")]
        public void ThenTheCustomerShouldBeUpdated()
        {
            var response = context.Get<CustomerTest>("addResponse");

            var request = new RestRequest($"api/Customer/{response.Id}");

            var findCustomer = client.Get<CustomerTest>(request);

            var updatedCustomer = context.Get<CustomerTest>("updatedCustomer");

            updatedCustomer.Id = response.Id;

            findCustomer.Should().NotBeNull();
            findCustomer.Should().BeEquivalentTo(updatedCustomer);
        }

    }
}
