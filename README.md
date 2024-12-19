# DevcomTestTask

A robust ASP.NET MVC application built using Clean Architecture principles, featuring Entity Framework for database operations and Google Identity Authentication for user authentication.

## 🛠 Prerequisites

- .NET 8.0 or newer
- SQL Server (or any other supported database)
- Google OAuth Client ID and Client Secret
- Git

## 📦 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Omega3D/DevcomTestTask.git
cd DevcomTestTask
```

### 2. Configure Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your_server>;Database=<your_database>;User Id=<your_user>;Password=<your_password>;"
  }
}
```

### 3. Set Up Google Authentication

Configure Google Identity keys in `appsettings.json`:

```json
{
  "GoogleAuth": {
    "ClientId": "Your_Google_Client_Id",
    "ClientSecret": "Your_Google_Client_Secret"
  }
}
```

### 4. Database Migration

Run the following commands to set up your database:

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### 5. Install Stored Procedures

The following stored procedures need to be added to your database. You can find the implementation code in the `Stored Procedures` folder:

- `spDeleteAnnouncement`
- `spCreateAnnouncement`
- `spGetAllAnnouncements`
- `spGetAnnouncementById`
- `spUpdateAnnouncement`

## 🚀 Running the Application

To start the application, run:

```bash
dotnet run
```

The application will be available at: `https://localhost:5001`

## 🏗️ Architecture

This project follows Clean Architecture principles and includes:

- ASP.NET MVC framework
- Entity Framework for data access
- Google Identity Authentication
- Stored Procedures for efficient data operations
