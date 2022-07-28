using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoApi.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;

        //public LibraryController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //[HttpGet("all")]
        //public async Task<object> GetAll()
        //{
        //    var values = await _unitOfWork.LibraryRepository.GetAllList();

        //    return values.ToList();
        //}
    }
}
