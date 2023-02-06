using Microsoft.EntityFrameworkCore;
public class OcupacionesBLL{

    private Contexto _contexto;


    public OcupacionesBLL(Contexto contexto){

        this._contexto= contexto;
    }

    public bool Existe(int ocupacionId){

        return _contexto.Ocupacion.Any(o => o.OcupacionID == ocupacionId);
    }

    private bool Insertar(Ocupacion Ocupacion){

        _contexto.Ocupacion.Add(Ocupacion);

        var insertado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Ocupacion).State = EntityState.Detached;
        return insertado;

    }


    private bool Modificar(Ocupacion Ocupacion){

        _contexto.Entry(Ocupacion).State= EntityState.Modified;
        
        var modificado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Ocupacion).State = EntityState.Detached;

        return modificado;

    }

    public bool Guardar(Ocupacion Ocupacion){

        if(!Existe(Ocupacion.OcupacionID))
            return this.Insertar(Ocupacion);
        else
            return this.Modificar(Ocupacion);
    }

    public bool Eliminar(Ocupacion Ocupacion){

        _contexto.Entry(Ocupacion).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM Ocupacion WHERE OcupacionID={Ocupacion.OcupacionID};");
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(Ocupacion).State = EntityState.Detached;
        Console.WriteLine($"{paso}");

        return paso;
    }

   

    public Ocupacion? Buscar(int ocupacionID){

        var buscada = _contexto.Ocupacion
        .Where(o => o.OcupacionID == ocupacionID)
        .AsNoTracking()
        .SingleOrDefault();

        return buscada;

    }

    public List<Ocupacion> GetList(){
        return _contexto.Ocupacion.ToList();
    }
}