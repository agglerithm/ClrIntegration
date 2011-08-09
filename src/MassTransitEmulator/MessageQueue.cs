using System;
using System.Collections;
using System.Collections.Generic;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.NativeAccess.Handles;

namespace MassTransitEmulator
{
    public class MessageQueue
    { 
        private   MessageQueueHandle _handle;
        private QueuePropertyVariants properties;
        private const string PREFIX_FORMAT_NAME = "FORMATNAME:";

        public MessageQueue(string machine, string queue)
        {
            Address = new QueueAddress(machine, queue);
            Open();
        }

        public QueueAddress Address { get; private set; }

        public   bool IsValid
        {
            get { return !_handle.IsInvalid; }
        }

        public   bool IsClosed
        {
            get { return _handle.IsClosed; }
        }

        private   int Open()
        { 
            return UnsafeNativeMethods.MQOpenQueue(FormatName, 2, 0, out _handle);
        }

        public int Send(Message msg)
        {
            if (_handle == null)
                throw new InvalidOperationException("Queue must be opened before sending!");
            var code =   UnsafeNativeMethods.MQSendMessage(_handle, msg.Lock(), (IntPtr) 1);
            msg.Unlock();

            if(IsFatalError(code))
            {
                throw new MessageQueueException(code);
            }
            return code;
        }

        QueuePropertyVariants Properties
        {
             get
            {
                if (this.properties == null)
                    this.properties = new QueuePropertyVariants();
                return this.properties;
            }
        }
        private void GenerateQueueProperties()
        {
 
                new MessageQueuePermission(MessageQueuePermissionAccess.Browse, MessageQueue.PREFIX_FORMAT_NAME + this.FormatName).Demand();
 
            int queueProperties =  UnsafeNativeMethods.MQGetQueueProperties(this.FormatName, this.Properties.Lock());
            Properties.Unlock();
            if (MessageQueue.IsFatalError(queueProperties))
                throw new MessageQueueException(queueProperties);
        }

        public string FormatName
        {
            get
            {
                return Address.FormatName;
            }
        }

        public void Close()
        {
            _handle.Close();
        }

        public static bool IsFatalError(int value)
        {
            var val = (int) value;
            var flag = value == 0;
            if ((val & -1073741824) != 1073741824)
                return !flag;
            return false;
        }

        public IEnumerable<int> SendAll(IEnumerable<IFlatMessage> msgList, QueueAddress sendQueue)
        {
            var returnList = new List<int>();
            foreach(var msg in msgList)
            {
                returnList.Add(Send(new Message(msg, sendQueue, Address)));
            }
            return returnList;
        }

        public static bool ValidatePath(string path, bool b)
        {
            throw new NotImplementedException();
        }

        public static Guid GetMachineId(string value)
        {
            throw new NotImplementedException();
        }

        public static IEnumerator GetMessageQueueEnumerator(MessageQueueCriteria criteria, bool b)
        {
            throw new NotImplementedException();
        }
    }
}
