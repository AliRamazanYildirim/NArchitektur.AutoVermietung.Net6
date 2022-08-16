using System.Linq.Expressions;
using Core.Persistenz.Paging;
using Core.Persistenz.Quellen;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistenz.Quellen;

public interface IQuelle<T> : IAbfrage<T> where T : Einheit
{
    //T Get(Expression<Func<T, bool>> predicate);

    //IPaginierung<T> GehZurListe(Expression<Func<T, bool>>? predicate = null,
    //                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    //                     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    //                     int index = 0, int size = 10,
    //                     bool enableTracking = true);

    //IPaginierung<T> ListeAbrufenVonDynamik(Dynamic.Dynamic dynamic,
    //                              Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    //                              int index = 0, int size = 10, bool enableTracking = true);

    //T Insert(T einheit);
    //T Aktualisieren(T einheit);
    //T Löschen(T einheit);
}