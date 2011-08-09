using System;
using MassTransitEmulator.NativeAccess;
using MassTransitEmulator.NativeAccess.Handles;

namespace MassTransitEmulator
{
    public class MessageProperties
    {
        private MessagePropertyVariants _props;

        public MessageProperties()
        {
            _props = new MessagePropertyVariants();
            _props.SetUI1Vector(2, new byte[20]);
        }

        internal MessagePropertyVariants.MQPROPS Lock()
        {
            return _props.Lock();
        }

        internal void Unlock()
        {
            _props.Unlock();
        }

        internal byte[] BodyBuffer
        {
            get { return _props.GetUI1Vector(9); }
            set
            {
                _props.SetUI1Vector(9, value);
            }
        }

        internal int BodyBufferSize
        {
            get { return _props.GetUI4(10); }
            set { _props.SetUI4(10, value); }
        }

        internal SecurityContext SecurityContext
        {
            get
            {
                return new SecurityContext(new SecurityContextHandle((IntPtr)this._props.GetUI4(37)));
            }
            set
            {
                if (value == null)
                {
                    this._props.Remove(37);
                }
                else
                {
                    this._props.SetUI4(37, value.Handle.DangerousGetHandle().ToInt32());
                }
            }
        }
        public void RemoveBodyBuffer()
        {
            _props.Remove(9);
            _props.Remove(42);
            _props.Remove(10);
        }
    }
}
