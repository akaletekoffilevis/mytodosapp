# My TodosApp

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
mytodosapp/
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
   git clone https://github.com/akaletekoffilevis/mytodosapp.git
   cd mytodosapp
   ```

2. **Install dependencies**
   ```bash
   cd mytodosapp
   dotnet restore
   ```

3. **Configure the database**
   - Edit `appsettings.json` if needed (default uses SQLite)
   - Run migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**
   - Open your browser and navigate to `https://localhost:[PORT]`
   - Or click on the link show in terminal 

## Usage

### Create a Todo
1. Click the **"Add Todo"** button
2. Fill in the title (required), description, and due date (optional)
3. Click **"Create"**

### View Todos
- All todos are displayed in a table on desktop or cards on mobile
- Todos show their title, description, due date, and status

### Edit a Todo
1. Click the **"Edit"** button next to the todo
2. Modify the details
3. Click **"Save"**

### Mark as Complete
- Click the checkmark icon to mark a todo as completed
- Click the undo icon to mark it as incomplete

### Delete a Todo
1. Click the **"Delete"** button
2. Confirm the deletion in the confirmation dialog
3. Click **"Delete Permanently"**

## Database Schema

```sql
CREATE TABLE Todos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    IsCompleted BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETUTCDATE(),
    DueDate DATETIME NULL
)
```

### Todo Model

```csharp
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }           // Required
    public string? Description { get; set; }    // Optional
    public bool IsCompleted { get; set; }       // Default: false
    public DateTime CreatedAt { get; set; }     // Auto-set
    public DateTime? DueDate { get; set; }      // Optional
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
