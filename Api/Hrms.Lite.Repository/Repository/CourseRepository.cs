using Hrms.Lite.Infrastructure.Helpers;
using Hrms.Lite.Repository.IRepository;
using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ISqlConnectionProvider _sql;

        public CourseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<IList<Course>> GetList()
        {
            return PopulateList(await _sql.GetDataTableAsync("ADMIN.SP_COURSE_LIST", CommandType.StoredProcedure));
        }

        public async Task<Course> GetDetails(Guid guid)
        {
            IDbDataParameter[] sqlParameters = { new SqlParameter("@guid", guid) };
            return PopulateDetails(await _sql.GetDataTableAsync("ADMIN.SP_COURSE_DETAILS", sqlParameters,
                CommandType.StoredProcedure));
        }

        public async Task<ResponseEntity> Save(Course input)
        {
            SqlParameter ResponseMessage = new SqlParameter
            {
                ParameterName = "@responseMessage",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };
            SqlParameter ResponseStatus = new SqlParameter
            {
                ParameterName = "@responseStatus",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA", JsonConvert.SerializeObject(input)), ResponseMessage, ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("ADMIN.SP_COURSE_SAVE", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseMessage.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

        public async Task<ResponseEntity> Delete(Guid guid)
        {
            SqlParameter ResponseMessage = new SqlParameter
            {
                ParameterName = "@responseMessage",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };
            SqlParameter ResponseStatus = new SqlParameter
            {
                ParameterName = "@responseStatus",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter
                {
                    DbType = DbType.Guid,
                    ParameterName = "@guid",
                    Direction = ParameterDirection.Input
                }
            };
            await _sql.ExecuteNonQueryAsync("ADMIN.SP_COURSE_DELETE", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseMessage.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

        private IList<Course> PopulateList(DataTable dt)
        {
            var list = new List<Course>();
            if ((dt?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Course item = new Course
                    {
                        UniqueID = MakeSafe.ToSafeGuid(row["GuId"]),
                        Name = MakeSafe.ToSafeString(row["Name"])
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        private Course PopulateDetails(DataTable dt)
        {
            var item = new Course();
            DataRow row = dt.Rows[0];
            if ((dt.Rows?.Count ?? 0) > 0)
            {
                item.UniqueID = MakeSafe.ToSafeGuid(row["GuId"]);
                item.Name = MakeSafe.ToSafeString(row["Name"]);
                return item;
            }
            return null;
        }

    }
}