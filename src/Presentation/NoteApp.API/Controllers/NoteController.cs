using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Application.Models.DTOs;
using NoteApp.Application.Models.VMs;
using NoteApp.Application.Services;

namespace NoteApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }


        [HttpGet("GetAllNotes")]
        public async Task<ActionResult<List<LiftOfNoteVM>>> GetAllNotes()
        {
            var notes = await _noteService.GetNotes();
            if (notes != null)
            {
                return Ok(notes);
            }

            return NotFound();
        }

        [HttpGet("GetNotes/{id}")]
        public async Task<ActionResult<List<LiftOfNoteVM>>> GetAllNotes([FromRoute]int id)
        {
            var notes = await _noteService.GetNotes(id);
            if (notes != null)
            {
                return Ok(notes);
            }

            return NotFound();
        }

        [HttpPost("CreateNote")]
        public async Task<ActionResult> CreateNote(CreateNoteDTO createNoteDTO)
        {
            if (ModelState.IsValid)
            {
                await _noteService.CreateNote(createNoteDTO);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("CreateNote/{id}")]
        public async Task<ActionResult> CreateNote([FromBody]CreateNoteDTO createNoteDTO,[FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                await _noteService.CreateNote(createNoteDTO, id);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("DeleteNote/{id}")]
        public async Task<ActionResult> DeleteNote([FromRoute] int id)
        {
            await _noteService.DeleteNote(id);
            return Ok();
        }


        [HttpPost("CreateSubNote")]
        public async Task<ActionResult> CreateNote([FromBody]SubNoteDTO subNoteDTO)
        {
            if (ModelState.IsValid)
            {
                await _noteService.CreateNote(subNoteDTO);
                return Ok();
            }
            return BadRequest();
        }
    }
}
