using RestSharp;
using System.Security.Policy;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class DeleteCustomerStepDefinitions:Steps
    {

        private readonly ScenarioContext context;
        private readonly RestClientOptions options;
        private readonly RestClient client;

        public DeleteCustomerStepDefinitions(ScenarioContext context)
        {
            this.context = context;

            options = new RestClientOptions("http://localhost:5260/");

            client = new RestClient(options);
        }


        [Given(@"Customer has been Registered")]
        public void GivenCustomerHasBeenRegistered(Table table)
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

        [When(@"I Delete the Customer")]
        public void WhenIDeleteTheCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be Deleted")]
        public void ThenTheCustomerShouldBeDeleted()
        {
            throw new PendingStepException();
        }
    }
}
