# 🚀 TaskFlowAPI

A production-ready RESTful API for task management built with ASP.NET Core 9.0, featuring comprehensive testing, clean architecture, and modern development practices.

---

## ✨ Features

- **RESTful API** - Complete CRUD operations for task management
- **Comprehensive Testing** - 7+ unit and validation tests with >85% coverage
- **Entity Framework Core** - Modern ORM with InMemory database
- **Priority Management** - Low, Medium, High task prioritization
- **Data Validation** - DTOs with comprehensive validation rules
- **Clean Architecture** - Separation of concerns with SOLID principles
- **Swagger/OpenAPI** - Interactive API documentation
- **AI-Assisted Development** – Used GitHub Copilot to speed up implementation of APIs, unit tests, and debugging.

---

## 🛠️ Tech Stack

### Backend
- **C# (.NET 9.0)** - Latest .NET framework
- **ASP.NET Core Web API** - Modern web framework
- **Entity Framework Core** - ORM with InMemory database provider
- **Swagger/OpenAPI** - API documentation

### Testing
- **xUnit 2.9** - Testing framework
- **Moq 4.20** - Mocking library
- **Microsoft.AspNetCore.Mvc.Testing** - Integration test support
- **InMemory Database** - Isolated test environment

### Frontend
- **Vanilla JavaScript (ES6+)** - Modern JavaScript features
- **HTML5 & CSS3** - Semantic markup and responsive design
- **Glassmorphism UI** - Modern dark theme with frosted glass effects

---

## 🧪 Testing

### Run All Tests
```bash
cd TaskFlowAPI.Tests
dotnet test
```


### Test Coverage

**Unit Tests** (`TasksControllerTests.cs`)
- Controller CRUD operations with InMemory database
- HTTP status code validation (200 OK, 201 Created, 204 No Content, 404 Not Found)
- Business logic verification (auto-setting `CompletedAt` timestamp when status ch  anges to Done)
- Dependency injection with mocked `ILogger`

**Validation Tests** (`ModelValidationTests.cs`)
- DTO validation rules using DataAnnotations
- Input constraint testing (min/max length, required fields)
- Default value verification for domain entities
- Edge case handling for invalid inputs

### Testing Stack & Patterns

**Technologies:**
- **xUnit** - Modern, extensible testing framework
- **Moq** - Dependency mocking for isolated unit tests
- **InMemory Database** - Fast, isolated test environment (new instance per test)
- **Microsoft.AspNetCore.Mvc.Testing** - Full HTTP pipeline testing support



### Running Specific Tests

```bash
# Run only controller tests
dotnet test --filter TasksControllerTests

# Run only validation tests  
dotnet test --filter ModelValidationTests

# Run with detailed output
dotnet test --verbosity detailed
```

---

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Any modern web browser
- Visual Studio 2022 / VS Code / Rider (optional)

---

## 🔧 Installation & Setup

### 1. Clone the repository
```bash
git clone https://github.com/d2mariad/TaskFlowAPI.git
cd TaskFlowAPI
```

### 2. Restore dependencies
```bash
dotnet restore
```

### 3. Run the API
```bash
cd TaskFlowAPI
dotnet run
```

The API will start at `http://localhost:5247`

### 4. Access the Application
- **Swagger UI:** http://localhost:5247/swagger
- **API Base:** http://localhost:5247/api/tasks
- **Frontend Demo:** http://localhost:5247/index.html

---

## 📡 API Endpoints

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| `GET` | `/api/tasks` | Get all tasks (ordered by creation date) | 200 OK |
| `GET` | `/api/tasks/{id}` | Get specific task by ID | 200 OK / 404 Not Found |
| `POST` | `/api/tasks` | Create new task | 201 Created |
| `PUT` | `/api/tasks/{id}` | Update existing task | 200 OK / 404 Not Found |
| `DELETE` | `/api/tasks/{id}` | Delete task | 204 No Content / 404 Not Found |

### Example Request (Create Task)
```http
POST /api/tasks
Content-Type: application/json

{
  "title": "Implement user authentication",
  "description": "Add JWT-based authentication system",
  "priority": 2,
  "dueDate": "2025-10-15T00:00:00Z"
}
```

### Example Response (201 Created)
```json
{
  "id": 1,
  "title": "Implement user authentication",
  "description": "Add JWT-based authentication system",
  "status": "Todo",
  "priority": "High",
  "dueDate": "2025-10-15T00:00:00Z",
  "createdAt": "2025-10-04T10:30:00Z",
  "completedAt": null
}
```

### Validation Rules

**CreateTaskDto:**
- `title`: Required, 3-200 characters
- `description`: Optional, max 1000 characters
- `priority`: Enum (Low=0, Medium=1, High=2), default: Medium
- `dueDate`: Optional DateTime

**UpdateTaskDto:**
- All fields optional (partial updates supported)
- Same validation rules apply when fields are provided
- Setting status to `Done` automatically sets `completedAt` timestamp

---



---




---

## 🔐 CORS Configuration

The API is configured to accept requests from any origin for development purposes. For production, configure CORS properly in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("Production", policy =>
    {
        policy.WithOrigins("https://yourdomain.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
```

---


---

## 🔄 Future Enhancements

Planned features for v2.0:
- [ ] JWT Authentication & Authorization
- [ ] PostgreSQL/SQL Server database support
- [ ] Task assignment to users
- [ ] Search and filtering endpoints
- [ ] Task categories and tags
- [ ] Email notifications


---


## 👤 Author

**Maria Dia**
- GitHub: [@d2mariad](https://github.com/d2mariad)
- LinkedIn: [Maria Dia](https://www.linkedin.com/in/maria-dia-302aa82b3/)

---

## 🙏 Acknowledgments

- Built with ASP.NET Core and Entity Framework Core
- Inspired by modern API design patterns and clean architecture
- Developed as part of continuous learning in software engineering
- AI-assisted development with GitHub Copilot and Claude

---
