using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TestAppNotesDTO;

namespace FrontEnd
{
    public class CreateNoteModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public CreateNoteModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [BindProperty]
        public Note Note { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.AddNoteAsync(Note);

            return RedirectToPage("/Index");
        }
    }
}