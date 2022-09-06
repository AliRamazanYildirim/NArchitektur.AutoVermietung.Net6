using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Paging
{
    public static class AbfragebareSeitenErweiterungen
    {
        public static async Task<IPaginierung<T>> ZumPaginierenAsync<T>(this IQueryable<T> source, int index, int size,
                                                              int from = 0,
                                                              CancellationToken cancellationToken = default)
        {
            if (from > index) throw new ArgumentException($"Von: {from} > Index: {index}, muss von <= Index");

            int zaehlen = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            List<T> element = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken)
                                        .ConfigureAwait(false);
            Paginierung<T> list = new()
            {
                Index = index,
                Grösse = size,
                Von = from,
                Zaehlen = zaehlen,
                Element = element,
                Seiten = (int)Math.Ceiling(zaehlen / (double)size)
            };
            return list;
        }


        public static IPaginierung<T> ZumPaginierenAsync<T>(this IQueryable<T> source, int index, int size,
                                                 int from = 0)
        {
            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

            int zaehlen = source.Count();
            List<T> element = source.Skip((index - from) * size).Take(size).ToList();
            Paginierung<T> list = new()
            {
                Index = index,
                Grösse = size,
                Von = from,
                Zaehlen = zaehlen,
                Element = element,
                Seiten = (int)Math.Ceiling(zaehlen / (double)size)
            };
            return list;
        }
    }
}
