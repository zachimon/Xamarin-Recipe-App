using System;
using System.Collections.Generic;

namespace LoginNavigation
{
    public class RecipeDetails
    {
        public string publisher { get; set; }
        public string f2f_url { get; set; }
        public List<string> ingredients { get; set; }
        public string source_url { get; set; }
        public string recipe_id { get; set; }
        public string image_url { get; set; }
        public double social_rank { get; set; }
        public string publisher_url { get; set; }
        public string title { get; set; }
    }

    public class RecipeDetail
    {
        public RecipeDetails recipe { get; set; }
    }
}
