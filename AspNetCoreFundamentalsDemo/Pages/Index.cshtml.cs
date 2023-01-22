using AspNetCoreFundamentalsDemo.Services;
using AspNetCoreFundamentalsDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreFundamentalsDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Service1 service1;
        private readonly Service2 service2;
        private readonly IService3 service3;

        public IndexModel(ILogger<IndexModel> logger, Service1 service1, Service2 service2, IService3 service3)
        {
            _logger = logger;
            this.service1 = service1;
            this.service2 = service2;
            this.service3 = service3;
        }

        public void OnGet()
        {
            service1.Write("IndexModel.OnGet");
            service2.Write("IndexModel.OnGet");
            service3.Write("IndexModel.OnGet");
        }
    }
}