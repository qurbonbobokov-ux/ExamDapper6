using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("timetable")]
public class TimeTableController : ControllerBase
{
    private readonly ITimeTableService _service;

    public TimeTableController(ITimeTableService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TimeTableDto dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TimeTableDto dto) => Ok(await _service.UpdateAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
}