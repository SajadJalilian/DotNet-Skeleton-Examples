namespace Consumer.Persistence.Models.Interfaces
{
    public interface ITeacher: IPersonModel
    {
        int TeacherId { get; set; }
    }
}