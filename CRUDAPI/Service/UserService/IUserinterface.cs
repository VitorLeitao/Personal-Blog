using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;

namespace CRUDAPI.Service.UserService
{
    public interface IUserinterface
    {
        Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel NovoUsuario);

        // Get ID by UserName -> Todas as rotas de texto Usam ID de usuario, no front vamos ter acesso apenas ao username, entao seria importante uma rota para opegar o id com base no userName
    }
}