using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using NUnit.Framework;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class MessagingTester
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
        public void can_get_msg()
        {
            var q = new MessageQueue(@"FormatName:DIRECT=OS:automation2\PRIVATE$\qa_sender");
            var msgs = q.GetAllMessages();

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
