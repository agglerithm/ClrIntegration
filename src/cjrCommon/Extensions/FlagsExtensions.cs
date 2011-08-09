namespace cjrCommon.Extensions
{
#pragma warning disable 1591
    public static class FlagsExtensions
    {
        public static bool Contains(this long flags, long flag)
        {
            return (flag & flags) == flag;
        }
    }
}
