using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TestAppNotesDTO;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient _apiClient;
        
        public IndexModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IEnumerable<Note> Notes { get; set; }


        public int Counter { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync()
        {
            Notes = await _apiClient.GetNotesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            await _apiClient.DeleteNoteAsync(Id);

            return RedirectToPage();
        } 
    }
}
