using LibraryManagementApp.Application.Books.Commands.CreateBook;
using LibraryManagementApp.Application.Books.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _sender.Send(new GetAllBooksQuery());
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookCommand command)
    {
        var bookId = await _sender.Send(command);
        return Ok(bookId);
    }
}