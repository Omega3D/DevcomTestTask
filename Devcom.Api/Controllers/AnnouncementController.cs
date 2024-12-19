using Devcom.Api.Models;
using Devcom.Application.Interfaces;
using Devcom.Domain.Entities;
using Devcom.Domain.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devcom.Api.Controllers
{
    [Authorize] 
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService) 
        {
            _announcementService = announcementService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var announcements =  await _announcementService.GetAllAsync();

            var response = announcements.Select(a => new AnnouncementDto(
                a.Id, a.Title, a.Description, a.CreatedDate, a.Status, a.Category, a.SubCategory)).ToList();

            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementRequest request)
        {
            var (ann, error) = Announcement.Create(
                0,
                request.Title,
                request.Description,
                DateTime.Now,
                request.Status,
                request.Category,
                request.SubCategory);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            if (ModelState.IsValid)
            {
                await _announcementService.AddAsync(new AddAnnouncementParams
                {
                    Title = ann.Title,
                    Description = ann.Description,
                    CreatedDate = ann.CreatedDate,
                    Status = ann.Status,
                    Category = ann.Category,
                    SubCategory = ann.SubCategory
                });

                return RedirectToAction("Index");
            }

            return View(request);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }

            var model = new UpdateAnnouncementParams
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Description = announcement.Description,
                Status = announcement.Status,
                Category = announcement.Category,
                SubCategory = announcement.SubCategory
            };

            return View(model);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAnnouncementParams request)
        {
            if (id != request.Id)
            {
                return BadRequest("Mismatched announcement ID.");
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _announcementService.UpdateAsync(request);
            if (result == 0)
            {
                ModelState.AddModelError("", "Announcement not found.");
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Announcement/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _announcementService.DeleteAsync(id);
            if (result == 0)
                return NotFound("Announcement not found.");

            return RedirectToAction("Index");
        }
    }
}
