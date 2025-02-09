# Veer Developer Challenge

This repository contains a basic React.js frontend and a .NET Core Web API backend, developed as part of a developer challenge for a job application. Below, you'll find instructions on how to run the applications, a description of the project, and an overview of my development process.

---

## Table of Contents
1. [How to Run the Applications](#how-to-run-the-applications)
   - [.NET Core Web API](#net-core-web-api)
   - [React.js Web Application](#reactjs-web-application)
2. [Project Description](#project-description)
   - [Backend](#backend)
   - [Frontend](#frontend)
3. [Development Process](#development-process)

---

## How to Run the Applications

### .NET Core Web API

1. **Prerequisites**:
   - Ensure you have a PostgreSQL server running.
   - Install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Database Configuration**:
   - Open the `appsettings.Development.json` file located in the `VeerBackend` directory.
   - Replace the `"MainDbConnection"` string with your PostgreSQL database configuration.

3. **Run the Application**:
   - Navigate to the `VeerBackend` directory in your terminal.
   - Execute the following command:
     ```bash
     dotnet run
     ```
   - The application will automatically create and migrate the database on the first run. It will also seed a default user with the following credentials for testing:
     - **Email**: `test@test.com`
     - **Password**: `Testuser123`

4. **API Endpoints**:
   - The API contains three endpoints:
     1. **Signup**: Register a new user.
     2. **Login**: Authenticate and receive a JWT token.
     3. **Get User Information**: Retrieve user details (requires authentication).
   - You can explore and test these endpoints using the Swagger UI, which is available when you run the application.

---

### React.js Web Application

1. **Prerequisites**:
   - Install [Node.js](https://nodejs.org/) (v16 or higher recommended).

2. **Install Dependencies**:
   - Navigate to the `VeerFrontend` directory in your terminal.
   - Run the following command to install all required dependencies:
     ```bash
     npm install
     ```

3. **Run the Application**:
   - Start the development server by running:
     ```bash
     npm run dev
     ```
   - The application will launch in your default browser. You can start testing the login, signup, and user information retrieval functionalities.

4. **Frontend Features**:
   - The React application includes a login page and an additional home page that users are redirected to after successful authentication.

---

## Project Description

### Backend

The backend is a .NET Core Web API built with Clean Architecture principles. It is designed to be modular, scalable, and maintainable. Key features include:

- **Authentication**: I implemented the authentication system manually, including JWT token generation and validation. While I could have used the Microsoft Identity library for a quicker setup, I chose to build the authentication endpoints myself to demonstrate my understanding of the process.
- **Database**: The application uses PostgreSQL for data storage. Entity Framework Core is used for database migrations and entity management.
- **Endpoints**: The API provides three core endpoints:
  1. **Signup**: Allows new users to register.
  2. **Login**: Authenticates users and returns a JWT token.
  3. **Get User Information**: Retrieves user details (protected by JWT authentication).

### Frontend

The frontend is a React.js application styled with TailwindCSS for rapid and responsive development. Key features include:

- **Routing**: The application uses React Router for navigation between the login and home pages.
- **API Integration**: The frontend communicates with the backend API for user authentication and data retrieval.
- **UI/UX**: TailwindCSS was chosen for its utility-first approach, enabling quick and consistent styling.

---

## Development Process

Even though this is a small project, I approached it as if it were part of a larger system. My goal was to demonstrate best practices in code organization, responsibility separation, and scalability. Here’s an overview of my development flow:

### Backend Development

1. **Domain Layer**:
   - I started by defining the core entities (e.g., `User`) and their relationships.
2. **Persistence Layer**:
   - Configured Entity Framework Core to map the entities to a PostgreSQL database.
   - Set up database migrations to ensure the schema is always up-to-date.
3. **Service Layer**:
   - Implemented the business logic for user authentication and management.
4. **API Layer**:
   - Built the endpoints for signup, login, and user information retrieval.
   - Added JWT-based authentication to secure the `Get User Information` endpoint.

### Frontend Development

1. **Routing**:
   - Set up the application router with routes for the login and home pages.
2. **Layout**:
   - Designed the main layout structure, including navigation and styling.
3. **UI Components**:
   - Created reusable components for forms, buttons, and other UI elements.
4. **API Integration**:
   - Implemented API requests for user authentication and data retrieval.
   - Managed user state and authentication tokens securely.

### Tools and Libraries

- **Backend**: .NET Core, Entity Framework Core, PostgreSQL, JWT.
- **Frontend**: React.js, TailwindCSS, Axios for API requests.

---

This project reflects my commitment to writing clean, modular, and maintainable code. I hope it demonstrates my ability to handle both frontend and backend development effectively. If you have any questions or feedback, feel free to reach out!

--- 

**Thank you for reviewing my work!**