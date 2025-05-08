# Ubuntu Health API

## Overview

The Ubuntu Health API is a modern healthcare management system designed to address inefficiencies in traditional healthcare systems, particularly in South Africa. Many healthcare providers still rely on outdated systems, including pen-and-paper record-keeping, which leads to inefficiencies, errors, and delays in patient care. This API provides a robust, scalable, and secure solution to digitize healthcare operations, enabling better patient management, appointment scheduling, billing, and more.

## Problem Statement

Healthcare providers in South Africa often face challenges due to:

- **Manual Record-Keeping**: Paper-based systems are prone to errors, loss, and inefficiencies.
- **Fragmented Systems**: Lack of integration between patient records, billing, and appointment scheduling.
- **Limited Accessibility**: Difficulty in accessing patient data across multiple locations.
- **Role-Based Restrictions**: Inefficient management of staff roles and permissions.

The Ubuntu Health API aims to solve these problems by providing a centralized, digital platform for managing healthcare operations.

## Features

### 1. User Authentication & Role Management

- Secure user authentication using JWT (JSON Web Tokens).
- Role-based access control for Admin, Doctor, Nurse, and Receptionist roles.
- Tenant-based isolation to ensure data privacy for multi-tenant environments.

### 2. Patient Management

- CRUD operations for managing patient records.
- Tenant-specific patient data to ensure data isolation.
- Support for storing detailed patient information, including medical history, allergies, and emergency contacts.

### 3. Appointment Scheduling

- Manage appointments for patients with support for different appointment types.
- Role-based access to appointment data.
- Conflict detection to prevent double-booking.

### 4. Prescription Handling

- Manage prescriptions for patients, including medications, dosages, and refill information.
- Role-based access for doctors to create and update prescriptions.

### 5. Billing

- Generate and manage invoices for patient appointments and treatments.
- Track payment statuses and add notes for billing records.

### 6. Clinical Notes

- Allow doctors to add and manage clinical notes for patients.
- Secure storage of sensitive medical information.

## Architecture

The Ubuntu Health API follows a modular, service-oriented architecture to ensure scalability, maintainability, and testability.

### 1. Layers

- **Controllers**: Handle HTTP requests and responses. Delegate business logic to services.
- **Services**: Contain business logic and interact with repositories.
- **Repositories**: Handle database interactions using Entity Framework Core.
- **Models**: Define the structure of data entities and DTOs (Data Transfer Objects).
- **Helpers**: Provide utility functions, such as tenant validation.

### 2. Multi-Tenant Design

- Tenant-based isolation ensures that each healthcare provider's data is securely separated.
- Tenant IDs are included in all major entities (e.g., Patient, Invoice, Appointment) to enforce data isolation.

### 3. Security

- **Authentication**: Secure login using JWT.
- **Authorization**: Role-based access control using ASP.NET Core's built-in authorization.
- **Data Validation**: Input validation to prevent SQL injection and other vulnerabilities.

## Tech Stack

### Frontend:

- _Backend services powered by [Ubuntu Health](https://github.com/Sean-Thomo/ubuntu-health)_

### Backend

- **ASP.NET Core 7.0**: Framework for building the API.
- **Entity Framework Core**: ORM for database interactions.
- **SQLite**: Lightweight database for development and testing (can be replaced with PostgreSQL or SQL Server for production).

### Authentication & Authorization

- **ASP.NET Identity**: User management and authentication.
- **JWT (JSON Web Tokens)**: Secure token-based authentication.

### Other Tools

- **DotNetEnv**: Load environment variables for configuration.
- **Migrations**: Database schema management using EF Core migrations.

## How It Works

### User Authentication:

- Users register with their tenant ID and role (e.g., Admin, Doctor).
- JWT tokens are issued upon successful login, containing claims for roles and tenant IDs.

### Role-Based Access Control:

- Admins can manage users, roles, and tenants.
- Doctors can manage patients, appointments, prescriptions, and clinical notes.
- Receptionists can manage appointments and billing.

### Tenant Isolation:

- All data is scoped to a specific tenant using the `TenantId` field.
- Tenant validation ensures that users can only access data belonging to their tenant.

### Healthcare Operations:

- **Patients**: Add, update, delete, and retrieve patient records.
- **Appointments**: Schedule, update, and cancel appointments.
- **Prescriptions**: Manage medications and dosages for patients.
- **Billing**: Generate invoices and track payment statuses.

## Setup Instructions

### 1. Prerequisites

- .NET 7 SDK
- SQLite (or another database for production)
- Postman (optional, for testing API endpoints)

### 2. Clone the Repository

### 3. Configure Environment Variables

Create a `.env` file in the root directory with the following variables:

### 4. Run Migrations

### 5. Start the Application

### 6. Access the API

- **Swagger UI**: http://localhost:5000/swagger
- **Example Endpoints**:
  - `POST /api/auth/register`: Register a new user.
  - `POST /api/auth/login`: Login and receive a JWT token.
  - `GET /api/patients`: Retrieve all patients for the tenant.
