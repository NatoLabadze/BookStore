using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Interfaces.Repositories;
using Core.Application.Paging;
using Core.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;

        public BookController(IMapper mapper, IBookRepository bookRepository)
        {
            this.mapper = mapper;
            this.bookRepository = bookRepository;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get([FromQuery] PageRequest pageRequest)
        {
            var result = bookRepository.GetBooks(pageRequest, out PageResponse pageResponse);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageResponse));

            return Ok(result);


        }


        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] AddBookDto addBookDTO)
        {

            var book = mapper.Map<Book>(addBookDTO);
            bookRepository.Add(book);
            return Ok();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = mapper.Map<Book>(updateBookDto);
            bookRepository.Update(id, book);
            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            bookRepository.Delete(id);
        }
    }
}
