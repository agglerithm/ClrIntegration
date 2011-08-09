using System;
using System.Collections.Generic;
using System.IO; 
using System.Reflection;
using System.Xml.Linq;
using cjrCommon.Extensions;

namespace MassTransitEmulator.Xml
{
    public class XmlMessageBuilder
    {
        private IList<IXmlTypeSpecifier> _typeSpecs = new List<IXmlTypeSpecifier>()
                                                         {
                                                             new XmlStringSpecifier(),
                                                             new XmlBooleanSpecifier(),
                                                             new XmlDateTimeSpecifier(),
                                                             new XmlDecimalSpecifier(),
                                                             new XmlGuidSpecifier(),
                                                             new XmlIntegerSpecifier(),
                                                             new XmlUriSpecifier()
                                                         };


        private XAttribute [] getTypeSpecAttributes(IEnumerable<Type> types)
        {
            var lst = new List<Type>(types.Distinct()); 
            if(!lst.Contains(typeof(int)))
                lst.Add(typeof(int));
            if (!lst.Contains(typeof(string)))
                lst.Add(typeof(string));
            return lst.Select(tp => _typeSpecs.Where(s => s.CanSpecify(tp)).First()).Select(spec => spec.GetAttribute()).ToArray(); 
        }

        public Stream Serialize(object msg, string source, string dest)
        {
            var env = GetEnvelopeFor(msg);
            var doc = env.GetDocument(source, dest);

            var txt = doc.Declaration + doc.ToString();


            var stream = (Stream)new MemoryStream();

            stream.Write(txt.ToByteArray(),0, txt.Length);

            return stream;
        }

        public XmlMessageEnvelope GetEnvelopeFor(object msg)
        {
            var msgType = msg.GetType();
            var types = new List<Type>();
            var props = msgType.GetProperties(); 
            foreach(var prop in props)
               types.Add(prop.PropertyType);
            var envelope = new XmlMessageEnvelope(getTypeSpecAttributes(types), msgType);
            AddInstance(envelope.MessageElement, msg);
            return envelope;
        }

        private   XElement AddInstance( XElement el, object msg )
        {
            var props = msg.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var val = prop.GetValue(msg, null);
                if (val == null) continue;
                var spec = _typeSpecs.Find(s => s.CanSpecify(prop.PropertyType));
                el.Add(spec.GetElementFor(val.ToString(), prop));
            }
            return el;
        }
    }
}
