using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;
using CRUDAPI.Service.TextoService;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Esse é o URL da rota
    public class TextoController: ControllerBase
    {
        private readonly ITextoInterface _textoInterface;
        public TextoController(ITextoInterface textoInterface)
        {
            _textoInterface = textoInterface;
        }

        // Começando a instanciar as rotas feitas em FuncionarioService

        // Criar um novo texto
        [HttpPost] // (Name = "CreateText")
        public async Task<ActionResult<ServiceResponse<List<TextosModels>>>> CreateText(TextosModels NovoTexto)
        {
            return Ok(await _textoInterface.CreateText(NovoTexto));
        }

        // Pegar texto por titulo
        [HttpGet("{id}/{title}")] 
        public async Task<ActionResult<ServiceResponse<TextosModels>>> GetByTitle(int id, string title)
        {
            return Ok(await _textoInterface.GetByTitle(id, title));
        }

        // Textos por ID do usuario 
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TextosModels>>>> GetTextosUser(int id){
            return Ok(await _textoInterface.GetTextosUser(id));
        }

        // Att texto
        [HttpPut("{id}/{Titulo}")]
        public async Task<ActionResult<ServiceResponse<List<TextosModels>>>> UpdateTexto(TextosModels NovoTexto, string Titulo, int id){
            return Ok(await _textoInterface.UpdateTexto(NovoTexto, Titulo, id));
        }

        // Deletar Texto
        [HttpDelete("{id}/{title}")]
        public async Task<ActionResult<ServiceResponse<TextosModels>>> DeleteText(int id, string title){
            return Ok(await _textoInterface.DeleteText(id, title));
        }
    }

}