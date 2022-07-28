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



        //[HttpGet]
        //public IActionResult GetBook()
        //{
        //    var values = _context.Books.ToList();
        //    return Ok(values);
        //}

        //GetAll
        [HttpGet("all")]
        public async Task<object> GetAll()
        {
            var values = await _unitOfWork.BookRepository.GetAllList();

            return values.ToList();
        }

    }
}
