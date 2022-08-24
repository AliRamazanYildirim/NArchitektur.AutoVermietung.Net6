using Core.Persistenz.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Quellen
{
    public interface IAsyncQuelle<T> : IAbfrage<T> where T : Einheit
    {
        Task<T?> GeheZurAsync(Expression<Func<T, bool>> Praedikat);

        Task<IPaginierung<T>> GeheZurListeAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        Task<IPaginierung<T>> GeheZurListeNachDynamischAsync(Dynamik.Dynamik dynamik,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 int index = 0, int size = 10, bool enableTracking = true,
                                                 CancellationToken cancellationToken = default);

        Task<T> InsertAsync(T einheit);
        Task<T> AktualisierenAsync(T einheit);
        Task<T> LöschenAsync(T einheit);
    }
}
