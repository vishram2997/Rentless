using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class AttributeValue
    {

        [Key, Column(Order = 0)]
        
        [StringLength(10)]
        public string AttributeTypeCode {get; set;}
        public AttributeType AttributeType {get; set;} 

        [Key, Column(Order = 1)]
        [StringLength(50)]
        public string Value {get; set;}
        
    }
}