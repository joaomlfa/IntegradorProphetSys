using IntegradorSV.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.DataBase.Contexts
{
    public class IntegradorSuasVendasContext:DbContext
    {
        public IntegradorSuasVendasContext(DbContextOptions<IntegradorSuasVendasContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
