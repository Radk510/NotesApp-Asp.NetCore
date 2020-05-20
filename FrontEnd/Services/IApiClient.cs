using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppNotesDTO;

namespace FrontEnd.Services
{
    public interface IApiClient
    {
        /// <summary>
        /// GET Notes
        /// </summary>
        /// <returns></returns>
        Task<List<Note>> GetNotesAsync();

        /// <summary>
        /// GET Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Note> GetNoteAsync(int id);

        /// <summary>
        /// POST(create) note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        Task<bool> AddNoteAsync(Note note);

        /// <summary>
        /// PUT(update) Note
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        Task PutNoteAsync(Note note);

        /// <summary>
        /// DELETE Note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteNoteAsync(int id);

    }
}
