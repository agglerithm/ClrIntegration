using System;
using System.ComponentModel;

namespace MassTransitEmulator
{
    [Serializable]
    public class MessageQueuePermissionEntry
    {
        private string label;
        private string machineName;
        private string path;
        private string category;
        private MessageQueuePermissionAccess permissionAccess;

        public string Category
        {
            get
            {
                return this.category;
            }
        }

        public string Label
        {
            get
            {
                return this.label;
            }
        }

        public string MachineName
        {
            get
            {
                return this.machineName;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }
        }

        public MessageQueuePermissionAccess PermissionAccess
        {
            get
            {
                return this.permissionAccess;
            }
        }

        public MessageQueuePermissionEntry(MessageQueuePermissionAccess permissionAccess, string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            else if (path != "*" && !MessageQueue.ValidatePath(path, false))
            {
                throw new ArgumentException(Res.GetString("PathSyntax"));
            }
            else
            {
                this.path = path;
                this.permissionAccess = permissionAccess;
            }
        }

        public MessageQueuePermissionEntry(MessageQueuePermissionAccess permissionAccess, string machineName, string label, string category)
        {
            if (machineName == null && label == null && category == null)
                throw new ArgumentNullException("machineName");
            else if (machineName != null && !SyntaxCheck.CheckMachineName(machineName))
            {
                throw new ArgumentException( string.Format("InvalidParameter: MachineName,{0}", machineName));
            }
            else
            {
                this.permissionAccess = permissionAccess;
                this.machineName = machineName;
                this.label = label;
                this.category = category;
            }
        }
    }
}