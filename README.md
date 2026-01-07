# Task Manager App

A full-stack task manager application built with **ASP.NET Core (C#)** for the backend and **React** for the frontend.  
Allows users to create, view, update, and delete tasks with a friendly web interface.

---

## Features

### Backend (ASP.NET Core)
- Create tasks with title, description, due date, and status
- Retrieve a single task by ID or all tasks
- Update task status
- Delete tasks
- Data stored in **SQLite**
- **Swagger** API documentation
- Validation and error handling
- Unit tests using **xUnit** and **EF Core InMemory**

### Frontend (React)
- Display all tasks in a table
- Create new tasks via a form
- Update task status via dropdown
- Delete tasks
- Communicates with backend via **Axios**

---

## Tech Stack
- **Backend:** ASP.NET Core 10, C#, Entity Framework Core, SQLite
- **Frontend:** React, Axios
- **Testing:** xUnit, EF Core InMemory
- **API Docs:** Swagger (OpenAPI)

---

## Getting Started

### 1. Clone the repository

```bash
git clone <your-repo-url>
cd <repo-folder>
```
### Setup Backend

```bash
cd TaskApi
dotnet restore
dotnet ef database update
dotnet run
```

### Setup Frontend

```bash
cd ../frontend
npm install
npm start
```

### Testing

Backend Unit Tests

```bash
cd TaskApi.Tests
dotnet test
```
