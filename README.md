# WalmartLabsSPA

## Application Overview

This is an ASP.NET CORE Single Page Application (SPA). It uses the Walmart APIs to return a search results page and shows product recommendations on the Product Detail page (PDP).

I have used ASP.NET CORE 2.1, AngularJS 1.x for client side binding and routing (UI-Route) to build this single page application. Bootsrap 3.x is used to create a responsive design. I have created a facade called ProductService to encapsulate the calls to the Walmart APIs. This makes it testable and maintainable. 

I have created an AngularJS factory called ProductService to centralize calls to the product APIs. The angular UI-Router component is used to implement routing for the SPA.

I have added unit tests and integration tests for the ProductController. The unit tests use NUnit and Moq, while the integration tests are built using xUnit and the Test Server class. With xUnit and Test Server we can host the app in memory to execute tests against. 

## Prerequisites

1. .NET CORE 2.1. SDK (Download and install using the following link: https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.402-windows-x64-installer)

2. Visual Studio 2017 or any other IDE

## How to run the application

1. Download and unzip the WalmartSPA master on your computer.
2. Open the command window
3. Change directory to navigate to the WalmartLabs folder. _Example cd "C:\Users\XYZ\Downloads\WalmartLabsSPA-master\WalmartLabsSPA-master\WalmartLabs\"_
4. Execute command `dotnet build` to build the application.
5. Once the application builds successfully, we will now run the tests. 
6. Change directory to navigate to the WalmartLabs.Tests folder. _Example cd "C:\Users\XYZ\Downloads\WalmartLabsSPA-master\WalmartLabsSPA-master\WalmartLabs.Tests"_ and execute the command `dotnet test`. 
7. All unit tests should pass
8. Change directory to navigate to the WalmartLabs.IntegrationTests folder. _Example cd "C:\Users\XYZ\Downloads\WalmartLabsSPA-master\WalmartLabsSPA-master\WalmartLabs.IntegrationTests"_
9. Execute command `dotnet test`. All integration tests should pass.
10. Change directory one last time to navigate to the WalmartLabs (Web App) folder. _Example. cd "C:\Users\XYZ\Downloads\WalmartLabsSPA-master\WalmartLabsSPA-master\WalmartLabs"_
11. Execute command `dotnet run` to run the application. Open the browser and type in the website url (http://localhost:5000)
12. Perform a search for a product on the search bar in the home page. 
13. Click on the image or product name to view the product details and recommendations. 
14. Use browser back button to go back to the list page, or on the Walmart image to start a new search.

## Future Improvements

1. Bundling and Minification of application level CSS and JavaScript. (Bundler and minification tool does not seem to work with VS2017. And in the interest of time, I did not create a Gulp task.)

2. Paged results on the search results page
