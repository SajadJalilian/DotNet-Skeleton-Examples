using System.Collections.Generic;
using Consumer.Persistence.Models.Interfaces;

namespace Consumer.Persistence.Models
{
    public class TeacherModel: PersonModel, ITeacher
    {
        public int TeacherId { get; set; }
        
        // Navigation property
        public virtual ICollection<StudentModel> Students { get; set; }
        public virtual ICollection<ClassModel> Classes { get; set; }
    }
}