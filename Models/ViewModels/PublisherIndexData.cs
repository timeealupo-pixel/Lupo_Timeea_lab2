using Lupo_Timeea_lab2.Models;

namespace Lupo_Timeea_lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }

}