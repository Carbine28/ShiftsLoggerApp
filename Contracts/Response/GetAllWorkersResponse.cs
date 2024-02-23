namespace ShiftsLoggerApp.Contracts.Response
{
    public class GetAllWorkersResponse
    {
        public IEnumerable<WorkerResponse> Workers { get; set; } = Enumerable.Empty<WorkerResponse>();
    }
}
