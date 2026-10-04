using System.Collections.Generic;
using PagedList;

namespace _25DH110475_MyStore.Models.ViewModel
{
    public class SearchProductVM
    {
        public string SearchString { get; set; }

        public IPagedList<Product> Products { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}