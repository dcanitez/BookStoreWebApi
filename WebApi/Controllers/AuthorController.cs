using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(context, mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(context, mapper);
            query.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(query);
            var model = query.Handle();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorVM model)
        {

            CreateAuthorCommand command = new CreateAuthorCommand(context, mapper);
            command.Model = model;
            CreateAuthorCommandValidator validate = new CreateAuthorCommandValidator();
            validate.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult EditAuthor([FromBody] UpdateAuthorVM model, int id)
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(context);
            command.AuthorId = id;
            command.Model = model;
            UpdateAuthorCommandValidator validate = new UpdateAuthorCommandValidator();
            validate.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validate = new DeleteAuthorCommandValidator();
            validate.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

    }
}
