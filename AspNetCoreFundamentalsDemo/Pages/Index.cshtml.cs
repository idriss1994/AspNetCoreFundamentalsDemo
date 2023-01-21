using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreFundamentalsDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMyDependency _myDependency;

        public IndexModel(ILogger<IndexModel> logger, IMyDependency myDependency)
        {
            _logger = logger;
            _myDependency = myDependency;
        }

        public void OnGet()
        {
            _myDependency.WriteMessage("IndexModel.OnGet handler");
        }
    }
}