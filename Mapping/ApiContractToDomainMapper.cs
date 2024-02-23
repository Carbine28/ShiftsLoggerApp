using ShiftsLoggerApp.Contracts.Requests;
using ShiftsLoggerApp.Models;

namespace ShiftsLoggerApp.Mapping
{
    public static class ApiContractToDomainMapper
    {

        public static Worker ToWorker(this WorkerRequest request)
        {
            return new Worker
            {
                //Id = 0,
                Name = request.Name,
                Department = request.Department,
                Email = request.Email,
            };
        }
    }
}
