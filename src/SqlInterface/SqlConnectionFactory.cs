using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonEntities.Messages;

namespace SqlInterface
{ 
    public class SqlConnectionFactory
    {

        public static IEnumerable<IFlatMessage> GetInsertedRecords(IQueryWrapper query, IMapMessages mapper)  
        {
            return query.GetList(mapper);
 
        } 
    }
} 
