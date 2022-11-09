using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Structure.App.DTO
{
    public class ProductDTO
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
