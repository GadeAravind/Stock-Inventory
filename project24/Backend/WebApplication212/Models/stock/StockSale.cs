using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication212.Models.stock
{
    [Table("StockSale")]
    public class StockSale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int saleId { get; set; }
        public string invoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string mobileNo { get; set; }
        public DateTime saleDate { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public int totalAmount { get; set; }
    }
}
