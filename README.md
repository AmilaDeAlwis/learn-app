// learn-app
01. In this backend application I have utilized Visual Studio with C# .NET 8 Web API and Azure Cosmos DB for NoSQL (Initial project using Azure Cosmos DB) 
  - To set up this project you have to use an suitable IDE like Visual Studio or Code Editor like Visual Studio Code.
  - Clone the Git repository and open it via the IDE/Code Editor.
  - Go to Project -> Manage NuGet packages (if you're using Visual Studio IDE) to install below packages.
      - Microsoft.Azure.Cosmos
      - Microsoft.Extensions.Configuration
      - Microsoft.Extensions.DependencyInjection
      - AutoMapper.Extensions.Microsoft.DependencyInjection
  - Make sure the appsettings.json and appsettings.Development.json files are in the .gitignore file (later need these files to store Cosmos DB variable)
  - Create an Azure (if already don't have) and navigate to Azure Cosmos DB for NoSQL or download Cosmos DB Emulator for local development.
  - Copy the URI and Primary Key and paste them in the "CosmosDb": "Endpoint" and "CosmosDb": "Key" respectively in the appsettings.json
      - Example: "CosmosDb": {
                            "Endpoint": "Endpoint URI",
                            "Key": "Primary key"
                  }
    
02. All the DTOs and Models are based on the Figma designs.
  - Creating models for the app's backend in .NET 8 involves defining classes that represent the data structure of the application.
  - According to the figma designs Course model represents the course details with a title and description, StudentInfo model captures the mandatory student information and optional details that can be toggled by the teacher. CustomQuestion model allows for the creation of various types of questions, with AnswerOption supporting multiple choice questions. QuestionType is an enum to specify the type of custom question. Properties are used in the model documents that reference the IDs of related documents.
03. CRUD APIs are implemented according to Models, Enums, DTOs, Interfaces, and Repositories.
04. Data are stored in Azure Cosmos DB for NoSQL. Database testing are done with local Cosmos DB Emulator.
05. Dependency injection are Utilized
