using System.Collections.Generic;
using Consumer.Persistence.Models.Interfaces;

namespace Consumer.Persistence.Models
{
    public class StudentModel: PersonModel, IStudentModel
    {
        public int StudentId { get; set; }
        
        // Navigation property
        public virtual TeacherModel Teacher { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
    }
}