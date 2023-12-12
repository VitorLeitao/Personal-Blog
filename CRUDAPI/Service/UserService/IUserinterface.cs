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
    }
}