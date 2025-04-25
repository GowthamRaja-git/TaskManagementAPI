using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using Task = TaskManagementAPI.Models.TaskItem;

namespace TaskManagementAPI.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // POST /tasks → Create a new task
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // role checks(only admins can create tasks)
        if (!IsUserAuthorized(Role.Admin)) 
            return Forbid("Only Admins can create tasks.");

        _context.TaskItems.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    // GET /tasks/{id} → Get task details by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        //var task = await _context.TaskItems
        //    .Include(t => t.AssignedToUserId)
        //    .FirstOrDefaultAsync(t => t.Id == id);

        var task = await _context.TaskItems
    .Include(t => t.AssignedToUser)
    .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null) return NotFound();
        return Ok(task);
    }

    // GET /tasks/user/{userId} → Get tasks assigned to a specific user
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetTasksByUserId(int userId)
    {
        var tasks = await _context.TaskItems
            .Where(t => t.AssignedToUserId == userId)
            .Include(t => t.AssignedToUser)
            .ToListAsync();

        return Ok(tasks);
    }

    // Simulated basic role check (replace with real JWT claims check later)
    private bool IsUserAuthorized(Role requiredRole)
    {
        // For now, just simulate admin check
        var fakeUserRole = Role.Admin; // Change this to test as Admin/User
        return fakeUserRole == requiredRole;
    }
}
