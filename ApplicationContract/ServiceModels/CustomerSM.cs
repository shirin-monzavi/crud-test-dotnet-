namespace ApplicationContract.ServiceModels
{
    public class CustomerSM
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Email { get;  set; }
        public string BankAccountNumber { get;  set; }
        public Guid Id { get;  set; }
    }
}
