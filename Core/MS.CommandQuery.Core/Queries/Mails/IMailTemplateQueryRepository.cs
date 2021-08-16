using MS.CommandQuery.Core.Enums;
using MS.CommandQuery.Core.Model;

namespace MS.CommandQuery.Core.Queries.Mails
{
    public interface IMailTemplateQueryRepository
    {
        EmailTemplateItem GetMailTemplateByLanguageId(EnumMailTemplate mailTemplate, int languageId);
    }
}
