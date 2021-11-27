using System.Collections.Generic;

namespace WebApplication1.Data
{
    public class Country
    {
        public int Id { get; set; } 

        public string Name { get; set; }  
        
        public string ShortName { get; set; }    
        
        public virtual IList<Club> Clubs { get; set; }
    }
}
