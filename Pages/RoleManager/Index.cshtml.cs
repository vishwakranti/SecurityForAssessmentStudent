using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecurityForAssessmentStudent.Data;
using SecurityForAssessmentStudent.DTO;
using System.Data;

namespace SecurityForAssessmentStudent.Pages.RoleManager
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public IndexModel(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        //Create list of all Roles
        public List<IdentityRole> Roles { get; set; }

        //Create the list of all current Users and Roles 
        public List<UserRoles> UserRoles { get; set; }

        //create the Users and Roles from the DB

        public List<UserRoles> GetUsersAndRoles()
        {
            var list = (from user in _context.Users
                        join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                        join role in _context.Roles on userRoles.RoleId equals role.Id
                        select new UserRoles { UserName = user.UserName, RoleName = role.Name }).ToList();
            return list;
        }

        public void OnGet()
        { //pass the Roles to the front end 
            Roles = _roleManager.Roles.ToList();

            //Pass the users and roles to the front end
            UserRoles = GetUsersAndRoles();
        }
    }

}

