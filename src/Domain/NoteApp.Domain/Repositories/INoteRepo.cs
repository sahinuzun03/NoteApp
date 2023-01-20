using NoteApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Domain.Repositories
{
    public interface INoteRepo : IBaseRepo<Note>
    {
    }
}
