Feature: Customer
@customer
Scenario: Add Customer
	Given Customer Has been defined
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I Register the Customer

	Then The customer should be created


Scenario: Update Customer
	Given Customer has been created
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I modify the Customer
		| FirstName     | LastName      |  DateOfBirth | PhoneNumber   | Email             | BankAccountNumber   |
		| EricNew       | EvansNew      | '1994/01/02' | +989301951213 | EricNew@gmail.com | 835802010014975     |

	Then the customer should be updated

Scenario: Delete Customer
	Given Customer has been Registered
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I Delete the Customer

	Then the customer should be Deleted

Scenario: Get All Customers
	Given Customer has been Given
		| FirstName  | LastName   | DateOfBirth  | PhoneNumber  | Email          | BankAccountNumber   |
		| Eric       | Evans      | '1994/01/01' | +989301951212 | Eric@gmail.com | 635802010014975 |

	When I get all customers

	Then customers should be returned