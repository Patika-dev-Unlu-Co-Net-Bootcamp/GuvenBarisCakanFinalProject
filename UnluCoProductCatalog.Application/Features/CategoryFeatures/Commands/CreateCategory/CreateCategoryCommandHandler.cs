using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var category = _mapper.Map<Category>(request);

            if (category is null)
            {
                throw new NotFoundExceptions(nameof(category), category.Id);
            }

            _unitOfWork.Category.Create(category);

            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Category");
            }

            return new CreateCategoryCommandResponse { Message = "Category added" };
        }
    }
}

