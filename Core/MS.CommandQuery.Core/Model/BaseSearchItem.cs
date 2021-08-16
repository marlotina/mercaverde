namespace MS.CommandQuery.Core.Model
{
    public class BaseSearchItem
    {
        public int NumItems { get; set; }

        public int StartItem { get; set; }

        public int TotalItems { get; set; }

        public int NumPages
        {
            get
            {
                return TotalItems/NumItems;
            }
        }
    }
}
