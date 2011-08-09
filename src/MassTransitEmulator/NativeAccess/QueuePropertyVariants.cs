namespace MassTransitEmulator.NativeAccess
{
    internal class QueuePropertyVariants : MessagePropertyVariants
    {
        private const int MAX_QUEUE_PROPERTY_INDEX = 26;

        public QueuePropertyVariants()
            : base(MAX_QUEUE_PROPERTY_INDEX, 101)
        {
        }
    }
}