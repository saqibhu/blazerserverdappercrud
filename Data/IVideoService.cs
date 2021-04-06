using System.Threading.Tasks;

namespace BlazerServerDapperCRUD.Data
{
    public interface IVideoService
    {
        Task<bool> VideoInsert(Video video);
    }
}