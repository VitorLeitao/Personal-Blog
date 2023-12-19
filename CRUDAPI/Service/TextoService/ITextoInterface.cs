using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;

namespace CRUDAPI.Service.TextoService
{
    public interface ITextoInterface
    {
        Task<ServiceResponse<List<TextosModels>>> GetTextosUser(int id);
        Task<ServiceResponse<TextosModels>> GetByTitle(int id, string title);
        Task<ServiceResponse<List<TextosModels>>> CreateText(TextosModels NovoTexto);
        Task<ServiceResponse<List<TextosModels>>> UpdateTexto(TextosModels NovoTexto, string Titulo, int id);
        Task<ServiceResponse<List<TextosModels>>> DeleteText(int id, string title);
    }
}