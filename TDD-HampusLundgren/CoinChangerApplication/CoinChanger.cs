using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication
{
    public class CoinChanger
    {
        public List<decimal> coinTypes;

        public CoinChanger(List<decimal> coinTypes)
        {
            this.coinTypes = coinTypes;
        }

        public Dictionary<decimal, int> MakeChange(decimal amount)
        {
            var change = new Dictionary<decimal, int>()
            return change;
        }
    }
}
