using System;
using System.Collections;

namespace MassTransitEmulator
{
    [Serializable]
    public class MessageQueuePermissionEntryCollection : CollectionBase
    {
        private MessageQueuePermission owner;

        public MessageQueuePermissionEntry this[int index]
        {
            get
            {
                return (MessageQueuePermissionEntry)this.List[index];
            }
            set
            {
                this.List[index] = (object)value;
            }
        }

        internal MessageQueuePermissionEntryCollection(MessageQueuePermission owner)
        {
            this.owner = owner;
        }

        public int Add(MessageQueuePermissionEntry value)
        {
            return this.List.Add((object)value);
        }

        public void AddRange(MessageQueuePermissionEntry[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            else
            {
                for (int index = 0; index < value.Length; ++index)
                    this.Add(value[index]);
            }
        }

        public void AddRange(MessageQueuePermissionEntryCollection value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            else
            {
                int count = value.Count;
                for (int index = 0; index < count; ++index)
                    this.Add(value[index]);
            }
        }

        public bool Contains(MessageQueuePermissionEntry value)
        {
            return this.List.Contains((object)value);
        }

        public void CopyTo(MessageQueuePermissionEntry[] array, int index)
        {
            this.List.CopyTo((Array)array, index);
        }

        public int IndexOf(MessageQueuePermissionEntry value)
        {
            return this.List.IndexOf((object)value);
        }

        public void Insert(int index, MessageQueuePermissionEntry value)
        {
            this.List.Insert(index, (object)value);
        }

        public void Remove(MessageQueuePermissionEntry value)
        {
            this.List.Remove((object)value);
        }

        protected override void OnClear()
        {
            this.owner.Clear();
        }

        protected override void OnInsert(int index, object value)
        {
            this.owner.Clear();
        }

        protected override void OnRemove(int index, object value)
        {
            this.owner.Clear();
        }

        protected override void OnSet(int index, object oldValue, object newValue)
        {
            this.owner.Clear();
        }
    }
}