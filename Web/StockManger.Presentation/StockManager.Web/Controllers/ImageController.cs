using Common;
using Common.Enum;
using StockManager.Business;
using StockManager.Entity.Service.Contract;
using StockManager.Web.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StockManager.Web.Controllers
{
    [RoutePrefix("image")]
    public class ImageController : Controller
    {
        private readonly IImagesService _IImagesService;

        public ImageController(IImagesService imagesService)
        {
            this._IImagesService = imagesService;
        }

        [Route("product-upload")]
        public ActionResult UploadProductImg(ProductImg_Upload_Modal modal)
        {
            bool result = false;
            try
            {
                foreach (string _fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[_fileName];
                    string ext = Path.GetExtension(file.FileName);
                    string fileName = string.Format("{0}_{1}", StringMenthod.friendly_urlSEO(modal.Product_Name), Guid.NewGuid());
                    string path = string.Format(@"~\uploads\img\product\{0}", modal.Product_Id);                   
                    if (file != null && file.ContentLength > 0)
                    {
                        if (!Directory.Exists(Server.MapPath(path)))
                        {
                            Directory.CreateDirectory(Server.MapPath(path));
                        }
                        path += @"\" + fileName + ext;

                        // insert  picture
                        var request = new CRUD_Image_Request()
                        {
                            RelateId = modal.Product_Id.ToString(),
                            Name = modal.Product_Name,
                            Path =  path.Replace(@"~\","").Replace(@"\","/"),
                            Type = IMAGE_TYPE.PRODUCT.ToString()
                        };
                        var insertPicResult = this._IImagesService.CreateImage(request);
                        if (insertPicResult != null && insertPicResult.StatusCode.Equals((int)RESULT_STATUS_CODE.SUCCESS))
                        {
                            result = true;
                            file.SaveAs(Server.MapPath(path));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return Json(new { res = result });
        }
    }
}