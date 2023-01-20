using NoteApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.Models.DTOs
{
    public class CreateNoteDTO
    {
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
