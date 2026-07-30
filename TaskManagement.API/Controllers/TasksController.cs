using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var task = _repository.GetById(id);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        task.Id = Guid.NewGuid();

        _repository.Add(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, TaskItem task)
    {
        var existingTask = _repository.GetById(id);

        if (existingTask == null)
            return NotFound();

        task.Id = id;
        _repository.Update(task);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var existingTask = _repository.GetById(id);

        if (existingTask == null)
            return NotFound();

        _repository.Delete(id);

        return NoContent();
    }
}