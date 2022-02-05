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
    public class IndexModel : PageModel
    {
        private readonly programingContestPage.Data.programingContestPageContext _context;

        public IndexModel(programingContestPage.Data.programingContestPageContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
