﻿using NUnit.Framework;
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
        public void CorrectChangeWhenUsingOneCoinType(int amount)
        {
            var coinTypes = new List<decimal> { 1.0m };
            var sut = new CoinChanger(coinTypes);
            Dictionary<decimal, int>  myChange= sut.MakeChange(14.0m);

            Assert.AreEqual(14, myChange[1m]);
        }
    }

 
}
