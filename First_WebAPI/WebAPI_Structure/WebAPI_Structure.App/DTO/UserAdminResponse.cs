using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Structure.App.DTO
{
    public class UserAdminResponse
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? Password { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
