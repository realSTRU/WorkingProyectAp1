using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Prestamo
{
    
    [Key]
    public int PrestamoID { get; set; }

    public DateOnly? Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public DateOnly? Vence { get; set; }


    public int PersonaID { get; set; }

    public string? Concepto { get; set; }


    public double? Monto { get; set; }

    public double? Balance { get; set; }

    


}