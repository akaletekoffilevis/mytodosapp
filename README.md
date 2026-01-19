# 📋 MyTodosApp

> A modern, production-ready todo management application built with **ASP.NET Core 9.0** and **Entity Framework Core**. Featuring a responsive UI with Bootstrap 5, real-time interactions, and robust server-side validation.

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-4B8BBE?logo=microsoft)](https://docs.microsoft.com/en-us/ef/)

## ✨ Features

- ✅ **Full CRUD Operations** – Create, read, update, and delete todos with comprehensive metadata
- ✅ **Smart Task Management** – Toggle completion status with instant UI feedback
- ✅ **Intelligent Sorting** – Auto-sorted by creation date for optimal workflow
- ✅ **Responsive Design** – Mobile-first Bootstrap 5 UI adapts seamlessly to all devices
- ✅ **Server-Side Validation** – Robust data annotation-based validation ensures data integrity
- ✅ **Optional Due Dates** – Plan ahead with built-in scheduling capabilities
- ✅ **Persistent Storage** – SQLite database with EF Core migrations for reliability

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| **ASP.NET Core** | 9.0 | Web framework & API layer |
| **Entity Framework Core** | 8.0+ | ORM & database abstraction |
| **SQLite** | Latest | Lightweight, file-based database |
| **Bootstrap** | 5.x | Responsive UI framework |
| **jQuery** | 3.x | DOM manipulation & interactions |
| **Font Awesome** | 6.x | Icon library |
| **C#** | 12 | Primary language |

## 📁 Project Architecture

```
mytodosapp/
├── Program.cs                          # Dependency injection & middleware configuration
├── appsettings.json                    # Configuration & connection strings
├── Data/
│   ├── TodoContext.cs                  # EF Core DbContext
│   └── Migrations/                     # Database version control
├── Models/
│   ├── Todo.cs                         # Core domain model with validation
│   └── ErrorViewModel.cs               # Error handling model
├── Services/
│   ├── Interfaces/
│   │   └── ITodoService.cs             # Service contract
│   └── TodoService.cs                  # Business logic layer
├── Controllers/
│   └── TodoController.cs               # MVC controller & request handling
├── Views/
│   ├── Shared/                         # Common layouts & templates
│   └── Todo/
│       ├── Index.cshtml                # List view
│       ├── Create.cshtml               # Create form
│       ├── Edit.cshtml                 # Edit form
│       └── Delete.cshtml               # Delete confirmation
└── wwwroot/                            # Static files (CSS, JS, images)
```

## 🚀 Quick Start

### Prerequisites

Ensure you have the following installed:
- **.NET 9.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **dotnet-ef** CLI tool:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Installation Steps

**1. Clone the repository**
```bash
git clone https://github.com/akaletekoffilevis/mytodosapp.git
cd mytodosapp
```

**2. Restore NuGet packages**
```bash
dotnet restore
```

**3. Configure the database**
- Review `appsettings.json` for connection string settings
- Default: SQLite database at `todo.db`

**4. Apply database migrations**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

**5. Run the application**
```bash
dotnet run
```

**6. Access in browser**
- Navigate to the URL shown in console (typically `https://localhost:5001` or `https://localhost:7001`)
- Or follow the direct link printed in terminal output

## 📖 Usage Guide

### ➕ Create a Todo
1. Click the **"Add Todo"** button on the dashboard
2. Fill in the required **Title** field
3. *(Optional)* Add a description and due date
4. Click **"Create"** to save

### 👁️ View Todos
- **Desktop:** Todos display in a full-featured table with sorting and filtering
- **Mobile:** Optimized card-based layout with touch-friendly interactions
- **Info:** Each todo shows title, description, due date, and status badge

### ✏️ Edit a Todo
1. Click the **"Edit"** button (pencil icon)
2. Modify the desired fields
3. Click **"Save Changes"**

### ✅ Mark as Complete
- Click the **checkmark icon** (✓) to mark complete
- Click the **undo icon** (↺) to revert to incomplete
- Status updates in real-time with visual feedback

### 🗑️ Delete a Todo
1. Click the **"Delete"** button (trash icon)
2. Confirm deletion in the safety dialog
3. Click **"Delete Permanently"** to confirm
4. Todo is immediately removed from database

## 🗄️ Database Schema

### SQL Structure
```sql
CREATE TABLE Todos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    IsCompleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    DueDate DATETIME NULL,
    CONSTRAINT CK_Title CHECK (LEN(Title) > 0)
)
```

### Todo Model
```csharp
public class Todo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [DefaultValue(false)]
    public bool IsCompleted { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    public DateTime? DueDate { get; set; }
}
```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/Todo/Index` | Get all todos |

5. **Run**: `dotnet run --project TodosApp.csproj` and browse to `https://localhost:5001` (or the port shown in the console).

## How It Works

- `Program.cs` wires up MVC, static files, and registers the SQLite `TodoContext`.
- `TodoController` uses `TodoService` to list, create, edit, delete, and toggle completion.
- `TodoService` persists todos with EF Core and orders them by `CreatedAt` descending.
- `Todo` model uses data annotations for required fields and lengths; `CreatedAt` defaults to UTC now.

## Endpoints

| Method | Route | Purpose |
| --- | --- | --- |
| GET | `/Todo/Index` | List todos |
| GET | `/Todo/Create` | Show create form |
| POST | `/Todo/Create` | Create a todo |
| GET | `/Todo/Edit/{id}` | Show edit form |
| POST | `/Todo/Edit/{id}` | Update a todo |
| GET | `/Todo/Delete/{id}` | Delete confirmation |
| POST | `/Todo/Delete/{id}` | Delete a todo |
| POST | `/Todo/ToggleComplete/{id}` | Toggle completion |

## Configuration Notes

- Current JSON key is `ConectionStrings` (with one “n”). Either keep it and read `TodoDatabase` under that key, or rename it to the standard `ConnectionStrings` and update `Program.cs` accordingly.
- Default SQLite file path is `todo.db` at the content root.

## Troubleshooting

- **Database not created**: ensure a migration exists, then run `dotnet ef database update`.
- **Connection string null**: verify the key spelling matches what `Program.cs` expects.
- **Port in use**: change the applicationUrl in `Properties/launchSettings.json`.

## License

MIT License. See the LICENSE file.
