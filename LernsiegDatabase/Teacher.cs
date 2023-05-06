using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase;

public class Teacher
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public School School { get; set; }
}
