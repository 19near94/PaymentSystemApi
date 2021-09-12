# PaymentSystemApi

Demo for Payment System Api

The Architecture have Web layer, Domain layer, Application.
Domain Layer - It is where my entities and repository reside.
Application Layer - It is where my business logic reside more like in service form.
Web layer - It is where my endpoint.

What I do is.

From the controller I call the GetAcctBalance method to get the account details and transactions.
I created a loop to get account detail with random generated data and use linq to order the account transaction to newest date and returned in to web layer or endpoint.
Adding unit test to the project to check if the conditions are met.

For status property my assumption is that it has 3 value which is Success,Failed,Closed.

Success - If the payment or calling the API is successful.

Failed - If the transaction to API is failed.

Closed - If the success transaction is now posted to the system.

I used JWT for API security and for CI I used github actions.

For you to see this in action.
Clone my repository and run it to your local or deploy it IIS.

If you have any suggestion for the improvement please let me know.

Thanks and Enjoy.
