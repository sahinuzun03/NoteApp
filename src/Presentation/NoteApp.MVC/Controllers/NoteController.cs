using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NoteApp.Application.Models.DTOs;
using NoteApp.Application.Models.VMs;
using NoteApp.MVC.Models;
using System.Text.Json.Serialization;

namespace NoteApp.MVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7209");
                var response = await client.GetAsync("api/Note/GetAllNotes");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = await response.Content.ReadAsStringAsync();

                    var readDate = JsonConvert.DeserializeObject<List<LiftOfNoteVM>>(readTask);

                    return View(readDate);
                }

                else
                {
                    ViewBag.EmptyList = "List is not found";
                    return View(new List<LiftOfNoteVM>());
                }
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteWithId(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7209");
                var response = await client.GetAsync($"api/Note/GetNotes/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = await response.Content.ReadAsStringAsync();

                    var readDate = JsonConvert.DeserializeObject<List<LiftOfNoteVM>>(readTask);

                    return View(readDate);
                }

                else
                {
                    ViewBag.EmptyList = "List is not found";
                    return View(new List<LiftOfNoteVM>());
                }
            }
        }

        [HttpGet]
        public IActionResult PostNotes()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PostNotes(CreateNoteDTO createNoteDTO)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7209");
                    var httpResponseMessage = await client.PostAsJsonAsync<CreateNoteDTO>("api/Note/CreateNote", createNoteDTO);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(GetNotes));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteNote(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7209");
                var httpResponseMessage = await client.GetAsync($"api/Note/DeleteNote/{id}");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(GetNotes));
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet]
        public ActionResult SubPostNotes(int id)
        {
            SubNoteDTO subNote = new SubNoteDTO();
            subNote.MainNoteId = id;
            return View(subNote);
        }

        [HttpPost]
        public async Task<ActionResult> SubPostNotes(SubNoteDTO subNoteDTO)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7209");
                    var httpResponseMessage = await client.PostAsJsonAsync<SubNoteDTO>($"api/Note/CreateSubNote", subNoteDTO);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(GetNotes));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
