using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransitEmulator;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class TestMessageCodeExtension
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
        public void can_get_description()
        {
            var txt = MessageQueueResponseCode.TransactionEnlist.Text();
            Assert.AreEqual(txt, "TransactionEnlist");
        }

        [Test]
        public void can_handle_unknowncode()
        {
            var txt = ((MessageQueueResponseCode)3).Text();
            Assert.AreEqual(txt, "Unknown Code");
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
