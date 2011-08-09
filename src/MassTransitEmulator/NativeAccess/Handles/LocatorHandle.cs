using Microsoft.Win32.SafeHandles;

namespace MassTransitEmulator.NativeAccess.Handles
{
    internal class LocatorHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly LocatorHandle InvalidHandle = (LocatorHandle)new LocatorHandle.InvalidLocatorHandle();

        public override bool IsInvalid
        {
            get
            {
                if (!base.IsInvalid)
                    return this.IsClosed;
                else
                    return true;
            }
        }

        static LocatorHandle()
        {
        }

        protected LocatorHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            SafeNativeMethods.MQLocateEnd(this.handle);
            return true;
        }

        private sealed class InvalidLocatorHandle : LocatorHandle
        {
            protected override bool ReleaseHandle()
            {
                return true;
            }
        }
    }
}