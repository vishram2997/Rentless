using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
namespace Rentless.Models

{
    public class AttributeType
    {

        [Key]
        [StringLength(10)]
        public string Code {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

       // [JsonConverter(typeof(StringEnumConverter))]
        public AttributeValueType ValueType {get; set;}

        public List<AttributeValue> values {get; set;} 
    }
}