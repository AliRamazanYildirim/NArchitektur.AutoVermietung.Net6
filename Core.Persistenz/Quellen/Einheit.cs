using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Einheit
{
    public int Id { get; set; }

    public Einheit()
    {
    }

    public Einheit(int id) : this()
    {
        Id = id;
    }
}
