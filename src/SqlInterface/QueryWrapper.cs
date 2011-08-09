using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonEntities.Messages;

namespace SqlInterface
{
    public class QueryWrapper : IQueryWrapper
    {
        private readonly string _connectionString;
        private readonly string _queryString;

        public QueryWrapper(string connectionString, string queryString)
        {
            _connectionString = connectionString;
            _queryString = queryString; 
        }

        public IEnumerable<IFlatMessage> GetList(IMapMessages mapper)
        {
            SqlCommand command; 
            SqlDataReader reader;

            IEnumerable<IFlatMessage> returnValues = null;
            using (SqlConnection connection
                = new SqlConnection(_connectionString))
            {
                connection.Open();
                command = new SqlCommand(_queryString,
                                         connection);
                reader = command.ExecuteReader(); 
                returnValues = getList(mapper,reader);
                reader.Close();
                
            }
            return returnValues;
        }

        private static IEnumerable<IFlatMessage> getList(IMapMessages mapper, SqlDataReader reader)
        {
            var returnList = new List<IFlatMessage>();
            if(reader.HasRows)  
            {
                while(reader.Read())
                {
                    returnList.Add(mapper.Map(reader));
                } 
            }
            return returnList;
        } 
    }
}