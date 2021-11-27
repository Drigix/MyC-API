using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ligue { get; set; }

        public double Rating { get; set; }  

        [ForeignKey(nameof(Country))]

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
