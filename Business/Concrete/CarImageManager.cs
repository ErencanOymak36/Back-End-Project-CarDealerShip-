using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public  IResult Add(CarImage carImage)
        {
            IResult result = BusinessRule.Run(CheckImageNumber(carImage.CarId));
            if(result!=null)
            {
                return result;
            }
            
            carImage.Date= DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
          
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }



        private IResult CheckImageNumber(int carid)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carid);
            if (result.Count > 5)
            {

                return new ErrorResult();


            }
            return new SuccessResult();
        }
    }
}
