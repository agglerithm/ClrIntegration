using System;
using Microsoft.Win32.SafeHandles;

namespace MassTransitEmulator.NativeAccess.Handles
{
    public sealed class SecurityContextHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public override bool IsInvalid
        {
            get
            {
                return base.IsInvalid || IsClosed;
            }
        }

        private SecurityContextHandle()
            : base(true)
        {
        }

        static SecurityContextHandle()
        {
            
        }
        public SecurityContextHandle(IntPtr existingHandle)
            : base(true)
        {
            this.SetHandle(existingHandle);
        }

        protected override bool ReleaseHandle()
        {
            SafeNativeMethods.MQFreeSecurityContext(this.handle);
            return true;
        }
    }
}