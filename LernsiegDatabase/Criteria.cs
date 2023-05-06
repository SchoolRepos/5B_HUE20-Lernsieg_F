using System.ComponentModel.DataAnnotations.Schema;

namespace LernsiegDatabase;

public class Criteria
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Die Spalte EvaluationType hat den Wert 1 für Schule und 2 für Lehrer.
    /// </summary>
    public int EvaluationType { get; set; }

    public int SequenceNr { get; set; }
    
    public string Description { get; set; }
}
