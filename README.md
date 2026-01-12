# TodosApp

Modern ASP.NET Core MVC todo list that uses Entity Framework Core with SQLite. The UI is built with Bootstrap 5 and Font Awesome for quick, responsive layouts.

## Features
- Create, edit, delete todos with title, description, and optional due date
- Toggle completion status from the list
- Items are sorted by creation date (newest first)
- Responsive views powered by Bootstrap 5
- Server-side validation via data annotations on the model

## Tech Stack
- ASP.NET Core 9.0 (MVC)
- Entity Framework Core + SQLite
- Bootstrap 5, jQuery, Font Awesome
- C# 12

## Project Structure
```
TodosApp/
├── Program.cs
├── Data/
│   └── TodoContext.cs
├── Models/
│   ├── Todo.cs
│   └── ErrorViewModel.cs
├── Service/
│   ├── Interface/ITodoService.cs
│   └── TodoService.cs
├── Controllers/
│   └── TodoController.cs
├── Views/
│   └── Todo/ (Index, Create, Edit, Delete)
└── wwwroot/
```

## Getting Started
1. **Prerequisites**: .NET 9 SDK and the `dotnet-ef` tool (`dotnet tool install --global dotnet-ef`).
2. **Restore packages**: `dotnet restore`.
3. **Configure SQLite**: in `appsettings.json`, ensure the connection string key is `ConectionStrings:TodoDatabase` (default `Data Source=todo.db`).
4. **Create database** (add a migration if none exists):
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
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
