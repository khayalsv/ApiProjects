 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoApi.Data;
using RepoApi.Data.Entities;
using RepoApi.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //GetAll
        [HttpGet("all")]
        public async Task<object> GetAll()
        {
            var values = await _unitOfWork.BookRepository.GetAllList();

            return values.ToList();
        }


        //Get
        [HttpGet("book/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var book = await _unitOfWork.BookRepository.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        //Create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.Commit();

            return Created($"/api/book/book/{book.Id}", book);
        }


        //Update
        [HttpPut("update")]
        public async Task<Book> Update(int id, Book newBook)
        {
            var book = await _unitOfWork.BookRepository.Find(id);

            book.Name = newBook.Name;

            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.Commit();

            return book;
        }


        //Delete
        [HttpDelete("delete")]
        public async Task<Book> Delete(int id)
        {
            var book = await _unitOfWork.BookRepository.Find(id);


            await _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.Commit();

            return book;
        }

    }
}
