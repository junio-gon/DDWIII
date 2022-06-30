using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.API.Data;
using Application.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        // API-REST: GET(pegar) - POST(enviar) - PUT(atualizar) - DELETE(excluir)
        [HttpPost]
        public async Task<IActionResult> PostContatos([FromBody] Contatos contato )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SqlContext _context = new SqlContext();

            try
            {
                _context.Contato.Add(contato);

                await _context.SaveChangesAsync();

                return CreatedAtAction("PostContatos", new { id = contato.Id }, contato);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível cadastrar o Contato: " + e.Message.ToString());
            }
        }

        [HttpGet]
        public IEnumerable<Contatos> GetAllContatos([FromBody] Contatos contato)
        {
            SqlContext _context = new SqlContext();

            return _context.Contato;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneContatos(int id)
        {
            SqlContext _context = new SqlContext();

            try
            {
                var contato =  await _context.Contato.FindAsync(id);

                if (contato == null)
                {
                    return NotFound("Contato não encontrado");
                }

                return Ok(contato);
            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível cadastrar o Contato: " + e.Message.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContatos(int id, [FromBody] Contatos contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SqlContext _context = new SqlContext();

            try
            {
                _context.Entry(contato).State = EntityState.Modified;
                _context.Contato.Update(contato);
                await _context.SaveChangesAsync();
                return Ok(contato);

            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível cadastrar o Contato: " + e.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatos(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SqlContext _context = new SqlContext();

            try
            {
                var contato = await _context.Contato.FindAsync(id);
                if (contato == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                _context.Contato.Remove(contato);
                await _context.SaveChangesAsync();
                return Ok($"Usuário {contato.Nome} Removido com sucesso! ");

            }
            catch (Exception e)
            {
                return BadRequest("Não foi possível cadastrar o Contato: " + e.Message.ToString());
            }
        }
    }
}