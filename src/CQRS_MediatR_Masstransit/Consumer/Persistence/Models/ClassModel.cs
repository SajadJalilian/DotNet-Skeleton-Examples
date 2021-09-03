using System.Collections.Generic;
using Consumer.Persistence.Models.Interfaces;

namespace Consumer.Persistence.Models
{
    public class ClassModel : IClassModel
    {
        public int Id { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<TeacherModel> Teachers { get; set; }
        public virtual ICollection<StudentModel> Students { get; set; }
    }
}