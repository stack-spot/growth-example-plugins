## **About**

The **dotnet-api-plugin** template adds to the stack the ability to provide REST and gRPC services.

## **Usage**

#### **Prerequisites**
See below the items you need to have installed on your machine:
- .NET 6; 

 ## Running the project

After creating the project, access the directory where it was created and run the command:

- Replace the `*` with the given name for application.

```bash
dotnet restore *.Api.sln
```

Now, build the project with the command below:

```bash
dotnet build *.Api.sln
```

Run the unit and integration test. Execute the command below:

```bash
dotnet test *.Api.sln
```

To run the application in the same directory, execute the command:

```bash
dotnet run --project ./src/*.Api/*.Api.csproj
```

Then open http://localhost:5000 in your browser.

Your application is running, now access https://localhost:5001/swagger to see more details.
If your browser prompts you about the website's security, click on **"Go to localhost (not secure)"**.  When you access this URL, you will see your application's documentation.

### Docker Configurations

If you want your application to work with Docker, you will need to add a temporary SSL certificate and mount a volume to hold that certificate.
For more details, see the [Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-6.0) that describe the necessary steps for Windows, macOS, and Linux.

For Windows:

```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

> NOTE: When using PowerShell, replace **%USERPROFILE% with $env:USERPROFILE**.

For macOS:
```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

For Linux:
```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p Your_password123
dotnet dev-certs https --trust
```

To build and run docker containers, go to the solution root where you find the **docker-compose.yml file** and execute the command below:

 ```bash
 docker-compose -f 'docker-compose.yml' up --build
 ```

- You can also use Visual Studio's "Docker Compose" for debugging.



## Overview

### Domain Project

It contains all domain layer-specific entities, enumerations, exceptions, interfaces, types, and logic.

### Application Project

This project has all the API logic. It's dependent on the domain layer but has no dependencies on any other layer or project. This layer defines interfaces implemented by external layers. For example, if the application needs to access a notification service, a new interface is added to the application and the implementation will be created in the infrastructure.

### Infrastructure Project

This project contains classes for accessing external resources such as File Systems, Web Services, SMTP, and so on. These classes need to be based on interfaces defined in the application layer.

### API Project

This project is an ASP.NET Core 6 application. This layer depends on the Application and Infrastructure layers, but the infrastructure dependency is only to support dependency injection. However, only the *Program.cs* should reference the infrastructure.

### Components References

- [AutoMapper](https://automapper.org/)
- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
- [FluentValidation](https://fluentvalidation.net/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Moq](https://github.com/moq/moq4)
- [Shouldly](https://github.com/shouldly/shouldly)
- [WireMock.Net](https://github.com/WireMock-Net/WireMock.Net)
- [xunit](https://github.com/xunit/xunit)

## References
- [Clean Architecture](https://www.zup.com.br/blog/clean-architecture-arquitetura-limpa)
- [Clean Architecture with ASP.NET Core 3.0 • Jason Taylor • GOTO 2019](https://www.youtube.com/watch?v=dK4Yb6-LxAk)