using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Persona
{


    [Key]
    public int PersonaId { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono {get; set;}

    public DateTime Fecha {get; set;}

    public string? Celular{get; set;}

    public string? Email {get; set;}

    public string? Direccion {get; set;}

    public DateTime? FechaNacimiento { get; set; }

    public int OcupacionID {get; set;}

    public double Balance {get; set;}



    
}