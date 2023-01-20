using NoteApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.Models.VMs
{
    public class LiftOfNoteVM
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
