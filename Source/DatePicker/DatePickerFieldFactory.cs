using System.Web;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class DatePickerFieldFactory
    {
        private static readonly UserAgentParser _parser = new UserAgentParser ();

        public static DefaultDatePickerField GetField (HttpBrowserCapabilities browserCapabilities)
        {
            DefaultDatePickerField field;
            BrowserType browserType = _parser.Parse (browserCapabilities);
            switch (browserType)
            {
                case BrowserType.IE5Up:
                case BrowserType.IE6Up:
                case BrowserType.IE7Up:
                    field = new IE5DatePickerField ();
                    break;

                case BrowserType.Mozilla:
                case BrowserType.FireFox2:
                    field = new MozDatePickerField ();
                    break;

                case BrowserType.Netscape:
                    field = new NSDatePickerField ();
                    break;

                case BrowserType.WebKit:
                    field = new WebKitDatePickerField ();
                    break;

                default:
                    field = new DefaultDatePickerField ();
                    break;
            }

            return field;
        }
    }
}
