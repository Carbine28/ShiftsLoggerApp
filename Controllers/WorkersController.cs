using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApp.Contracts.Requests;
using ShiftsLoggerApp.Mapping;
using ShiftsLoggerApp.Models;
using ShiftsLoggerApp.Services;

namespace ShiftsLoggerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : Controller
    {
        private readonly ShiftLoggerService _service;
        public WorkersController(ShiftLoggerService service)
        {
            _service = service;
        }

        // POST: api/Workers
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> CreateWorker(WorkerRequest request)
        {
            var worker = request.ToWorker();

            await _service.CreateWorkerAsync(worker);

            var workerResponse = worker.ToWorkerResponse();
            // One Option, URI needs to be changed;
            //return Created("Workers", workerResponse);    

            // Second Option, needs action name, route values, object value
            // For more details, see https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core#what-and-why
            return CreatedAtAction(nameof(GetWorker), new { workerResponse.Id }, workerResponse);
        }

        // GET: api/Workers/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWorker(int id)
        {
            var worker = await _service.GetWorkerAsync(id);

            if (worker == null) 
                return NotFound();

            var workerResponse = worker.ToWorkerResponse();
            return Ok(workerResponse);
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            var workers = await _service.GetWorkersAsync();
            var workersResponse = workers.ToWorkersResponse();
            return Ok(workersResponse);
        }


        // PUT: api/Workers/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateWorker(int id, WorkerRequest request)
        {
            var existingWorker = await _service.GetWorkerAsync(id);
            if (existingWorker is null)
                return NotFound();

            var updatedWorker = request.ToWorker();

            existingWorker.Name = updatedWorker.Name;
            existingWorker.Department = updatedWorker.Department;
            existingWorker.Email = updatedWorker.Email;

            await _service.UpdateWorker(existingWorker);
            return Ok(existingWorker);
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var toDelete = await _service.GetWorkerAsync(id);
            if (toDelete == null) 
                    return NotFound();
            await _service.DeleteWorkerAsync(toDelete);
            return Ok();
        }
    }
}
