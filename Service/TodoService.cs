using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosApp.Data;
using TodosApp.Models;
using TodosApp.Service.Interface;

namespace TodosApp.Service;

public class TodoService : ITodoService
{
    private readonly TodoContext _db;

    public TodoService(TodoContext db)
    {
        _db = db;
    }

    public List<Todo> Index()
    {
        return _db.Todos.OrderByDescending(t => t.CreatedAt).ToList();
    }

    public void CreateTodo(Todo todo)
    {
        _db.Todos.Add(todo);
        _db.SaveChanges();
    }

    public Todo? Edit(int? id)
    {
        return _db.Todos.Find(id);
    }

    public bool EditTodo(Todo todo)
    {
        try
        {

            _db.Update(todo);
            _db.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            // if (!_db.Todos.Any(e => e.Id == id)){};
            return false;
        }
    }

    public Todo? Delete(int? id)
    {
        var todo = _db.Todos.FirstOrDefault(t => t.Id == id);
        return todo;
    }

    public void DeleteTodo(int id)
    {
        var todo = Delete(id);
        if (todo != null)
        {
            _db.Todos.Remove(todo);
            _db.SaveChanges();
        }
    }

    public void IsCompleted(int id)
    {
        var todo = _db.Todos.Find(id);
        if (todo != null)
        {
            todo.IsCompleted = !todo.IsCompleted;
            _db.Update(todo);
            _db.SaveChangesAsync();
        }
    }

}















