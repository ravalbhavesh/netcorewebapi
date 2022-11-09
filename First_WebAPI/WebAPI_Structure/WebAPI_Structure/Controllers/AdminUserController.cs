using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Infra.Services.UserAdmin;
using WebAPI_Structure.Core.Models;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI_Structure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly DemoDBContext _context;
        private readonly IUserAdminServices _useradminServices;
        private readonly IConfiguration _configuration;
        //public object Message { get; private set; }

        public AdminUserController(IUserAdminServices useradminServices, IConfiguration configuration, DemoDBContext context)
        {
            _useradminServices = useradminServices;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserAdminDTO request)
        {
            var user = await _context.UserAdmins.Where(x => x.Email == request.Email && x.IsDeleted == false).SingleOrDefaultAsync();
            if (user == null) return NotFound();
            if (user.Email != request.Email)
            {
                return BadRequest("User Not Found");
            }
            //string salt = BCrypt.Net.BCrypt.GenerateSalt(); ;
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            int salt = 11;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            bool verified = BCrypt.Net.BCrypt.Verify(user.Password, passwordHash);
            if (verified)
            {
                string token = CreateToken(user);
                var data = new UserAdminResponse();
                data.Email = user.Email;
                data.Password = user.Password;
                data.UserId = user.UserId;
                data.Token = token;
                return Ok(data);
            }
            else
            {
                return Ok("Password is not match");
            }
        }
        private string CreateToken(UserAdmin user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Appsettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddSeconds(60);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: d2,
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
