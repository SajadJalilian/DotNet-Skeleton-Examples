namespace Consumer.Persistence.Models.Interfaces
{
    public interface IPersonModel
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int BirthYear { get; set; }
    }
}