using TodosApp.Models;

namespace TodosApp.Service.Interface;

public interface ITodoService
{
    List<Todo> Index();
    void CreateTodo(Todo todo);
    Todo? Edit(int? id);
    bool EditTodo(Todo todo);
    Todo? Delete(int? id);
    void DeleteTodo(int id);

    void IsCompleted(int id);
}