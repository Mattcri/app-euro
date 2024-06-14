using backend_api.DTOs;
using backend_api.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
  private readonly IAuthorService _authorService;

  public AuthorsController(IAuthorService authorService)
  {
    _authorService = authorService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
  {
    var authors = await _authorService.GetAuthorsAsync();
    return Ok(authors);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AuthorDto>> GetAuthor(Guid id)
  {
    var author = await _authorService.GetAuthorByIdAsync(id);
    
    if (author == null)
    {
      return NotFound();
    }

    return Ok(author);
  }

  [HttpPost]
  public async Task<ActionResult<AuthorDto>> PostAuthor(AuthorCreateDto authorDto)
  {
    var author = await _authorService.CreateAuthorAsync(authorDto);
    return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutAuthor(Guid id, AuthorUpdateDto authorDto)
  {
    var result = await _authorService.UpdateAuthorAsync(id, authorDto);
    
    if (!result)
    {
      return NotFound();
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAuthor(Guid id)
  {
    var result = await _authorService.DeleteAuthorAsync(id);
    if (!result)
    {
      return NotFound();
    }

    return NoContent();
  }

}
