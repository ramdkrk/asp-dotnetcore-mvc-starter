using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_MVC.Repositories
{
    public interface IExampleRepository
    {
        Task<IReadOnlyList<string>> GetItemsAsync();
    }
}



