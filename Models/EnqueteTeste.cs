using System.ComponentModel.DataAnnotations;

namespace Enquete.Test.MVC.Models
{
    public class EnqueteTeste
    {
        public EnqueteTeste()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public virtual List<Opcao> Opcoes { get; set; } = new List<Opcao>();

        
    }
}
