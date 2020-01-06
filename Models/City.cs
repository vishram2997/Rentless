using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentless.Models

{
    public class City
    {
        [Key]
        [StringLength(10)]
        public string Code {get; set;}
        [StringLength(50)]
        public string Name {get; set;}

        [StringLength(10)]
        public string StateCode {get; set;}
        public State State {get; set;}

        [StringLength(10)]
        public string CountryCode {get; set;}
        public Country Country {get; set;}
    }

}