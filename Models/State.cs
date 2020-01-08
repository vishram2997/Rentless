using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentless.Models

{
    public class State
    {
        [Key]
        [StringLength(10)]
        public string Code {get; set;}
        
        [StringLength(50)]
        public string Name {get; set;}

        [StringLength(10)]
        public string CountryId {get; set;}
        public Country Country {get; set;}
    }

}