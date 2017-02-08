using System.Web;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class RichTextFieldFactory
    {
        private static readonly UserAgentParser _parser = new UserAgentParser ();

        public static DefaultRTField GetField (RichTextBox richTextBox, HttpBrowserCapabilities browserCapabilities)
        {
            DefaultRTField field;
            BrowserType browserType = _parser.Parse (browserCapabilities);
            switch (browserType)
            {
                case BrowserType.IE5Up:
                case BrowserType.IE6Up:
                    field = new IE5RTField (richTextBox);
                    break;

                case BrowserType.IE7Up:
                    field = new IE7RTField (richTextBox);
                    break;

                case BrowserType.Mozilla:
                    field = new MozRTField (richTextBox);
                    break;

                case BrowserType.FireFox2:
                    field = new Firefox2RTField (richTextBox);
                    break;

                case BrowserType.WebKit:
                    field = new WebKitRTField (richTextBox);
                    break;

                default:
                    field = new DefaultRTField (richTextBox);
                    break;
            }

            return field;
        }
    }
}
