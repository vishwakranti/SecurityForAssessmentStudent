using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecurityForAssessmentStudent.Pages.RoleManager
{
    public class CreateModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Name { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = Name.Trim() };
                var result = await _roleManager.CreateAsync(role);
                await _roleManager.CreateAsync(role);
                if (result .Succeeded)
                {
                    return RedirectToPage("/RolesManager/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);


                }
               
            }
          return Page();
        }
    }
}
