using backend_api.DTOs;
using backend_api.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
  private readonly IBookService _bookService;

  public BooksController(IBookService bookService)
  {
    _bookService = bookService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
  {
    var books = await _bookService.GetBooksAsync();
    return Ok(books);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<BookDto>> GetBook(Guid id)
  {
    var book = await _bookService.GetBookByIdAsync(id);
    
    if (book == null)
    {
      return NotFound();
    }

    return Ok(book);
  }

  [HttpPost]
  public async Task<ActionResult<BookDto>> PostBook(BookCreateDto bookDto)
  {
    try
    {
      var book = await _bookService.CreateBookAsync(bookDto);
      return CreatedAtAction("GetBook", new { id = book.BookId }, book);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message + "El autor no se encuentra en los registros.");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutBook(Guid id, BookUpdateDto bookDto)
  {
    var result = await _bookService.UpdateBookAsync(id, bookDto);
    if (!result)
    {
      return NotFound();
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBook(Guid id)
  {
    var result = await _bookService.DeleteBookAsync(id);
    if (!result)
    {
      return NotFound();
    }

    return NoContent();
  }


}


