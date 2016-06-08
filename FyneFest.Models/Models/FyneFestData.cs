using System;
using System.Collections.Generic;
using System.Text;

namespace FyneFest
{
    public class FyneFestData
    {
        public String Note { get; set; }
        public List<Beer> Beers { get; set; } = new List<Beer>();
    }
}
