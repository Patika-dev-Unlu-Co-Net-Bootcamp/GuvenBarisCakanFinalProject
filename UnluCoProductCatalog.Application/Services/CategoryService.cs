using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = _unitOfWork.Category.GetAll();
            var result = _mapper.Map<IList<CategoryViewModel>>(categories);

            return result;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            if (id == 0)
            { 
                var productsAll = _unitOfWork.Product.GetProductsByCategories();
                //_mapper.Map<IList<GetProductViewModel>>(productsAll);
                return productsAll;
            }

            return null;

            //var productsFilter = _unitOfWork.Product.GetProductsByCategoryId(id);
            //return _mapper.Map<IList<GetProductViewModel>>(productsFilter);

        }

        public void Create(CategoryViewModel entity)
        {
            var validator = new CategoryViewModelValidator();
            validator.Validate(entity);

            var category =  _mapper.Map<Category>(entity);

            _unitOfWork.Category.Create(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }

        public void Update(CategoryViewModel entity,int id)
        {
            var validator = new CategoryViewModelValidator();
            validator.Validate(entity);

            var category = _unitOfWork.Category.GetById(id);

            if (category is null)
                throw new NotFoundExceptions("Category", id);

            category.CategoryName = category.CategoryName != default ? entity.CategoryName : category.CategoryName;

            _unitOfWork.Category.Update(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");

        }

        public void Delete(int id)
        {
            var category = _unitOfWork.Category.GetById(id);

            if (category is null)
                throw new NotFoundExceptions("Category", id);

            category.IsDeleted = true;

            _unitOfWork.Category.Update(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }
    }
}
