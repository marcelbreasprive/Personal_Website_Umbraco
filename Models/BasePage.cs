using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Models
{
    public class BasePage : PublishedContentModel
    {
        public BasePage(IPublishedContent content) : base(content) {}

        public virtual string PageTitle { get; set; }

        public virtual string MetaTitle { get; set; }
        public virtual string MetaKeywords { get; set; }
        public virtual string MetaDescription { get; set; }

        public virtual string MenuText { get; set; }


        public bool IsApp {
            get {
                return System.Web.HttpContext.Current.Request.Headers["MBR_APP_VIEW"] == "true";
            }
        }
    }
}