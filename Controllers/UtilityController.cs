using MandMOnTheRoad.Models;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;
using System.Linq;
using System;
using Our.Umbraco.Ditto;

namespace MandMOnTheRoad.Controllers
{
    public class UtilityController : UmbracoApiController
    {
        public string GetGoogleApiKey()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            List<Homepage> list = Umbraco.TypedContentAtRoot().Where(x => x.DocumentTypeAlias.Equals("homepage", StringComparison.InvariantCultureIgnoreCase)).Select(x => x.As<Homepage>()).ToList();
            if (list.Any())
              return list.FirstOrDefault(x => !string.IsNullOrEmpty(x.GoogleAPIKey)).GoogleAPIKey;
            return string.Empty;
        }
    }
}