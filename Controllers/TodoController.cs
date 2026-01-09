using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodosApp.Data;
using TodosApp.Models;
using System.Diagnostics;
namespace TodosApp.Controllers;

public class TodoController : Controller
{
   
    private readonly AppDbContext _db;

    public TodoController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index() => View(await _db.Todos.OrderByDescending(t => t.CreatedAt).ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Todo todo)
    {
        if (!ModelState.IsValid) return View(todo);

        todo.CreatedAt = DateTime.UtcNow;
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return NotFound();

        return View(todo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsCompleted,DueDate,CreatedAt")] Todo todo)
    {
        if (id != todo.Id) return NotFound();

        if (!ModelState.IsValid) return View(todo);

        try
        {
            _db.Update(todo);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_db.Todos.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var todo = await _db.Todos.FirstOrDefaultAsync(m => m.Id == id);
        if (todo == null) return NotFound();

        return View(todo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo != null)
        {
            _db.Todos.Remove(todo);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return NotFound();

        todo.IsCompleted = !todo.IsCompleted;
        _db.Update(todo);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
