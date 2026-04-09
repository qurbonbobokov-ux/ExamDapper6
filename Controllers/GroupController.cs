using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("groups")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _service;
    private readonly ITimeTableService _timeTableService;

    public GroupsController(IGroupService service, ITimeTableService timeTableService)
    {
        _service = service;
        _timeTableService = timeTableService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(GroupDto dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GroupDto dto) => Ok(await _service.UpdateAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));

    [HttpPost("{groupId}/students/{studentId}")]
    public async Task<IActionResult> AddStudent(int groupId, int studentId)
        => Ok(await _service.AddStudentToGroupAsync(groupId, studentId));

    [HttpDelete("{groupId}/students/{studentId}")]
    public async Task<IActionResult> RemoveStudent(int groupId, int studentId)
        => Ok(await _service.RemoveStudentFromGroupAsync(groupId, studentId));

    [HttpGet("{groupId}/students")]
    public async Task<IActionResult> GetStudents(int groupId)
        => Ok(await _service.GetStudentsByGroupAsync(groupId));

    [HttpGet("{groupId}/timetable")]
    public async Task<IActionResult> GetTimetable(int groupId)
        => Ok(await _timeTableService.GetByGroupIdAsync(groupId));

    [HttpGet("{groupId}/progress")]
    public async Task<IActionResult> GetGroupProgress(int groupId)
        => Ok(await _service.GetGroupProgressAsync(groupId));

    [HttpGet("{groupId}/top-students")]
    public async Task<IActionResult> GetTopStudents(int groupId)
        => Ok(await _service.GetTopStudentsAsync(groupId));
}