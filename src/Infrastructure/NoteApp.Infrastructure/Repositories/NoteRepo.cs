using NoteApp.Domain.Entities;
using NoteApp.Domain.Repositories;
using NoteApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Infrastructure.Repositories
{
    public class NoteRepo : BaseRepo<Note>, INoteRepo
    {
        public NoteRepo(NoteDbContext noteDbContext) : base(noteDbContext)
        {
        }
    }
}
