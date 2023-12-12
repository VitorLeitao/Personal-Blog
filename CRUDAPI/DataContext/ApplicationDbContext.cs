using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.DataContext
{
    public class ApplicationDbContext: DbContext
    {
        // Sempre se usa em conexão com banco
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Transformando nossa classe em uma tabela
        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<TextosModels> Textos { get; set; }
    }
}