using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase;

public class Evaluation
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int SchoolOrTeacherId { get; set; }

    /// <summary>
    /// Die Spalte EvaluationType hat den Wert 1 für Schule und 2 für Lehrer.
    /// </summary>
    public int EvaluationType { get; set; }
    
    public string PhoneNr { get; set; }
    
    public List<EvaluationItem> EvaluationItems { get; set; }
}
