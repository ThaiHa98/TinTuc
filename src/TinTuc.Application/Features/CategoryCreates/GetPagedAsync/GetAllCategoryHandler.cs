using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TinTuc.Domain.Model;
using TinTuc.Domain.PagingRequest;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.CategoryCreates.GetPagedAsync
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
    {
        private readonly IRepositoryInterface<Category> _repositoryInterface;

        public GetAllCategoryHandler(IRepositoryInterface<Category> repositoryInterface)
        {
            _repositoryInterface = repositoryInterface;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryInterface.GetPagedAsync(request.Request);
        }
    }
}
