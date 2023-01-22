using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreFundamentalsDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;

        public IndexModel(ILogger<IndexModel> logger,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton)
        {
            _logger = logger;
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
        }

        public void OnGet()
        {
            _logger.LogInformation($"Transient: {_operationTransient.OperationId}");
            _logger.LogInformation($"Scoped: {_operationScoped.OperationId}");
            _logger.LogInformation($"Singleton: {_operationSingleton.OperationId}");
        }
    }
}