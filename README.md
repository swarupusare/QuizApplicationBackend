1️⃣ Backend (ASP.NET Core Web API)

#Prerequisites:

1)Visual Studio   
2).NET 8.0 SDK installed

#Steps:

1)Open the backend project in Visual Studio.

2)If required packages are not installed, install these NuGet packages:
  MongoDB.Driver
  MongoDB.Bson

3)Update appsettings.json with your MongoDB connection string:

{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "QuizDB"
  }
}


4)Run the API (F5 in Visual Studio or dotnet run in terminal).

Swagger UI will open at https://localhost:<port>/swagger
