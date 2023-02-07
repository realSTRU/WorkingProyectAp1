using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Ocupacion
{

    [Key]
    public int OcupacionID { get; set; }

    public string? Descripcion { get; set; }

    public double? Sueldo { get; set; }



}