using Our.Umbraco.Ditto;
using System.Collections.Generic;
using System.ComponentModel;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Models
{
    [TypeConverter(typeof(DittoPickerConverter))]
    public class TimeLine : PublishedContentModel
    {
        public TimeLine(IPublishedContent content) : base(content) { }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("Children")]
        public virtual IEnumerable<TimeLineItem> Items { get; set; }
    }
}