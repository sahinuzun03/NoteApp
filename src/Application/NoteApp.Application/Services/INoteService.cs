using NoteApp.Application.Models.DTOs;
using NoteApp.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.Services
{
    public interface INoteService
    {
        Task CreateNote(CreateNoteDTO createNoteDTO);
        Task<List<LiftOfNoteVM>> GetNotes();
        Task DeleteNote(int id);
        Task<List<LiftOfNoteVM>> GetNotes(int id);
        Task CreateNote(CreateNoteDTO createNoteDTO, int id);
        Task CreateNote(SubNoteDTO subNoteDTO);
    }
}
