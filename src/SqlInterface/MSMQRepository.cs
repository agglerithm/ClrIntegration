using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;

namespace SqlInterface
{
    public class MSMQRepository : IMSMQRepository
    {
        public IEnumerable<MessageQueueInfo> GetAllFrom(string machineName)
        {
            return get_info(MessageQueue.GetPrivateQueuesByMachine(machineName));
        }

        public IEnumerable<MessageWrapper> FindWhere(string machineName, Func<MessageQueue,bool> findRoutine)
        {
            return get_messages(MessageQueue.GetPrivateQueuesByMachine(machineName).Where(findRoutine).ToArray());
        }

        public long MessageCount(string machineName, string queueName)
        {
            var counter = System.Diagnostics.PerformanceCounterCategory.GetCategories(machineName).Where(
                x => x.CategoryName.Contains("MSMQ Queue")).FirstOrDefault();

            return counter.GetCounters(machineName + "\\private$\\" + queueName).Where(x => x.CounterName.EndsWith("Messages in Queue")).FirstOrDefault().RawValue;
        }

        private static IEnumerable<MessageWrapper> get_messages(MessageQueue[] queues)
        {
            var msgs = new List<MessageWrapper>();
            queues.ToList().ForEach(q => msgs.AddRange(q.GetAllMessages().Select(m =>  new MessageWrapper(q,m))));
            return msgs;
        }
        private static IEnumerable<MessageQueueInfo> get_info(MessageQueue[] queues)
        {
            queues.OrderBy(q => q.QueueName);
            return queues.Select(queue => new MessageQueueInfo(queue)).ToList();
        }

        public void Resend(string machine, MessageQueueInfo queue)
        {
//            var productionQueue = queue.Name.Replace("_error", "");
//            var queues = MessageQueue.GetPrivateQueuesByMachine(machine);
//            var prodQ = queues.ToList().Find(q => q.QueueName.EndsWith(productionQueue)); 
//            queue.SendAll(prodQ); 
        }


    }
}