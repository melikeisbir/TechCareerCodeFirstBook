using System.ComponentModel.DataAnnotations;

namespace TechCareerCodeFirstBook.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KitapAdi { get; set; }

        [Required]
        public double Fiyati { get; set; }

        [Required]
        public int SayfaSayisi { get; set; }
    }
}
