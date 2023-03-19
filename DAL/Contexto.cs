using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    

    public DbSet<Persona> Persona {get; set;}

    public DbSet<Prestamo> Prestamo {get; set;}

    public DbSet<Ocupacion> Ocupacion {get; set;}

    public Contexto(DbContextOptions <Contexto> options): base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Persona>().HasData(
            new Persona{
                PersonaID = 1,
                Nombre ="Cesar Reynoso",
                FechaNacimiento = new DateOnly(2003,7,8),
                Telefono ="829-863-5107",
                Celular = "829-863-5107",
                Email ="CesarUnknowPro@Hotmail.com",
                Balance =0,
                Direccion ="Desconocida o prefiere no decirelo",
                OcupacionID = 1



            },
            new Persona{
                PersonaID = 2,
                Nombre ="Casper Gonzalez Reynoso",
                FechaNacimiento = new DateOnly(2003,7,8),
                Telefono ="829-863-5107",
                Celular = "829-863-5107",
                Email ="CesarUnknowPro@Hotmail.com",
                Balance =0,
                Direccion ="Desconocida o prefiere no decirelo",
                OcupacionID = 1



            },
            new Persona{
                PersonaID = 3,
                Nombre ="Gustavo Reynoso",
                FechaNacimiento = new DateOnly(2003,7,8),
                Telefono ="829-863-5107",
                Celular = "829-863-5107",
                Email ="CesarUnknowPro@Hotmail.com",
                Balance =0,
                Direccion ="Desconocida o prefiere no decirelo",
                OcupacionID = 1



            }
        );

        modelBuilder.Entity<Ocupacion>().HasData(

            new Ocupacion
            {
                OcupacionID = 1,
                Descripcion ="Full stack DevOp",
                Sueldo = 89000
            }
            
        );


    }



}