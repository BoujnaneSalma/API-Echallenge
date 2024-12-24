using GestionBiblio.Models;
using GestionBiblio.Repository;
using GestionBiblio.Service;
using GestionBiblio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly ILivreService livreService;

        public LivreController(ILivreService livreService)
        {
            this.livreService = livreService;
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<Livre>> GetAll()
        {
            var livres = livreService.GetAll();  // Récupère tous les livres de la liste
            return Ok(livres);
        }

        [HttpGet("{id}")]
        public ActionResult<Livre> GetById(int id)
        {
            try
            {
                var livre = livreService.GetById(id);
                return Ok(livre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpGet("titre/{titre}")]
        public ActionResult<Livre> GetByTitre(string titre)
        {
            try
            {
                var livre = livreService.GetByTitre(titre);
                return Ok(livre);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] AddBookVM livrevm)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    livreService.Create(livrevm);
                    return CreatedAtAction(nameof(GetById), new { id = livrevm.ISBN }, livrevm);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(new { Message = ex.Message });
                }
            }
            return UnprocessableEntity();
        }
            
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateBookVM updatevm)
        {
            if (ModelState.IsValid)
            {
            updatevm.Id = id;
            livreService.Update(updatevm);
            return NoContent();
            }
            return UnprocessableEntity();
           

        }

        // DELETE: api/livres/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var deletedBook = livreService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
