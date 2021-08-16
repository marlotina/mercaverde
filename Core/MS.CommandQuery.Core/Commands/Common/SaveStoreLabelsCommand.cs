using System.Collections.Generic;
using MS.CommandQuery.Core.Base;

namespace MS.CommandQuery.Core.Commands.Common
{
    public class SaveStoreLabelsCommand : ICommand
    {
        public int IdStore { get; set; }

        public List<int> LabeList { get; set; }
    }
}
