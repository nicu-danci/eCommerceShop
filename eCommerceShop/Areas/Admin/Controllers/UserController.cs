using eCommerceShop.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eCommerceShop.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]

        public IActionResult GetAll() 
        {
            var userList = _context.ApplicationUsers.ToList();
            var userRole = _context.UserRoles.ToList();
            var roles = _context.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id== roleId).Name;
            }

            return Json(new { data = userList });
        }

        #endregion
    }
}
