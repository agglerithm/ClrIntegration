using System;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace MassTransitEmulator
{
    internal sealed class Res
    { 
        private static Res loader;
        private ResourceManager resources;
        private static object s_InternalSyncObject;

        static object InternalSyncObject
        {
            get
            {
                if (Res.s_InternalSyncObject == null)
                {
                    object obj = new object();
                    Interlocked.CompareExchange(ref Res.s_InternalSyncObject, obj, (object)null);
                }
                return Res.s_InternalSyncObject;
            }
        }

        static CultureInfo Culture
        {
            get
            {
                return (CultureInfo)null;
            }
        }

        internal Res()
        {
            this.resources = new ResourceManager("System.Messaging", this.GetType().Assembly);
        }

        private static Res GetLoader()
        {
            if (Res.loader == null)
            {
                lock (Res.InternalSyncObject)
                {
                    if (Res.loader == null)
                        Res.loader = new Res();
                }
            }
            return Res.loader;
        }

        public static string GetString(string name)
        {
            Res loader = Res.GetLoader();
            if (loader == null)
                return (string)null; 
            return loader.resources.GetString(name, Res.Culture);
        }

        public static string GetString(string invaliddatevalue, object toString, object o)
        {
            throw new NotImplementedException();
        }
    }
}
