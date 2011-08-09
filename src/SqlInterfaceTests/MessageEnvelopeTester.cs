using System;
using CommonEntities;
using MassTransitEmulator;
using MassTransitEmulator.Xml;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class MessageEnvelopeTester
    {
        private XmlMessageBuilder _body;
        [TestFixtureSetUp]
        public void SetUpForAllTests()
        {

        }

        [SetUp]
        public void SetUpForEachTest()
        {
            _body = new XmlMessageBuilder();
        }

        [Test]
        public void can_create_message_envelope()
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
            var env = _body.GetEnvelopeFor(msg);
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
