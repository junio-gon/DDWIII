using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        //Usa-se o get para obter dados da API
        [HttpGet]
        public ActionResult getAll()
        {
            return Ok(
                    new
                    {
                        id = 1234,
                        user = "Mario Bross"
                    }
                );
            //return BadRequest(new { error = "Houve uma problema ao processar a requisição"});
        }

        //usa-se Post para enviar dados à API
        [HttpPost]
        public ActionResult setUser([FromBody] Usuario dataRequest)
        {
            int id = dataRequest.id;
            string nome = dataRequest.nome;
            string email = dataRequest.email;
            Console.WriteLine($"Recebido os valores ==> id: {id}, nome: {nome}, email: {email}");
            return Ok();
        }
    }
    public class Usuario
    {
        public int id {get; set;}
        public string nome {get; set;}
        public string email { get; set; }
    }
}