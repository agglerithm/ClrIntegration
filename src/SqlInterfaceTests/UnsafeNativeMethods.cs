// Type: System.Messaging.Interop.UnsafeNativeMethods
// Assembly: System.Messaging, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Messaging.dll

using System;
using System.Runtime.InteropServices;
using System.Security;
using MassTransitEmulator;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.NativeAccess.Handles;

namespace SqlInterfaceTests
{
  [SuppressUnmanagedCodeSecurity]
  [ComVisible(false)]
  internal static class UnsafeNativeMethods
  {
    [DllImport("mqrt.dll", EntryPoint = "MQOpenQueue", CharSet = CharSet.Unicode)]
    private static extern int IntMQOpenQueue(string formatName, int access, int shareMode, out MessageQueueHandle handle);

    public static int MQOpenQueue(string formatName, int access, int shareMode, out MessageQueueHandle handle)
    {
      try
      {
        return IntMQOpenQueue(formatName, access, shareMode, out handle);
      }
      catch (DllNotFoundException ex)
      {
        throw new InvalidOperationException(Res.GetString("MSMQNotInstalled"));
      }
    }

    [DllImport("mqrt.dll", CharSet = CharSet.Unicode)]
    public static extern int MQSendMessage(MessageQueueHandle handle, MessagePropertyVariants.MQPROPS properties, IntPtr transaction);


    [DllImport("mqrt.dll", EntryPoint = "MQGetQueueProperties", CharSet = CharSet.Unicode)]
    private static extern int IntMQGetQueueProperties(string formatName, MessagePropertyVariants.MQPROPS queueProperties);

    public static int MQGetQueueProperties(string formatName, MessagePropertyVariants.MQPROPS queueProperties)
    {
        try
        {
            return UnsafeNativeMethods.IntMQGetQueueProperties(formatName, queueProperties);
        }
        catch (DllNotFoundException ex)
        {
            throw new InvalidOperationException(Res.GetString("MSMQNotInstalled"));
        }
    }

    [DllImport("mqrt.dll", EntryPoint = "MQGetSecurityContextEx", CharSet = CharSet.Unicode)]
    private static extern int IntMQGetSecurityContextEx(IntPtr lpCertBuffer, int dwCertBufferLength, out SecurityContextHandle phSecurityContext);

    public static int MQGetSecurityContextEx(out SecurityContextHandle securityContext)
    {
        try
        {
            return IntMQGetSecurityContextEx(IntPtr.Zero, 0, out securityContext);
        }
        catch (DllNotFoundException ex)
        {
            throw new InvalidOperationException(Res.GetString("MSMQNotInstalled"));
        }
    }
  }
}
