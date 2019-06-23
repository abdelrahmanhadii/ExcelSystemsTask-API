using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Contracts;
using DTOs;
using Logger.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class BooksController : ControllerBase
    {
        IBookService BookService;
        ILoggerService Logger;
        public BooksController(IBookService bookService, ILoggerService logger)
        {
            BookService = bookService;
            Logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            return await BookService.ReadAll().AsQueryable<Book>().ToListAsync();
        }
        [HttpPost("New")]
        public async Task<IActionResult> Create([FromBody]CreateBookDTO newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.FromResult(Ok(BookService.Create(newBook)));
                }
                else
                {
                    Logger.LogError("Model Not Valid!");
                    return BadRequest("Mode Not Valid");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.InnerException.ToString());
                return BadRequest("Failed To insert" + ex);
            }
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody]CreateBookDTO newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await Task.FromResult(Ok(BookService.Update(newBook)));
                }
                else
                {
                    Logger.LogError("Model Not Valid!");
                    return BadRequest("Mode Not Valid");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.InnerException.ToString());
                return BadRequest("Failed To insert" + ex);
            }
        }
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                return await Task.FromResult(Ok(BookService.Delete(id)));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.InnerException.ToString());
                return BadRequest("Failed To insert" + ex);
            }
        }
    }
}