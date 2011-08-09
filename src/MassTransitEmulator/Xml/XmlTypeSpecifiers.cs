using System;
using System.Reflection;
using System.Xml.Linq;

namespace MassTransitEmulator.Xml
{
    public class XmlStringSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;
        
        public XmlStringSpecifier ()
        {
            _namespace = this.GetStringDefinition();

        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof (string);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "s", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val); 
        }
    }

    public class XmlDecimalSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace ;
        
        public XmlDecimalSpecifier ()
        {
            _namespace = this.GetDecimalDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(decimal);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "d", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

    public class XmlBooleanSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;
        
        public XmlBooleanSpecifier ()
        {
            _namespace = this.GetBooleanDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(bool);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "b", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

    public class XmlDateTimeSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;
        
        public XmlDateTimeSpecifier ()
        {
            _namespace = this.GetDateTimeDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(DateTime);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "dt", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

    public class XmlIntegerSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;

        
        public XmlIntegerSpecifier ()
        {
            _namespace = this.GetIntegerDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(int);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "i", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

    public class XmlGuidSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;
        
        public XmlGuidSpecifier ()
        {
            _namespace = this.GetGuidDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(Guid);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "g", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

    public class XmlUriSpecifier : IXmlTypeSpecifier
    {
        private XNamespace _namespace;
        
        public XmlUriSpecifier ()
        {
            _namespace = this.GetUriDefinition();
        }
        public bool CanSpecify(Type objType)
        {
            return objType == typeof(Uri);
        }

        public XAttribute GetAttribute()
        {
            return new XAttribute(XNamespace.Xmlns + "u", _namespace.NamespaceName); 
        }

        public XElement GetElementFor(string val, PropertyInfo prop)
        {
            return new XElement(_namespace + prop.Name, val);
        }
    }

 
 
}
