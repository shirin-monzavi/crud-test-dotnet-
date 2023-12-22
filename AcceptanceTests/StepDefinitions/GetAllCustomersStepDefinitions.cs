using RestSharp;
using System.Security.Policy;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GetAllCustomersStepDefinitions:Steps
    {
        private readonly ScenarioContext context;
        private readonly RestClientOptions options;
        private readonly RestClient client;

        public GetAllCustomersStepDefinitions(ScenarioContext context)
        {
            this.context = context;

            options = new RestClientOptions("http://localhost:5260/");

            client = new RestClient(options);
        }

        [Given(@"Customer has been Given")]
        public void GivenCustomerHasBeenGiven(Table table)
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

        [When(@"I get all customers")]
        public void WhenIGetAllCustomers()
        {
            throw new PendingStepException();
        }

        [Then(@"customers should be returned")]
        public void ThenCustomersShouldBeReturned()
        {
            throw new PendingStepException();
        }
    }
}
