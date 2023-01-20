using NoteApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Domain.Entities
{
    public class Note : IBaseEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }
        public List<Note> SubNotes { get; set; }
        public int? MainNoteId { get; set; }
        public Note? MainNote { get; set; }
        public Note()
        {
            SubNotes = new List<Note>();
        }
    }
}
