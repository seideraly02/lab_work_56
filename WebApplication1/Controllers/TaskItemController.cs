using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

public class TasksController : Controller
{
    private static List<TaskItem> tasks = new List<TaskItem>();

    public IActionResult Index()
    {
        return View(tasks);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        task.Id = tasks.Count + 1;
        tasks.Add(task);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    public IActionResult Delete(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        if (task.IsOpen)
        {
            ModelState.AddModelError(string.Empty, "Невозможно удалить открытую задачу.");
            return View(task);
        }
        tasks.Remove(task);
        return RedirectToAction("Index");
    }

    public IActionResult Close(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        task.IsOpen = false;
        return RedirectToAction("Index");
    }
}