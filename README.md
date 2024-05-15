// learn-app
01. In this backend application I have utilized Visual Studio with C# .NET 8 Web API and Azure Cosmos DB for NoSQL (Initial project using Azure Cosmos DB)
02. All the DTOs and Models are based on the Figma designs.
  - Creating models for the app's backend in .NET 8 involves defining classes that represent the data structure of the application.
  - According to the figma designs Course model represents the course details with a title and description, StudentInfo model captures the            mandatory student information and optional details that can be toggled by the teacher. CustomQuestion model allows for the creation of              various types of questions, with AnswerOption supporting multiple choice questions. QuestionType is an enum to specify the type of custom         question.
03. CRUD APIs are implemented according to Models, Enums, DTOs, Interfaces, and Repositories.
04. Data are stored in Azure Cosmos DB for NoSQL. Database testing are done with local Cosmos DB Emulator.
05. Dependency injection are Utilized
