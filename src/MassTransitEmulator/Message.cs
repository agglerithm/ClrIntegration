using System;
using System.ComponentModel;
using System.IO;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.Xml;

namespace MassTransitEmulator
{
    [Designer("System.Messaging.Design.MessageDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class Message
    {

        private object cachedBodyObject;
        private Stream cachedBodyStream;
        private IMessageFormatter cachedFormatter;
        internal MessageProperties properties;







        public object Body
        { 
            set
            {
                this.cachedBodyObject = value;
            }
        }


        public Stream BodyStream
        {
            get
            {

                {
                    if (this.cachedBodyStream == null)
                        this.cachedBodyStream = (Stream)new MemoryStream(this.properties.BodyBuffer, 0, this.properties.BodyBufferSize);
                    return this.cachedBodyStream;
                }
            }
            set
            {
                if (value == null)
                {
                    properties.RemoveBodyBuffer();
                }
                this.cachedBodyStream = value;
            }
        }

 

        [Browsable(false)]
        private IMessageFormatter Formatter
        {
            get
            {
                return cachedFormatter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                cachedFormatter = value;
            }
        }


        public string SourceAddress
        {
            get;
            private set;
        }

        public string DestinationAddress
        {
            get;
            private set;
        }


        private Message()
        {
            this.properties = new MessageProperties();
        }

        public Message(object body, QueueAddress sourceAddress, QueueAddress destinationAddress)
            : this()
        {
            this.Body = body;
            SourceAddress = sourceAddress.Url;
            DestinationAddress = destinationAddress.Url; 
        }


        private void AdjustToSend()
        {
            this.SecurityContext = SecurityContext.Create();
            if (this.Formatter == null)
                this.Formatter = new XmlMessageFormatter();
            this.Formatter.Write(this, this.cachedBodyObject);

            if (cachedBodyStream == null) return;
            cachedBodyStream.Position = 0L;
            var buffer = new byte[(int)this.cachedBodyStream.Length];
            cachedBodyStream.Read(buffer, 0, buffer.Length);
            properties.BodyBuffer = buffer;
            properties.BodyBufferSize = buffer.Length;
        }


        internal MessagePropertyVariants.MQPROPS Lock()
        {
            AdjustToSend();
            return this.properties.Lock();
        }



        internal void Unlock()
        {
            this.properties.Unlock();
        }

        [ReadOnly(true)] 
        public SecurityContext SecurityContext
        {
            get
            {
                return properties.SecurityContext;
            }
            set
            {
                properties.SecurityContext = value;
            }
        }
    }
}

