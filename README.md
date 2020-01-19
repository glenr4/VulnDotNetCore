# Vulnerable ASP.Net Core Application
This is a deliberately vulnerable web application for the purposes of practicing penetration testing.

## Initialise
1. Open a command prompt in the ClientApp directory and run: yarn install (npm has proven to be unreliable in this project, so use yarn instead)
2. If you want to use something other than SQL Express localdb for the database, then set the DefaultConnection in: appsettings.Development.json
2. In Visual Studio, open Package Console Manager and run: Update-Database

## To run in Development mode
1. Open a command prompt in the ClientApp directory and run: yarn start
2. Open a command prompt in the VulnDotNetCore directory (where the .csproj file is) and run: dotnet run watch

### Notes:
To use this with FireFox, I had to set network.websocket.allowInsecureFromHTTPS = true in about:config. But you should remember to set this back to false
once you have finished testing.
Alternatively, you can create your own SSL certificate.
