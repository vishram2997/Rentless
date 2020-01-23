using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class ProductDocument
    {

        public int ProductCode {get; set;}
        public Product Product {get; set;}


        public int DocumentId {get; set;}
        public Document Document {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        public VerificationStatus VerificationStatus {get; set;}          


    }
}