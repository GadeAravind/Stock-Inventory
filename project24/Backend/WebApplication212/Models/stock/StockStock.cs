using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication212.Models.stock
{
    [Table("StockStockMaster")]
    public class StockStock
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int stockId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastModifiedDate { get; set; }

    }
}
