using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rentless.Models
{
    public class Currency
    {
       
        [Key]
        [StringLength(10)]
        public string  Code {get; set;}
        [StringLength(50)]
        public string Name {get; set;}

    }
}