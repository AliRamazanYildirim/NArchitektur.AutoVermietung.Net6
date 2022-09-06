using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Paging
{
    public class Paginierung<T> : IPaginierung<T>
    {


        internal Paginierung(IEnumerable<T> source, int index, int size, int from)
        {
            var enumerable = source as T[] ?? source.ToArray();

            if (from > index)
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

            if (source is IQueryable<T> querable)
            {
                Index = index;
                Grösse = size;
                Von = from;
                Zaehlen = querable.Count();
                Seiten = (int)Math.Ceiling(Zaehlen / (double)Grösse);

                Element = querable.Skip((Index - Von) * Grösse).Take(Grösse).ToList();
            }
            else
            {
                Index = index;
                Grösse = size;
                Von = from;

                Zaehlen = enumerable.Count();
                Seiten = (int)Math.Ceiling(Zaehlen / (double)Grösse);

                Element = enumerable.Skip((Index - Von) * Grösse).Take(Grösse).ToList();
            }
        }

        internal Paginierung()
        {
            Element = new T[0];
        }
        public int Von { get; set; }
        public int Index { get; set; }
        public int Grösse { get; set; }
        public int Zaehlen { get; set; }
        public int Seiten { get; set; }
        public IList<T> Element { get; set; }
        public bool HatVorheriges => Index - Von > 0;
        public bool HatNaechstes => Index - Von + 1 < Seiten;


    }
    internal class Paginierung<TSource, TResult> : IPaginierung<TResult>
    {
        public Paginierung(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
                        int index, int size, int from)
        {
            var enumerable = source as TSource[] ?? source.ToArray();

            if (from > index) throw new ArgumentException($"Von: {from} > Index: {index}, muss Von <= Index");

            if (source is IQueryable<TSource> queryable)
            {
                Index = index;
                Grösse = size;
                Von = from;
                Zaehlen = queryable.Count();
                Seiten = (int)Math.Ceiling(Zaehlen / (double)Grösse);

                var element = queryable.Skip((Index - Von) * Grösse).Take(Grösse).ToArray();

                Element = new List<TResult>(converter(element));
            }
            else
            {
                Index = index;
                Grösse = size;
                Von = from;
                Zaehlen = enumerable.Count();
                Seiten = (int)Math.Ceiling(Zaehlen / (double)Grösse);

                var element = enumerable.Skip((Index - Von) * Grösse).Take(Grösse).ToArray();

                Element = new List<TResult>(converter(element));
            }
        }


        public Paginierung(IPaginierung<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            Index = source.Index;
            Grösse = source.Grösse;
            Von = source.Von;
            Zaehlen = source.Zaehlen;
            Seiten = source.Seiten;

            Element = new List<TResult>(converter(source.Element));
        }
        public int Von { get; }
        public int Index { get; }
        public int Grösse { get; }
        public int Zaehlen { get; }
        public int Seiten { get; }
        public IList<TResult> Element { get; }
        public bool HatVorheriges => Index - Von > 0;
        public bool HatNaechstes => Index - Von + 1 < Seiten;
    }
    public static class Paginierung
    {
        public static IPaginierung<T> Leer<T>()
        {
            return new Paginierung<T>();
        }

        public static IPaginierung<TResult> Von<TResult, TSource>(IPaginierung<TSource> source,
                                                                Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            return new Paginierung<TSource, TResult>(source, converter);
        }
    }
}
