using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication.Tests
{
    [TestFixture]
   public class CoinChangerTests
    {
        [Test]
        public void CorrectChangeWhenUsingOneCoinType()
        {
            var coinTypes = new List<decimal> { 1.0m };
            var sut = new CoinChanger(coinTypes);

            Dictionary<decimal, int>  myChange= sut.MakeChange(14.0m);

            Assert.AreEqual(14, myChange[1m]);
        }

        [Test]
        public void CorrectChangeWhenUsingTwoCoinType()
        {
            var coinTypes = new List<decimal> { 1.0m ,5.0m};
            var sut = new CoinChanger(coinTypes);

            Dictionary<decimal, int> myChange = sut.MakeChange(23.0m);

            Assert.AreEqual(3, myChange[1m]);
            Assert.AreEqual(4, myChange[5m]);
        }
        [Test]
        public void PutInCointTypesInDifferentOrder()
        {
            var coinTypes = new List<decimal> {10.0m, 1.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);

            Dictionary<decimal, int> myChange = sut.MakeChange(58.0m);

            Assert.AreEqual(3, myChange[1m]);
            Assert.AreEqual(1, myChange[5m]);
            Assert.AreEqual(5, myChange[10m]);
        }
    }

 
}
