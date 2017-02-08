using System.Web;

namespace OpinionatedGeek.Web.PowerPack
{
    internal class ComboBoxFieldFactory
    {
        private static readonly UserAgentParser _parser = new UserAgentParser ();

        public static DefaultComboBoxField GetField (HttpBrowserCapabilities browserCapabilities)
        {
            DefaultComboBoxField field;
            BrowserType browserType = _parser.Parse (browserCapabilities);
            switch (browserType)
            {
                case BrowserType.IE5Up:
                    field = new IE5ComboBoxField ();
                    break;

                case BrowserType.IE6Up:
                    field = new IE6ComboBoxField ();
                    break;

                case BrowserType.IE7Up:
                    field = new IE7ComboBoxField ();
                    break;

                case BrowserType.Mozilla:
                    field = new MozComboBoxField ();
                    break;

                case BrowserType.FireFox2:
                    field = new Firefox2ComboBoxField ();
                    break;

                case BrowserType.WebKit:
                    field = new WebKitComboBoxField ();
                    break;

                default:
                    field = new DefaultComboBoxField ();
                    break;
            }

            return field;
        }
    }
}
