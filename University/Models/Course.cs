using System.Collections.Generic;

namespace University.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
      this.JoinEntities2 = new HashSet<CourseInstructor>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; set; }
    public virtual ICollection<CourseInstructor> JoinEntities2 { get; }
  }
}