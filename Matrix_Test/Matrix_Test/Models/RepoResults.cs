using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix_Test.Models
{
    public class RepoResults
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
}