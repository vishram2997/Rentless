using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;
namespace Rentless.Models

{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        [StringLength(50)]
        public string Desc2 {get; set;}


        public List<ProductAttribute> ProductAttributes {get; set;}
        public List<ProdImage> Images {get; set;}

        

        
    }
}