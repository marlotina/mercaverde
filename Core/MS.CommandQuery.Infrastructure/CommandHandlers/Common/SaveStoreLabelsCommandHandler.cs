using System.Linq;
using MS.CommandQuery.Core.Base;
using MS.CommandQuery.Core.Commands.Common;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.CommandHandlers.Common
{
    public class SaveStoreLabelsCommandHandler : ICommandHandler<SaveStoreLabelsCommand>
    {
        private readonly IMsContext _context;

        public SaveStoreLabelsCommandHandler(IMsContext context)
        {
            _context = context;
        }

        public void Handle(object commandObj)
        {
            var command = (SaveStoreLabelsCommand)commandObj;

            var store = _context.Store.FirstOrDefault(s => s.IdStore == command.IdStore);
            if (store != null)
            {
                var storeLabels = store.Labels;

                foreach (var label in storeLabels.ToList())
                {
                    if (!command.LabeList.Contains(label.IdLabel))
                    {
                        storeLabels.Remove(label);
                    }
                }

                foreach (var label in command.LabeList)
                {
                    if (storeLabels.All(l => l.IdLabel != label))
                    {
                        storeLabels.Add(_context.Label.FirstOrDefault(l => l.IdLabel == label));
                    }
                } 
            }

            _context.SaveChanges();
        }
    }
}
