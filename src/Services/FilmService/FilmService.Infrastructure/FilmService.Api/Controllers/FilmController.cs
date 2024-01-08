﻿using Ardalis.GuardClauses;
using FilmService.Application.Services.Dto;
using FilmService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmController : ControllerBase
{
    private readonly IFilmService _filmService;

    public FilmController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        Guard.Against.Default(id, nameof(id));

        var film = await _filmService.GetFilmByIdAsync(id);
        return Ok(film);
    }

    // todo: Нормально смапить ошибку если мы падаем по titlePK constraint + сделать пагинацию
    [HttpGet]
    public async Task<ActionResult> GetByTitle([FromQuery] string title)
    {
        Guard.Against.NullOrEmpty(title, nameof(title));

        var films = await _filmService.GetFilmsByTitleAsync(title);

        return Ok(films);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] CreateFilmRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var filmId = await _filmService.CreateFilmAsync(request);
        return Ok(filmId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateFilmRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        await _filmService.UpdateFilmAsync(request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        Guard.Against.Default(id, nameof(id));

        await _filmService.DeleteFilmAsync(id);
        return NoContent();
    }
}