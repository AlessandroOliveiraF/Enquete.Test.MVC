using System.ComponentModel.DataAnnotations;

namespace Enquete.Test.MVC.Models
{
    public class RespostaEnquete
    {
        public RespostaEnquete()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public EnqueteTeste Enquete { get; set; }

        public override string ToString()
        {
            return String.Format($"Nome: {Nome} Email: {Email}");
        }
    }
}
