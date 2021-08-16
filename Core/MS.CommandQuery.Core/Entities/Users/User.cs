using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MS.CommandQuery.Core.Entities.CMS;
using MS.CommandQuery.Core.Entities.Common;
using MS.CommandQuery.Core.Entities.Location;
using MS.CommandQuery.Core.Entities.Product;
using MS.CommandQuery.Core.Entities.Tasks;

namespace MS.CommandQuery.Core.Entities.Users
{
    [Table("TblUser")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            //BrandComments = new HashSet<BrandComment>();
            Posts = new HashSet<Post>();
            PostComments = new HashSet<PostComment>();
            Stores = new HashSet<Store>();
            //Brands = new HashSet<Brand>();
            StoreComment = new HashSet<StoreComment>();
            TaskProcesses = new HashSet<TaskProcess>();
            Subscribeds = new HashSet<Subscribed>();
            Suggestings = new HashSet<Suggesting>();
            Event = new HashSet<Event>();
            News = new HashSet<NewsItem>();
            NewsComment = new HashSet<NewsComment>();
        }

        [Key]
        public int IdUser { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        public string PostalCode { get; set; }

        public DateTime? CreationDate { get; set; }

        public bool Published { get; set; }

        public DateTime? LastActivity { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool? IsCompany { get; set; }

        public bool? AcceptedConditions { get; set; }

        public DateTime? AcceptedConditionsDate { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public int? LanguageId { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public string Street { get; set; }

        public string NumberStreet { get; set; }

        public string CityName { get; set; }

        public string UrlWebSite { get; set; }

        public DateTime? BirthDate { get; set; }

        public Country Country { get; set; }

        public int? CountryId { get; set; }

        public bool MailActivation { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BrandComment> BrandComments { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostComment> PostComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Stores { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Brand> Brands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreComment> StoreComment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskProcess> TaskProcesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribed> Subscribeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suggesting> Suggestings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsItem> News { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsComment> NewsComment { get; set; }
    }
}
