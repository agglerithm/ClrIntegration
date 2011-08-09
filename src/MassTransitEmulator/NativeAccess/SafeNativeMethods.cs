using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using MassTransitEmulator.NativeAccess.Handles;

namespace MassTransitEmulator.NativeAccess
{
    [SuppressUnmanagedCodeSecurity]
    [ComVisible(false)]
    internal static class SafeNativeMethods
    {
 
 

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("mqrt.dll", CharSet = CharSet.Unicode)]
        public static extern int MQCloseQueue(IntPtr handle);


        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport("mqrt.dll", CharSet = CharSet.Unicode)]
        public static extern void MQFreeSecurityContext(IntPtr handle);
   }
}
