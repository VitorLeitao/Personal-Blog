using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;
using CRUDAPI.Service.TextoService;
using CRUDAPI.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("Users")] // Esse é o URL da rota
    public class UserController: ControllerBase
    {
        private readonly IUserinterface _userInterface;
        public UserController(IUserinterface userInterface)
        {
            _userInterface = userInterface;
        }

        // Começando rotas
        // Começando a instanciar as rotas feitas em FuncionarioService
        [HttpPost] // (Name = "CreateUser")
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> CreateUser(UserModel NovoUsuario)
        {
            return Ok(await _userInterface.CreateUser(NovoUsuario));
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ServiceResponse<int>>> GetUserIdByUserName(string userName){
            return Ok(await _userInterface.GetUserIdByUserName(userName));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<UserModel>>>> UpdateUser(UserModel NovoUsuario, int id){
            return Ok(await _userInterface.UpdateUser(NovoUsuario, id));
        }
    }
}