using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(StudentDto dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, StudentDto dto) => Ok(await _service.UpdateAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));

    [HttpGet("{id}/progress")]
    public async Task<IActionResult> GetProgress(int id) => Ok(await _service.GetStudentProgressAsync(id));

    [HttpGet("{id}/average-grade")]
    public async Task<IActionResult> GetAverageGrade(int id) => Ok(await _service.GetAverageGradeAsync(id));

    [HttpGet("{id}/attendance")]
    public async Task<IActionResult> GetAttendance(int id) => Ok(await _service.GetAttendanceAsync(id));
}