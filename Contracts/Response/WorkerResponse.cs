namespace ShiftsLoggerApp.Contracts.Response
{
    public class WorkerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Department { get; set; } = default!;
        public string Email { get; set; } = default!;

    }
}
