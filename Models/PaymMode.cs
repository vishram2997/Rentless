using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Rentless.Models
{
    public class PaymMode
    {
        [StringLength(10)]
        [Key]
        public string Code {get; set;}

        [StringLength(50)]
        public string Desc {get; set;}

        public bool ReqAccountNo {get; set;}
        public bool ReqIFSC {get; set;}
        public bool ReqCVV {get; set;}
        public bool ReqCVV2 {get; set;}
        public bool ReqExpDate {get; set;}
        public bool ReqSwift {get; set;}
        public bool ReqIBAN {get; set;}
        public bool ReqRoutingNo {get; set;}
        public bool ReqBIC {get; set;}


       
    }
}