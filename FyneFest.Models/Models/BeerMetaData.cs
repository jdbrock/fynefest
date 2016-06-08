using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace FyneFest
{
    [ImplementPropertyChanged]
    public class BeerMetaData
    {
        public String BeerId { get; set; }

		public Boolean IsTicked { get; set; }
        public DateTime TickDate { get; set; }
        public Decimal TickRating { get; set; }
        public String TickComments { get; set; }

        public Boolean IsFavorited { get; set; }

		public Boolean IsEmpty { get { return !IsTicked && !IsFavorited && TickRating == default(Decimal); } }
    }
}
