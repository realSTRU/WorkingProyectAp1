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

        var PrestamoAnterior = _contexto.Prestamo
        .Where(p=>p.PrestamoID == prestamo.PrestamoID)
        .AsNoTracking()
        .SingleOrDefault();

        if(prestamo.Monto != PrestamoAnterior.Monto)
        {
            var persona = _contexto.Persona
            .Where(o => o.PersonaID == prestamo.PrestamoID)
            .AsNoTracking()
            .SingleOrDefault();
            
            if(persona != null)
            {
                
                persona.Balance -= PrestamoAnterior.Monto;
                persona.Balance += prestamo.Monto;
                _contexto.Entry(persona).State = EntityState.Modified;
                _contexto.SaveChanges();
                _contexto.Entry(persona).State = EntityState.Modified;

            }
            else
            {
                Console.WriteLine($"Persona con el Id:{prestamo.PersonaID} No encontrada");
            }
            
        }
        else
        {
            Console.WriteLine("No hubo cambios en el monto del prestamo");
        }
        
        _contexto.Entry(prestamo).State = EntityState.Modified;

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

        var persona = _contexto.Persona.Where(p => p.PersonaID == prestamo.PersonaID).AsNoTracking().SingleOrDefault();

        if(persona != null)
        {
            persona.Balance -= prestamo.Monto;
            _contexto.Entry(persona).State =EntityState.Modified;
            _contexto.SaveChanges();
            _contexto.Entry(persona).State = EntityState.Detached;
        }
        else
        {
            Console.WriteLine("Persona No Existe");

        }



        _contexto.Entry(prestamo).State = EntityState.Deleted;

        var eliminado = _contexto.SaveChanges() > 0;

        _contexto.Entry(prestamo).State = EntityState.Detached;

        return eliminado;
        


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