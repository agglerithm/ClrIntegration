using System.Linq;
using CommonEntities.Messages;
using MassTransitEmulator;
using NUnit.Framework;
using SqlInterface;

namespace SqlInterfaceTests
{
    [TestFixture]
    public class TestTriggers
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
        public void can_run_trigger_logic()
        {
            var msgList =
    SqlConnectionFactory.GetInsertedRecords(new QueryWrapper("server=automation2;database=automation;user=asctracdbo;password=dbo2006", 
        "SELECT 0,'','','','',cast(0 as decimal(5,5)),cast(0 as decimal(5,5)),'','','5/5/2005','',''"),

        new ArOpenReceiptsUpdatedMessageMapper());
            var q = new MessageQueue("automation2", "reporting_aropenreceipts"); 
            var source = new QueueAddress("sql", "triggers");
            q.SendAll(msgList, source);
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
