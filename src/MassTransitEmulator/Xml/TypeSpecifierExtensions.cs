using System;

namespace MassTransitEmulator.Xml
{
    public static class TypeSpecifierExtensions
    {
        public static string GetStringDefinition(this object spec)
        {
            return "System.String, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetDecimalDefinition(this object spec)
        {
            return "System.Decimal, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetBooleanDefinition(this object spec)
        {
            return "System.Boolean, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetDateTimeDefinition(this object spec)
        {
            return "System.DateTime, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetIntegerDefinition(this object spec)
        {
            return "System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetGuidDefinition(this object spec)
        {
            return "System.Guid, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetUriDefinition(this object spec)
        {
            return
                "System.Uri, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        }

        public static string GetMessageDefinition(this object msg)
        {
            var tp = msg.GetType();
            return tp.GetMessageDefinitionFromType();
        }


        public static string GetMessageDefinitionFromType(this Type tp)
        { 
            return string.Format("{0}, {1}, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null", tp.FullName, tp.Assembly.GetName());
        }

    }
}
