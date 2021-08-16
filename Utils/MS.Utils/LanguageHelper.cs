namespace MS.Utils
{
    public static class LanguageHelper
    {
        public const string DefaultLanguage = "es-ES";

        public const string DefaultUrlLanguage = "es";

        public enum EnumLanguage
        {
            Spanish = 1,
            English = 2,
            Catalan = 3
        }

        public static string GetCultureCodeByLanguageId(int languagId)
        {
            switch (languagId)
            {
                case 1:
                    return "es-ES";
                case 2:
                    return "en-GB";
                case 3:
                    return "ca-ES";
            }

            return DefaultLanguage;
        }

        public static int GetLanguageIdFromUrlCulture(string code)
        {
            switch (code)
            {
                case "es":
                    return 1;
                case "en":
                    return 2;
                case "ca":
                    return 3;
            }

            return 1;
        }

        public static string GetUrlCultureFromLanguageId(int languagId)
        {
            switch (languagId)
            {
                case 1:
                    return "es";
                case 2:
                    return "en";
                case 3:
                    return "ca";
            }

            return DefaultUrlLanguage;
        }

        public static string GetCultureCodeBySortName(string culture)
        {
            switch (culture)
            {
                case "es":
                    return "es-ES";
                case "en":
                    return "en-GB";
                case "ca":
                    return "ca-ES";
            }

            return DefaultLanguage;
        }
    }
}
