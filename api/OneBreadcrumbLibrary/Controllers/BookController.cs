using Microsoft.AspNetCore.Mvc;
using OneBreadcrumbLibrary.Models;
using OneBreadcrumbLibrary.Services;
using System.Globalization;

namespace OneBreadcrumbLibrary.Controllers;


[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet]
    [Route("books")]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await _bookService.GetAllBooks();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _bookService.GetBookById(id);
        if (result.Status)
            return Ok(result);
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBook(id);
        if (result.Status)
            return Ok(result);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(string title, string owner, string isbn, string publishedDate)
    {

        var book = new Book
        {
            Title = title,
            Owner = owner,
            Isbn = isbn,
            PublishedDate = DateTime.TryParseExact(publishedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime) ? dateTime : DateTime.MinValue,
            Availability = true
        };

        var result = await _bookService.AddBook(book);
        if (result.Status)
            return Created();
        return Problem();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(string title, string owner, string isbn, string publishedDate)
    {
        var book = new Book
        {
            Title = title,
            Owner = owner,
            Isbn = isbn,
            PublishedDate = DateTime.TryParseExact(publishedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime) ? dateTime : DateTime.MinValue,
            Availability = true
        };

        var result = await _bookService.UpdateBook(book);
        if (result.Status)
            return Created();
        return Problem();
    }
}

