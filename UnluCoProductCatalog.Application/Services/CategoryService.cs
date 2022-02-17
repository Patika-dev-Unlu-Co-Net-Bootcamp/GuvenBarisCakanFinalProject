using AutoMapper;
using System.Collections.Generic;
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
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id)
        {
            if (id == 0)
            { 
                var productsAll = _unitOfWork.Product.GetAll();
                return _mapper.Map<IEnumerable<GetProductViewModel>>(productsAll);
            }

            var productsFilter = _unitOfWork.Product.Get(p => p.CategoryId == id);
            return _mapper.Map<IEnumerable<GetProductViewModel>>(productsFilter);

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

            category.IsDeleted = false;

            _unitOfWork.Category.Update(category);

            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Category");
        }
    }
}
