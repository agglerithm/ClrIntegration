using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransitEmulator;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class ExceptionTester
    {
        [TestFixtureSetUp]
        public void SetUpForAllTests()
        {

        }

        [SetUp]
        public void SetUpForEachTest()
        {

        }

        [Test]
        public void can_get_message()
        {
            var ex = new MessageQueueException(-1074659329);

            Assert.Equals(ex.Message, "Unknown error");
        }

        [TearDown]
        public void TearDownForEachTest()
        {

        }

        [TestFixtureTearDown]
        public void TearDownAfterAllTests()
        {

        }
    }
}
