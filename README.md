## CI/CD

The project uses GitHub Actions for continuous integration.

A workflow is automatically triggered on every push to the `main` branch.

The pipeline performs the following steps:

- checkout repository
- setup .NET 8 SDK
- restore NuGet dependencies
- build the Web API project