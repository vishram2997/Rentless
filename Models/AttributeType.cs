using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class AttributeType
    {

        [Key]
        [StringLength(10)]
        public string Code {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        public AttributeValueType ValueType {get; set;}
    }
}