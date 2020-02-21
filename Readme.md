Setup Instructions

1. install dotnet core from https://dotnet.microsoft.com/download
2. install postgres from https://www.postgresql.org/
2. clone the repository 
3. run inside  project "dotnet tool install --global dotnet-ef"
3. Navigate to project directory and run "dotnet build" command
5. connect to database in postgres and run script
  CREATE EXTENSION postgis;
  CREATE EXTENSION postgis_topology;
4. Run "dotnet-ef migrations add initials"
5. Run "dotnet-ef database update
