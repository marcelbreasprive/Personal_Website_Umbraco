using Our.Umbraco.Ditto;
using System.ComponentModel;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Models
{
    [TypeConverter(typeof(DittoPickerConverter))]
    public class Image : PublishedContentModel
    {
        public Image(IPublishedContent content): base(content) {}

        [UmbracoProperty("Width")]
        public int Width { get; set; }

        [UmbracoProperty("Height")]
        public int Height { get; set; }

        [UmbracoProperty("Size")]
        public int Bytes { get; set; }

        [UmbracoProperty("Type")]
        public string Extension { get; set; }
    }
}