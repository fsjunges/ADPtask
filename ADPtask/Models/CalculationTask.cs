namespace ADPtask.Models
{
    public class CalculationTask
    {
        public Guid id { get; set; }
        public string operation { get; set; }
        public long left { get; set; }
        public long right { get; set; }
    }
}
