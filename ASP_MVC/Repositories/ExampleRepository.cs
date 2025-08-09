using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_MVC.Repositories
{
    public sealed class ExampleRepository : IExampleRepository
    {
        public Task<IReadOnlyList<string>> GetItemsAsync()
        {
            IReadOnlyList<string> items = new List<string> { "Alpha", "Beta", "Gamma" };
            return Task.FromResult(items);
        }
    }
}



