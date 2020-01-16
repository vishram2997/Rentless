using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class Product
    {

        [Key]
        [Identity]
        public int Code {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        [StringLength(50)]
        public string Desc2 {get; set;}

        
    }
}