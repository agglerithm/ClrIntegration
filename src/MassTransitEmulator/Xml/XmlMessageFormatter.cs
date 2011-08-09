using System;

namespace MassTransitEmulator.Xml
{
    public class XmlMessageFormatter : IMessageFormatter
    {
        public void Write(Message message, object obj)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            var msgBody = new XmlMessageBuilder();

            message.BodyStream = msgBody.Serialize(obj, message.SourceAddress, message.DestinationAddress);
        }
    }
    public interface IMessageFormatter
    {
        void Write(Message message, object cachedBodyObject);
    }
}

