﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRent(Rental rental)
        {
            
            if(rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.TestError);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IDataResult<List<Rental>> GetAllRents()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
