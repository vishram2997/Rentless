using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;
namespace Rentless.Models

{
    public class ProdImage
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        public string FileBase64 {get; set;}   

        public int ProductCode {get; set;}
        public Product Product {get; set;}

        
    }
}