using System;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.NativeAccess.Handles;

namespace MassTransitEmulator
{
    public sealed class SecurityContext : IDisposable
    {
        private SecurityContextHandle handle;
        private bool disposed;

        internal SecurityContextHandle Handle
        {
            get
            {
                if (this.disposed)
                    throw new ObjectDisposedException(this.GetType().Name);
                else
                    return this.handle;
            }
        }

        internal SecurityContext(SecurityContextHandle securityContext)
        {
            this.handle = securityContext;
        }

        public void Dispose()
        {
            this.handle.Close();
            this.disposed = true;
        }

        public static SecurityContext Create()
        {
            SecurityContextHandle handle ;
            var result = (MessageQueueResponseCode) NativeMethods.MQGetSecurityContextEx(out handle);
            if (result != MessageQueueResponseCode.OK)
                throw new InvalidOperationException("Error creating security context: " + result.Text());
            return new SecurityContext(handle);
        }
    }
}