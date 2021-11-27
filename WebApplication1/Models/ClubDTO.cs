using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class ClubDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:60,ErrorMessage ="Club name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Ligue name is too long")]
        public string Ligue { get; set; }

        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }

    public class CreateClubDTO
    {

        [Required]
        [StringLength(maximumLength: 60, ErrorMessage = "Club name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Ligue name is too long")]
        public string Ligue { get; set; }

        [Required]
        [Range(1,10)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }

        
    }
}
