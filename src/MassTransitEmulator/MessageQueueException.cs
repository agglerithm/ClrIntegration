using System;
using System.Globalization;
using System.Text;
using MassTransitEmulator;
using MassTransitEmulator.NativeAccess;

namespace MassTransitEmulator
{
    public class MessageQueueException : Exception
    {
        public MessageQueueResponseCode ResponseCode
        {
            get; private set;
        }

        public MessageQueueException(int code)
        {
            ResponseCode = (MessageQueueResponseCode) code;
        }

        public override string Message
        {
            get
            {
                try
                {
                    return Res.GetString(Convert.ToString((int) ResponseCode, 16).ToUpper(CultureInfo.InvariantCulture));
                }
                catch
                {
                    return GetUnknownErrorMessage((int) ResponseCode);
                }
            }
        }

        private static string GetUnknownErrorMessage(int error)
        {
            var lpBuffer = new StringBuilder(256);
            string str;
            if (NativeMethods.FormatMessage(12800, IntPtr.Zero, error, 0, lpBuffer, lpBuffer.Capacity + 1, IntPtr.Zero) != 0)
            {
                int length;
                for (length = lpBuffer.Length; length > 0; --length)
                {
                    char ch = lpBuffer[length - 1];
                    if ((int)ch > 32 && (int)ch != 46)
                        break;
                }
                str = lpBuffer.ToString(0, length);
            }
            else
                str = "Unknown error";
 
            return str;
        }
    }

  
 

}