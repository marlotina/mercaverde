namespace MS.Web.Models
{
    public class Search
    {
        public class Filter : PaginationFilter
        {
            public int IdLocation { get; set; }

            public string LocationName { get; set; }

            public int[] DistrictsList { get; set; }

            public int[] CategoryList { get; set; }

            public int[] LabelList { get; set; }

            public int Order { get; set; }
        }

        public class PaginationFilter
        {
            public int StartItem { get; set; }

            public int NumItems  { get; set; }

            public int LanguageId { get; set; }
        }
    }
}