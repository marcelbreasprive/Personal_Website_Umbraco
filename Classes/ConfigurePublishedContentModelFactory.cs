using Our.Umbraco.Ditto;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Classes
{
    public class ConfigurePublishedContentModelFactory : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var types = PluginManager.Current.ResolveTypes<PublishedContentModel>();
            var factory = new DittoPublishedContentModelFactory(types);
            PublishedContentModelFactoryResolver.Current.SetFactory(factory);
        }
    }
}