using MediatR;

namespace UnluCoProductCatalog.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
    }
}