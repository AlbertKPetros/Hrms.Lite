﻿using System.Data;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.IRepository
{
    public interface ISqlConnectionProvider
    {
        Task<int> ExecuteNonQueryAsync(string sql, CommandType commandType);
        Task<int> ExecuteNonQueryAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
        int ExecuteNonQuery(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
        Task<DataSet> GetDataSetAsync(string storedProcedureName);
        Task<DataSet> GetDataSetAsync(string storedProcedureName, IDbDataParameter[] sqlParameters);
        Task<DataTable> GetDataTableAsync(string sql, CommandType commandType);
        Task<DataTable> GetDataTableAsync(string sql, IDbDataParameter[] sqlParameters, CommandType commandType);
    }
}