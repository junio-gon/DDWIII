using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.API.Data;
using Application.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}