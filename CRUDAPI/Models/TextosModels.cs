using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class TextosModels
    {
        [Key]
        public int TextoId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        [ForeignKey("UserId")]
        public int UsuarioId { get; set; }
    }
}