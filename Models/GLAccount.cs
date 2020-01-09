using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Rentless.Models
{
    public class GLAccount
    {
       
        [Key]
        [StringLength(10)]
        public string  No {get; set;}

        [StringLength(20)]
        public string  No2 {get; set;}

        [StringLength(50)]
        public string Name {get; set;}

        [StringLength(50)]
        public string SearchName {get; set;}

        public AccounType AccounType {get; set;}
        public IncomeBalance IncomeBalance {get; set;}
        public bool DirectPosting {get; set;}
        public bool Blocked {get; set;}

    }
}