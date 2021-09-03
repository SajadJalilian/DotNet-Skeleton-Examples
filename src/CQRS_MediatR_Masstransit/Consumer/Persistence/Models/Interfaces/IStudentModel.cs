namespace Consumer.Persistence.Models.Interfaces
{
    public interface IStudentModel: IPersonModel
    {
        int StudentId { get; set; }
    }
}