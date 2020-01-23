using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class City
    {
        [StringLength(30)]
        public string Code {get; set;}
        [StringLength(50)]
        [DefaultValue("")]
        public string Name {get; set;}
        
        [StringLength(10)]
        [DefaultValue("")]
        public string StateCode{get; set;}
        public State State {get; set;}

        [StringLength(10)]
        [DefaultValue("")]
        public string CountryId{get; set;}
        public Country Country {get; set;}
    }

}