using System;
using System.Collections;
using System.Globalization;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace MassTransitEmulator
{
    [Serializable]
    public sealed class MessageQueuePermission : CodeAccessPermission, IUnrestrictedPermission
    {
        internal const string Any = "*";
        internal Hashtable resolvedFormatNames;
        internal MessageQueuePermissionEntryCollection innerCollection;
        internal bool isUnrestricted;

        public MessageQueuePermissionEntryCollection PermissionEntries
        {
            get
            {
                if (this.innerCollection == null)
                {
                    if (this.resolvedFormatNames == null)
                    {
                        this.innerCollection = new MessageQueuePermissionEntryCollection(this);
                    }
                    else
                    {
                        Hashtable hashtable = this.resolvedFormatNames;
                        this.innerCollection = new MessageQueuePermissionEntryCollection(this);
                        foreach (string str in (IEnumerable)hashtable.Keys)
                        {
                            string path = !(str == "*") ? "FORMATNAME:" + str : "*";
                            this.innerCollection.Add(new MessageQueuePermissionEntry((MessageQueuePermissionAccess)hashtable[(object)str], path));
                        }
                    }
                }
                return this.innerCollection;
            }
        }

        public MessageQueuePermission()
        {
        }

        public MessageQueuePermission(PermissionState state)
        {
            if (state == PermissionState.Unrestricted)
                this.isUnrestricted = true;
            else
                this.isUnrestricted = false;
        }

        public MessageQueuePermission(MessageQueuePermissionAccess permissionAccess, string path)
        {
            this.PermissionEntries.Add(new MessageQueuePermissionEntry(permissionAccess, path));
        }

        public MessageQueuePermission(MessageQueuePermissionAccess permissionAccess, string machineName, string label, string category)
        {
            this.PermissionEntries.Add(new MessageQueuePermissionEntry(permissionAccess, machineName, label, category));
        }

        public MessageQueuePermission(MessageQueuePermissionEntry[] permissionAccessEntries)
        {
            if (permissionAccessEntries == null)
                throw new ArgumentNullException("permissionAccessEntries");
            else
                this.PermissionEntries.AddRange(permissionAccessEntries);
        }

        private static IEqualityComparer GetComparer()
        {
            return (IEqualityComparer)StringComparer.InvariantCultureIgnoreCase;
        }

        internal void Clear()
        {
            this.resolvedFormatNames = (Hashtable)null;
        }

        public override IPermission Copy()
        {
            MessageQueuePermission messageQueuePermission = new MessageQueuePermission();
            messageQueuePermission.isUnrestricted = this.isUnrestricted;
            foreach (MessageQueuePermissionEntry queuePermissionEntry in (CollectionBase)this.PermissionEntries)
                messageQueuePermission.PermissionEntries.Add(queuePermissionEntry);
            messageQueuePermission.resolvedFormatNames = this.resolvedFormatNames;
            return (IPermission)messageQueuePermission;
        }

        public override void FromXml(SecurityElement securityElement)
        {
            this.PermissionEntries.Clear();
            string strA = securityElement.Attribute("Unrestricted");
            if (strA != null && string.Compare(strA, "true", true, CultureInfo.InvariantCulture) == 0)
                this.isUnrestricted = true;
            else if (securityElement.Children != null)
            {
                for (int index = 0; index < securityElement.Children.Count; ++index)
                {
                    SecurityElement securityElement1 = (SecurityElement)securityElement.Children[index];
                    string str1 = securityElement1.Attribute("access");
                    int num = 0;
                    if (str1 != null)
                    {
                        string str2 = str1;
                        char[] chArray = new char[1]
                                             {
                                                 '|'
                                             };
                        foreach (string str3 in str2.Split(chArray))
                        {
                            string str4 = str3.Trim();
                            if (Enum.IsDefined(typeof(MessageQueuePermissionAccess), (object)str4))
                                num |= (int)Enum.Parse(typeof(MessageQueuePermissionAccess), str4);
                        }
                    }
                    MessageQueuePermissionEntry queuePermissionEntry;
                    if (securityElement1.Tag == "Path")
                    {
                        string path = securityElement1.Attribute("value");
                        if (path == null)
                            throw new InvalidOperationException(Res.GetString("InvalidXmlFormat"));
                        else
                            queuePermissionEntry = new MessageQueuePermissionEntry((MessageQueuePermissionAccess)num, path);
                    }
                    else if (securityElement1.Tag == "Criteria")
                    {
                        string label = securityElement1.Attribute("label");
                        string category = securityElement1.Attribute("category");
                        string machineName = securityElement1.Attribute("machine");
                        if (machineName == null && label == null && category == null)
                            throw new InvalidOperationException(Res.GetString("InvalidXmlFormat"));
                        else
                            queuePermissionEntry = new MessageQueuePermissionEntry((MessageQueuePermissionAccess)num, machineName, label, category);
                    }
                    else
                        throw new InvalidOperationException(Res.GetString("InvalidXmlFormat"));
                    this.PermissionEntries.Add(queuePermissionEntry);
                }
            }
        }

        public override IPermission Intersect(IPermission target)
        {
            if (target == null)
                return (IPermission)null; 
            if (!(target is MessageQueuePermission))
            {
                throw new ArgumentException( "InvalidParameter: target" + target);
            }

            MessageQueuePermission messageQueuePermission1 = (MessageQueuePermission)target;
            if (this.IsUnrestricted())
                return messageQueuePermission1.Copy();
            if (messageQueuePermission1.IsUnrestricted())
            {
                return this.Copy();
            }  
            this.ResolveFormatNames();
            messageQueuePermission1.ResolveFormatNames();
            MessageQueuePermission messageQueuePermission2 = new MessageQueuePermission();
            Hashtable hashtable1 = new Hashtable(MessageQueuePermission.GetComparer());
            messageQueuePermission2.resolvedFormatNames = hashtable1;
            IDictionaryEnumerator enumerator;
            Hashtable hashtable2;
            if (this.resolvedFormatNames.Count < messageQueuePermission1.resolvedFormatNames.Count)
            {
                enumerator = this.resolvedFormatNames.GetEnumerator();
                hashtable2 = messageQueuePermission1.resolvedFormatNames;
            }
            else
            {
                enumerator = messageQueuePermission1.resolvedFormatNames.GetEnumerator();
                hashtable2 = this.resolvedFormatNames;
            }
            while (enumerator.MoveNext())
            {
                if (hashtable2.ContainsKey(enumerator.Key))
                {
                    string str = (string)enumerator.Key;
                    MessageQueuePermissionAccess permissionAccess1 = (MessageQueuePermissionAccess)enumerator.Value;
                    MessageQueuePermissionAccess permissionAccess2 = (MessageQueuePermissionAccess)hashtable2[(object)str];
                    hashtable1.Add((object)str, (object)(permissionAccess1 & permissionAccess2));
                }
            }
            return (IPermission)messageQueuePermission2;
 
        } 

        public override bool IsSubsetOf(IPermission target)
        {
            if (target == null)
                return false;
            if (!(target is MessageQueuePermission))
            {
                throw new ArgumentException("InvalidParameter: target" + target.ToString());
            } 
            {
                MessageQueuePermission messageQueuePermission = (MessageQueuePermission)target;
                if (messageQueuePermission.IsUnrestricted())
                    return true;
                else if (this.IsUnrestricted())
                {
                    return false;
                }
                else
                {
                    this.ResolveFormatNames();
                    messageQueuePermission.ResolveFormatNames();
                    if (this.resolvedFormatNames.Count == 0 && messageQueuePermission.resolvedFormatNames.Count != 0 || this.resolvedFormatNames.Count != 0 && messageQueuePermission.resolvedFormatNames.Count == 0)
                        return false;
                    else if (messageQueuePermission.resolvedFormatNames.ContainsKey((object)"*"))
                    {
                        MessageQueuePermissionAccess permissionAccess1 = (MessageQueuePermissionAccess)messageQueuePermission.resolvedFormatNames[(object)"*"];
                        IDictionaryEnumerator enumerator = this.resolvedFormatNames.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            MessageQueuePermissionAccess permissionAccess2 = (MessageQueuePermissionAccess)enumerator.Value;
                            if ((permissionAccess2 & permissionAccess1) != permissionAccess2)
                                return false;
                        }
                        return true;
                    }
                    else
                    {
                        IDictionaryEnumerator enumerator = this.resolvedFormatNames.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            string str = (string)enumerator.Key;
                            if (!messageQueuePermission.resolvedFormatNames.ContainsKey((object)str))
                            {
                                return false;
                            }
                            else
                            {
                                MessageQueuePermissionAccess permissionAccess1 = (MessageQueuePermissionAccess)enumerator.Value;
                                MessageQueuePermissionAccess permissionAccess2 = (MessageQueuePermissionAccess)messageQueuePermission.resolvedFormatNames[(object)str];
                                if ((permissionAccess1 & permissionAccess2) != permissionAccess1)
                                    return false;
                            }
                        }
                        return true;
                    }
                }
            }
        }

        public bool IsUnrestricted()
        {
            return this.isUnrestricted;
        }

        internal void ResolveFormatNames()
        {
            if (this.resolvedFormatNames == null)
            {
                this.resolvedFormatNames = new Hashtable(MessageQueuePermission.GetComparer());
                foreach (MessageQueuePermissionEntry queuePermissionEntry in (CollectionBase)this.PermissionEntries)
                {
                    if (queuePermissionEntry.Path != null)
                    {
                        if (queuePermissionEntry.Path == "*")
                        {
                            this.resolvedFormatNames.Add((object)"*", (object)queuePermissionEntry.PermissionAccess);
                        }
                        else
                        {
                            try
                            {
                                this.resolvedFormatNames.Add((object)new MessageQueue(queuePermissionEntry.MachineName, queuePermissionEntry.Path).FormatName, (object)queuePermissionEntry.PermissionAccess);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            MessageQueueCriteria criteria = new MessageQueueCriteria();
                            if (queuePermissionEntry.MachineName != null)
                                criteria.MachineName = queuePermissionEntry.MachineName;
                            if (queuePermissionEntry.Category != null)
                                criteria.Category = new Guid(queuePermissionEntry.Category);
                            if (queuePermissionEntry.Label != null)
                                criteria.Label = queuePermissionEntry.Label;
                            IEnumerator enumerator = (IEnumerator)MessageQueue.GetMessageQueueEnumerator(criteria, false);
                            while (enumerator.MoveNext())
                                this.resolvedFormatNames.Add((object)((MessageQueue)enumerator.Current).FormatName, (object)queuePermissionEntry.PermissionAccess);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        public override SecurityElement ToXml()
        {
            SecurityElement securityElement = new SecurityElement("IPermission");
            Type type = this.GetType();
            securityElement.AddAttribute("class", type.FullName + ", " + type.Module.Assembly.FullName.Replace('"', '\''));
            securityElement.AddAttribute("version", "1");
            if (this.isUnrestricted)
            {
                securityElement.AddAttribute("Unrestricted", "true");
                return securityElement;
            }
            else
            {
                foreach (MessageQueuePermissionEntry queuePermissionEntry1 in (CollectionBase)this.PermissionEntries)
                {
                    MessageQueuePermissionEntry queuePermissionEntry2 = queuePermissionEntry1;
                    SecurityElement child;
                    if (queuePermissionEntry2.Path != null)
                    {
                        child = new SecurityElement("Path");
                        child.AddAttribute("value", queuePermissionEntry2.Path);
                    }
                    else
                    {
                        child = new SecurityElement("Criteria");
                        if (queuePermissionEntry2.MachineName != null)
                            child.AddAttribute("machine", queuePermissionEntry2.MachineName);
                        if (queuePermissionEntry2.Category != null)
                            child.AddAttribute("category", queuePermissionEntry2.Category);
                        if (queuePermissionEntry2.Label != null)
                            child.AddAttribute("label", queuePermissionEntry2.Label);
                    }
                    int num = (int)queuePermissionEntry2.PermissionAccess;
                    if (num != 0)
                    {
                        StringBuilder stringBuilder = (StringBuilder)null;
                        int[] numArray = (int[])Enum.GetValues(typeof(MessageQueuePermissionAccess));
                        //Array.Sort((Array)numArray, (IComparer)InvariantComparer.Default);
                        for (int index = numArray.Length - 1; index >= 0; --index)
                        {
                            if (numArray[index] != 0 && (num & numArray[index]) == numArray[index])
                            {
                                if (stringBuilder == null)
                                    stringBuilder = new StringBuilder();
                                else
                                    stringBuilder.Append("|");
                                stringBuilder.Append(Enum.GetName(typeof(MessageQueuePermissionAccess), (object)numArray[index]));
                                num &= numArray[index] ^ numArray[index];
                            }
                        }
                        child.AddAttribute("access", ((object)stringBuilder).ToString());
                    }
                    securityElement.AddChild(child);
                }
                return securityElement;
            }
        }

        public override IPermission Union(IPermission target)
        {
            if (target == null)
                return this.Copy();
            else if (!(target is MessageQueuePermission))
            {
                throw new ArgumentException(Res.GetString("InvalidParameter", (object)"target", (object)target.ToString()));
            }
            else
            {
                MessageQueuePermission messageQueuePermission1 = (MessageQueuePermission)target;
                MessageQueuePermission messageQueuePermission2 = new MessageQueuePermission();
                if (this.IsUnrestricted() || messageQueuePermission1.IsUnrestricted())
                {
                    messageQueuePermission2.isUnrestricted = true;
                    return (IPermission)messageQueuePermission2;
                }
                else
                {
                    Hashtable hashtable = new Hashtable(MessageQueuePermission.GetComparer());
                    this.ResolveFormatNames();
                    messageQueuePermission1.ResolveFormatNames();
                    IDictionaryEnumerator enumerator1 = this.resolvedFormatNames.GetEnumerator();
                    IDictionaryEnumerator enumerator2 = messageQueuePermission1.resolvedFormatNames.GetEnumerator();
                    while (enumerator1.MoveNext())
                        hashtable[(object)(string)enumerator1.Key] = enumerator1.Value;
                    while (enumerator2.MoveNext())
                    {
                        if (!hashtable.ContainsKey(enumerator2.Key))
                        {
                            hashtable[enumerator2.Key] = enumerator2.Value;
                        }
                        else
                        {
                            MessageQueuePermissionAccess permissionAccess = (MessageQueuePermissionAccess)hashtable[enumerator2.Key];
                            hashtable[enumerator2.Key] = (object)(permissionAccess | (MessageQueuePermissionAccess)enumerator2.Value);
                        }
                    }
                    messageQueuePermission2.resolvedFormatNames = hashtable;
                    return (IPermission)messageQueuePermission2;
                }
            }
        }
    }
}