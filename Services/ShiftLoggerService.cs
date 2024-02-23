using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApp.Models;

namespace ShiftsLoggerApp.Services
{
    public class ShiftLoggerService
    {
        private readonly ShiftLoggerDbContext _dbContext;
        public ShiftLoggerService(ShiftLoggerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateShiftAsync(Shift shift)
        {
            await _dbContext.AddAsync(shift);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddWorkerToShift(int workerId, int shiftId)
        {
            try
            {
                Worker? worker = await _dbContext.Workers.FindAsync(workerId);      // Get the worker
                if (worker == null) { return false; }

                Shift? shift = await _dbContext.Shifts.FindAsync(shiftId);          // Get the shift
                if (shift == null) { return false; }

                //// Update the shift with the worker and save it into the db
                //shift.Worker = worker;
                _dbContext.Shifts.Update(shift);
                await _dbContext.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine("Error adding worker to shift: {0}", ex.Message);
                return false;
            } finally
            { 
                _dbContext.Dispose(); 
            }
        }

        public async Task<bool> CreateWorkerAsync(Worker worker)
        {
            try
            {
                await _dbContext.Workers.AddAsync(worker);
                await _dbContext.SaveChangesAsync();
                return true;
            } catch (Exception ex) 
            {
                Console.WriteLine($"Error in creating Worker: {ex.Message}");
                return false;
            } finally { _dbContext.Dispose(); }
        }

        public async Task<Worker?> GetWorkerAsync(int id) 
        {
            Worker? worker = await _dbContext.Workers.FindAsync(id);
            return worker;
        }

        public async Task<Shift?> GetShiftAsync(int id)
        {
            Shift? shift = await _dbContext.Shifts.FindAsync(id);
            return shift;
        }

        public async Task<IEnumerable<Worker>> GetWorkersAsync()
        {
            return await _dbContext.Workers.ToListAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            return await _dbContext.Shifts.ToListAsync();
        }

        public async Task UpdateWorker(Worker worker)
        {
            _dbContext.Update(worker);
            await SaveChangesASync();
        }


        // Deleting shifts and workers, how do I handle logic of finding where the worker has worked in shifts?
        public async Task DeleteWorkerAsync(Worker worker)
        {
            _dbContext.Remove(worker);
            await _dbContext.SaveChangesAsync();
        }
        // Deleteing a shift, how do I handle the logic of removing that shifts from all workers?
        public async Task DeleteShiftAsync(Shift shift)
        {
            _dbContext.Remove(shift);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesASync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public bool WorkerExists(int id)
        {
            return _dbContext.Workers.Any(e => e.Id == id);
        }

        public bool ShiftExists(int id)
        {
            return _dbContext.Shifts.Any(e => e.Id == id);
        }
    }
}
