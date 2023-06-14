using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilites
{
    public class PagedResults<T> where T : class
    {
        public PagedResults()
        {
            
        }

        public List<T> Results { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
