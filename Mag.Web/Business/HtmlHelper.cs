using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Mag.Web.Business
{
    public static class HtmlHelper
    {
        public static Control WrapInLi(this Control innerControl)
        {
            var li = CreateLi();
            li.Controls.Add(innerControl);

            return li;
        }

        private static Control CreateLi()
        {
            return new HtmlGenericControl("li");
        }

        public static string Glyph(string customCssClass)
        {
            return string.Format("<span class=\"glyphicon {0}\"></span>&nbsp;", customCssClass);
        }
    }
}