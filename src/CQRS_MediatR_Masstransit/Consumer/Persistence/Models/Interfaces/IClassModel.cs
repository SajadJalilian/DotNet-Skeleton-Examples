namespace Consumer.Persistence.Models.Interfaces
{
    public interface IClassModel
    {
        int Id { get; set; }
        int StartTime { get; set; }
        int EndTime { get; set; }
        string Name { get; set; }
    }
}