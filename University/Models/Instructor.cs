using System.Collections.Generic;

namespace University.Models
{
  public class Instructor
  {
    public Instructor()
    {
      this.JoinEntities2 = new HashSet<CourseInstructor>();
    }

    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
    public virtual ICollection<CourseInstructor> JoinEntities2 { get; set; }
  }
}