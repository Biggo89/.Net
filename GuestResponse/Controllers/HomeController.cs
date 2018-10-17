using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestResponse.Models;
using System.ComponentModel.DataAnnotations;

namespace GuestResponse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GetMetadataAttributeValues<BaseViewModel>();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void GetMetadataAttributeValues<T>()
        {

            var type = typeof(T);
            var metadataType = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true)
                .OfType<MetadataTypeAttribute>().FirstOrDefault();
            var metaData = (metadataType != null)
                ? ModelMetadataProviders.Current.GetMetadataForType(null, typeof(BaseMetadata))
                : ModelMetadataProviders.Current.GetMetadataForType(null, type);
            List<CustomAttribute> customAttributeList = new List<CustomAttribute>();
            foreach (var item in metaData.Properties)
            {
                customAttributeList.Add(metaData.ModelType.GetProperty(item.PropertyName)
                                        .GetCustomAttributes(typeof(CustomAttribute), false)
                                        .FirstOrDefault() as CustomAttribute);
            }
        }
    }
}