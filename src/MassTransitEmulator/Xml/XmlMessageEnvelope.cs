using System;
using System.Xml.Linq;

namespace MassTransitEmulator.Xml
{
    public class XmlMessageEnvelope
    {
        private readonly XElement _root;
        private readonly XElement _message;
        private readonly XElement _sourceAddress;
        private readonly XElement _destinationAddress; 
        public XmlMessageEnvelope(XAttribute [] attributes, Type msgType)
        {
            XNamespace x = this.GetMessageDefinition();
            XNamespace m = msgType.GetMessageDefinitionFromType();
            XNamespace s = this.GetStringDefinition();
            XNamespace i = this.GetIntegerDefinition();
            _root = new XElement(x + "XmlMessageEnvelope", new XAttribute(XNamespace.Xmlns + "x", x.NamespaceName), 
                new XAttribute(XNamespace.Xmlns + "m", m.NamespaceName));
            _root.Add(attributes);
            _message = new XElement(m + "Message");
            _sourceAddress = new XElement(s + "SourceAddress");
             _destinationAddress = new XElement(s + "DestinationAddress"); 
            _root.Add(_message);
            _root.Add(_sourceAddress);
            _root.Add(_destinationAddress);
            _root.Add(new XElement(i + "RetryCount",new XText("0")));
            _root.Add(new XElement(s + "MessageType", new XText(msgType.FullName + ", " + msgType.Assembly.GetName())));
        } 
        public XElement MessageElement { get { return _message; } }

 

        public XDocument GetDocument(string sourceAddr,string destAddr)
        {
            _sourceAddress.Add(new XText(sourceAddr));
            _destinationAddress.Add(new XText(destAddr));
            return new XDocument(new XDeclaration("1.0","utf-8","yes"),_root);
        }
    }
}
