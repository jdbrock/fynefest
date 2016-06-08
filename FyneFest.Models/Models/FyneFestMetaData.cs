using System;
using System.Collections.Generic;
using System.Text;

namespace FyneFest
{
    public class FyneFestMetaData
    {
        public List<BeerMetaData> BeerMetaData { get; set; }

        public FyneFestMetaData()
        {
            BeerMetaData = new List<BeerMetaData>();
        }
    }
}
