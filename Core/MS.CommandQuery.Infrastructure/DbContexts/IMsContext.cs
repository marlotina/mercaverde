using System.Data.Entity;
using MS.CommandQuery.Core.Entities;
using MS.CommandQuery.Core.Entities.Tasks;
using MS.CommandQuery.Core.Entities.Users;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Location;
using MS.CommandQuery.Core.Entities.Product;

namespace MS.CommandQuery.Infrastructure.DbContexts
{
    public interface IMsContext
    {
        IDbSet<C__RefactorLog> C__RefactorLog { get; set; }
        //IDbSet<Brand> Brand { get; set; }
        //IDbSet<BrandComment> BrandComment { get; set; }
        //IDbSet<BrandDescription> BrandDescription { get; set; }
        //IDbSet<BrandImage> BrandImage { get; set; }
        IDbSet<Category> Category { get; set; }
        IDbSet<CategoryLanguage> CategoryLanguage { get; set; }
        IDbSet<City> City { get; set; }
        IDbSet<CityLanguage> CityLanguage { get; set; }
        IDbSet<Country> Country { get; set; }
        IDbSet<CountryLanguage> CountryLanguage { get; set; }
        IDbSet<District> District { get; set; }
        IDbSet<TaskProcess> ExtranetTaskProcess { get; set; }
        IDbSet<Label> Label { get; set; }
        IDbSet<LabelLanguage> LabelLanguage { get; set; }
        IDbSet<Language> Language { get; set; }
        IDbSet<Post> Post { get; set; }
        IDbSet<PostComment> PostComment { get; set; }
        IDbSet<Store> Store { get; set; }
        IDbSet<StoreComment> StoreComment { get; set; }
        IDbSet<StoreDescription> StoreDescription { get; set; }
        IDbSet<StoreImage> StoreImage { get; set; }
        IDbSet<Text> Text { get; set; }
        IDbSet<TextAndTextTypes> TextAndTextTypes { get; set; }
        IDbSet<TextLanguage> TextLanguage { get; set; }
        IDbSet<TextType> TextType { get; set; }
        IDbSet<User> User { get; set; }
        IDbSet<MailTemplate> MailTemplate { get; set; }
        IDbSet<MailTemplateLanguage> MailTemplateLanguage { get; set; }
        IDbSet<Suggesting> Suggesting { get; set; }
        IDbSet<Event> Event { get; set; }
        IDbSet<NewsItem> News { get; set; }
        IDbSet<NewsComment> NewsComment { get; set; }
        int SaveChanges();

        Database Database { get; }
    }
}