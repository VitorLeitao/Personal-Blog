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
        [HttpPost] // (Name = "CreateText")
        public async Task<ActionResult<ServiceResponse<List<TextosModels>>>> CreateText(TextosModels NovoTexto)
        {
            return Ok(await _textoInterface.CreateText(NovoTexto));
        }

    }

}