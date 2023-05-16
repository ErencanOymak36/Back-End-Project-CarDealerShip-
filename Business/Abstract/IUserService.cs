﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Delete(User user);
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);


    }
}
