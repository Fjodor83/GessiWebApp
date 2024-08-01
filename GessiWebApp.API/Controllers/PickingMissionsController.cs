using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GessiWebApp.API.Data;
using GessiWebApp.API.Models;

namespace GessiWebApp.API.Controllers
{
    public class PickingMissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PickingMissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PickingMissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.PickingMissions.ToListAsync());
        }

        // GET: PickingMissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickingMission = await _context.PickingMissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickingMission == null)
            {
                return NotFound();
            }

            return View(pickingMission);
        }

        // GET: PickingMissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PickingMissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MissionCode,DestinationType,Description,Status")] PickingMission pickingMission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pickingMission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pickingMission);
        }

        // GET: PickingMissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickingMission = await _context.PickingMissions.FindAsync(id);
            if (pickingMission == null)
            {
                return NotFound();
            }
            return View(pickingMission);
        }

        // POST: PickingMissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MissionCode,DestinationType,Description,Status")] PickingMission pickingMission)
        {
            if (id != pickingMission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pickingMission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PickingMissionExists(pickingMission.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pickingMission);
        }

        // GET: PickingMissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pickingMission = await _context.PickingMissions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pickingMission == null)
            {
                return NotFound();
            }

            return View(pickingMission);
        }

        // POST: PickingMissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pickingMission = await _context.PickingMissions.FindAsync(id);
            if (pickingMission != null)
            {
                _context.PickingMissions.Remove(pickingMission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PickingMissionExists(int id)
        {
            return _context.PickingMissions.Any(e => e.Id == id);
        }
    }
}
