using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase;

public class School
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Country { get; set; } = "at";

    public int SchoolNumber { get; set; }
    
    public string Address { get; set; }

    public List<Teacher> Teachers { get; set; }
}
