// learn-app

01. In this backend application, Visual Studio with C# .NET 8 Web API and Azure Cosmos DB for NoSQL (initial project using Azure Cosmos DB) have been utilized.
  - To set up this project, use a suitable IDE like Visual Studio or a code editor like Visual Studio Code.
  - Clone the Git repository and open it via the IDE/Code Editor.
  - Go to Project -> Manage NuGet Packages (if using Visual Studio IDE) to install the following packages:
      - Microsoft.Azure.Cosmos
      - Microsoft.Extensions.Configuration
      - Microsoft.Extensions.DependencyInjection
      - AutoMapper.Extensions.Microsoft.DependencyInjection
  - Ensure the appsettings.json and appsettings.Development.json files are included in the .gitignore file (will need these files later to store Cosmos DB variables).
  - Create an Azure account (if don't already have one) and navigate to Azure Cosmos DB for NoSQL, or download the Cosmos DB Emulator for local development.
  - Copy the URI and Primary Key and paste them into the Endpoint and Key fields, respectively, in the appsettings.json file.
      - Example: "CosmosDb": {
                            "Endpoint": "Your Endpoint URI",
                            "Key": "Your Primary Key"
                  }

02. All the DTOs and Models are based on the Figma designs.
  - Creating models for the app's backend in .NET 8 involves defining classes that represent the data structure of the application.
  - According to the Figma designs, the Course model represents the course details with a title and description. The StudentInfo model captures the mandatory student information and optional details that can be toggled by the teacher. The CustomQuestion model allows for the creation of various types of questions, with the AnswerOption supporting multiple-choice questions. QuestionType, Nationality, Residency, and Gender are developed as enums to specify the type of custom question. Properties 7\[are used in the model documents that reference the IDs of related documents.
  - In the StudentInfo model, properties such as IsNationalityVisible, IsGenderVisible, and IsDateOfBirthVisible are boolean properties that determine the visibility of the respective optional fields. When a teacher creates or updates a course, they can set these properties to true or false to control whether students will see the additional questions.

03. CRUD APIs are implemented according to Models, Enums, DTOs, Interfaces, and Repositories.
  - DTOs (Data Transfer Objects) are used to encapsulate data and send it from one subsystem of an application to another. Create and Get DTOs are created for the four models.
  - A common repository interface is initialized as a starting point and follows the repository pattern. This common interface defines the basic CRUD operations (Create, Read, Update, Delete) that can be performed on an entity of type T. Based on the requirements and models, all the other necessary interfaces are implemented.
  - These interfaces include methods such as GetAllAsync: Retrieves all entities, GetByIdAsync: Retrieves a single entity by its identifier, AddAsync: Adds a new entity, UpdateAsync: Updates an existing entity by its identifier, and DeleteAsync: Deletes an entity by its identifier.
  - Repository classes that implement these interfaces are created for each of the models and provide the actual logic for interacting with Cosmos DB.
  - Then, in the Program.cs file, the database and the containers are created.

04. Dependency Injection is utilized in the following ways:
  - Repository Pattern: In the data access layer, repositories (such as ICourseRepository, IStudentInfoRepository, etc.) are injected into the controllers and the Program.cs file. This decouples the data access code from the business logic, making it easier to test and maintain.
  - Configuration: IConfiguration is injected into Program.cs and repositories to access application settings, such as Cosmos DB connection strings.
  - AutoMapper: IMapper is injected into the controllers to facilitate the mapping between entities and DTOs.
  - Cosmos Client: In Program.cs, CosmosClient is injected as a singleton to enable interaction with the Cosmos DB emulator.
