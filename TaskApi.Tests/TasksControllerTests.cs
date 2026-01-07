using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;
using TaskStatus = TaskApi.Models.TaskStatus;
using Xunit;
using TaskApi.Controllers;

namespace TaskApi.Tests;

public class TasksControllerTests
{
    private readonly AppDbContext _context;
    private readonly TasksController _controller;

    public TasksControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new AppDbContext(options);
        _controller = new TasksController(_context);
    }

    [Fact]
    public async Task CreateTask_ReturnsCreatedTask()
    {
        // Arrange
        var dto = new CreateTaskDto
        {
            Title = "Test Task",
            Description = "This is a test task.",
            DueDate = DateTime.UtcNow.AddDays(1)
        };

        // Act
        var result = await _controller.Create(dto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdTask = Assert.IsType<TodoTask>(createdAtActionResult.Value);

        Assert.Equal(dto.Title, createdTask.Title);
        Assert.Equal(dto.Description, createdTask.Description);
        Assert.Equal(dto.DueDate, createdTask.DueDate);
        Assert.Equal(TaskStatus.Pending, createdTask.Status);
    }

    [Fact]
    public async Task GetAllTasks_ReturnsAllTasks()
    {
        _context.Tasks.Add(new TodoTask
        {
           Title = "Task 1",
           DueDate = DateTime.UtcNow.AddDays(1) 
        });

        await _context.SaveChangesAsync();

        var result = await _controller.GetAll();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var tasks = Assert.IsType<List<TodoTask>>(okResult.Value);

        Assert.Single(tasks);
    }

    [Fact]
    public async Task UpdateTaskStatus_UpdatesTaskStatus()
    {
        var task = new TodoTask
        {
            Title = "Task to Update",
            DueDate = DateTime.UtcNow.AddDays(1)
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        var dto = new UpdateTaskStatusDto
        {
            Status = TaskStatus.Completed
        };

        var result = await _controller.UpdateStatus(task.Id, dto);
        Assert.IsType<NoContentResult>(result);

        var updatedTask = await _context.Tasks.FindAsync(task.Id);
        Assert.Equal(TaskStatus.Completed, updatedTask.Status);
    }

    [Fact]
    public async Task DeleteTask_RemovesTask()
    {
        var task = new TodoTask
        {
            Title = "Task to Delete",
            DueDate = DateTime.UtcNow.AddDays(1)
        };
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        var result = await _controller.Delete(task.Id);
        Assert.IsType<NoContentResult>(result);

        var deletedTask = await _context.Tasks.FindAsync(task.Id);
        Assert.Null(deletedTask);
    }
}