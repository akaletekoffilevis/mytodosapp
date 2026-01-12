using Microsoft.AspNetCore.Mvc;
using TodosApp.Service;
using TodosApp.Models;
using System.Diagnostics;
namespace TodosApp.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _service;

    public TodoController(TodoService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var todo = _service.Index();
        return View(todo);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Todo todo)
    {
        if (!ModelState.IsValid) return View(todo);
        _service.CreateTodo(todo);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var todo = _service.Edit(id);
        if (todo == null) return NotFound();
        return View(todo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsCompleted,DueDate")] Todo todo)
    {
        if (id != todo.Id) return NotFound();
        if (!ModelState.IsValid) return View(todo);
        if (!_service.EditTodo(todo)) return NotFound();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var todo = _service.Delete(id);
        if (todo == null) return NotFound();
        return View(todo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        _service.DeleteTodo(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        _service.IsCompleted(id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
