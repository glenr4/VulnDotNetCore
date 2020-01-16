## Initialise
1. Open a command prompt in the ClientApp directory and run: npm i
2. If you want to use something other than SQL Express localdb for the database, then set the DefaultConnection in: appsettings.Development.json
2. In Visual Studio, open Package Console Manager and run: Update-Database

## To run in Development mode
1. Open a command prompt in the ClientApp directory and run: npm start
2. Open a command prompt in the VulnDotNetCore directory (where the .csproj file is) and run: dotnet run watch

For more information see:
https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.1&tabs=visual-studio
