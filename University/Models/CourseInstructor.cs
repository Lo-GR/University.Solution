namespace University.Models
{
  public class CourseInstructor
  {
    public int CourseInstructorId { get; set;}
    public int InstructorId {get; set;}
    public int CourseId {get; set;}
    public virtual Instructor Instructor {get; set;}
    public virtual Course Course {get; set;}

  }
}