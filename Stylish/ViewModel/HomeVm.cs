using Stylish.Models;

namespace Stylish.ViewModel
{
    public class HomeVm
    {
        public Banner Banner { get; set; }
        public About  About { get; set; }
        public List<Service> Services { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public Callout Callout { get; set; }

    }
}
