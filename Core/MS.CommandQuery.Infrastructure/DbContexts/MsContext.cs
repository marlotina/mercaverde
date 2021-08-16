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
    public class MsContext : DbContext, IMsContext
    {
        public IDbSet<C__RefactorLog> C__RefactorLog { get; set; }
        //public IDbSet<Brand> Brand { get; set; }
        //public IDbSet<BrandComment> BrandComment { get; set; }
        //public IDbSet<BrandDescription> BrandDescription { get; set; }
        //public IDbSet<BrandImage> BrandImage { get; set; }
        public IDbSet<Category> Category { get; set; }
        public IDbSet<CategoryLanguage> CategoryLanguage { get; set; }
        public IDbSet<City> City { get; set; }
        public IDbSet<CityLanguage> CityLanguage { get; set; }
        public IDbSet<Country> Country { get; set; }
        public IDbSet<CountryLanguage> CountryLanguage { get; set; }
        public IDbSet<District> District { get; set; }
        public IDbSet<TaskProcess> ExtranetTaskProcess { get; set; }
        public IDbSet<Label> Label { get; set; }
        public IDbSet<LabelLanguage> LabelLanguage { get; set; }
        public IDbSet<Language> Language { get; set; }
        public IDbSet<Post> Post { get; set; }
        public IDbSet<PostComment> PostComment { get; set; }
        public IDbSet<Store> Store { get; set; }
        public IDbSet<StoreComment> StoreComment { get; set; }
        public IDbSet<StoreDescription> StoreDescription { get; set; }
        public IDbSet<StoreImage> StoreImage { get; set; }
        public IDbSet<Text> Text { get; set; }
        public IDbSet<TextAndTextTypes> TextAndTextTypes { get; set; }
        public IDbSet<TextLanguage> TextLanguage { get; set; }
        public IDbSet<TextType> TextType { get; set; }
        public IDbSet<User> User { get; set; }
        public IDbSet<MailTemplate> MailTemplate { get; set; }
        public IDbSet<MailTemplateLanguage> MailTemplateLanguage { get; set; }
        public IDbSet<Suggesting> Suggesting { get; set; }
        public IDbSet<Event> Event { get; set; }
        public IDbSet<NewsItem> News { get; set; }
        public IDbSet<NewsComment> NewsComment { get; set; }

        public MsContext()
            : base("MSContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Brand>()
            //    .HasMany(e => e.BrandComments)
            //    .WithRequired(e => e.Brand)
            //    .HasForeignKey(e => e.BrandId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Brand>()
            //    .HasMany(e => e.BrandDescriptions)
            //    .WithRequired(e => e.Brand)
            //    .HasForeignKey(e => e.BrandId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Brand>()
            //    .HasMany(e => e.BrandImages)
            //    .WithRequired(e => e.Brand)
            //    .HasForeignKey(e => e.BrandId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Brand>()
            //    .HasMany(e => e.Categories)
            //    .WithMany(e => e.Brands)
            //    .Map(m => m.ToTable("TblBrandCategories").MapLeftKey("BrandId").MapRightKey("CategoryId"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryLanguages)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.ParentCategory)
                .HasForeignKey(e => e.ParentCategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Stores)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("TblStoreCategories").MapLeftKey("CategoryId").MapRightKey("StoreId"));

            modelBuilder.Entity<City>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<City>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 0);

            //modelBuilder.Entity<City>()
            //    .HasMany(e => e.Brand)
            //    .WithOptional(e => e.City)
            //    .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<City>()
                .HasMany(e => e.CityLanguage)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.District)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Store)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<Country>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Country>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.CountryLanguages)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<District>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<District>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 0);

            //modelBuilder.Entity<District>()
            //    .HasMany(e => e.Brands)
            //    .WithOptional(e => e.District)
            //    .HasForeignKey(e => e.DistrictId);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Stores)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.DistrictId);

            modelBuilder.Entity<Label>()
                .HasMany(e => e.LabelLanguages)
                .WithRequired(e => e.Label)
                .HasForeignKey(e => e.LabelId)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Label>()
            //    .HasMany(e => e.Brands)
            //    .WithMany(e => e.Labels)
            //    .Map(m => m.ToTable("TblBrandLabels").MapLeftKey("LabelId").MapRightKey("BrandId"));

            modelBuilder.Entity<Label>()
                .HasMany(e => e.Stores)
                .WithMany(e => e.Labels)
                .Map(m => m.ToTable("TblStoreLabels").MapLeftKey("LabelId").MapRightKey("StoreId"));

            modelBuilder.Entity<Language>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Charset)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.URLFolder)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Domain)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.CultureName)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Folder)
                .IsUnicode(false);

            //modelBuilder.Entity<Language>()
            //    .HasMany(e => e.BrandComments)
            //    .WithRequired(e => e.Language)
            //    .HasForeignKey(e => e.LanguageId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Language>()
            //    .HasMany(e => e.BrandDescriptions)
            //    .WithRequired(e => e.Language)
            //    .HasForeignKey(e => e.LanguageId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.CategoryLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.CityLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.CountryLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.LabelLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.MailTemplateLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.StoreDescriptions)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.TextLanguages)
                .WithRequired(e => e.Language)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Language)
                .HasForeignKey(e => e.LanguageId);

            modelBuilder.Entity<MailTemplate>()
                .HasMany(e => e.MailTemplateLanguages)
                .WithRequired(e => e.MailTemplate)
                .HasForeignKey(e => e.MailTemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MailTemplateLanguage>()
                .Property(e => e.Subject)
                .IsFixedLength();

            modelBuilder.Entity<NewsItem>()
                .HasMany(e => e.NewsComment)
                .WithRequired(e => e.News)
                .HasForeignKey(e => e.NewsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostComments)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.StoreComments)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.StoreDescriptions)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.StoreImages)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.Label)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.String)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .HasMany(e => e.TextLanguage)
                .WithRequired(e => e.Text)
                .HasForeignKey(e => e.TextId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TextLanguage>()
                .Property(e => e.Translation)
                .IsUnicode(false);

            modelBuilder.Entity<TextType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TextType>()
                .HasMany(e => e.TextAndTextTypes)
                .WithRequired(e => e.TextType)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.Brands)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.UserId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.BrandComments)
            //    .WithRequired(e => e.User)
            //    .HasForeignKey(e => e.UserId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.News)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NewsComment)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostComments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Stores)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.StoreComment)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subscribeds)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TaskProcesses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new UserConfiguration());
        //    modelBuilder.Configurations.Add(new DepartmentConfiguration());
        //}
    }
}
