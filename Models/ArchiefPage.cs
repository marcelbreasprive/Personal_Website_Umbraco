using Umbraco.Core.Models;

namespace MandMOnTheRoad.Models
{
    public class ArchiefPage : BasePage
    {
        //public virtual Image PageBanner { get; set; }
        public ArchiefPage(IPublishedContent content) : base(content) {}
        public virtual string TestProp { get; set; }

    }
}