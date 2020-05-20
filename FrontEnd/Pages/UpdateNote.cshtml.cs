using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAppNotesDTO;

namespace FrontEnd
{
    public class UpdateNoteModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public UpdateNoteModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Note Note { get; set; }

        [FromRoute]
        public int Id { get; set; }

        public async Task OnGet()
        {
            Note = await _apiClient.GetNoteAsync(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutNoteAsync(Note);

            return RedirectToPage("/Index");
        }
    }
}