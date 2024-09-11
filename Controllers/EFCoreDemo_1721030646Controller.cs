//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Runtime.InteropServices;
//using WebAPI_1721030646.Data;
//using WebAPI_1721030646.Models.EFC;

//namespace WebAPI_1721030646.Controllers
//{
//    [Route("[controller]/[action]")]
//    [ApiController]
//    public class EFCoreDemo_1721030646Controller : ControllerBase
//    {
//        private readonly EfcoreDemoContext _context;

//        public EFCoreDemo_1721030646Controller(EfcoreDemoContext context)
//        {
//            _context = context;
//        }

//        //1. Lấy tất cả các sản phẩm:
//        [HttpGet(Name = "Q01")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
//        {
//            return await _context.Products
//                .ToListAsync();
//        }

//        //2. Lấy danh sách tên của tất cả các sản phẩm
//        [HttpGet(Name = "Q02")]
//        public async Task<ActionResult<IEnumerable<string>>> GetAllProductsName()
//        {
//            return await _context.Products
//                .Select(x => x.ProductName)
//                .ToListAsync();
//        }

//        //3. Lấy danh sách tất cả các sản phẩm không bị ngừng bán (Discontinued = false):
//        [HttpGet(Name = "Q03")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsStillContinued()
//        {
//            return await _context.Products
//                .Where(x => x.Discontinued == false)
//                .ToListAsync();
//        }

//        //4. Lấy các sản phẩm có giá lớn hơn 20:
//        [HttpGet(Name = "Q04")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithUnitHigherThan20()
//        {
//            return await _context.Products
//                .Where(x => x.UnitPrice > 20)
//                .ToListAsync();
//        }

//        //5. Lấy danh sách các sản phẩm sắp xếp theo tên sản phẩm(ProductName) tăng dần:
//        [HttpGet(Name = "Q05")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductAsc()
//        {
//            return await _context.Products
//                .OrderBy(x => x.ProductName)
//                .ToListAsync();
//        }

//        //6. Đếm số lượng sản phẩm trong cơ sở dữ liệu:
//        [HttpGet(Name = "Q06")]
//        public async Task<ActionResult<int>> GetSumOfProducts()
//        {
//            return await _context.Products.CountAsync();
//        }

//        //7. Lấy danh sách tên các sản phẩm và tên công ty cung cấp tương ứng:
//        [HttpGet(Name = "Q07")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductNameAndSupplierName(int supplierId)
//        {
//            return await _context.Products
//                .Where(x => x.SupplierId == supplierId)
//                .ToListAsync();

//        }

//        //8. Lấy danh sách sản phẩm thuộc về một danh mục cụ thể:
//        [HttpGet(Name = "Q08")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBaseOnCategoryId(int categoryId)
//        {
//            return await _context.Products
//                .Where(x => x.CategoryId == categoryId)
//                .ToListAsync();
//        }

//        //9. Lấy tất cả các sản phẩm của một nhà cung cấp cụ thể:
//        [HttpGet(Name = "Q09")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBaseOnSupplierId(int supplierId)
//        {
//            return await _context.Products
//                .Where(x => x.SupplierId == supplierId)
//                .ToListAsync();
//        }

//        //10.Lấy danh sách các nhà cung cấp có sản phẩm:
//        [HttpGet(Name = "Q10")]
//        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliersHaveAtleastOneProduct()
//        {
//            return await _context.Suppliers
//                .Where(x => x.Products.Any())
//                .ToListAsync();
//        }

//        //Part 2
//        //11.Tìm sản phẩm có giá cao nhất:
//        [HttpGet(Name = "Q11")]
//        public async Task<ActionResult<Product>> GetHighestPriceProduct()
//        {
//            return await _context.Products
//                .OrderByDescending(x => x.UnitPrice)
//                .FirstOrDefaultAsync();
//        }
        
//        //12.Tìm sản phẩm có giá thấp nhất:
//        [HttpGet(Name = "Q12")]
//        public async Task<ActionResult<Product>> GetLowestPriceProduct()
//        {
//            return await _context.Products
//                .OrderBy(x => x.UnitPrice)
//                .FirstOrDefaultAsync();
//        }

//        //13.Lấy danh sách các sản phẩm với tên danh mục tương ứng:
//        [HttpGet(Name = "Q13")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategoryName()
//        {
//            return await _context.Products
//            .Select(x => new
//            {
//                x.ProductName,
//                x.Category.CategoryName
//            }
//            )
//            .ToListAsync();
//        }

//        //14.Lấy danh sách sản phẩm và nhà cung cấp tương ứng:
//        [HttpGet(Name = "Q14")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithSupplier()
//        {
//            return await _context.Products
//            .Select(x => new
//            {
//                x.ProductName,
//                x.Supplier.CompanyName
//            }
//            )
//            .ToListAsync();
//        }

//        //15.Lấy danh sách sản phẩm có giá trị trung bình của giá sản phẩm (UnitPrice):
//        [HttpGet(Name = "Q15")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsHavePriceEqualAverageAll()
//        {
//            var average = await _context.Products.AverageAsync(x => x.UnitPrice);
//            return await _context.Products
//                .Where(x => x.UnitPrice == average)
//                .ToListAsync();
//        }

//        //16.Tính tổng số sản phẩm trong mỗi danh mục:
//        [HttpGet(Name = "Q16")]
//        public async Task<ActionResult<IEnumerable<object>>> GetSumProductsCountPerCategory()
//        {
//            return await _context.Products
//                .GroupBy(x => x.Category.CategoryName)
//                .Select(y => new { Category = y.Key, ProductCount = y.Count() })
//                .ToListAsync();
//        }

//        //17.Lấy danh sách các danh mục và tổng số lượng sản phẩm trong mỗi danh mục:
//        [HttpGet(Name = "Q17")]
//        public async Task<ActionResult<IEnumerable<object>>> GetCategoriesAndSumProductsCountPerCategory()
//        {
//            return await _context.Categories
//                .Select(x => new
//                {
//                    x.CategoryName,
//                    ProductCount = x.Products.Count
//                }
//                )
//                .ToListAsync();
//        }

//        //18.Lấy danh sách các nhà cung cấp không có sản phẩm:
//        [HttpGet(Name = "Q18")]
//        public async Task<ActionResult<IEnumerable<Supplier>>> GetSupplierHaveNoneProducts()
//        {
//            return await _context.Suppliers
//                .Where(x => !x.Products.Any())
//                .ToListAsync();
//        }

//        //19.Lấy danh sách các sản phẩm có giá lớn hơn giá trung bình của tất cả các sản phẩm:
//        [HttpGet(Name = "Q19")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsHavePriceHigherThanAveragePriceAllProducts()
//        {
//            var average = await _context.Products.AverageAsync(x => x.UnitPrice);
//            return await _context.Products
//                .Where(x => x.UnitPrice > average)
//                .ToListAsync();
//        }

//        //20.Lấy danh sách tên sản phẩm cùng với danh mục và nhà cung cấp:
//        [HttpGet(Name = "Q20")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithCategoryAndSupplierNames()
//        {
//            return await _context.Products
//                .Select(x => new
//                {
//                    x.ProductName,
//                    x.Category.CategoryName,
//                    x.Supplier.CompanyName
//                }
//                )
//                .ToListAsync();
//        }

//        //Part 3
//        //21.Lấy danh sách các sản phẩm bị ngừng bán nhưng có giá lớn hơn 50:
//        [HttpGet(Name = "Q21")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetDiscontinuedProductsHavePriceHigherThan50()
//        {
//            return await _context.Products
//                .Where(x => x.Discontinued && x.UnitPrice > 50)
//                .ToListAsync();
//        }

//        //22.Tìm danh mục có nhiều sản phẩm nhất:
//        [HttpGet(Name = "Q22")]
//        public async Task<ActionResult<object>> GetCategoryHaveMostProducts()
//        {
//            return await _context.Products
//                .GroupBy(x => x.Category.CategoryName)
//                .OrderByDescending(y => y.Count())
//                .Select(y => new 
//                    { Category = y.Key, ProductCount = y.Count() }
//                )
//                .FirstOrDefaultAsync();
//        }

//        //23.Tìm nhà cung cấp cung cấp nhiều sản phẩm nhất:
//        [HttpGet(Name = "Q23")]
//        public async Task<ActionResult<object>> GetSupplierProvideMostProducts()
//        {
//            return await _context.Products
//                .GroupBy(x => x.Supplier.CompanyName)
//                .OrderByDescending(y => y.Count())
//                .Select(y => new 
//                    { Supplier = y.Key, ProductCount = y.Count() }
//                )
//                .FirstOrDefaultAsync();
//        }

//        //24.Lấy danh sách sản phẩm với số lượng sản phẩm của từng nhà cung cấp:
//        [HttpGet(Name = "Q24")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithProductCountPerSupplier()
//        {
//            return await _context.Products
//                .GroupBy(x => x.Supplier.CompanyName)
//                .Select(y => new 
//                    { Supplier = y.Key, ProductCount = y.Count(), Products = y.Select(x => x.ProductName).ToList() }
//                )
//                .ToListAsync();
//        }

//        //25.Lấy danh sách các sản phẩm cùng với số lượng sản phẩm trong danh mục tương ứng:
//        [HttpGet(Name = "Q25")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsWithProductCountPerCategory()
//        {
//            return await _context.Products
//                .GroupBy(x => x.Category.CategoryName)
//                .Select(y => new 
//                    { Category = y.Key, ProductCount = y.Count(), Products = y.Select(x => x.ProductName).ToList() }
//                )
//                .ToListAsync();
//        }

//        //26.Tìm tất cả các nhà cung cấp có sản phẩm với giá trung bình thấp hơn 30:
//        [HttpGet(Name = "Q26")]
//        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliersHaveProductAveratePriceLowerThan30()
//        {
//            return await _context.Suppliers
//                .Where(s => s.Products.Any(p => p.UnitPrice < 30))
//                .ToListAsync();
//        }

//        //27.Lấy danh sách sản phẩm với tên danh mục và tên nhà cung cấp, sắp xếp theo giá sản phẩm giảm dần:
//        [HttpGet(Name = "Q27")]
//        public async Task<ActionResult<IEnumerable<object>>> GetProductsHaveeCategoryNameAndSupplierNameSortByDsc()
//        {
//            return await _context.Products
//                .OrderByDescending(x => x.UnitPrice)
//                .Select(x => new 
//                    { x.ProductName, CategoryName = x.Category.CategoryName, SupplierName = x.Supplier.CompanyName }
//                )
//                .ToListAsync();
//        }

//        //28.Lấy danh sách tất cả các sản phẩm thuộc về danh mục có số lượng sản phẩm nhiều hơn 5:
//        [HttpGet(Name = "Q28")]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProductsFromCategoryHaveProductCountMoreThan5()
//        {
//            return await _context.Products
//                .Where(x => x.Category.Products.Count > 5)
//                .ToListAsync();
//        }

//        //29.Tính tổng giá trị của tất cả các sản phẩm thuộc một danh mục cụ thể:
//        [HttpGet(Name = "Q29")]
//        public async Task<ActionResult<decimal>> GetSumProcutsFromCategory(int categoryId)
//        {
//            return await _context.Products
//                .Where(x => x.CategoryId == categoryId)
//                .SumAsync(x => x.UnitPrice);
//        }

//        //30.Tìm nhà cung cấp có giá trung bình sản phẩm thấp nhất:
//        [HttpGet(Name = "Q30")]
//        public async Task<ActionResult<object>> GetSupplierHaveLowestAveragePriceProduct()
//        {
//            return await _context.Suppliers
//                .OrderBy(x => x.Products.Average(y => y.UnitPrice))
//                .Select(x => new { x.CompanyName, AveragePrice = x.Products.Average(y => y.UnitPrice) })
//                .FirstOrDefaultAsync();
//        }
//    }
//}