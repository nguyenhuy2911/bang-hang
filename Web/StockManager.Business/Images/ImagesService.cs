using AutoMapper;
using Common.Enum;
using StockManager.Data.Infrastructure;
using StockManager.Data.Repository;
using StockManager.Entity;
using StockManager.Entity.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Business
{
    public interface IImagesService
    {
        CRUD_Image_Response CreateImage(CRUD_Image_Request request);
        Get_Images_By_RelateId_Response Get_Images_By_RelateId(Get_Images_By_RelateId_Request request);
    }
    public class ImagesService : IImagesService
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IImageRepository _IImagesRepository;
        public ImagesService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            this._IImagesRepository = imageRepository;
            this._IUnitOfWork = unitOfWork;
        }

        public CRUD_Image_Response CreateImage(CRUD_Image_Request request)
        {
            var response = new CRUD_Image_Response();
            try
            {
                var image = Mapper.Map<CRUD_Image_Request, StockManager.Entity.DataAccess.Images>(request);
                this._IImagesRepository.Add(image);
                int saveStatus = this._IUnitOfWork.Commit();
                if (saveStatus > 0)
                    response.StatusCode = (int)RESULT_STATUS_CODE.SUCCESS;
                else
                    response.StatusCode = (int)RESULT_STATUS_CODE.DATABASE_ERROR;

            }
            catch (Exception ex)
            {

                response.StatusCode = (int)RESULT_STATUS_CODE.SYSTEM_ERROR;
                response.StatusMessage = ex.ToString();
            }
            return response;
        }

        public Get_Images_By_RelateId_Response Get_Images_By_RelateId(Get_Images_By_RelateId_Request request)
        {
            var response = _IImagesRepository.GetPage(request.Page, p => p.RelateId.Equals(request.RelateId), p=>p.Id);
            var retData = Mapper.Map<ResponseBase<List< StockManager.Entity.DataAccess.Images>>, Get_Images_By_RelateId_Response>(response);
            return retData;
        }
    }
}
