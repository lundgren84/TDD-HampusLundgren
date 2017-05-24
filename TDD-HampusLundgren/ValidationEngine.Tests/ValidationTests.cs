using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngine.Tests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            Validator sut = new Validator();

            var result = sut.ValidateEmailAddress("mike@edument.se");

            Assert.IsTrue(result);
        }
        [Test]
        public void NotValidEmailExeptionForNotValidAddress()
        {
            Validator sut = new Validator();

            Assert.Throws<NotValidEmailExeption>(() =>
            {
                sut.ValidateEmailAddress("Name2015@test.com");
            });
        }
        [Test]
        public void NullOrEmptyExeptionForNullOREmpty()
        {
            Validator sut = new Validator();

            Assert.Throws<NullOrEmptyExeption>(() =>
            {
                sut.ValidateEmailAddress(null);
            });

        }

    }
}
