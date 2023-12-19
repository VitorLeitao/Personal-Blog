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

        public async Task<ServiceResponse<List<UserModel>>> Deleteuser(int id){
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try{
                UserModel user = _context.Usuarios.FirstOrDefault(x=> x.UserId == id);
                if(user == null){
                    serviceResponse.Mensagem = "Usuario não encontrada";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
                
                // Vamps retornar todos os textos desse usuario que sobraram
                serviceResponse.Dados = _context.Usuarios.ToList();

            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<int>> GetUserIdByUserName(string userName){
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            try{
                UserModel user = _context.Usuarios.FirstOrDefault(x=> x.UserName == userName);
                if(user == null){
                    serviceResponse.Mensagem = "Nenhum usuario encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = user.UserId;
                serviceResponse.Mensagem = "Usuario encontrado com sucesso";
            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        // Atualizar usuario - senha ou user
        public async Task<ServiceResponse<List<UserModel>>> UpdateUser(UserModel NovoUsuario, int id){
            
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try{
                UserModel user = _context.Usuarios.FirstOrDefault(x=> x.UserId == id);
                if(user == null){
                    serviceResponse.Mensagem = "Usuario nao encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                foreach (var prop in typeof(UserModel).GetProperties()){
                // Não alterar nem a chave primaria nem a estrangeira
                    if (prop.Name != "UserId"){
                        var novoValor = prop.GetValue(NovoUsuario);
                        if (novoValor != ""){
                            prop.SetValue(user, novoValor);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                // Retornando o texto que foi alterado
                serviceResponse.Dados = _context.Usuarios.Where(x=> x.UserId == id).ToList();

            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}