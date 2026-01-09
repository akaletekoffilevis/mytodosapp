# My TodosApp

A modern and responsive Todo application built with **ASP.NET Core MVC**. This application allows users to create, read, update, and delete todos with ease. It features a clean user interface that works seamlessly on both desktop and mobile devices.

## Features

- ✅ **Create Todos** - Add new todos with title, description, and due date
- 📝 **Edit Todos** - Update todo details anytime
- ✨ **Mark as Complete** - Toggle todo completion status
- 🗑️ **Delete Todos** - Remove todos you no longer need
- 📱 **Responsive Design** - Works perfectly on desktop and mobile devices
- 🎨 **Bootstrap UI** - Modern and clean interface with Bootstrap 5
- 🔍 **Easy Navigation** - Intuitive and user-friendly design

## Tech Stack

- **Framework**: ASP.NET Core 9.0
- **Architecture**: MVC (Model-View-Controller)
- **Database**: Entity Framework Core
- **Frontend**: Bootstrap 5, jQuery
- **Icons**: Font Awesome
- **Language**: C#

## Project Structure

```
mytodosapp/
├── Controllers/
│   └── TodoController.cs          # Handles all todo operations
├── Models/
│   └── Todo.cs                    # Todo data model
├── Data/
│   └── AppDbContext.cs            # Entity Framework DbContext
├── Views/
│   └── Todo/
│       ├── Index.cshtml           # Todo list view
│       ├── Create.cshtml          # Create todo view
│       ├── Edit.cshtml            # Edit todo view
│       └── Delete.cshtml          # Delete confirmation view
├── wwwroot/                       # Static files (CSS, JS)
└── Program.cs                     # Application entry point
```

## Installation

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 / Visual Studio Code (optional)

### Setup

1. **Clone the repository**
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
| GET | `/Todo/Create` | Show create form |
| POST | `/Todo/Create` | Create a new todo |
| GET | `/Todo/Edit/{id}` | Show edit form |
| POST | `/Todo/Edit/{id}` | Update a todo |
| GET | `/Todo/Delete/{id}` | Show delete confirmation |
| POST | `/Todo/Delete/{id}` | Delete a todo |
| POST | `/Todo/ToggleComplete/{id}` | Toggle completion status |

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=todos.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

## Troubleshooting

### Database issues
- Delete `todos.db` file and re-run migrations: `dotnet ef database update`

### Port already in use
- Change the port in `launchSettings.json`

### Migration errors
- Install EF Tools: `dotnet tool install --global dotnet-ef`

## Contributing

Contributions are welcome! Please feel free to submit issues and pull requests.

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Author

Created with ❤️

## Support

If you encounter any issues or have questions, please open an issue on GitHub.

---

**Enjoy organizing your todos! 📝**
