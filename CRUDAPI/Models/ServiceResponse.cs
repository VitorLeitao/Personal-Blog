using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class ServiceResponse<T> // Significa que vamos receber dados genericos(nao so funcionarios)
    {
        public T? Dados { get; set; } // Pode ser NULO(T?)
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}