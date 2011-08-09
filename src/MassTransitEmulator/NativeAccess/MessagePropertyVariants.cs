using System;
using System.Runtime.InteropServices;

namespace MassTransitEmulator.NativeAccess
{

 
    [StructLayout(LayoutKind.Explicit)]
    internal struct MQPROPVARIANTS
    {
        [FieldOffset(0)]
        internal short vt;
        [FieldOffset(2)]
        internal short wReserved1;
        [FieldOffset(4)]
        internal short wReserved2;
        [FieldOffset(6)]
        internal short wReserved3;
        [FieldOffset(8)]
        internal byte bVal;
        [FieldOffset(8)]
        internal short iVal;
        [FieldOffset(8)]
        internal int lVal;
        [FieldOffset(8)]
        internal long hVal;
        [FieldOffset(8)]
        internal IntPtr ptr;
        [FieldOffset(8)]
        internal MQPROPVARIANTS.CAUB caub;

        internal struct CAUB
        {
            internal uint cElems;
            internal IntPtr pElems;
        }
    }
    internal class MessagePropertyVariants
    {
        private int MAX_PROPERTIES = 61;
        private int basePropertyId = 1;
        private const short VT_UNDEFINED = (short)0;
        public const short VT_EMPTY = (short)32767;
        public const short VT_ARRAY = (short)8192;
        public const short VT_BOOL = (short)11;
        public const short VT_BSTR = (short)8;
        public const short VT_CLSID = (short)72;
        public const short VT_CY = (short)6;
        public const short VT_DATE = (short)7;
        public const short VT_I1 = (short)16;
        public const short VT_I2 = (short)2;
        public const short VT_I4 = (short)3;
        public const short VT_I8 = (short)20;
        public const short VT_LPSTR = (short)30;
        public const short VT_LPWSTR = (short)31;
        public const short VT_NULL = (short)1;
        public const short VT_R4 = (short)4;
        public const short VT_R8 = (short)5;
        public const short VT_STREAMED_OBJECT = (short)68;
        public const short VT_STORED_OBJECT = (short)69;
        public const short VT_UI1 = (short)17;
        public const short VT_UI2 = (short)18;
        public const short VT_UI4 = (short)19;
        public const short VT_UI8 = (short)21;
        public const short VT_VECTOR = (short)4096;
        private int propertyCount;
        private GCHandle handleVectorProperties;
        private GCHandle handleVectorIdentifiers;
        private GCHandle handleVectorStatus;
        private MessagePropertyVariants.MQPROPS reference;
        private int[] vectorIdentifiers;
        private int[] vectorStatus;
        private MQPROPVARIANTS[] vectorProperties;
        private short[] variantTypes;
        private object[] objects;
        private object[] handles;

        internal MessagePropertyVariants(int maxProperties, int baseId)
        {
            this.reference = new MessagePropertyVariants.MQPROPS();
            this.MAX_PROPERTIES = maxProperties;
            this.basePropertyId = baseId;
            this.variantTypes = new short[this.MAX_PROPERTIES];
            this.objects = new object[this.MAX_PROPERTIES];
            this.handles = new object[this.MAX_PROPERTIES];
        }

        public MessagePropertyVariants()
        {
            this.reference = new MessagePropertyVariants.MQPROPS();
            this.variantTypes = new short[this.MAX_PROPERTIES];
            this.objects = new object[this.MAX_PROPERTIES];
            this.handles = new object[this.MAX_PROPERTIES];
        }

        public byte[] GetGuid(int propertyId)
        {
            return (byte[])this.objects[propertyId - this.basePropertyId];
        }

        public void SetGuid(int propertyId, byte[] value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)72;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public short GetI2(int propertyId)
        {
            return (short)this.objects[propertyId - this.basePropertyId];
        }

        public void SetI2(int propertyId, short value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)2;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public int GetI4(int propertyId)
        {
            return (int)this.objects[propertyId - this.basePropertyId];
        }

        public void SetI4(int propertyId, int value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)3;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public IntPtr GetStringVectorBasePointer(int propertyId)
        {
            return (IntPtr)this.handles[propertyId - this.basePropertyId];
        }

        public uint GetStringVectorLength(int propertyId)
        {
            return (uint)this.objects[propertyId - this.basePropertyId];
        }

        public byte[] GetString(int propertyId)
        {
            return (byte[])this.objects[propertyId - this.basePropertyId];
        }

        public void SetString(int propertyId, byte[] value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)31;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public byte GetUI1(int propertyId)
        {
            return (byte)this.objects[propertyId - this.basePropertyId];
        }

        public void SetUI1(int propertyId, byte value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)17;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public byte[] GetUI1Vector(int propertyId)
        {
            return (byte[])this.objects[propertyId - this.basePropertyId];
        }

        public void SetUI1Vector(int propertyId, byte[] value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)4113;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public short GetUI2(int propertyId)
        {
            return (short)this.objects[propertyId - this.basePropertyId];
        }

        public void SetUI2(int propertyId, short value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)18;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public int GetUI4(int propertyId)
        {
            return (int)this.objects[propertyId - this.basePropertyId];
        }

        public void SetUI4(int propertyId, int value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)19;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public long GetUI8(int propertyId)
        {
            return (long)this.objects[propertyId - this.basePropertyId];
        }

        public void SetUI8(int propertyId, long value)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)21;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)value;
        }

        public IntPtr GetIntPtr(int propertyId)
        {
            object obj = this.objects[propertyId - this.basePropertyId];
            if (obj.GetType() == typeof(IntPtr))
                return (IntPtr)obj;
            else
                return IntPtr.Zero;
        }

        public virtual void AdjustSize(int propertyId, int size)
        {
            this.handles[propertyId - this.basePropertyId] = (object)(uint)size;
        }

        public virtual void Ghost(int propertyId)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] != 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)0;
                --this.propertyCount;
            }
        }

        public virtual MessagePropertyVariants.MQPROPS Lock()
        {
            int[] propertyIds1 = new int[this.propertyCount];
            int[] numArray2 = new int[this.propertyCount];
            MQPROPVARIANTS[] mqpropvariantsArray = new MQPROPVARIANTS[this.propertyCount];
            int index1 = 0;
            for (int index2 = 0; index2 < this.MAX_PROPERTIES; ++index2)
            {
                short num = this.variantTypes[index2];
                if ((int)num != 0)
                {
                    propertyIds1[index1] = index2 + this.basePropertyId;
                    mqpropvariantsArray[index1].vt = num;
                    if ((int)num == 4113)
                    {
                        mqpropvariantsArray[index1].caub.cElems = this.handles[index2] != null ? (uint)this.handles[index2] : (uint)((byte[])this.objects[index2]).Length;
                        GCHandle gcHandle = GCHandle.Alloc(this.objects[index2], GCHandleType.Pinned);
                        this.handles[index2] = (object)gcHandle;
                        mqpropvariantsArray[index1].caub.pElems = gcHandle.AddrOfPinnedObject();
                    }
                    else if ((int)num == 17 || (int)num == 16)
                        mqpropvariantsArray[index1].bVal = (byte)this.objects[index2];
                    else if ((int)num == 18 || (int)num == 2)
                        mqpropvariantsArray[index1].iVal = (short)this.objects[index2];
                    else if ((int)num == 19 || (int)num == 3)
                        mqpropvariantsArray[index1].lVal = (int)this.objects[index2];
                    else if ((int)num == 21 || (int)num == 20)
                        mqpropvariantsArray[index1].hVal = (long)this.objects[index2];
                    else if ((int)num == 31 || (int)num == 72)
                    {
                        GCHandle gcHandle = GCHandle.Alloc(this.objects[index2], GCHandleType.Pinned);
                        this.handles[index2] = (object)gcHandle;
                        mqpropvariantsArray[index1].ptr = gcHandle.AddrOfPinnedObject();
                    }
                    else if ((int)num == (int)short.MaxValue)
                        mqpropvariantsArray[index1].vt = (short)0;
                    ++index1;
                    if (this.propertyCount == index1)
                        break;
                }
            }
            this.handleVectorIdentifiers = GCHandle.Alloc((object)propertyIds1, GCHandleType.Pinned);
            this.handleVectorProperties = GCHandle.Alloc((object)mqpropvariantsArray, GCHandleType.Pinned);
            this.handleVectorStatus = GCHandle.Alloc((object)numArray2, GCHandleType.Pinned);
            this.vectorIdentifiers = propertyIds1;
            this.vectorStatus = numArray2;
            this.vectorProperties = mqpropvariantsArray;
            this.reference.propertyCount = this.propertyCount;
            this.reference.propertyIdentifiers = this.handleVectorIdentifiers.AddrOfPinnedObject();
            this.reference.propertyValues = this.handleVectorProperties.AddrOfPinnedObject();
            this.reference.status = this.handleVectorStatus.AddrOfPinnedObject();
            return this.reference;
        }

        public virtual void Remove(int propertyId)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] != 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)0;
                this.objects[propertyId - this.basePropertyId] = (object)null;
                this.handles[propertyId - this.basePropertyId] = (object)null;
                --this.propertyCount;
            }
        }

        public virtual void SetNull(int propertyId)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = (short)1;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)null;
        }

        public virtual void SetEmpty(int propertyId)
        {
            if ((int)this.variantTypes[propertyId - this.basePropertyId] == 0)
            {
                this.variantTypes[propertyId - this.basePropertyId] = short.MaxValue;
                ++this.propertyCount;
            }
            this.objects[propertyId - this.basePropertyId] = (object)null;
        }

        public virtual void Unlock()
        {
            for (int index = 0; index < this.vectorIdentifiers.Length; ++index)
            {
                short num = this.vectorProperties[index].vt;
                if ((int)this.variantTypes[this.vectorIdentifiers[index] - this.basePropertyId] == 1)
                {
                    if ((int)num == 4113 || (int)num == 1)
                        this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].caub.cElems;
                    else if ((int)num == 4127)
                    {
                        this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index * 4].caub.cElems;
                        this.handles[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index * 4].caub.pElems;
                    }
                    else
                        this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].ptr;
                }
                else if ((int)num == 31 || (int)num == 72 || (int)num == 4113)
                {
                    ((GCHandle)this.handles[this.vectorIdentifiers[index] - this.basePropertyId]).Free();
                    this.handles[this.vectorIdentifiers[index] - this.basePropertyId] = (object)null;
                }
                else if ((int)num == 17 || (int)num == 16)
                    this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].bVal;
                else if ((int)num == 18 || (int)num == 2)
                    this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].iVal;
                else if ((int)num == 19 || (int)num == 3)
                    this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].lVal;
                else if ((int)num == 21 || (int)num == 20)
                    this.objects[this.vectorIdentifiers[index] - this.basePropertyId] = (object)this.vectorProperties[index].hVal;
            }
            this.handleVectorIdentifiers.Free();
            this.handleVectorProperties.Free();
            this.handleVectorStatus.Free();
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MQPROPS
        {
            internal int propertyCount;
            internal IntPtr propertyIdentifiers;
            internal IntPtr propertyValues;
            internal IntPtr status;
        }
    }

    internal class MachinePropertyVariants : MessagePropertyVariants
    {
        public MachinePropertyVariants()
            : base(5, 201)
        {
        }
    }
}

