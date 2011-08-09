using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using CommonEntities.Messages;
using MassTransitEmulator;

namespace SqlInterface
{
    public class MessageFactory
    {
        public static Message GetOrderUpdatedMessage(string orderNum)
        {
            return new Message(orderNum, new XmlMessageFormatter());
        }

        public static Message GetReportArOpenReceiptsUpdatedMessage(string documentid, string location, string documenttype,
            string applytonum, decimal amt1, decimal amt2, string custid, string reference, DateTime documentdate, string salespersonid)
        { 
            return new Message(new ReportArOpenReceiptsUpdatedMessage(documentid,  location,  documenttype,
             applytonum,  amt1,  amt2,  custid,  reference,  documentdate,  salespersonid));
        }
    }
}
