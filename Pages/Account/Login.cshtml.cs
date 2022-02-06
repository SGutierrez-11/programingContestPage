using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using programingContestPage.Models;
using System.ComponentModel.DataAnnotations;
using programingContestPage.Data;
using programingContestPage.Models;

namespace programingContestPage.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly programingContestPage.Data.programingContestPageContext _context;

		public LoginModel(programingContestPage.Data.programingContestPageContext context)
		{
			_context = context;
		}

		[TempData]
        public string Alert { get; set; }

        public new IList<User> User { get; set; }

        public IActionResult OnGet()
        {
           return Page();
        }

        [BindProperty]
        public Credential Credential { get; set; }


		public async Task<IActionResult> OnPostAsync()
		{
			var TotalUsers = from m in _context.User select m;
			var user = TotalUsers.Where(s => s.UserName.Equals(Credential.UserName));
			User = await user.ToListAsync();

			for (int i= 0; i<User.Count;i++)
			{
				string nameUser = User[i].UserName;
				if (Credential.UserName.Equals(nameUser))
				{
					if (User[i].Password == Credential.Password)
					{
						return RedirectToPage("../Users/Index");
					}
					else
					{
						Alert = "ERROR";
						return Page();
					}
				}
			}

			Alert = "ERROR";
			return Page();
		}


	}

    public class Credential 
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }


    
}
