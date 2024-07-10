Profile API

This is my first attempt at building a backend API for the Profile project for newsclip, developed using C# and ASP.NET Core. It manages profile information such as headers, skills, projects, about, and contact sections. The API connects to an MS SQL Server database hosted on Docker.

Prerequisites
.NET SDK 7.0
Docker
SQL Server image for Docker
Getting Started
Clone the Repository

git clone https://github.com/yourusername/NewProfileAPI.git
cd NewProfileAPI

Setup Docker and SQL Server
Pull the SQL Server Docker image:

docker pull mcr.microsoft.com/mssql/server

Run the Docker container:
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=LJ@4jn49sxy' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server

Connect to the SQL Server using your preferred client and create the database:
CREATE DATABASE ProfileDB;

Ensure your appsettings.json file has the correct connection string:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=ProfileDB;User Id=sa;Password=YourStrong!Passw0rd;"
}
The API should now be running on https://localhost:7075.

Endpoints
Here are some of the key endpoints:

Header

GET /api/Header
POST /api/Header
PUT /api/Header
DELETE /api/Header/{id}
Skills

GET /api/Skills
POST /api/Skills
PUT /api/Skills
DELETE /api/Skills/{id}
Projects

GET /api/Projects
POST /api/Projects
PUT /api/Projects
DELETE /api/Projects/{id}
About

GET /api/About
PUT /api/About
Contact

GET /api/Contact
PUT /api/Contact

