## CI/CD

The project uses GitHub Actions for continuous integration.

A workflow is automatically triggered on every push to the `main` branch.

The pipeline performs the following steps:

- checkout repository
- setup .NET 8 SDK
- restore NuGet dependencies
- build the Web API project
- ## Azure Deployment

The Web API is deployed to **Azure App Service** and is publicly available.

API base URL:

https://ecommercecicd-c0hqhfbdd5eda4b5.polandcentral-01.azurewebsites.net

Swagger documentation:

https://ecommercecicd-c0hqhfbdd5eda4b5.polandcentral-01.azurewebsites.net/swagger

### Azure services used

The following Azure services were used:

- **Azure App Service** – hosting the ASP.NET Core Web API
- **Azure Database for MySQL Flexible Server** – relational database
- **GitHub Actions** – CI/CD pipeline for automatic deployment

### Deployment process

1. Code is pushed to the `main` branch.
2. GitHub Actions workflow builds the project.
3. The application is automatically deployed to Azure App Service.
4. The API becomes publicly available after deployment.

## Infrastructure as Code

The project also includes Infrastructure as Code using **Bicep**.

A **Storage Account** is deployed to Azure from the GitHub Actions pipeline using the `infra/main.bicep` template.

This means the pipeline handles both:

- application deployment
- infrastructure deployment