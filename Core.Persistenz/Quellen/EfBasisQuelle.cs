﻿using Core.Persistenz.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

    public Task<TEinheit?> GeheZurAsync(Expression<Func<TEinheit, bool>> Praedikat)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginierung<TEinheit>> GeheZurListeAsync(Expression<Func<TEinheit, bool>>? predicate = null, Func<IQueryable<TEinheit>, IOrderedQueryable<TEinheit>>? orderBy = null, Func<IQueryable<TEinheit>, IIncludableQueryable<TEinheit, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPaginierung<TEinheit>> GeheZurListeNachDynamischAsync(Dynamik.Dynamik dynamik, Func<IQueryable<TEinheit>, IIncludableQueryable<TEinheit, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<TEinheit> InsertAsync(TEinheit einheit)
    {
        Context.Entry(einheit).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return einheit;
    }

    public Task<TEinheit> AktualisierenAsync(TEinheit einheit)
    {
        throw new NotImplementedException();
    }

    public Task<TEinheit> LöschenAsync(TEinheit einheit)
    {
        throw new NotImplementedException();
    }
}