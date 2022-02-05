#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using programingContestPage.Data;
using programingContestPage.Models;

namespace programingContestPage.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly programingContestPage.Data.programingContestPageContext _context;

        public DetailsModel(programingContestPage.Data.programingContestPageContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
