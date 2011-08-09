using System;
using System.Collections.Generic;
using System.Reflection;

namespace MassTransitEmulator
{
    public static class Extensions
    {
        public static string Text(this MessageQueueResponseCode code)
        {
            //get all of the fields within the enum
            FieldInfo[] fields = typeof(MessageQueueResponseCode).GetFields();

            //loop through the array

            var descriptions = new List<StringDescriptionAttribute>();

            foreach (FieldInfo field in fields)
            {
                if (!field.IsSpecialName)

                    descriptions.Add(GetFieldDescription(field, typeof (StringDescriptionAttribute)));
            }
            //finally return the populated list
            var attr = descriptions.Find(a => a.Value == (int) code);
            return attr == null ? "Unknown Code" : attr.Description;
        }

        private static StringDescriptionAttribute GetFieldDescription(FieldInfo field, Type tpe)
        {
            //try to get the description attribute
            var attributes = field.GetCustomAttributes(tpe, false);

            //if there has been a description attribute...
            if ((attributes != null) && (attributes.Length > 0))
            { 
                return (StringDescriptionAttribute)attributes[0]; 
            }
            return null;
        }
 
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> lst)
        {
            var list = new List<T>();
            foreach(var item in lst)
            {
                if(!list.Contains(item))
                    list.Add(item);
            }
            return list;
        }

        public static IEnumerable<N> Select<T,N>(this IEnumerable<T> lst, Func<T,N> f)
        {
            var list = new List<N>();
            foreach (var item in lst)
            { 
                    list.Add(f(item));
            }
            return list;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> lst, Func<T, bool> f)
        {
            var list = new List<T>();
            foreach (var item in lst)
            {
                if(f(item))
                list.Add(item);
            }
            return list;
        }
        public static T  First<T>(this IEnumerable<T> lst)
        {
            return new List<T>(lst)[0];
        }

        public static T[] ToArray<T>(this IEnumerable<T> lst)
        {
            return new List<T>(lst).ToArray();
        }
    }
}
