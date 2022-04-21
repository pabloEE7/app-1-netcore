using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_1.Contexto;
using app_1.Entidades;
using Microsoft.EntityFrameworkCore;

namespace app_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return this.context.Libros.Include(x => x.Autor).ToList();
        }

        [HttpGet("{Id}", Name = "GetLibro")]
        public ActionResult<Libro> Get(int Id)
        {
            var result = this.context.Libros.Include(x => x.Autor).FirstOrDefault( x => x.Id == Id);
            if(result != null)
            {
                return result;
            }
            return NotFound();
        }

        [HttpGet("{Id}/{name}", Name = "GetLibroName")] // para hacerlo opcional "{Id}/{name?}" o "{Id}/{name=""}"
        public ActionResult<Libro> Get(int Id, string name)
        {
            var result = this.context.Libros.Include( x => x.Autor).FirstOrDefault(x => x.Id == Id || x.Name == name);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        [HttpGet("primerRegistro")]
        public ActionResult<Libro> PrimerRegistro()
        {
            return this.context.Libros.FirstOrDefault();
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Libro>> GetPrimerAutor()
        //asincrónico
        {
            return await context.Libros.FirstOrDefaultAsync();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro Libro)
        {
            this.context.Add(Libro);
            this.context.SaveChanges();
            return new CreatedAtRouteResult(
                "GetLibro",
                new
                {
                    id = Libro.Id
                },
                Libro
            );
        }//crea el registro y retorna los valores de ese registro a travez del get ObtenerAutor
        [HttpPut("{id}")]
        public ActionResult Put(int Id, [FromBody] Libro Value)
        {
            if(Id != Value.Id)
            {
                BadRequest();
            }
            this.context.Entry(Value).State = EntityState.Modified;
            this.context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult<Libro> Delete(int Id)
        {
            var result = this.context.Libros.FirstOrDefault(x => x.Id == Id);
            if(result == null)
            {
                return NotFound();
            }

            this.context.Libros.Remove(result);
            return result;
        }

        /*


        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var resultado = context.Autores.FirstOrDefault(x => x.Id ==
            id);
            if (resultado == null)
            { return NotFound(); }
            context.Autores.Remove(resultado);
            context.SaveChanges();
            return resultado;
        }*/
    }
}
