using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.DataContext;
using CRUDAPI.Models;

namespace CRUDAPI.Service.TextoService
{
    public class TextoService : ITextoInterface
    {
        private readonly ApplicationDbContext _context;

        public TextoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TextosModels>>> GetTextosUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<TextosModels>>> GetByTitle(int id, string title)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<TextosModels>>> CreateText(TextosModels NovoTexto)
        {
            ServiceResponse<List<TextosModels>> serviceResponse = new ServiceResponse<List<TextosModels>>(); // Vamos retornar a lista de todos os textos
            try{
                if(NovoTexto == null){
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Texto Invalido!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Textos.Add(NovoTexto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Textos.ToList();
            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TextosModels>>> UpdateTexto(TextosModels NovoTexto)
        {
            throw new NotImplementedException();
        }
    }
}
