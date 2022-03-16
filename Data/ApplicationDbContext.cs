using Enquete.Test.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enquete.Test.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EnqueteTeste> Enquetes { get; set; }
        public virtual DbSet<Opcao> Opcoes { get; set; }
        public virtual DbSet<RespostaEnquete> RespostasEnquete { get; set; }
    }
}