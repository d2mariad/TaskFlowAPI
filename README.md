# ⚡ TaskFlow

A modern, full-stack task management system built with C# .NET and vanilla JavaScript featuring a sleek dark UI with glassmorphic design.


## 🚀 Features

- **RESTful API** - Complete CRUD operations for task management
- **Entity Framework Core** - Modern ORM with migrations support
- **Status Tracking** - Todo, InProgress, Done workflow
- **Priority Levels** - Low, Medium, High task prioritization
- **Modern UI** - Dark theme with glassmorphic design and smooth animations
- **Real-time Updates** - Instant task synchronization
- **Data Validation** - DTOs with comprehensive validation rules

## 🛠️ Tech Stack

**Backend:**
- C# (.NET 8.0)
- ASP.NET Core Web API
- Entity Framework Core
- SQLite Database

**Frontend:**
- Vanilla JavaScript (ES6+)
- HTML5 & CSS3
- Glassmorphism UI Design

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Any modern web browser
- Visual Studio 2022 / VS Code / Rider (optional)

## 🔧 Installation & Setup

### 1. Clone the repository
```bash
git clone https:https://github.com/d2mariad/TaskFlowAPI.git
cd TaskFlow
```

### 2. Restore dependencies
```bash
dotnet restore
```

### 3. Apply database migrations
```bash
dotnet ef database update
```

### 4. Run the API
```bash
dotnet run
```
The API will start at `http://localhost:5247`

### 5. Open the frontend
- Open `index.html` in your browser
- Or use a local server:
```bash
# Using Python
python -m http.server 8000

# Using Node.js
npx http-server
```

## 📡 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get task by ID |
| POST | `/api/tasks` | Create new task |
| PUT | `/api/tasks/{id}` | Update task |
| DELETE | `/api/tasks/{id}` | Delete task |

### Example Request (Create Task)
```json
POST /api/tasks
Content-Type: application/json

{
  "title": "Implement user authentication",
  "description": "Add JWT-based authentication system",
  "priority": 2,
  "dueDate": "2025-10-15T00:00:00Z"
}
```

## 🗄️ Database Schema

**TaskItem**
- `Id` (int, PK)
- `Title` (string, required, max 200)
- `Description` (string, optional, max 1000)
- `Status` (enum: Todo, InProgress, Done)
- `Priority` (enum: Low, Medium, High)
- `DueDate` (DateTime?, optional)
- `CreatedAt` (DateTime)
- `CompletedAt` (DateTime?, optional)

## 🎨 UI Features

- **Glassmorphic Cards** - Modern frosted glass effect
- **Gradient Animations** - Smooth color transitions
- **Hover Effects** - Interactive task cards
- **Responsive Design** - Mobile-friendly layout
- **Status Badges** - Visual priority and status indicators

## 📂 Project Structure

```
TaskFlow/
├── Controllers/
│   └── TasksController.cs
├── Models/
│   └── TaskItem.cs
├── DTOs/
│   ├── CreateTaskDto.cs
│   └── UpdateTaskDto.cs
├── Data/
│   └── TaskDbContext.cs
├── wwwroot/
│   └── index.html
├── Program.cs
└── README.md
```

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

## 🚧 Roadmap

- [ ] User authentication & authorization
- [ ] Task categories and tags
- [ ] Due date reminders
- [ ] Task search and filtering
- [ ] Dark/Light theme toggle
- [ ] Drag-and-drop task reordering

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 👤 Author

**Your Name**
- GitHub: [d2mariad](https://github.com/d2mariad)
- LinkedIn: [Your LinkedIn](https://www.linkedin.com/in/maria-dia-302aa82b3/)



⭐ Star this repo if you find it useful!
