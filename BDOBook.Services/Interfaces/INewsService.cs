using BDOBook.Services.Responses;
using System.Threading.Tasks;

namespace BDOBook.Services.Interfaces
{
    public interface INewsService
    {
        Task<GetMostRecentResponse> GetMostRecent();
    }
}
