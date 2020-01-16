using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class ProductDocument
    {

        [Key,  Column(Order = 0)]
        public int ProductCoode {get; set;}
        public Product Product {get; set;}


        [Key,  Column(Order = 1)]
        public int DocumentId {get; set;}
        public Document Document {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        public VerificationStatus VerificationStatus {get; set;}          


    }
}