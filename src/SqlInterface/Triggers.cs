using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonEntities.Messages;
using MassTransitEmulator;
using Microsoft.SqlServer.Server;

namespace SqlInterface
{
    public class Triggers
    {
  
        [SqlTrigger(Name = @"SendReportArOpenReceiptsUpdatedMessage", Target = "[dbo].[ReportArOpenReceipts]", Event = "FOR UPDATE")] 
        public static void SendReportArOpenReceiptsUpdatedMessage()
        {
            sendReportArOpenReceiptsChangedMsgs();
        }

        [SqlTrigger(Name = @"SendReportArOpenReceiptsInsertedMessage", Target = "[dbo].[ReportArOpenReceipts]", Event = "FOR INSERT")]
        public static void SendReportArOpenReceiptsInsertedMessage()
        {
            sendReportArOpenReceiptsChangedMsgs();
        }

        [SqlTrigger(Name = @"SendReportArOpenReceiptsDeletedMessage", Target = "[dbo].[ReportArOpenReceipts]", Event = "FOR DELETE")]
        public static void SendReportArOpenReceiptsDeletedMessage()
        {
            sendReportArOpenReceiptsDeletedMsgs();
        }

        private static void sendReportArOpenReceiptsDeletedMsgs()
        {
            var msgList =
                SqlConnectionFactory.GetInsertedRecords(new QueryWrapper("context connection=true", "SELECT * from DELETED"),
                                               new ArOpenReceiptsDeletedMessageMapper());
            sendArOpenReceiptsMsgList(msgList);
        }

        private static void sendArOpenReceiptsMsgList(IEnumerable<IFlatMessage> msgList)
        {
            var q = new MessageQueue("automation2", "reporting_aropenreceipts");
            var source = new QueueAddress("sql", "triggers");
            var lst = q.SendAll(msgList, source);
            foreach (var i in lst)
            {
                if (i != 0)
                    SqlContext.Pipe.Send(((MessageQueueResponseCode)i).Text());
            }
        }

        private static void sendReportArOpenReceiptsChangedMsgs()
        {
            var msgList =
                SqlConnectionFactory.GetInsertedRecords(new QueryWrapper("context connection=true", "SELECT * from INSERTED"),
                                                        new ArOpenReceiptsUpdatedMessageMapper());
            sendArOpenReceiptsMsgList(msgList);
        }
    }
}
 
