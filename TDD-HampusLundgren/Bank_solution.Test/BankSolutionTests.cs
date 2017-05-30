using Extra_Exercise_3;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_solution.Test
{
    [TestFixture]
    public class BankSolutionTests
    {
        private Bank sut { get; set; }
        private IAuditLogger auditLogger { get; set; }
        private Account TestAccount { get; set; }
        [SetUp]
        public void Setup()
        {
            auditLogger = Substitute.For<IAuditLogger>();
            sut = new Bank(auditLogger);
            TestAccount = new Account()
            {
                Name = "Olle Svensson",
                Number = "1234",
                Balance = 1234,
            };
        }
        /// <summary>
        /// Create a valid account and verify that when we call GetAccount, we get the correct information back. Verify Name, Number and Balance. Balance should be zero.
        /// </summary>
        [Test]
        public void CanCreateBankAccount()
        {
            //Act
            sut.CreateAccount(TestAccount);
            var acc = sut.GetAccount(TestAccount.Number);
            //Assert
            Assert.AreEqual(TestAccount, acc);
        }
        /// <summary>
        /// When creating two accounts with the same account number, then a DuplicateAccount exception should be thrown
        /// </summary>
        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            sut.CreateAccount(TestAccount);
            Assert.Throws<DuplicateAccount>(() =>
            {
                sut.CreateAccount(TestAccount);
            });
        }
        /// <summary>
        /// •	Each time we create an account, we need to verify that the written message to the audit log contains both the name and account number of the newly created account.
        /// </summary>
        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            sut.CreateAccount(TestAccount);
            auditLogger.Received().AddMessage(Arg.Is<string>(x => x.Contains(TestAccount.Name) &&
            x.Contains(TestAccount.Number)));
        }
        /// <summary>
        /// •	Each time we create an account with a valid account number, we need to verify that one record is written to the audit log. Ignore what is written to the log, just make sure exactly one call are made.
        /// </summary>
        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {          
                sut.CreateAccount(TestAccount);

                auditLogger.Received(1).AddMessage(Arg.Any<string>());          
        }
        /// <summary>
        /// Each time we create an account with an invalid account number, we need to verify that two records are written to the audit log. Ignore what is written to the log, just make sure two calls are made.
        /// </summary>
        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            TestAccount.Number = "OneOneTwoThree";
          
            Assert.Throws<InvalidAccount>(() => 
            {
                sut.CreateAccount(TestAccount);
              
            });
            auditLogger.Received(2).AddMessage(Arg.Any<string>());
        }
        /// <summary>
        /// Each time we create an invalid account, the two messages written to the audit log must either contain Warn12: or Error45:
        /// </summary>
        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            TestAccount.Number = "OneOneTwoThree";

            Assert.Throws<InvalidAccount>(() =>
            {
                sut.CreateAccount(TestAccount);

            });
            auditLogger.Received(2).AddMessage(Arg.Is<string>(x => x.Contains("Warn12") 
            || x.Contains("Error45")));

        }
        /// <summary>
        /// We need to verify that when we call GetAuditLog on the bank object, that it do actually call the AuditLogger.GetLog() method. Setup the test so that the GetLog() method on the audit logger returns a list of three items. Use the mocking feature in NSubstitute to do this. Make sure in the test these three items are returned from the GetAuditLog Method. 
        /// </summary>
        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            List<string> injectLoggs = new List<string>()
        {
            "string1","string2","string3"
        };
            auditLogger.GetLog().Returns(injectLoggs);
            //Act
            var loggs = sut.GetAuditLog();
            //Assert
            Assert.AreEqual(3, loggs.Count);
        }



    }
}
