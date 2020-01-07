using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rentless.Models

{
    public class PostalCode
    {
        [Key]
        [StringLength(10)]
        public string Code {get; set;}
        [StringLength(50)]
        public string Desc {get; set;}

        
        [StringLength(10)]
        public string CityCode {get; set;}
        public City City {get; set;}


        [StringLength(10)]
        public string StateCode {get; set;}
        public State State {get; set;}

        [StringLength(10)]
        public string CountryCode {get; set;}
        public Country Country {get; set;}
    }

}