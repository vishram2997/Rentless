using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class DocuType
    {
        [Key]
        [StringLength(10)]
        public string Code {get; set;}
        [StringLength(50)]
        [DefaultValue("")]
        public string Desc {get; set;}
              
    }

}