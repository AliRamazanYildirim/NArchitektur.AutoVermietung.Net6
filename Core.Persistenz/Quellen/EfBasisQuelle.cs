using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Core.Persistenz.Quellen;

public class EfBasisQuelle<TEinheit, TKontext> : IAsyncQuelle<TEinheit>, IQuelle<TEinheit>
    where TEinheit : Einheit
    where TKontext : DbContext
{
    protected TKontext Context { get; }

    public EfBasisQuelle(TKontext context)
    {
        Context = context;
    }


}