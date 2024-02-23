using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApp.Models;
using ShiftsLoggerApp.Services;

namespace ShiftsLoggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController(ShiftLoggerService service) : Controller
    {
        private readonly ShiftLoggerService _service = service;
        // GET: api/Shifts
        [HttpGet]
        public async Task<IEnumerable<Shift>> GetShifts()
        {
            return await _service.GetShiftsAsync();
        }

        // GET: api/Shifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShift(int id)
        {
            Shift? shift = await _service.GetShiftAsync(id);
            if (shift == null) return NotFound();
            return shift;
        }

        // PUT: api/Shifts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShift(int id, Shift shift)
        {
            if (id != shift.Id) return BadRequest();

            var updateShift = await _service.GetShiftAsync(id);
            if (updateShift == null) return NotFound();

            updateShift.Date = shift.Date;
            updateShift.StartTime = shift.StartTime;
            updateShift.EndTime = shift.EndTime;
            updateShift.HasLunchBreak = shift.HasLunchBreak;
            updateShift.TotalTime = shift.TotalTime;                        // Calculate the new total time instead

            try
            {
                await _service.SaveChangesASync();
            }
            catch (DbUpdateConcurrencyException) when (!_service.ShiftExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // POST: api/Shifts
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Shift>> CreateWorker(Shift shift)
        {
            var newShift = new Shift
            {
                Date = shift.Date,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                HasLunchBreak = shift.HasLunchBreak,
                TotalTime = shift.TotalTime,
            };

            await _service.CreateShiftAsync(newShift);
            return newShift;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var shift = await _service.GetShiftAsync(id);
            if (shift == null) return NotFound();
            await _service.DeleteShiftAsync(shift);
            return NoContent();
        }

    }
}
