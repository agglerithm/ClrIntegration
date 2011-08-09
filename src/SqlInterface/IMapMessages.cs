using System.Data.SqlClient;
using cjrCommon.Messages;

namespace SqlInterface
{
    public interface IMapMessages
    {
        IFlatMessage Map(SqlDataReader reader) ;
    }
}