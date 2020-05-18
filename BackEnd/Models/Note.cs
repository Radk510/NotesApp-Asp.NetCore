using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string NoteString { get; set; }
    }
}
