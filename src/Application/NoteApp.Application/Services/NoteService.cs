using AutoMapper;
using NoteApp.Application.Models.DTOs;
using NoteApp.Application.Models.VMs;
using NoteApp.Domain.Entities;
using NoteApp.Domain.Enums;
using NoteApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly INoteRepo _noteRepo;

        public NoteService(IMapper mapper, INoteRepo noteRepo)
        {
            _mapper = mapper;
            _noteRepo = noteRepo;
        }

        public async Task CreateNote(CreateNoteDTO createNoteDTO)
        {
            var addNote = _mapper.Map<Note>(createNoteDTO);
            await _noteRepo.Create(addNote);
        }

        public async Task DeleteNote(int id)
        {
            var model = await _noteRepo.GetDefault(x => x.Id == id);
            model.DeleteDate = DateTime.Now;
            model.Status = Status.Passive;

            await _noteRepo.Update(model);

        }

        public async Task<Note> GetNote(int id)
        {
            var note = await _noteRepo.GetDefault(x => x.Id == id);
            return note;
        }

        public async Task<List<LiftOfNoteVM>> GetNotes()
        {
            var notes = await _noteRepo.GetFilteredList(
                select: x => new LiftOfNoteVM
                {
                    Id = x.Id,
                    Body = x.Body,
                    Subject = x.Subject
                },
                where: x => x.Status == Status.Active || x.Status == Status.Modified);

            return notes;
        }

        public async Task<List<LiftOfNoteVM>> GetNotes(int id)
        {
            var notes = await _noteRepo.GetFilteredList(
                select: x => new LiftOfNoteVM
                {
                    Id = x.Id,
                    Body = x.Body,
                    Subject = x.Subject
                },
                where: x => ((x.Status == Status.Active || x.Status == Status.Modified) && x.MainNoteId == id));

            return notes;
        }

        public async Task CreateNote(CreateNoteDTO createNoteDTO,int id)
        {
            var addNote = _mapper.Map<Note>(createNoteDTO);
            var mainNote = await GetNote(id);

            mainNote.SubNotes.Add(addNote);
            await _noteRepo.Update(mainNote);
        }


        public async Task CreateNote(SubNoteDTO subNoteDTO)
        {
            var addNote = _mapper.Map<Note>(subNoteDTO);
            var mainNote = await GetNote(subNoteDTO.MainNoteId);

            mainNote.SubNotes.Add(addNote);
            await _noteRepo.Update(mainNote);
        }
    }
}
