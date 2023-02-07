using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    

    public DbSet<Persona> Persona {get; set;}

    public DbSet<Prestamo> Prestamo {get; set;}

    public DbSet<Ocupacion> Ocupacion {get; set;}

    public Contexto(DbContextOptions <Contexto> options): base(options)
    {
        
    }




}