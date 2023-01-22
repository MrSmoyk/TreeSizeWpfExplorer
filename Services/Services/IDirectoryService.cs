using Services.Models;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IDirectoryService
    {
        Task<BaseEntyty> GetAllEntytys(string path);
    }
}
