using System;
using System.ComponentModel;
using System.Globalization;
using System.Security;
using System.Security.Permissions;
using MassTransitEmulator.NativeAccess;

namespace MassTransitEmulator
{
    public class MessageQueueCriteria
    {
        private static DateTime minDate = new DateTime(1970, 1, 1);
        private static DateTime maxDate = new DateTime(2038, 1, 19);
        private MessageQueueCriteria.CriteriaPropertyFilter filter = new MessageQueueCriteria.CriteriaPropertyFilter();
        private DateTime createdAfter;
        private DateTime createdBefore;
        private string label;
        private string machine;
        private DateTime modifiedAfter;
        private DateTime modifiedBefore;
        private Guid category;
        private Restrictions restrictions;
        private Guid machineId;

        public DateTime CreatedAfter
        {
            get
            {
                if (!this.filter.CreatedAfter)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.createdAfter;
            }
            set
            {
                if (value < MessageQueueCriteria.minDate || value > MessageQueueCriteria.maxDate)
                {
                    throw new ArgumentException(Res.GetString("InvalidDateValue", (object)MessageQueueCriteria.minDate.ToString((IFormatProvider)CultureInfo.CurrentCulture), (object)MessageQueueCriteria.maxDate.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
                }
                else
                {
                    this.createdAfter = value;
                    if (this.filter.CreatedBefore && this.createdAfter > this.createdBefore)
                        this.createdBefore = this.createdAfter;
                    this.filter.CreatedAfter = true;
                }
            }
        }

        public DateTime CreatedBefore
        {
            get
            {
                if (!this.filter.CreatedBefore)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.createdBefore;
            }
            set
            {
                if (value < MessageQueueCriteria.minDate || value > MessageQueueCriteria.maxDate)
                {
                    throw new ArgumentException(Res.GetString("InvalidDateValue", (object)MessageQueueCriteria.minDate.ToString((IFormatProvider)CultureInfo.CurrentCulture), (object)MessageQueueCriteria.maxDate.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
                }
                else
                {
                    this.createdBefore = value;
                    if (this.filter.CreatedAfter && this.createdAfter > this.createdBefore)
                        this.createdAfter = this.createdBefore;
                    this.filter.CreatedBefore = true;
                }
            }
        }

        internal bool FilterMachine
        {
            get
            {
                return this.filter.MachineName;
            }
        }

        public string Label
        {
            get
            {
                if (!this.filter.Label)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.label;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    this.label = value;
                    this.filter.Label = true;
                }
            }
        }

        public string MachineName
        {
            get
            {
                if (!this.filter.MachineName)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.machine;
            }
            set
            {
                if (!SyntaxCheck.CheckMachineName(value))
                {
                    throw new ArgumentException(Res.GetString("InvalidProperty", (object)"MachineName", (object)value));
                }
                else
                {
                    new MessageQueuePermission(PermissionState.Unrestricted).Assert();
                    try
                    {
                        this.machineId = MessageQueue.GetMachineId(value);
                    }
                    finally
                    {
                        CodeAccessPermission.RevertAssert();
                    }
                    this.machine = value;
                    this.filter.MachineName = true;
                }
            }
        }

        public DateTime ModifiedAfter
        {
            get
            {
                if (!this.filter.ModifiedAfter)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.modifiedAfter;
            }
            set
            {
                if (value < MessageQueueCriteria.minDate || value > MessageQueueCriteria.maxDate)
                {
                    throw new ArgumentException(Res.GetString("InvalidDateValue", (object)MessageQueueCriteria.minDate.ToString((IFormatProvider)CultureInfo.CurrentCulture), (object)MessageQueueCriteria.maxDate.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
                }
                else
                {
                    this.modifiedAfter = value;
                    if (this.filter.ModifiedBefore && this.modifiedAfter > this.modifiedBefore)
                        this.modifiedBefore = this.modifiedAfter;
                    this.filter.ModifiedAfter = true;
                }
            }
        }

        public DateTime ModifiedBefore
        {
            get
            {
                if (!this.filter.ModifiedBefore)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.modifiedBefore;
            }
            set
            {
                if (value < MessageQueueCriteria.minDate || value > MessageQueueCriteria.maxDate)
                {
                    throw new ArgumentException(Res.GetString("InvalidDateValue", (object)MessageQueueCriteria.minDate.ToString((IFormatProvider)CultureInfo.CurrentCulture), (object)MessageQueueCriteria.maxDate.ToString((IFormatProvider)CultureInfo.CurrentCulture)));
                }
                else
                {
                    this.modifiedBefore = value;
                    if (this.filter.ModifiedAfter && this.modifiedAfter > this.modifiedBefore)
                        this.modifiedAfter = this.modifiedBefore;
                    this.filter.ModifiedBefore = true;
                }
            }
        }

        internal Restrictions.MQRESTRICTION Reference
        {
            get
            {
                int maxRestrictions = 0;
                if (this.filter.CreatedAfter)
                    ++maxRestrictions;
                if (this.filter.CreatedBefore)
                    ++maxRestrictions;
                if (this.filter.Label)
                    ++maxRestrictions;
                if (this.filter.ModifiedAfter)
                    ++maxRestrictions;
                if (this.filter.ModifiedBefore)
                    ++maxRestrictions;
                if (this.filter.Category)
                    ++maxRestrictions;
                this.restrictions = new Restrictions(maxRestrictions);
                if (this.filter.CreatedAfter)
                    this.restrictions.AddI4(109, 2, this.ConvertTime(this.createdAfter));
                if (this.filter.CreatedBefore)
                    this.restrictions.AddI4(109, 1, this.ConvertTime(this.createdBefore));
                if (this.filter.Label)
                    this.restrictions.AddString(108, 4, this.label);
                if (this.filter.ModifiedAfter)
                    this.restrictions.AddI4(110, 2, this.ConvertTime(this.modifiedAfter));
                if (this.filter.ModifiedBefore)
                    this.restrictions.AddI4(110, 1, this.ConvertTime(this.modifiedBefore));
                if (this.filter.Category)
                    this.restrictions.AddGuid(102, 4, this.category);
                return this.restrictions.GetRestrictionsRef();
            }
        }

        public Guid Category
        {
            get
            {
                if (!this.filter.Category)
                    throw new InvalidOperationException(Res.GetString("CriteriaNotDefined"));
                else
                    return this.category;
            }
            set
            {
                this.category = value;
                this.filter.Category = true;
            }
        }

        static MessageQueueCriteria()
        {
        }

        public void ClearAll()
        {
            this.filter.ClearAll();
        }

        private int ConvertTime(DateTime time)
        {
            time = time.ToUniversalTime();
            return (int)(time - MessageQueueCriteria.minDate).TotalSeconds;
        }

        private class CriteriaPropertyFilter
        {
            public bool CreatedAfter;
            public bool CreatedBefore;
            public bool Label;
            public bool MachineName;
            public bool ModifiedAfter;
            public bool ModifiedBefore;
            public bool Category;

            public void ClearAll()
            {
                this.CreatedAfter = false;
                this.CreatedBefore = false;
                this.Label = false;
                this.MachineName = false;
                this.ModifiedAfter = false;
                this.ModifiedBefore = false;
                this.Category = false;
            }
        }
    }
}