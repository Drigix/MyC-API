using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public  IList<ClubDTO> Clubs { get; set; }

        [Required]
        [StringLength(maximumLength:50, ErrorMessage ="Country name is too long")]

        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Short Country name is too long")]

        public string ShortName { get; set; }
    }

    public class CreateCountryDTO
    {
        
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country name is too long")]

        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Short Country name is too long")]

        public string ShortName { get; set; }
    }
}
