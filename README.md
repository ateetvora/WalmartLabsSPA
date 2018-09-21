# WalmartLabsSPA

Prerequisites

1. .NET CORE 2.1. SDK (Download and install using the following link: https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.402-windows-x64-installer)

2. Visual Studio 2017 or any other IDE

How to run the application

1. 

Application Overview

This is an ASP.NET CORE 2.1 single page web application. It uses the Walmart APIs to return product list and show recommendations on the Product Detail page (PDP).

As mentioned above, I have used ASP.NET CORE 2.1, AngularJS 1.x for client side binding and routing (UI-Route) to build this single page application. I have created a facade called ProductService to encapsulate the calls to the Walmart APIs. This makes it testable and maintainable. 

I have added unit tests and integration tests for the ProductController. The unit tests use NUnit and Moq, while the integration tests are built using xUnit and the Test Server class. With xUnit and Test Server we can host the app in memory to execute tests against. 

Future Improvements

1. Bundling and Minification of application level CSS and JavaScript. (Bundler and minification tool does not seem to work with VS2017. And in the interest of time, I did not create a Gulp task.)

2. Paged results on the product list page
