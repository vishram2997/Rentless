using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Rentless.Models
{
    public class CustPaymMode
    {
       

        [StringLength(10)]
        public string CustomerId {get; set;}
        public Customer Customer {get; set;}

        [StringLength(10)]
        public string PaymModeCode {get; set;}
        public PaymMode PaymMode {get; set;}

        [StringLength(50)]
        public string Name {get; set;}

        [StringLength(50)]
        public string AccountNo {get; set;}
        [StringLength(50)]
        public string IFSC {get; set;}
        [StringLength(50)]
        public string CVV {get; set;}
        [StringLength(50)]
        public string CVV2 {get; set;}

        [DataType(DataType.Date)]
        public DateTime ExpDate {get; set;}
        [StringLength(50)]
        public string Swift {get; set;}
        [StringLength(50)]
        public string IBAN {get; set;}
        [StringLength(50)]
        public string RoutingNo {get; set;}
        [StringLength(50)]
        public string BIC {get; set;}


       
    }
}