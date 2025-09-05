# Ubuntu Health API

A comprehensive multi-tenant healthcare management API built with ASP.NET Core, featuring patient management, appointment scheduling, clinical notes, prescriptions, and invoicing.

## 🚀 Features

### Core Functionality
- **Multi-tenant Architecture**: Isolated data per organization
- **Role-based Access Control**: Admin, Doctor, Nurse, Receptionist roles
- **Patient Management**: Complete patient records with medical history
- **Appointment Scheduling**: Flexible appointment management system
- **Clinical Notes**: Digital clinical documentation
- **Prescription Management**: Medication tracking and management
- **Invoice Generation**: Automated billing and payment tracking

### Technical Features
- **Input Validation**: Comprehensive data validation with custom error messages
- **Global Exception Handling**: Centralized error management with custom exceptions
- **Structured Logging**: Detailed logging throughout the application
- **Security Headers**: Enhanced security with proper HTTP headers
- **Async/Await Patterns**: Proper async programming with cancellation tokens

## 🛠️ Technology Stack

- **.NET 8.0**
- **ASP.NET Core Web API**
- **Entity Framework Core** (SQL Server)
- **AutoMapper** (Object mapping)
- **JWT Authentication**
- **xUnit** (Unit testing)
- **Moq** (Mocking framework)
- **Serilog** (Structured logging)

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code
- Git

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/ubuntu-health-api.git
cd ubuntu-health-api
```

### 2. Database Setup
```bash
# Update connection string in appsettings.json
# Run migrations
dotnet ef database update
```

### 3. Install Dependencies
```bash
dotnet restore
```

### 4. Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:7000` (HTTPS) or `http://localhost:5000` (HTTP).

## 📚 API Documentation

### Authentication Endpoints
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login
- `POST /api/auth/assign-role` - Assign role to user (Admin only)
- `GET /api/auth/user-roles` - Get user roles (Admin only)

### Patient Management
- `GET /api/patients` - Get all patients
- `GET /api/patients/{id}` - Get patient by ID
- `POST /api/patients` - Create new patient
- `PUT /api/patients/{id}` - Update patient
- `DELETE /api/patients/{id}` - Delete patient

### Appointment Management
- `GET /api/appointments` - Get all appointments (paginated)
- `GET /api/appointments/{id}` - Get appointment by ID
- `POST /api/appointments` - Create new appointment
- `PUT /api/appointments/{id}` - Update appointment
- `DELETE /api/appointments/{id}` - Delete appointment

### Clinical Notes
- `GET /api/clinicalnotes` - Get all clinical notes
- `GET /api/clinicalnotes/{id}` - Get clinical note by ID
- `POST /api/clinicalnotes` - Create new clinical note
- `PUT /api/clinicalnotes/{id}` - Update clinical note
- `DELETE /api/clinicalnotes/{id}` - Delete clinical note

### Prescriptions
- `GET /api/prescriptions` - Get all prescriptions
- `GET /api/prescriptions/{id}` - Get prescription by ID
- `POST /api/prescriptions` - Create new prescription
- `PUT /api/prescriptions/{id}` - Update prescription
- `DELETE /api/prescriptions/{id}` - Delete prescription

### Invoices
- `GET /api/invoices` - Get all invoices
- `GET /api/invoices/{id}` - Get invoice by ID
- `POST /api/invoices` - Create new invoice
- `PUT /api/invoices/{id}` - Update invoice
- `DELETE /api/invoices/{id}` - Delete invoice

## 🔧 Configuration

### Environment Variables
```bash
# Database
ConnectionStrings__DefaultConnection="Server=(localdb)\\mssqllocaldb;Database=UbuntuHealthDb;Trusted_Connection=true;"

# JWT Settings
JWT__Secret="your-super-secret-key-here"
JWT__ValidIssuer="UbuntuHealthAPI"
JWT__ValidAudience="UbuntuHealthUsers"

# Logging
Serilog__MinimumLevel="Information"
```

### appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=UbuntuHealthDb;Trusted_Connection=true;"
  },
  "JWT": {
    "Secret": "your-super-secret-key-here",
    "ValidIssuer": "UbuntuHealthAPI",
    "ValidAudience": "UbuntuHealthUsers"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Security
- JWT token authentication
- Role-based authorization
- Input validation and sanitization
- Security headers middleware
- HTTPS enforcement

## 🏗️ Architecture

### Project Structure
```
├── Controllers/          # API Controllers
├── Services/            # Business Logic Layer
├── Repositories/        # Data Access Layer
├── Models/              # Data Models and DTOs
├── Middleware/          # Custom Middleware
├── Exceptions/          # Custom Exceptions
├── Helpers/             # Utility Classes
├── Tests/               # Unit Tests
└── Data/                # Database Context
```

### Design Patterns
- **Repository Pattern**: Data access abstraction
- **Service Layer Pattern**: Business logic separation
- **Dependency Injection**: Loose coupling
- **CQRS**: Command Query Responsibility Segregation
- **Middleware Pattern**: Cross-cutting concerns

## 🔒 Security Considerations

- All endpoints require authentication (except registration/login)
- Tenant isolation prevents cross-tenant data access
- Input validation prevents malicious data
- Rate limiting prevents API abuse
- Security headers protect against common attacks
- JWT tokens with expiration for secure authentication

## 🚀 Deployment

### Docker
```bash
# Build image
docker build -t ubuntu-health-api .

# Run container
docker run -p 5000:80 ubuntu-health-api
```


## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

**Built with ❤️ for healthcare professionals**