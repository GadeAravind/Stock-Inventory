using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication212.Utilities;


namespace WebApplication212.Utilities
{
    public class ApiResponse<T>
    {
        public bool Result { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
    [SwaggerSchema(Required = new[] { "productId", "productName", "price", "categoryName" })]
    public class ProductData
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string CategoryName { get; set; }
        public DateTime createdDate { get; set; }
        public double price { get; set; }
        public string productDetails { get; set; }
        //public string productDetails { get; set; }
        //public int purchaseId { get; set; }
        //public DateTime purchaseDate { get; set; }
        //public int quantity { get; set; }
        //public string supplierName { get; set; }
        //public double invoiceAmount { get; set; }
        //public int saleId { get; set; }
        //public string invoiceNo { get; set; }
        //public string CustomerName { get; set; }
        //public string mobileNo { get; set; }
        //public DateTime saleDate { get; set; }
        //public int totalAmount { get; set; }
        //public int stockId { get; set; }
        //public DateTime lastModifiedDate { get; set; }
    }

    [SwaggerSchema(Required = new[] { "purchaseId", "purchaseDate", "productId", "quantity", "supplierName","invoiceAmount","invoiceNumber","productName" })]
    public class PurchaseData
    {
        public int purchaseId { get; set; }
        public DateTime purchaseDate {  get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string supplierName { get; set; }
        public string invoiceNumber { get; set; }
        public double invoiceAmount { get; set; }
        public string productName { get; set; }
    }
    [SwaggerSchema(Required = new[] { "mobileNo", "invoiceNumber", "productId", "quantity", "saleDate", "totalAmount", "productName" })]
    public class SaleData
    {
        public string mobileNo { get; set; }
        public string invoiceNumber { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public DateTime saleDate { get; set; }
        public int saleId {  get; set; }
        public int totalAmount { get; set; }
        public string productName { get; set; }
    }

    [SwaggerSchema(Required = new[] { "createdDate", "lastModifiedDate", "productId", "quantity", "productName","stockId" })]

    public class AllStock
    {
        public DateTime createdDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string productName { get; set; }
        public int stockId { get; set; }
    }

    [SwaggerSchema(Required = new[] { "stockId","productId", "quantity", "createdDate", "lastModifiedDate" })]

    public class StockById
    {
        public int stockId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
    }
}
