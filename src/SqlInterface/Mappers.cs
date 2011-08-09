using System.Data.SqlClient;
using cjrCommon.Extensions;
using cjrCommon.Messages;
using CommonEntities.Extensions;
using CommonEntities.Messages;

namespace SqlInterface
{
    public class ArOpenReceiptsDeletedMessageMapper : IMapMessages
    {
        public IFlatMessage Map(SqlDataReader reader)
        {
            return new ReportArOpenReceiptsDeletedMessage(reader[0].CastToInt());
        }
    }

    public class ArOpenReceiptsUpdatedMessageMapper : IMapMessages 
    { 
        public IFlatMessage Map(SqlDataReader reader)  
        {
 
            return  new ReportArOpenReceiptsUpdatedMessage(reader[1].ToString(), reader[2].ToString(),
                                                               reader[3].ToString(), reader[4].ToString(),
                                                               (decimal)reader[5], (decimal)reader[6],
                                                               reader[7].ToString(), reader[8].ToString(),
                                                               reader[9].CastToDateTime(), reader[11].ToString());
        }
    }
}
