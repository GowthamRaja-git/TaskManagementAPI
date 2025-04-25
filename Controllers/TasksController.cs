using Azure.Core;
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
    public async Task<IActionResult> CreateTask([FromBody] TaskItemRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // role checks(only admins can create tasks)
        if (!IsUserAuthorized(Role.Admin)) 
            return Forbid("Only Admins can create tasks.");

        var taskItem = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            AssignedToUserId = request.AssignedToUserId
        };

        _context.TaskItems.Add(taskItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTaskById), new { id = taskItem.Id }, taskItem);
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

        var taskResponse = new TaskResponse
        {
            TaskID = task.Id,
            Title = task.Title,
            Description = task.Description,
            AssignedToUserId = task.AssignedToUserId,
            UserDetails = task.AssignedToUser == null ? null : new UserDetails
            {
                UserID = task.AssignedToUser.Id,
                Username = task.AssignedToUser.Username,
                RoleID = task.AssignedToUser.Role
            }
        };

        return Ok(taskResponse);
    }

    // GET /tasks/user/{userId} → Get tasks assigned to a specific user
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetTasksByUserId(int userId)
    {
        //var tasks = await _context.TaskItems
        //    .Where(t => t.AssignedToUserId == userId)
        //    .Include(t => t.AssignedToUser)
        //    .ToListAsync();

        //return Ok(tasks);

        var userTasks = await _context.TaskItems
        .Where(t => t.AssignedToUserId == userId)
        .Select(t => new UserTask
        {
            TaskID = t.Id,
            Title = t.Title,
            Description = t.Description
        })
        .ToListAsync();

        return Ok(userTasks);
    }

    // Simulated basic role check
    private bool IsUserAuthorized(Role requiredRole)
    {
        var fakeUserRole = Role.Admin;
        return fakeUserRole == requiredRole;
    }
}
