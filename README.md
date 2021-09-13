# PaymentSystemApi

Demo for Payment System Api

The Architecture have Web layer, Domain layer, Application.

PS.Domain Layer - It is where my entities and repository reside.
PS.Application Layer - It is where my business logic reside more like in service form.
PS.EntiyFramework core - This where the dbcontext code.
PaymentSystem layer - It is where my endpoint.

What I do is.

From the controller I call the GetAcctBalance method to get the account details and transactions.
I created a loop to get account detail with random generated data and use linq to order the account transaction to newest date and returned in to web layer or endpoint.
Adding unit test to the project to check if the conditions are met.

For status property my assumption is that it has 3 value which is Success,Failed,Closed.

Success - If the payment or calling the API is successful.

Failed - If the transaction to API is failed.

Closed - If the success transaction is now posted to the system.

I used JWT for API security and for CI I used github actions.

For authentication
username = test123
password = test123


For you to see this in action.
Clone my repository 
,Open it in Visual studio 2019
,Run Update-Database to Package Manager Console to have the local db tables
and choose iis express and run it to your local.

Run the below url's in postman
https://localhost:44367/api/Token?Username=test123&Password=test123 - To authenticate and copy the generated access token.

https://localhost:44367/api/Account - Paste the access token to the authorization Tab and choose bearer token. Post method to insert initial value to database.

https://localhost:44367/api/Account - get the account balance and transaction list



If you have any suggestion for the improvement please let me know.

Thanks and Enjoy.
