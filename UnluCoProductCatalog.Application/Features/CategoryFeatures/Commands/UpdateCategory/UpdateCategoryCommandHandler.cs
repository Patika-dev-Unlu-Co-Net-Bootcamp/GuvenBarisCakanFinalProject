using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;

namespace UnluCoProductCatalog.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //var category = _unitOfWork.Category.GetById(request.Id);

            //if (category is null)
            //{
            //    throw new NotFoundExceptions(nameof(category), request.Id);
            //}

            //_unitOfWork.Category.Update(category);
            return null;

        }
    }

    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {

    }

    public class UpdateCategoryCommandResponse
    {

    }
}
