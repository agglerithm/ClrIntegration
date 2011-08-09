using System;
using System.Runtime.InteropServices;

namespace MassTransitEmulator.NativeAccess
{
    internal class Restrictions
    {
        public const int PRLT = 0;
        public const int PRLE = 1;
        public const int PRGT = 2;
        public const int PRGE = 3;
        public const int PREQ = 4;
        public const int PRNE = 5;
        private Restrictions.MQRESTRICTION restrictionStructure;

        public Restrictions(int maxRestrictions)
        {
            this.restrictionStructure = new Restrictions.MQRESTRICTION(maxRestrictions);
        }

        public virtual void AddGuid(int propertyId, int op, Guid value)
        {
            IntPtr num = Marshal.AllocHGlobal(16);
            Marshal.Copy(value.ToByteArray(), 0, num, 16);
            this.AddItem(propertyId, op, (short)72, num);
        }

        public virtual void AddGuid(int propertyId, int op)
        {
            IntPtr data = Marshal.AllocHGlobal(16);
            this.AddItem(propertyId, op, (short)72, data);
        }

        private void AddItem(int id, int op, short vt, IntPtr data)
        {
            Marshal.WriteInt32(this.restrictionStructure.GetNextValidPtr(0), op);
            Marshal.WriteInt32(this.restrictionStructure.GetNextValidPtr(4), id);
            Marshal.WriteInt16(this.restrictionStructure.GetNextValidPtr(8), vt);
            Marshal.WriteInt16(this.restrictionStructure.GetNextValidPtr(10), (short)0);
            Marshal.WriteInt16(this.restrictionStructure.GetNextValidPtr(12), (short)0);
            Marshal.WriteInt16(this.restrictionStructure.GetNextValidPtr(14), (short)0);
            Marshal.WriteIntPtr(this.restrictionStructure.GetNextValidPtr(16), data);
            Marshal.WriteIntPtr(this.restrictionStructure.GetNextValidPtr(16 + IntPtr.Size), (IntPtr)0);
            ++this.restrictionStructure.restrictionCount;
        }

        public virtual void AddI4(int propertyId, int op, int value)
        {
            this.AddItem(propertyId, op, (short)3, (IntPtr)value);
        }

        public virtual void AddString(int propertyId, int op, string value)
        {
            if (value == null)
            {
                this.AddItem(propertyId, op, (short)1, (IntPtr)0);
            }
            else
            {
                IntPtr data = Marshal.StringToHGlobalUni(value);
                this.AddItem(propertyId, op, (short)31, data);
            }
        }

        public virtual Restrictions.MQRESTRICTION GetRestrictionsRef()
        {
            return this.restrictionStructure;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MQRESTRICTION
        {
            public int restrictionCount;
            public IntPtr restrinctions;

            public MQRESTRICTION(int maxCount)
            {
                this.restrinctions = Marshal.AllocHGlobal(maxCount * Restrictions.MQRESTRICTION.GetRestrictionSize());
            }

            ~MQRESTRICTION()
            {
                if (this.restrinctions != (IntPtr)0)
                {
                    for (int index = 0; index < this.restrictionCount; ++index)
                    {
                        if ((int)Marshal.ReadInt16((IntPtr)((long)this.restrinctions + (long)(index * Restrictions.MQRESTRICTION.GetRestrictionSize()) + 8L)) != 3)
                            Marshal.FreeHGlobal(Marshal.ReadIntPtr((IntPtr)((long)this.restrinctions + (long)(index * Restrictions.MQRESTRICTION.GetRestrictionSize()) + 16L)));
                    }
                    Marshal.FreeHGlobal(this.restrinctions);
                    this.restrinctions = (IntPtr)0;
                }
            }

            public IntPtr GetNextValidPtr(int offset)
            {
                return (IntPtr)((long)this.restrinctions + (long)(this.restrictionCount * Restrictions.MQRESTRICTION.GetRestrictionSize()) + (long)offset);
            }

            public static int GetRestrictionSize()
            {
                return 16 + IntPtr.Size * 2;
            }
        }
    }
}