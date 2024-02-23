namespace ShiftsLoggerApp.Contracts.Requests
{
    public class WorkerRequest
    {
        public string Name { get; set; } = default!;
        public string Department { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
