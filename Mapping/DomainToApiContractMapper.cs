using ShiftsLoggerApp.Contracts.Response;
using ShiftsLoggerApp.Models;

namespace ShiftsLoggerApp.Mapping
{
    public static class DomainToApiContractMapper
    {
        public static WorkerResponse ToWorkerResponse(this Worker worker)
        {
            return new WorkerResponse
            {
                Id = worker.Id,
                Name = worker.Name,
                Department = worker.Department,
                Email = worker.Email
            };
        }

        public static GetAllWorkersResponse ToWorkersResponse(this IEnumerable<Worker> workers) 
        {
            return new GetAllWorkersResponse
            {
                Workers = workers.Select(x => new WorkerResponse
                {
                    Id = x.Id,
                    Name = x.Name,  
                    Department = x.Department,  
                    Email = x.Email
                })
            };
        }
    }
}
