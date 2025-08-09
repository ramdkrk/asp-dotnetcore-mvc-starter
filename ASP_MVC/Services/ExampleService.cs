using System.Collections.Generic;
using System.Threading.Tasks;
using ASP_MVC.Repositories;

namespace ASP_MVC.Services
{
    public sealed class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public Task<IReadOnlyList<string>> GetItemsAsync()
        {
            return _exampleRepository.GetItemsAsync();
        }
    }
}



