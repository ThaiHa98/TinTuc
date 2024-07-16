using MediatR;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.CategoryCreates.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, string>
    {
        private readonly IRepositoryInterface<Category> _repositoryInterface;
        private readonly MyDBContext _dbContext;
        public DeleteCategoryHandler(IRepositoryInterface<Category> repositoryInterface, MyDBContext myDBContext)
        {
            _dbContext = myDBContext;
            _repositoryInterface = repositoryInterface;
        }

        public async Task<string> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("Id has not been entered");
                }
                var category = _dbContext.Categories.FirstOrDefault(c => c.Id == request.Id);

                _repositoryInterface.Remove(category);

                return await Task.FromResult("Delete Category Successfully");
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while Delete Category");
            }
        }
    }
}
