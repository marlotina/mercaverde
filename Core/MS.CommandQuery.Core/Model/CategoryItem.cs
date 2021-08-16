namespace MS.CommandQuery.Core.Model
{
    public class CategoryItem
    {
        public int IdCategory { get; set; }

        public int? ParentCategoryId { get; set; }

        public string Name { get; set; }
    }
}
