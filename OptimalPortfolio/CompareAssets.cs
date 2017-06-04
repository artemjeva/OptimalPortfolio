using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPortfolio
{
    class CompareAssets : IComparer<Asset>
    {
        public int Compare(Asset a, Asset b)
        {
          //  if (a.volatility == b.volatility) return 0;
          //  if (a.volatility < b.volatility) return -1;
          //  if (a.volatility > b.volatility) return 1;
          //  else return 
            return a.Volatility.CompareTo(b.Volatility);
        }
    }
}
