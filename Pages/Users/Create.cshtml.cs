#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using programingContestPage.Data;
using programingContestPage.Models;

namespace programingContestPage.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly programingContestPage.Data.programingContestPageContext _context;

        public CreateModel(programingContestPage.Data.programingContestPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public bool Status { get; set; }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Status = false;
            bool status = false;
			foreach (var item in _context.User)
			{
                if (item.UserName==User.UserName) {
                    status = true;
                }
			}

            if (!status)
            {
                _context.User.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Account/Login");
            }
            else {
                Status = true;
                return Page();
            }
            

            
        }
    }
}
