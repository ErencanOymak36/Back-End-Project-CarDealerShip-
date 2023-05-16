using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntitiyRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (Context db= new Context())
            {
                var result = from c in db.Cars
                             join b in db.Brands
                             on c.BrandId equals b.BrandId 
                             from ca in db.Cars
                             join cl in db.Colors
                             on ca.ColorId equals cl.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, ColorName=cl.ColorName };
                            

                
              
                return result.ToList();

            }
        }
    }
}
