using Microsoft.EntityFrameworkCore;

public class PersonaBLL
{

    private Contexto _contexto;


    public PersonaBLL(Contexto contexto){

        this._contexto= contexto;
    }

    public bool Existe(int personaId){

        return _contexto.Persona.Any(o => o.PersonaID == personaId);
    }

    private bool Insertar(Persona Persona){

        _contexto.Persona.Add(Persona);

        var insertado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Persona).State = EntityState.Detached;
        return insertado;

    }


    private bool Modificar(Persona Persona){

        _contexto.Entry(Persona).State= EntityState.Modified;
        
        var modificado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Persona).State = EntityState.Detached;

        return modificado;

    }

    public bool Guardar(Persona Persona){

        if(!Existe(Persona.PersonaID))
            return this.Insertar(Persona);
        else
            return this.Modificar(Persona);
    }

    public bool Eliminar(Persona Persona){

        _contexto.Entry(Persona).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM Ocupacion WHERE OcupacionID={Persona.PersonaID};");
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(Persona).State = EntityState.Detached;
        Console.WriteLine($"{paso}");

        return paso;
    }

   

    public Persona? Buscar(int PersonaID){

        var buscada = _contexto.Persona
        .Where(o => o.PersonaID == PersonaID)
        .AsNoTracking()
        .SingleOrDefault();

        return buscada;

    }

    public List<Persona> GetList(){
        return _contexto.Persona.ToList();
    }

}

