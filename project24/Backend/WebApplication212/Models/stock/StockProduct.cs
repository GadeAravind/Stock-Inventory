using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication212.Models.stock
{
    [Table("StockProduct")]
    public class StockProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int productId { get; set; }
        public string productName { get; set; }
        public string CategoryName { get; set; }
        public DateTime createdDate { get; set; }
        public double price { get; set; }
        public string productDetails { get; set; }
    }
}
