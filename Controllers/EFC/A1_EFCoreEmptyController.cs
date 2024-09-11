using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.Data;
using WebAPI_1721030646.Models.EFC;
using WebAPI_1721030646.DTO.EFC;

namespace WebAPI_1721030646.Controllers.EFC
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class A1_EFCoreEmptyController : ControllerBase
    {
        private readonly EfcoreDemoContext _context;
        private readonly IMapper _mapper;
        public A1_EFCoreEmptyController(EfcoreDemoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var Product = await _context.Products
                .Select(Product => _mapper.Map<ProductDTO>(Product))
                .ToListAsync();
            return Product;
        }

        [HttpGet(Name = "GetProductByName")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductByName(string productname)
        {
            var Product = await _context.Products
                .Where(Product => Product.ProductName == productname)
                .Select(Product => _mapper.Map<ProductDTO>(Product))
                .ToListAsync();
            return Product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddNewProduct(ProductDTO Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var NewProduct = _mapper.Map<Product>(Product);
            _context.Products.Add(NewProduct);

            await _context.SaveChangesAsync();

            return NewProduct;
        }

        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(int ProductId, ProductDTO Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdateProduct = _mapper.Map<Product>(Product);
            UpdateProduct.ProductId = ProductId;

            _context.Products.Update(UpdateProduct);

            await _context.SaveChangesAsync();

            return UpdateProduct;
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(int ProductId)
        {
            var Product = await _context.Products.FindAsync(ProductId);
            if (Product is null)
            {
                ModelState.AddModelError("ProductId", "Invalid ProductId");
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return Product;
        }
    }
}

