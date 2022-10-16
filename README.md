# MinimalApi

I used the MinimalApi with .net6 concept to create a REST API with the default operations and one more that is to get the most common words in located in the 
Description of each Part.

To run the project use:

```
docker-compose build
docker-compose up
```
From the API Folder, it will run and you can access the swagger interface with this URL: ```https://localhost:8000/swagger/index.html```

**OR**

```
dotnet build
dotnet run
```

From the API folder then access ```https://localhost:7196/swagger/index.html``` to test the endpoints.

To execute the integration test run:

```
dotnet test
``` 

This project is focused on simplicity so it don't have a multi-layered architecture. It is a small microservice with integrated tests of the API;

It is possible to implement unit tests with an isolated domain and create many layers such as infrastructure, application, domain, crosscutting, etc.

