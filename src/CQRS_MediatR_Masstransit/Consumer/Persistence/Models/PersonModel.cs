using Consumer.Persistence.Models.Interfaces;

namespace Consumer.Persistence.Models
{
    public class PersonModel : IPersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
    }
}