using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Structure.Infra.Services.Products
{
    public interface IProductsServices
    {
        Task<dynamic> GetAllProduct();
    }
}
