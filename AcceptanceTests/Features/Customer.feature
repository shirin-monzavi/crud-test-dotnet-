Feature: Customer
@customer
Scenario: Add Customer
	Given Customer Has been defined
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I Register the Customer

	Then The customer should be created


	Scenario: Add Customer
	Given Customer Has been defined
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I Register the Customer

	Then The customer should be created