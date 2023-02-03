using ShohinDesktopAdoNet.Models.DomainObjects.Entitys;
using ShohinDesktopAdoNet.Models.DomainObjects.InterfaceRepositorys;
using ShohinDesktopAdoNet.Models.DomainObjects.ShohinValueObjects;
using Microsoft.Data.SqlClient;
using ShohinDesktopAdoNet.Models.DomainObjects;

namespace ShohinDesktopAdoNet.Models.Repositorys
{
    public class ShohinRepository : IShohinRepository
    {
        private const string SHOHIN_TABLE = "shohins"; //"SHOHIN_DATA_DESK";
        private const string UNIQUE_ID = "unique_id"; //"UNIQUE_ID";
        private const string SHOHIN_CODE = "shohin_code"; //"SHOHIN_CODE";
        private const string SHOHIN_NAME = "shohin_name"; //"SHOHIN_NAME";
        private const string EDIT_DATE = "updated_on"; //"EDIT_DATE";
        private const string EDIT_TIME = "updated_at"; //"EDIT_TIME";
        private const string REMARKS = "remarks"; //"REMARKS";

        public ShohinEntity FindByUniqueId(UniqueId UniqueId)
        {
            using (var con = new SqlConnection(DbConfig.ConnectionString))
            {
                con.Open();
                using (var com = con.CreateCommand())
                {
                    com.CommandText = $"SELECT * FROM {SHOHIN_TABLE} WHERE {UNIQUE_ID} = @id";
                    com.Parameters.Add(new SqlParameter("@id", UniqueId.Value));
                    var reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        var code = (int)reader[SHOHIN_CODE];
                        var name = reader[SHOHIN_NAME] as string;
                        var date = (decimal)reader[EDIT_DATE];
                        var time = (decimal)reader[EDIT_TIME];
                        var note = reader[REMARKS] as string;
                        return new ShohinEntity(
                          UniqueId,
                          new ShohinCode(code),
                          new ShohinName(name),
                          new EditDateTime(new VoDate(date), new VoTime(time)),
                          new Remarks(note)
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public ShohinEntity FindByShohinCode(ShohinCode shohinCode)
        {
            using (var con = new SqlConnection(DbConfig.ConnectionString))
            {
                con.Open();
                using (var com = con.CreateCommand())
                {
                    com.CommandText = $"SELECT * FROM {SHOHIN_TABLE} WHERE {SHOHIN_CODE} = @code";
                    com.Parameters.Add(new SqlParameter("@code", shohinCode.Value));
                    var reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        var id = reader[UNIQUE_ID] as string;
                        var name = reader[SHOHIN_NAME] as string;
                        var date = (decimal)reader[EDIT_DATE];
                        var time = (decimal)reader[EDIT_TIME];
                        var note = reader[REMARKS] as string;

                        return new ShohinEntity(
                          new UniqueId(id),
                          shohinCode,
                          new ShohinName(name),
                          new EditDateTime(new VoDate(date), new VoTime(time)),
                          new Remarks(note)
                        );
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<ShohinEntity> FindAll()
        {
            using (var con = new SqlConnection(DbConfig.ConnectionString))
            {
                con.Open();
                using (var com = con.CreateCommand())
                {
                    com.CommandText = $"SELECT * FROM {SHOHIN_TABLE}";
                    var reader = com.ExecuteReader();
                    var results = new List<ShohinEntity>();
                    while (reader.Read())
                    {
                        var id = reader[UNIQUE_ID] as string;
                        var num = (int)reader[SHOHIN_CODE];
                        var name = reader[SHOHIN_NAME] as string;
                        var date = (decimal)reader[EDIT_DATE];
                        var time = (decimal)reader[EDIT_TIME];
                        var note = reader[REMARKS] as string;
                        var shohin = new ShohinEntity(
                          new UniqueId(id),
                          new ShohinCode(num),
                          new ShohinName(name),
                          new EditDateTime(new VoDate(date), new VoTime(time)),
                          new Remarks(note)
                        );
                        results.Add(shohin);
                    }
                    return results;
                }
            }
        }

        public void Save(ShohinEntity shohin)
        {
            using (var con = new SqlConnection(DbConfig.ConnectionString))
            {
                con.Open();

                bool isExist;
                using (var com = con.CreateCommand())
                {
                    com.CommandText = $"SELECT * FROM {SHOHIN_TABLE} WHERE {UNIQUE_ID} = @id";
                    com.Parameters.Add(new SqlParameter("@id", shohin.UniqueId.Value));
                    var reader = com.ExecuteReader();
                    isExist = reader.Read();
                    reader.Close();
                }

                using (var command = con.CreateCommand())
                {
                    command.CommandText = isExist
                      ? $"UPDATE {SHOHIN_TABLE} SET {SHOHIN_CODE} = @code, {SHOHIN_NAME} = @name, {EDIT_DATE} = @date, {EDIT_TIME} = @time, {REMARKS} = @note WHERE {UNIQUE_ID} = @id"
                      : $"INSERT INTO {SHOHIN_TABLE} VALUES (@id, @code, @name, @date, @time, @note)";
                    command.Parameters.Add(new SqlParameter("@id", shohin.UniqueId.Value));
                    command.Parameters.Add(new SqlParameter("@code", shohin.ShohinCode.Value));
                    command.Parameters.Add(new SqlParameter("@name", shohin.ShohinName.Value));
                    command.Parameters.Add(new SqlParameter("@date", shohin.EditDateTime.EditDate.Value));
                    command.Parameters.Add(new SqlParameter("@time", shohin.EditDateTime.EditTime.Value));
                    command.Parameters.Add(new SqlParameter("@note", shohin.Remarks.Value));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remove(ShohinEntity shohin)
        {
            using (var con = new SqlConnection(DbConfig.ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM {SHOHIN_TABLE} WHERE {UNIQUE_ID} = @id";
                    command.Parameters.Add(new SqlParameter("@id", shohin.UniqueId.Value));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}