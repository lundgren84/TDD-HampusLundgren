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
            var change = new Dictionary<decimal, int>();      
            var sortedCoinTypes = coinTypes.OrderByDescending(x => x).ToList();
          
            foreach (var cointType in sortedCoinTypes)
            {
                change.Add(cointType, 0);

                while(amount >= cointType)
                {
                    change[cointType]++;
                    amount -= cointType;
                }
            
            }
           
            return change;

        }
    }
}
