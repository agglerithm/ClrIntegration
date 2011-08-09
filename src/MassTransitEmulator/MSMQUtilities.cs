using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.NativeAccess.Handles;

namespace MassTransitEmulator
{
    public class MSMQUtilities
    {
        private static MessageQueueHandle _handle;

        public static int OpenQueue(string name, int access, int shareMode)
        { 
            return UnsafeNativeMethods.MQOpenQueue(name, access, shareMode, out _handle); 
        }
    }
}
