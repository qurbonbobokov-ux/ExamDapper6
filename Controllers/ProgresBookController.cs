using Domain.DTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("progress")]
public class ProgressController : ControllerBase
{
    private readonly IProgressService _service;

    public ProgressController(IProgressService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProgressBookDto dto) => Ok(await _service.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProgressBookDto dto) => Ok(await _service.UpdateAsync(id, dto));
}