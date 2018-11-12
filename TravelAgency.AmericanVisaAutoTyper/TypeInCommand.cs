using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace TravelAgency.AmericanVisaAutoTyper
{
    public abstract class TypeInCommand
    {
        public void Run(WebBrowser webBrowser, TabItem tabItem)
        {
            if (CheckStatus(webBrowser, tabItem))
            {
                TypeIn();
            }
        }

        public abstract void TypeIn();
        public bool CheckStatus(WebBrowser webBrowser, TabItem tabItem)
        {
            return webBrowser.Url.ToString().Contains(tabItem.Tag.ToString());
        }
    }
}