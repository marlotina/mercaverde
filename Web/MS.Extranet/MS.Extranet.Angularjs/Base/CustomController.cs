
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using MS.Utils;

namespace MS.Extranet.Angularjs.Base
{
    public class CustomController : Controller
    {
        public CurrentUserInfo CurrentUser { get; set; }

        public int IdPost { get; set; }

        public int IdBrand { get; set; }

        public const string DefaultProfileImage = "/Images/DefaultProfile.jpg";

        public void Load()
        {
            CurrentUser = (CurrentUserInfo)Session["currentUser"];

            if (CurrentUser != null)
            {
                CurrentUser.IdPost = !string.IsNullOrEmpty(HttpContext.Request.QueryString["PostId"]) ? int.Parse(HttpContext.Request.QueryString["PostId"]) : 0;

                CurrentUser.IdBrand = !string.IsNullOrEmpty(HttpContext.Request.QueryString["BrandId"]) ? int.Parse(HttpContext.Request.QueryString["BrandId"]) : 0;

                CurrentUser.IdStore = !string.IsNullOrEmpty(HttpContext.Request.QueryString["StoreId"]) ? int.Parse(HttpContext.Request.QueryString["StoreId"]) : 0;

                if (!string.IsNullOrEmpty(HttpContext.Request.QueryString["dlt"]))
                {
                    ViewData["ImageProfile"] = DefaultProfileImage;
                    CurrentUser.ImageProfile = DefaultProfileImage;
                }
                else
                {
                    ViewData["ImageProfile"] = !string.IsNullOrEmpty(CurrentUser.ImageProfile) ? CurrentUser.ImageProfile +"?" + DateTime.Now.Second : DefaultProfileImage; 
                }

                

                ViewData["IdUser"] = CurrentUser.UserId;

                if (!string.IsNullOrEmpty(CurrentUser.UserName))
                {
                    ViewData["NameUser"] = CurrentUser.UserName;
                }
                else
                {
                    ViewData["NameUser"] = CurrentUser.Email;
                }
            }
        }

        public void LogOut()
        {
            Session["currentUser"] = null;
            FormsAuthentication.SignOut();
        }
    }
}