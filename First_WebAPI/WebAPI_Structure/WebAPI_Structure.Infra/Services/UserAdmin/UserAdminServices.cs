using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.Core.Models;

namespace WebAPI_Structure.Infra.Services.UserAdmin
{
    public class UserAdminServices : IUserAdminServices 
    {
        private readonly DemoDBContext _context;
        public UserAdminServices(DemoDBContext context)
        {
            _context = context;
        }
    }
}
