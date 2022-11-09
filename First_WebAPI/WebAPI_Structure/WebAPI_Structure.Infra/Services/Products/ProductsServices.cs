using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Core.Models;

namespace WebAPI_Structure.Infra.Services.Products
{
    public class ProductsServices : IProductsServices   
    {
        private readonly DemoDBContext _context;
        public ProductsServices(DemoDBContext context)
        {
            _context = context;
        }
        async Task<dynamic> IProductsServices.GetAllProduct()
        {
            return await _context.Products.Select(x => new ProductDTO { ProductId = x.ProductId,ProductName=x.ProductName }).ToListAsync();
            //return null;
        }
    }
}
