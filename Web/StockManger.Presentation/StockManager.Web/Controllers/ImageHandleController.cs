using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.ImagesExtention;
namespace StockManager.Web.Controllers
{

    [RoutePrefix("images-handle")]
    [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Server)]
    public class ImageHandleController : Controller
    {
        [HttpGet]
        [Route("get-image")]
        public FileStreamResult GetImages(string path, int w, int h)
        {
            System.Drawing.Image image = (@"~/" + path).GetImageFromPath(w, h, true);
            Stream ms = new MemoryStream(image.ToByteArray());
            return new FileStreamResult(ms, "image/jpg");
        }
    }
}