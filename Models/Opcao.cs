using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enquete.Test.MVC.Models
{
    public class Opcao
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EnqueteTeste")]
        public int EnqueteId { get; set; }

        [Required]
        public string OpcaoDescricao { get; set; }

        public virtual EnqueteTeste Enquete { get; private set; }

        public Opcao()
        {

        }
    }
}
