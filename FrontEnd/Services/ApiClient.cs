using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestAppNotesDTO;

namespace FrontEnd.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// GET ALL Notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetNotesAsync()
        {
            var response = await _httpClient.GetAsync("/api/notes");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Note>>();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/notes/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Note>();
        }

        public async Task<bool> AddNoteAsync(Note note)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/notes", note);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;

        }

        public async Task PutNoteAsync(Note note)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/notes/{note.Id}", note);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/notes/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }

            response.EnsureSuccessStatusCode();
        }
    }
}
