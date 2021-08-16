using System.Collections.Generic;

namespace MS.CommandQuery.Core.Enums
{
    public class LanguageDictionary 
    {
        public Dictionary<int, string> LanguageInfoDictionary { get; set; }

        public LanguageDictionary()
        {
            LanguageInfoDictionary = new Dictionary<int, string>()
        {
            {1, "Español"},
            {3, "Catalán"},
            {2, "English"}
        };
        }
    }
}
