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
        Task<ServiceResponse<List<UserModel>>> Deleteuser(int id);
        Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel NovoUsuario, int id);
        // Get ID by UserName -> Todas as rotas de texto Usam ID de usuario, no front vamos ter acesso apenas ao username, entao seria importante uma rota para opegar o id com base no userName
        Task<ServiceResponse<int>> GetUserIdByUserName(string userName);
    }
}