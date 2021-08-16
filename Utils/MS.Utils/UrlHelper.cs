using System.Configuration;

namespace MS.Utils
{
    public static class UrlHelper
    {
        public static string GetStoreUrl(int storeId, int languageId)
        {
            var urlCulture = LanguageHelper.GetUrlCultureFromLanguageId(languageId);

            switch (languageId)
            {
                case (int)LanguageHelper.EnumLanguage.Spanish:
                    return "/" + urlCulture + "/stores/storedetail?storeId=" + storeId;
                case (int)LanguageHelper.EnumLanguage.English:
                    return "/" + urlCulture + "/stores/storedetail?storeId=" + storeId;
                case (int)LanguageHelper.EnumLanguage.Catalan:
                    return "/" + urlCulture + "/stores/storedetail?storeId=" + storeId;
                default :
                    return "/" + urlCulture + "/stores/storedetail?storeId=" + storeId;
            }
        }

        public static string GetNewsUrl(int newsId, int languageId)
        {
            var urlCulture = LanguageHelper.GetUrlCultureFromLanguageId(languageId);

            switch (languageId)
            {
                case (int)LanguageHelper.EnumLanguage.Spanish:
                    return "/" + urlCulture + "/news/newsDetail?newsId=" + newsId;
                case (int)LanguageHelper.EnumLanguage.English:
                    return "/" + urlCulture + "/news/newsDetail?newsId=" + newsId;
                case (int)LanguageHelper.EnumLanguage.Catalan:
                    return "/" + urlCulture + "/news/newsDetail?newsId=" + newsId;
                default:
                    return "/" + urlCulture + "/news/newsDetail?newsId=" + newsId;
            }
        }

        public static string GetPosturl(int postId, int languageId)
        {
            var urlCulture = LanguageHelper.GetUrlCultureFromLanguageId(languageId);

            switch (languageId)
            {
                case (int)LanguageHelper.EnumLanguage.Spanish:
                    return "/" + urlCulture + "/posts/postdetail?postId=" + postId;
                case (int)LanguageHelper.EnumLanguage.English:
                    return "/" + urlCulture + "/posts/postdetail?postId=" + postId;
                case (int)LanguageHelper.EnumLanguage.Catalan:
                    return "/" + urlCulture + "/posts/postdetail?postId=" + postId;
                default:
                    return "/" + urlCulture + "/posts/postdetail?postId=" + postId;
            }
        }

        public static string GetStoreFullUrl(int storeId, int languageId)
        {
            var urlCulture = LanguageHelper.GetUrlCultureFromLanguageId(languageId);

            switch (languageId)
            {
                case (int)LanguageHelper.EnumLanguage.Spanish:
                    return ConfigurationManager.AppSettings["UrlStoreSpanish"] + urlCulture + "/stores/storedetail?storeId=" + storeId;
                case (int)LanguageHelper.EnumLanguage.English:
                    return ConfigurationManager.AppSettings["UrlStoreEnglish"] + urlCulture + "/stores/storedetail?storeId=" + storeId;
                case (int)LanguageHelper.EnumLanguage.Catalan:
                    return ConfigurationManager.AppSettings["UrlStoreCatalan"] + urlCulture + "/stores/storedetail?storeId=" + storeId;
                default:
                    return ConfigurationManager.AppSettings["UrlStoreSpanish"] + urlCulture + "/stores/storedetail?storeId=" + storeId;
            }
        }
    }
}
