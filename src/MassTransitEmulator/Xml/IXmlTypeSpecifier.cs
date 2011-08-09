using System;
using System.Reflection;
using System.Xml.Linq;

namespace MassTransitEmulator.Xml
{
    public interface IXmlTypeSpecifier
    {
        bool CanSpecify(Type objType);
        XAttribute GetAttribute();
        XElement GetElementFor(string val, PropertyInfo prop);
    }
}