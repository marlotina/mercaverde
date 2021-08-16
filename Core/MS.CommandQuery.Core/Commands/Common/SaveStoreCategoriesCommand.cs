using System.Collections.Generic;
using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Common
{
    public class SaveStoreCategoriesCommand : ICommand
    {
        public int IdStore { get; set; }

        public List<int> CategoryList { get; set; }
    }
}
