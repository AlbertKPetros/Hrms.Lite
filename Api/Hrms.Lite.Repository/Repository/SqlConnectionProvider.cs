using Hrms.Lite.Repository.IRepository;
using Hrms.Lite.Shared.General;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.Repository
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly string _sqlConnection;

        public SqlConnectionProvider(IOptions<AppSettings> settings)
        {
            _sqlConnection = settings.Value.ConnectionStrings.DefaultConnection;
        }

        public int ExecuteNonQuery(string sql, IDbDataParameter[] sqlParameters, CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);
                int result = cmd.ExecuteNonQuery();
                return result;
            }

            ;
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;

                int result = await cmd.ExecuteNonQueryAsync();
                return result;
            }

            ;
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, IDbDataParameter[] sqlParameters,
            CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);

                int result = await cmd.ExecuteNonQueryAsync();
                return result;
            }

            ;
        }

        public async Task<DataSet> GetDataSetAsync(string storedProcedureName)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                DataSet ds = new DataSet();

                await Task.Run(() =>
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                });

                return ds;
            }

            ;
        }

        public async Task<DataSet> GetDataSetAsync(string storedProcedureName, IDbDataParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                DataSet ds = new DataSet();

                await Task.Run(() =>
                {
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                });

                return ds;
            }

            ;
        }

        public async Task<DataTable> GetDataTableAsync(string sql, CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                DataTable dt = new DataTable();

                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();


                dt.Load(rdr);
                return dt;
            }

            ;
        }

        public async Task<DataTable> GetDataTableAsync(string sql, IDbDataParameter[] sqlParameters,
            CommandType commandType)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection);
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                DataTable dt = new DataTable();

                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(sqlParameters);

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();


                dt.Load(rdr);
                return dt;
            }

            ;
        }
    }
}