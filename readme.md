this is a simple project that does crud operation and contains some layers such as: framework,domain, application, infrastructure, endpoint. 

it contains some test project such as: xunit test for domain layer white box test for application layer integration test for ef core bdd test for testing endpoint.

ioc is Castle Windsor. 

customer is an aggregate root that adds domain events in deferred way.

application layer dispatch all events and event handler just log the name of domain event.
