1️⃣ Backend (ASP.NET Core Web API)

Prerequisites:

Visual Studio 2022 (or VS Code with C# extension)

.NET 8.0 SDK installed

Steps:

Open the backend project in Visual Studio or VS Code.

If required packages are not installed, install these NuGet packages:

MongoDB.Driver

MongoDB.Bson

Update appsettings.json with your MongoDB connection string:

{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "QuizDB"
  }
}


Run the API (F5 in Visual Studio or dotnet run in terminal).

Swagger UI will open at https://localhost:<port>/swagger
