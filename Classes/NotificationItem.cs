using umbraco.NodeFactory;
using Umbraco.Core;
using Umbraco.Web.Trees;

namespace MandMOnTheRoad.Classes
{

    public class NotificationItem : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            TreeControllerBase.MenuRendering += ContentTreeController_MenuRendering;
        }

        void ContentTreeController_MenuRendering(TreeControllerBase sender, MenuRenderingEventArgs e)
        {
            if (sender.TreeAlias != Constants.Applications.Content)
                return;

            var node = new Node(e.NodeId.ParseInto<int>());

            

            var i = new Umbraco.Web.Models.Trees.MenuItem("notifyApp", "Push Notification to App");
            i.AdditionalData.Add("actionView", "/App_Plugins/Notifications/nofication.html");
            i.AdditionalData.Add("nodeId", e.NodeId);
            i.AdditionalData.Add("isMap", node.NodeTypeAlias == "map");
            i.SeperatorBefore = true;
            //i.AdditionalData
            switch (node.NodeTypeAlias) {
                case "timeline":
                    i.Icon = "globe-inverted-europe-africa";
                    break;
                case "map":
                    i.Icon = "globe-europe---africa";
                    break;
            }

            if (node.NodeTypeAlias == "timeline" || node.NodeTypeAlias == "map")
            {
                e.Menu.Items.Insert(0, i);
            }            
        }
    }
}