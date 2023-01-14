Hello! Welcome to the **Royal Library**

## Sumary

1. [The project Royal Library](#the-project-royal-library)
2. [Setup and Running](#setup-and-running)
3. Understanding the **Server**
    * How to create a new **Endpoint**
    * How to create a new **Setup**
    * How to create a new **Repository**
4. Understanding the **Web**


## The Project Royal Library

Royal Library was a project conceived to bring books to anyone in the world free of charge! 
Besides this honored task, passing this assessment would be great too :)


## Setup and Running

The [web](#web), [database](#database) and the [server](#server) sections are for you to be able to work on a development environment. The section [compose](#compose-everything-together) it's to just run the project

**OBS:** The compose containers uses the same doors as the development ones, so pay attention to choose either one

### Web

1. Check if you have node installed (version must be greater than v14), running: `node -v`. Should return something like v00.00.00, if you did not received this [install node](https://nodejs.org/en/download/)
2. Check if you have yarn installed, running: `yarn -v`. Should return something similar to the node command, if not, [install yarn](https://classic.yarnpkg.com/en/docs/getting-started)
3. Go to the web folder
4. Run `yarn`
5. Run `yarn dev`
6. Open the [Royal Library](http://localhost:5173/) in your browser

&emsp; **OBS:** **The page will not work!** because you need the server and the database running to everything works as expected.

---

### Database

This project uses the Microsoft SQL Server.
You can install the MSSQL entire server on your machine or run it using docker. 

To run on docker:

Check if you have docker installed running: `docker -v` should return something like:

> Docker version 20.10.21, build baeda1f

If need [install docker](https://docs.docker.com/get-docker/)

Run the database:

> docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

Your connection string will be:

> Server=127.0.0.1,1433;Database=Master;User Id=SA;Password=yourStrong(!)Password

**OBS**: This container takes time to start completely, so grab some coffee before continuing. 

---

### API Server

Check if you have the .Net installed running `dotnet --info` should return something like:


```
.NET SDK (reflecting any global.json):
 Version:   6.0.400
 Commit:    7771abd614

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.22000
 OS Platform: Windows
 RID:         win10-x64
 Base Path:   C:\Program Files\dotnet\sdk\6.0.400\

global.json file:
  Not found

Host:
  Version:      6.0.10
  Architecture: x64
  Commit:       5a400c212a

.NET SDKs installed:
  6.0.400 [C:\Program Files\dotnet\sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.8 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.8 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 6.0.10 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 6.0.8 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 6.0.10 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]

Download .NET:
  https://aka.ms/dotnet-download

Learn about .NET Runtimes and SDKs:
  https://aka.ms/dotnet/runtimes-sdk-info
```

**OBS:** You **must** to have version 6 installed. Even with version 7, you still need to have the 6. (I know it's weird...)

If need, install [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

1. Go to the server/RoyalLib.Api folder
2. Run `dotnet run`
3. Open the [server](https://localhost:7028/swagger/index.html) in your browser

---

### Compose everything together

1. Make sure that you have the docker installed, see the [database](#database) section
2. Go to the root
3. Run the command `docker-compose up`
4. Open the [Royal Library](http://localhost:5173/) in your browser

**OBS** Sometimes 

## Understanding the Server

TODO

## Understanding the Web

TODO