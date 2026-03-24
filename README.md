# User Management API

This repository contains the User Management API built using ASP.NET Core. The project features CRUD operations, data validation, error handling, authentication, and request logging.

## Microsoft Copilot Documentation

As part of the project requirements, Microsoft Copilot was utilized to assist in writing, debugging, and enhancing the API code. Below is a detailed summary of how Copilot contributed to each phase of the development:

### 1. Generating API Endpoints (Activity 1)
* **Project Scaffolding:** Copilot helped generate the initial boilerplate code for the ASP.NET Core Web API, streamlining the initial setup.
* **CRUD Operations:** By using specific prompts, Copilot generated the `GET`, `POST`, `PUT`, and `DELETE` endpoints within the `UsersController`. It successfully scaffolded the core logic for managing the in-memory user list and returning the appropriate HTTP status codes (like 200 OK, 201 Created, and 204 No Content).

### 2. Debugging and Enhancing Code (Activity 2)
* **Data Validation:** After analyzing the initial code, I used Copilot to identify potential bugs, such as users being added without proper validation. Copilot suggested implementing Data Annotations (`[Required]`, `[EmailAddress]`, and `[StringLength]`) directly into the `User` model to ensure only valid data is processed.
* **Exception Handling:** To prevent the API from crashing due to unhandled exceptions, Copilot assisted in implementing `try-catch` blocks within the endpoints, ensuring the API remains stable and returns meaningful error messages.

### 3. Implementing Middleware (Activity 3)
* **Custom Middlewares Generation:** Copilot was used to generate three essential middleware components:
  * **Logging Middleware:** Automatically logs all incoming HTTP requests (method and path) and outgoing responses (status code and execution time).
  * **Error-Handling Middleware:** Catches any unhandled exceptions globally across the application and returns a standardized JSON error response (`Internal server error`).
  * **Authentication Middleware:** Secures the API by validating a Bearer token (`valid-token`) from incoming requests. It automatically returns a `401 Unauthorized` response if the token is invalid or missing.
* **Pipeline Configuration:** Finally, Copilot guided the correct ordering of these middlewares in the `Program.cs` file. It ensured that the Error-Handling middleware was placed first, followed by Authentication, and lastly Logging, optimizing the pipeline for security and performance.
