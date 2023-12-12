using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.DataContext;
using CRUDAPI.Models;

namespace CRUDAPI.Service.UserService
{
    public class UserService: IUserinterface
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Começando rotas
        public async Task<ServiceResponse<List<UserModel>>> CreateUser(UserModel NovoUsuario)
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>(); // Vamos retornar a lista de todos os textos
            try{
                if(NovoUsuario == null){
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario Invalido!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Usuarios.Add(NovoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();
            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

    }
}