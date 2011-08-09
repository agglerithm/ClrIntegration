using System.Collections.Generic;
using cjrCommon.Messages;

namespace SqlInterface
{
    public interface IQueryWrapper
    {
        IEnumerable<IFlatMessage> GetList(IMapMessages mapper);
    }
}