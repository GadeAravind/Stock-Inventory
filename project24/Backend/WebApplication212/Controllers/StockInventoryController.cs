using WebApplication212.Models.stock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication212.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;



namespace WebApplication212.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockInventoryController : ControllerBase
    {
        private readonly StockDbContext _context;
        public StockInventoryController(StockDbContext context)
        {
            _context = context;
        }

        #region Purchase API
        [HttpGet("GetAllPurchase")]
        public ApiResponse<List<PurchaseData>> GetAllPurchase()
        {
            ApiResponse<List<PurchaseData>> _res = new ApiResponse<List<PurchaseData>>();
            try
            {
                var all = (from purchase in _context.StockPurchases
                           join product in _context.StockProducts on purchase.productId equals product.productId
                           select new PurchaseData
                           {
                               invoiceAmount = purchase.invoiceAmount,
                               invoiceNumber = purchase.invoiceNumber,
                               productId = purchase.productId,
                               purchaseDate = purchase.purchaseDate,
                               purchaseId = purchase.purchaseId,
                               quantity = purchase.quantity,
                               supplierName = purchase.supplierName,
                               productName = product.productName,
                           }).OrderByDescending(b => b.productId).ToList();
                _res.Result = true;
                _res.Data = all;
                return _res;
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        [HttpPost("CreateNewPurchase")]
        public ApiResponse<List<PurchaseData>> CreateNewResponse([FromBody] StockPurchase obj)
        {
            ApiResponse<List<PurchaseData>> _res = new ApiResponse<List<PurchaseData>>();
            if (!ModelState.IsValid)
            {
                _res.Result = false;
                _res.Message = "Validation Error";
                return _res;
            }
            try
            {
                var isExist = _context.StockPurchases.SingleOrDefault(b => b.invoiceNumber.ToLower() == obj.invoiceNumber.ToLower());
                if (isExist == null)
                {
                    _context.StockPurchases.Add(obj);
                    _context.SaveChanges();
                    var isStockExist = _context.StockStocks.SingleOrDefault(b => b.productId == obj.productId);
                    if (isStockExist == null)
                    {
                        StockStock _stock = new StockStock()
                        {
                            createdDate = DateTime.Now,
                            lastModifiedDate = DateTime.Now,
                            productId = obj.productId,
                            quantity = obj.quantity
                        };
                        _context.StockStocks.Add(_stock);
                        _context.SaveChanges();
                    }
                    else
                    {
                        isStockExist.quantity = isStockExist.quantity + obj.quantity;
                        isStockExist.lastModifiedDate = DateTime.Now;
                        _context.SaveChanges();
                    }
                    _res.Result = true;
                    _res.Message = "Purchase Entry Created Successfully";
                    return _res;
                }
                else
                {
                    _res.Result = false;
                    _res.Message = "Invoice No Already Exists";
                    return _res;
                }
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        #endregion

        #region Sale API
        [HttpGet("GetAllSale")]
        public ApiResponse<List<SaleData>> GetAllSale()
        {
            ApiResponse<List<SaleData>> _res = new ApiResponse<List<SaleData>>();
            try
            {
                var all = (from sale in _context.StockSales
                           join product in _context.StockProducts on sale.productId equals product.productId
                           select new SaleData
                           {
                               mobileNo = sale.mobileNo,
                               invoiceNumber = sale.invoiceNumber,
                               productId = sale.productId,
                               quantity = sale.quantity,
                               saleDate = sale.saleDate,
                               saleId = sale.saleId,
                               totalAmount = sale.totalAmount,
                               productName = product.productName,
                           }).OrderByDescending(b => b.saleId).ToList();
                _res.Result = true;
                _res.Data = all;
                return _res;
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        [HttpPost("CreateNewSale")]
        public ApiResponse<List<SaleData>> CreateNewSale([FromBody] StockSale obj)
        {
            ApiResponse<List<SaleData>> _res = new ApiResponse<List<SaleData>>();
            if (!ModelState.IsValid)
            {
                _res.Result = false;
                _res.Message = "Validation Error";
                return _res;
            }
            try
            {
                var isExist = _context.StockSales.SingleOrDefault(b => b.invoiceNumber.ToLower() == obj.invoiceNumber.ToLower());
                var isStockExist = _context.StockStocks.SingleOrDefault(b => b.productId == obj.productId);
                if (isExist == null && isStockExist != null)
                {
                    _context.StockSales.Add(obj);
                    _context.SaveChanges();
                    isStockExist.quantity = isStockExist.quantity - obj.quantity;
                    isStockExist.lastModifiedDate = DateTime.Now;
                    _context.SaveChanges();
                    _res.Result = true;
                    _res.Message = "Sale Entry Created Successfully";
                    return _res;
                }
                else
                {
                    _res.Result = false;
                    _res.Message = "Invoice No Already Exists";
                    return _res;
                }
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        #endregion

        #region Products API

        [HttpGet("GetAllProducts")]
        public ApiResponse<List<ProductData>> GetAllproducts()
        {
            ApiResponse<List<ProductData>> _res = new ApiResponse<List<ProductData>>();
            try
            {
                var all = _context.StockProducts.ToList();
                var dataList = all.Select(product => new ProductData
                {
                    productId = product.productId,
                    productName = product.productName,
                    CategoryName = product.CategoryName,
                    createdDate = product.createdDate,
                    price = product.price,
                    productDetails = product.productDetails,
                }).ToList();
                _res.Result = true;
                _res.Data = dataList;
                return _res;
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        [HttpPost("CreateNewProduct")]
        public async Task<ApiResponse<List<ProductData>>> CreateNewproduct([FromBody] StockProduct obj)
        {
            ApiResponse<List<ProductData>> _res = new ApiResponse<List<ProductData>>();
            if (!ModelState.IsValid)
            {
                _res.Result = false;
                _res.Message = "Validation Error";
                return _res;
            }
            try
            {
                var isExist = _context.StockProducts.SingleOrDefault(b => b.productName.ToLower() == obj.productName.ToLower());
                if (isExist == null)
                {
                    _context.StockProducts.Add(obj);
                    await _context.SaveChangesAsync();
                    _res.Result = true;
                    _res.Message = "Product Entry Created Successfully";
                    return _res;
                }
                else
                {
                    _res.Result = false;
                    _res.Message = "Product Already Exists";
                    return _res;
                }
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        #endregion

        #region Stock API

        [HttpGet("GetAllStock")]
        public ApiResponse<List<AllStock>> GetAllStock()
        {
            ApiResponse<List<AllStock>> _res = new ApiResponse<List<AllStock>>();
            try
            {
                var all = (from stock in _context.StockStocks
                           join product in _context.StockProducts on stock.productId equals product.productId
                           select new AllStock
                           {
                               createdDate = stock.createdDate,
                               lastModifiedDate = stock.lastModifiedDate,
                               productId = stock.productId,
                               quantity = stock.quantity,
                               productName = product.productName,
                               stockId = stock.stockId
                           }).OrderByDescending(b => b.stockId).ToList();
                _res.Result = true;
                _res.Data = all;
                return _res;
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        [HttpPost("CheckStockByProductId")]
        public ApiResponse<List<StockById>> CheckStockByProductId(int productId)
        {
            ApiResponse<List<StockById>> _res = new ApiResponse<List<StockById>>();
            try
            {
                var stock = _context.StockStocks.SingleOrDefault(b => b.productId == productId);
                if (stock != null)
                {
                    if (stock.quantity != 0)
                    {
                        _res.Result = true;
                        _res.Data = new List<StockById> { new StockById
                        {
                            stockId = stock.stockId,
                            productId = stock.productId,
                            quantity = stock.quantity,
                            createdDate = stock.createdDate,
                            lastModifiedDate = stock.lastModifiedDate,
                        }
                    };
                        _res.Message = "Stock Available";
                       
                    }
                    else
                    {
                        _res.Result = false;
                        _res.Message = "No Stock Available";
                    }
                }
                else
                {
                    _res.Result = false;
                    _res.Message = "No Stock Available";
                }
                return _res;
            }
            catch (Exception ex)
            {
                _res.Result = false;
                _res.Message = ex.Message;
                return _res;
            }
        }
        #endregion
    }
}
