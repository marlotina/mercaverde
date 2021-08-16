using System.Linq;
using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Model;
using MS.CommandQuery.Core.Queries.Mails;
using MS.CommandQuery.Infrastructure.DbContexts;

namespace MS.CommandQuery.Infrastructure.QueryRepositories.Mails
{
    public class MailTemplateQueryRepository : QueryBase, IMailTemplateQueryRepository
    {
        public MailTemplateQueryRepository(IMsContext context)
            : base(context)
        {
        }

        public EmailTemplateItem GetMailTemplateByLanguageId(EnumMailTemplate mailTemplate, int languageId)
        {
            const string query = "EXEC spGetMailTeamplateByLanguageId @IdMailTemplate = {0},  @LanguageId = {1}";

            string qlQuery = string.Format(query, (int) mailTemplate, languageId);
            var template = Context.Database.SqlQuery<EmailTemplateItem>(qlQuery).FirstOrDefault();

            return template;
        }
    }
}