using AutoMapper;
using NoteApp.Application.Models.DTOs;
using NoteApp.Application.Models.VMs;
using NoteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateNoteDTO, Note>().ReverseMap();
            CreateMap<LiftOfNoteVM, Note>().ReverseMap();
            CreateMap<SubNoteDTO,Note>().ReverseMap();  
        }
    }
}
