using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetApiRestExample.Data;
using NetApiRestExample.Models;

namespace NetApiRestExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly NetApiRestDbContext _context;

        public BooksController(NetApiRestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Book>> Listar()
        {
            return await _context.Book.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> BuscarPorId(decimal id)
        {
            var retorno = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);

            if (retorno != null)
                return retorno;
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Guardar(Book c)
        {
            try
            {
                await _context.Book.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Id = await _context.Book.MaxAsync(u => u.Id);

                return c;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Actualizar(Book b)
        {
            if (b == null || b.Id == 0)
                return BadRequest("Faltan datos");

            Book book = await _context.Book.FirstOrDefaultAsync(x => x.Id == b.Id);

            if (book == null)
                return NotFound();

            try
            {
                book.Title = b.Title;
                _context.Book.Update(book);
                await _context.SaveChangesAsync();

                return book;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(decimal id)
        {
            Book book = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
                return NotFound();

            try
            {
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Se encontró un error");
            }
        }
    }
}
