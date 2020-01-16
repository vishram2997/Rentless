using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class ProductAttribute
    {

        [Key]
        public int ProductCoode {get; set;}
        public Product Product {get; set;}

        [StringLength(10)]
        public string AttributeTypeCode {get; set;}
        public AttributeType AttributeType {get; set;} 

        [StringLength(50)]
        public string Value {get; set;}
        
    }
}