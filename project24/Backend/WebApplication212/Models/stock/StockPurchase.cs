using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication212.Models.stock
{
    [Table("StockPurchase")]
    public class StockPurchase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int purchaseId { get; set; }
        public DateTime purchaseDate { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string supplierName { get; set; }
        public double invoiceAmount { get; set; }
        public string invoiceNumber { get; set; }
    }
}
