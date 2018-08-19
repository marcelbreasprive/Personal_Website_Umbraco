using Our.Umbraco.Ditto;
using System.ComponentModel;
using Umbraco.Core.Models;

namespace MandMOnTheRoad.Models
{
    public class ArchiveItemPage : BasePage
    {
        //public virtual Image PageBanner { get; set; }
        public ArchiveItemPage(IPublishedContent content) : base(content) {}

        public virtual Image ThumbnailImage { get; set; }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("TimelineFolder")]
        public virtual TimeLine TimeLine { get; set; }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("MapLocations")]
        public virtual Map Map { get; set; }
    }
}