using kaitoss.Data.Models;

namespace kaitoss.ViewModel
{
    public class IndexVM
    {
        public List<Blog> Blogs { get; set; }
        public List<kaitoss.Data.Models.Services> Services { get; set; }
        public Settings Settings { get; set; }
        public ContactUs ContactUs { get; set; }

    }
}
