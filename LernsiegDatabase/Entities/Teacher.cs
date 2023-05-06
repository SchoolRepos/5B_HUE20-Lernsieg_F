using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase.Entities;

public class Teacher
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    // has to be named [TargetEntity]Id or similar
    // see https://learn.microsoft.com/en-us/ef/core/modeling/relationships/conventions#discovering-foreign-key-properties
    public int SchoolId { get; set; }
    
    public School School { get; set; }
}
