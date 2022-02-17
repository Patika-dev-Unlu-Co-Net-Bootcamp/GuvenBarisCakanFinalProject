using System.Linq;
using System.Collections.Generic;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class UserService :IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OperationClaim> GetClaims(int userId)
        {
            return _unitOfWork.User.GetClaims(userId);
        }

        public void Create(User user)
        {
            _unitOfWork.User.Create(user);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("User");
            }
            //İşlem başarılıdır dönülecek 
        }

        public User GetByMail(string email)
        {
            var result = _unitOfWork.User.Get(u => u.Email == email).SingleOrDefault();
            if (result is null)
                throw new NotFoundExceptions("Email");

            return result;
        }
    }
}
