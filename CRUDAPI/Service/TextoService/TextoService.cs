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

        // Pegando todos os textos de um usuario
        public async Task<ServiceResponse<List<TextosModels>>> GetTextosUser(int id)
        {
            ServiceResponse<List<TextosModels>> serviceResponse = new ServiceResponse<List<TextosModels>>();
            try{
                List<TextosModels> textos = _context.Textos.Where(x=> x.UsuarioId == id).ToList(); // Fazendo consulta
                if(textos == null || textos.Count == 0){
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum texto localizado para o usuário.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = textos;

            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }       
            return serviceResponse;
        }

        // Pegando textos por titulo de um usuario especifico
        public async Task<ServiceResponse<TextosModels>> GetByTitle(int id, string title)
        {
            ServiceResponse<TextosModels> serviceResponse = new ServiceResponse<TextosModels>();
            try{
                TextosModels texto = _context.Textos.FirstOrDefault(x=> x.UsuarioId == id && x.Titulo == title);

                if(texto == null){
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum texto foi localizado!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = texto;

            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        // Criando um texto para um usuario
        public async Task<ServiceResponse<List<TextosModels>>> CreateText(TextosModels NovoTexto)
        {
            ServiceResponse<List<TextosModels>> serviceResponse = new ServiceResponse<List<TextosModels>>(); // Vamos retornar a lista de todos os textos
            try{
                // Verificando se o novoTexto é null ou se ja existe um testo com esse titulo para esse usuario
                if(NovoTexto == null || _context.Textos.FirstOrDefault(x=> x.UsuarioId == NovoTexto.UsuarioId && x.Titulo == NovoTexto.Titulo) != null){
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

        public async Task<ServiceResponse<List<TextosModels>>> UpdateTexto(TextosModels NovoTexto, string Titulo, int id)
        {
            ServiceResponse<List<TextosModels>> serviceResponse = new ServiceResponse<List<TextosModels>>();
            try{
                // Pegando o antigo texto
                TextosModels textoAntigo = _context.Textos.FirstOrDefault(x=> x.Titulo == Titulo && x.UsuarioId == id);
                if(textoAntigo == null){
                    serviceResponse.Mensagem = "nenhum texto com esse titulo";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                // Iterar sobre as propriedades de NovoTexto e atualizar o textoAntigo
                foreach (var prop in typeof(TextosModels).GetProperties()){
                // Não alterar nem a chave primaria nem a estrangeira
                if (prop.Name != "TextoId" && prop.Name != "UsuarioId")
                {
                    var novoValor = prop.GetValue(NovoTexto);
                    if (novoValor != "")
                    {
                        prop.SetValue(textoAntigo, novoValor);
                    }
                }
            }
                // Salvar as mudanças no banco de dados
                await _context.SaveChangesAsync();
                // Retornando o texto que foi alterado
                serviceResponse.Dados = _context.Textos.Where(x=> x.UsuarioId == id).ToList();
            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        // Deletar texto
        public async Task<ServiceResponse<List<TextosModels>>> DeleteText(int id, string title){
            ServiceResponse<List<TextosModels>> serviceResponse = new ServiceResponse<List<TextosModels>>(); 
            try{
                TextosModels texto = _context.Textos.FirstOrDefault(x=> x.Titulo == title && x.UsuarioId == id);

                if(texto == null){
                    serviceResponse.Mensagem = "nenhum texto com esse titulo";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Textos.Remove(texto);
                await _context.SaveChangesAsync();
                
                // Vamps retornar todos os textos desse usuario que sobraram
                serviceResponse.Dados = _context.Textos.Where(x=> x.UsuarioId == id).ToList();
            }catch(Exception ex){
                Console.WriteLine(ex);
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
