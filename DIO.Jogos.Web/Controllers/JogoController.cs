using DIO.Jogos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Jogos.Web.Controllers
{
    [Route("[controller]")]
    public class JogoController : Controller
    {
        private readonly IRepositorio<Jogo> _repositorioJogo;

        public JogoController(IRepositorio<Jogo> reposotirioJogo)
        {
            _repositorioJogo = reposotirioJogo;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorioJogo.Lista().Select(s => new JogoModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] JogoModel model)
        {
            _repositorioJogo.Atualiza(id, model.ToJogo());
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Exclui(int id)
        {
            _repositorioJogo.Exclui(id);
            return NoContent();
        }

        [HttpPost("")]        
        public IActionResult Insere([FromBody] JogoModel model)
        {
            model.Id = _repositorioJogo.ProximoId();

            Jogo jogo = model.ToJogo();            

            _repositorioJogo.Insere(jogo);
            return Created("", jogo);
        }
        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new JogoModel (_repositorioJogo.Lista().FirstOrDefault(s => s.Id == id)));
        }
    }
}
