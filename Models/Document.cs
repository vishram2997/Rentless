using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Rentless.Models

{
    public class Document
    {
        [Key]
        [StringLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        public string DocuTypeCode {get; set;}
        public DocuType DocuType {get; set;}
        [StringLength(50)]
        public string Desc {get; set;}

        [StringLength(10)]
        public string FileType {get; set;}

        public string FileBase64 {get; set;}   

         
    }

}