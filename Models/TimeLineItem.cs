using Our.Umbraco.Ditto;
using System;
using System.ComponentModel;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Models
{
    [TypeConverter(typeof(DittoPickerConverter))]
    public class TimeLineItem : PublishedContentModel
    {
        public TimeLineItem(IPublishedContent content) : base(content) {}

        public virtual string Title { get; set; }

        public virtual Image Image { get; set; }

        public virtual string Type { get; set; }

        public virtual string YoutubeVideo { get; set; }

        private string _youtubeVideoCode;
        [DittoIgnore]
        public string YoutubeVideoCode {
            get {
                try
                {
                    if (string.IsNullOrWhiteSpace(_youtubeVideoCode))
                        if (YoutubeVideo.Contains("?"))
                            _youtubeVideoCode = HttpUtility.ParseQueryString(new Uri(YoutubeVideo).Query)["v"];
                        else if(YoutubeVideo.Contains("/") && YoutubeVideo.Length > 8)
                            _youtubeVideoCode = YoutubeVideo.Substring(YoutubeVideo.LastIndexOf("/"));

                        else
                            _youtubeVideoCode = YoutubeVideo;

                    return _youtubeVideoCode;
                }
                catch (Exception) {
                    return string.Empty;
                }
            }
        }

        [DittoIgnore]
        public string Icon {
            get {
                switch (Type.ToLowerInvariant())
                {
                    case "photo":
                        return "/assets/img/icon-photo.png";
                    case "video":
                        return "/assets/img/icon-video.png";
                    default:
                        return "/assets/img/icon-photo.png";
                }
            }
        }

        [DittoIgnore]
        public string ColorClass {
            get {
                switch (Type.ToLowerInvariant())
                {
                    case "photo":
                        return "cd-picture";
                    case "video":
                        return "cd-movie";
                    default:
                        return "cd-location";
                }
            }

        }

    }
}