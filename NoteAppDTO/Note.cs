using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestAppNotesDTO
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string NoteString { get; set; }
    }
}
