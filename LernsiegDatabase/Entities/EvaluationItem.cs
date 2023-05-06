using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase.Entities;

public class EvaluationItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int Value { get; set; }

    public Evaluation Evaluation { get; set; }
    public Criteria Criteria { get; set; }
}
