using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rentless.Models
{
    public class Country
    {
        [StringLength(10)]
        [Key]
        public string Id {get; set;}

        [StringLength(50)]
        public string Name {get; set;}

        [StringLength(10)]
        public string CurrencyCode {get; set;}
        public Currency Currency {get; set;}
    }
}