using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransitEmulator;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class OpenQueueTest
    {
        private MessageQueue _queue;
        [TestFixtureSetUp]
        public void SetUpForAllTests()
        { 
            _queue = new MessageQueue("automation2", "mt_orders_in");
        }
        [SetUp]
        public void SetUpForEachTest()
        {

        }

        [Test]
        public void can_open_queue()
        {  
            Assert.IsTrue(_queue.IsValid);
            Assert.IsFalse(_queue.IsClosed);
            _queue.Close();
            Assert.IsTrue(_queue.IsClosed); 
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
