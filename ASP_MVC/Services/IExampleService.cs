using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_MVC.Services
{
    public interface IExampleService
    {
        Task<IReadOnlyList<string>> GetItemsAsync();
    }
}



