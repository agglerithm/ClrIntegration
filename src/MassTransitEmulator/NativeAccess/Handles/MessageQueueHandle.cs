using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace MassTransitEmulator.NativeAccess.Handles
{
    internal class MessageQueueHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly MessageQueueHandle InvalidHandle = (MessageQueueHandle)new MessageQueueHandle.InvalidMessageQueueHandle();

        public override bool IsInvalid
        {
            get {
                return base.IsInvalid || this.IsClosed;
            }
        }

        static MessageQueueHandle()
        {
        }

        private MessageQueueHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            SafeNativeMethods.MQCloseQueue(this.handle);
            return true;
        }

        private sealed class InvalidMessageQueueHandle : MessageQueueHandle
        {
            protected override bool ReleaseHandle()
            {
                return true;
            }
        }
    }
}
