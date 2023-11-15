using System;
using System.Collections.Generic;

namespace FinalApp.Model
{
    public class ApiResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<NewsArticle> Articles { get; set; }
    }
}
