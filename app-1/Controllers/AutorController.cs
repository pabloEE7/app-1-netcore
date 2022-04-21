using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_1.Contexto;
using app_1.Entidades;
using Microsoft.EntityFrameworkCore;
using app_1.Helpers;
namespace app_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/listado")]
        [HttpGet("listado")]
        [ServiceFilter(typeof(FiltroAction))]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return this.context.Autores.ToList();
        }
        /*[HttpGet]
        [ResponseCache(Duration = 15)]
        public ActionResult<string> Get()
        {
            return DateTime.Now.Second.ToString();
        }*/


        [HttpGet("{Id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int Id)
        {
            var result = this.context.Autores.Include(x => x.Libros).FirstOrDefault(x => x.Id == Id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new
            {
                id = autor.Id
            }, autor); //crea el registro y retorna los valores de ese registro a travez del get ObtenerAutor
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

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
        }
    }
}
