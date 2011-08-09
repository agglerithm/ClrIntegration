using System;
using CommonEntities;
using MassTransitEmulator;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class TestFixtureTemplate
    {
        private MessageQueue _queue;

        [TestFixtureSetUp]
        public void SetUpForAllTests()
        {

            _queue = new MessageQueue("automation2", "reporting_aropenreceipts"); 
        }
        [SetUp]
        public void SetUpForEachTest()
        {

        }

        [Test]
        public void can_send_message()
        {
            var msg = new AcknowledgedOrderLine()
            {
                ActualPrice = 1,
                ActualQuantity = 100,
                CustomerPartNumber = "AEFE-A01",
                EstimatedDeliveryDate = DateTime.Today,
                ItemDescription = "P/N AEFE",
                ItemID = "FIN234098392",
                LineNumber = "1",
                RequestedPrice = 1,
                RequestedQuantity = 110
            };

            var source = new QueueAddress(@"jreeselaptop2", "mt_orders_in");
            var result = _queue.Send(new Message(msg, source, _queue.Address));
             
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
