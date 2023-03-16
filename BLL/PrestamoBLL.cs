using Microsoft.EntityFrameworkCore;


public class PrestamoBLL
{

    private Contexto _contexto;


    public PrestamoBLL(Contexto contexto){

        this._contexto= contexto;
    }

    public bool Existe(int prestamoId){

        return _contexto.Prestamo.Any(o => o.PrestamoID == prestamoId);
    }

    private bool Insertar(Prestamo prestamo){

        var insertado = false;
        var personaEncontrada = _contexto.Persona.Find(prestamo.PersonaID);
        
        if(personaEncontrada != null)
        {
            personaEncontrada.Balance += prestamo.Monto;
            prestamo.Balance = prestamo.Monto;
            _contexto.Prestamo.Add(prestamo);
            _contexto.Entry(personaEncontrada).State = EntityState.Modified;
            insertado = _contexto.SaveChanges() > 0;
            _contexto.Entry(personaEncontrada).State = EntityState.Detached;
        }
       

        

        
        return insertado;

    }


    private bool Modificar(Prestamo prestamo){

        _contexto.Entry(prestamo).State= EntityState.Modified;
        
        var modificado = _contexto.SaveChanges() > 0;

        _contexto.Entry(prestamo).State = EntityState.Detached;

        return modificado;

    }

    public bool Guardar(Prestamo prestamo){

        if(!Existe(prestamo.PrestamoID))
            return this.Insertar(prestamo);
        else
            return this.Modificar(prestamo);
    }

    public bool Eliminar(Prestamo prestamo){

        _contexto.Entry(prestamo).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM Prestamo WHERE PrestamoID={prestamo.PrestamoID};");
        return _contexto.SaveChanges() > 0;
        
    }

   

    public Prestamo? Buscar(int PrestamoID){

        var buscada = _contexto.Prestamo
        .Where(o => o.PrestamoID == PrestamoID)
        .AsNoTracking()
        .SingleOrDefault();

        return buscada;

    }

    public List<Prestamo> GetList(){
        return _contexto.Prestamo.ToList();
    }

    





}