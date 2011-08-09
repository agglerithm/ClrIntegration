namespace MassTransitEmulator
{
    internal static class ValidationUtility
    {
        public static bool ValidateAccessControlEntryType(AccessControlEntryType value)
        {
            if (value >= AccessControlEntryType.Allow)
                return value <= AccessControlEntryType.Revoke;
            else
                return false;
        }

        public static bool ValidateCryptographicProviderType(CryptographicProviderType value)
        {
            if (value >= CryptographicProviderType.None)
                return value <= CryptographicProviderType.SttIss;
            else
                return false;
        }

        public static bool ValidateEncryptionAlgorithm(EncryptionAlgorithm value)
        {
            if (value != EncryptionAlgorithm.None && value != EncryptionAlgorithm.Rc2)
                return value == EncryptionAlgorithm.Rc4;
            else
                return true;
        }

        public static bool ValidateEncryptionRequired(EncryptionRequired value)
        {
            if (value >= EncryptionRequired.None)
                return value <= EncryptionRequired.Body;
            else
                return false;
        }

        public static bool ValidateHashAlgorithm(HashAlgorithm value)
        {
            if (value != HashAlgorithm.None && value != HashAlgorithm.Md2 && (value != HashAlgorithm.Md4 && value != HashAlgorithm.Md5) && value != HashAlgorithm.Sha)
                return value == HashAlgorithm.Mac;
            else
                return true;
        }

        public static bool ValidateMessageLookupAction(MessageLookupAction value)
        {
            if (value != MessageLookupAction.Current && value != MessageLookupAction.Next && (value != MessageLookupAction.Previous && value != MessageLookupAction.First))
                return value == MessageLookupAction.Last;
            else
                return true;
        }

        public static bool ValidateMessagePriority(MessagePriority value)
        {
            if (value >= MessagePriority.Lowest)
                return value <= MessagePriority.Highest;
            else
                return false;
        }

        public static bool ValidateMessageQueueTransactionType(MessageQueueTransactionType value)
        {
            if (value != MessageQueueTransactionType.None && value != MessageQueueTransactionType.Automatic)
                return value == MessageQueueTransactionType.Single;
            else
                return true;
        }

        public static bool ValidateQueueAccessMode(QueueAccessMode value)
        {
            if (value != QueueAccessMode.Send && value != QueueAccessMode.Peek && (value != QueueAccessMode.Receive && value != QueueAccessMode.PeekAndAdmin) && value != QueueAccessMode.ReceiveAndAdmin)
                return value == QueueAccessMode.SendAndReceive;
            else
                return true;
        }

        public static bool ValidateTrusteeType(TrusteeType trustee)
        {
            if (trustee >= TrusteeType.Unknown)
                return trustee <= TrusteeType.Computer;
            else
                return false;
        }
    }
}