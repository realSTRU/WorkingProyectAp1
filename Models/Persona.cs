using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Persona
{


    [Key]
    public int PersonaID { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono {get; set;}

    public DateOnly? Fecha {get; set;}

    public string? Celular{get; set;}

    public string? Email {get; set;}

    public string? Direccion {get; set;}

    public DateOnly? FechaNacimiento { get; set; }

    [ForeignKey("PersonaID")]
    public List<Prestamo>? Prestamos { get; set; }

    public int OcupacionID {get; set;}

    public double? Balance {get; set;} = 0; 



    
}