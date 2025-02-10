# Code Paste and Share App

## Description
This is a web application built with ASP.NET Core and EF Core, allowing users to paste code, highlight it (with or without line numbers), save it, and generate a shortened URL for easy sharing. It integrates with an external URL shortener API to provide a quick and convenient way to share code snippets.

> **Note:** This project is outdated. While it demonstrates basic functionality with ASP.NET Core and EF Core, the code may not reflect the latest best practices or technologies. 
> 
> If you are looking for something more advanced or up-to-date, I encourage you to check out my [SignalR chat](https://github.com/PairOfPenguins/petchat-signalr), which is a more technically complex and up-to-date application.

## UI Screenshot
Here's a screenshot of the app's user interface:

![UI Screenshot](https://github.com/user-attachments/assets/2f2184f4-480f-40f3-a6e7-329b9045535d)


## Features
- **Code Highlighting**: Paste any code and choose whether to highlight specific lines.
- **Save & Share**: Save your code snippet and get a shortened URL to easily share it.
- **External URL Shortener Integration**: After saving, the application generates a short URL using an external URL shortening API.

## Technologies Used
- **ASP.NET Core**: Backend framework for handling requests and serving the application.
- **EF Core**: Database framework for persisting user data (code snippets).
- **HTML**: Structure of the front-end pages.
- **CSS**: Styling of the front-end pages.
- **JavaScript**: Interactivity for code highlighting and UI elements.
- **External API**: Integration with a URL shortener API to generate short URLs.

## Installation

### Prerequisites
- .NET SDK (version 6.0 or higher)
- Visual Studio or VS Code
- SQL Server (or other supported DB for EF Core)


### Steps to Install

1. **Clone the repository:**
   ```bash
   git clone https://github.com/PairOfPenguins/syntaxhighlighter-urlshortner.git
   cd syntaxhighlighter-urlshortner
   ```
2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
3. **Set up connection string in `appsettings.json`:**
   Open the `appsettings.json` file in the project root and add your connection string. It should look like this:
   ```json
   {
     "ConnectionStrings": {
       "NotesPortal": "Your connection string here"
     }
   }
   ```
   Replace `"Your connection string here"` with the actual database connection string.

4. **Update the database:**
   ```bash
   dotnet ef database update
   ```
5. **Run the application:**
   ```bash
   dotnet run
   ```
6. **Open your browser** and navigate to `http://localhost:5265` or `http://localhost:7067` to use the app.
