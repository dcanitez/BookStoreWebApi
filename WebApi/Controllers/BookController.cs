using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetails;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DbOperations;
using static WebApi.Application.BookOperations.Queries.GetBookDetails.GetBookByIdQuery;



namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailsQueryValidator validate = new GetBookDetailsQueryValidator();
            validate.ValidateAndThrow(query);
            BookDetailVM model = query.Handle();
            return Ok(model);

        }

        //POST
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookVM newBook)
        {
            #region Before CreateBookCommand.cs
            //CRUD işlemlerde yapılması gereken validations 
            // Gelen book elimizdeki bookListte mevcut mu kontrolü yapılmalı!
            // var book=_context.Books.SingleOrDefault(b=>b.Title==newBook.Title);
            // if(book is not null)
            //     return BadRequest();

            // _context.Books.Add(newBook);
            // _context.SaveChanges();
            // return Ok();   
            #endregion

            #region Before Error Management by CustomExceptionMiddleware
            //try
            //{
            // ValidationResult result = validator.Validate(command);
            // if (!result.IsValid)                
            //     foreach (ValidationFailure item in result.Errors)                    
            //         throw new Exception("Özellik "+ item.PropertyName+"- Error Message: "+ item.ErrorMessage);
            // else  
            //     command.Handle();

            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // } 
            #endregion


            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //PUT

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookVM updatedBook)
        {
            #region Before UpdateBookCommand.cs
            //gelen id li book listemde var mı kontrolü yapmalıyım.
            // var book = _context.Books.SingleOrDefault(b => b.Id == id);
            // if (book is null)
            //     return BadRequest();
            // //güncelleme yapacağız.
            // //gelen veri doldurulmuş ya da değiştirilmiş bir değer mi? kontrol etmeliyim.
            // book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            // book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.GenreId;
            // book.PublishedDate = updatedBook.PublishedDate != default ? updatedBook.PublishedDate : book.PublishedDate;
            // book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            // _context.SaveChanges();
            // return Ok();
            #endregion

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Model = updatedBook;
            command.BookId = id;
            UpdateBookCommandValidator validate = new UpdateBookCommandValidator();
            validate.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            #region Before DeleteBookQuery.cs
            //id validation yapılması gerekiyor.
            // var book = _context.Books.SingleOrDefault(b => b.Id == id);
            // if (book is null)
            //     return BadRequest();

            // _context.Books.Remove(book);
            // _context.SaveChanges();
            // return Ok();  
            #endregion

            DeleteBookQuery query = new DeleteBookQuery(_context);
            query.BookId = id;
            DeleteBookQueryValidator validator = new DeleteBookQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

    }
}