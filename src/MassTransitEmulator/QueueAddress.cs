using System;

namespace MassTransitEmulator
{
    public class QueueAddress
    {  

        public QueueAddress(string machine, string queue)
        {
            MachineName = machine == "localhost" ? Environment.MachineName : machine;
            QueueName = queue;
            this.FormatName = string.Format(@"DIRECT=OS:{0}\PRIVATE$\{1}", MachineName, QueueName);
        }

        public string MachineName
        {
            get; private set;
        }

        public string QueueName
        {
            get; private set;
        }
        public string FormatName { get; private set; }

        public string Url
        {
            get { return string.Format("msmq://{0}/{1}", MachineName, QueueName); }
        }

        public override string ToString()
        {
            return string.Format(@"{0}\{1}", MachineName, QueueName);
        }
    }
}