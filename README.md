# ASP.NET Core Identity Management System

## Project Overview
This is an ASP.NET Core web application that implements user identity management and employee management functionality. The project is built using ASP.NET Core 8.0 and follows the MVC (Model-View-Controller) architectural pattern.

## Features
- User Authentication & Authorization
  - User Registration
  - User Login
  - Password Management
  - Email Verification
- Employee Management System
- Secure Identity Management using ASP.NET Core Identity
- Modern UI using Bootstrap

## Technical Stack
- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server
- **ORM**: Entity Framework Core 9.0
- **Authentication**: ASP.NET Core Identity
- **Frontend**: 
  - Bootstrap 5.3.3
  - Twitter Bootstrap 3.0.1.1
- **Development Environment**: Visual Studio 2022

## Project Structure
```
FinalProject/
├── Controllers/
│   ├── AccountController.cs    # Handles user authentication
│   ├── EmployeesController.cs  # Manages employee operations
│   └── HomeController.cs       # Handles main application flow
├── Models/                     # Data models
├── Views/                      # MVC views
├── ViewModels/                 # View-specific models
├── Services/                   # Business logic services
├── Data/                      # Database context and configurations
├── wwwroot/                   # Static files (CSS, JS, Images)
└── Program.cs                 # Application startup and configuration
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 (recommended) or VS Code

### Installation
1. Clone the repository
2. Open the solution in Visual Studio
3. Update the connection string in `appsettings.json` if needed
4. Run the following commands in Package Manager Console:
   ```
   Update-Database
   ```
5. Build and run the application

### Configuration
The application uses the following connection string (configured in appsettings.json):
```json
"ConnectionStrings": {
  "StoreContext": "Server=(localdb)\\mssqllocaldb;Database=Store;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

## Features Documentation

### User Authentication
- **Registration**: Users can create new accounts with email and password
- **Login**: Secure authentication using ASP.NET Core Identity
- **Password Management**: Includes password reset and change functionality
- **Email Verification**: Email verification system for account security

### Employee Management
- CRUD operations for employee records
- Employee profile management
- File upload for employee documents

## Security Features
- Secure password hashing
- Protection against CSRF attacks
- Secure session management
- Input validation and sanitization

## Contributing
1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request

## License
This project is licensed under the MIT License - see the LICENSE file for details. 