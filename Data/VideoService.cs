using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace BlazerServerDapperCRUD.Data
{
    public class VideoService : IVideoService
    {
        //Database connections
        private readonly SqlConnectionConfiguration _configuration;

        public VideoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Add a new video - sql insert
        public async Task<bool> VideoInsert(Video video)
        {
            using(var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Title", video.Title, DbType.String);
                parameters.Add("DatePublished", video.DatePublished, DbType.Date);
                parameters.Add("IsActive", video.IsActive, DbType.Boolean);

                //Raw sql method
                const string query = "INSERT INTO Video (Title, DatePublished, IsActive) VALUES (@Title, @DatePublished, @IsActive)";
                await conn.ExecuteAsync(query, new {video.Title, video.DatePublished, video.IsActive}, commandType: CommandType.Text);
            }

            return true;
        }
    }
}