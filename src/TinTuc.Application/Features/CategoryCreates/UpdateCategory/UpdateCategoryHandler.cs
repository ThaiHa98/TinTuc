using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.MyDB;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.CategoryCreates.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, string>
    {
        private readonly IRepositoryInterface<Category> _repositoryInterface;
        public readonly MyDBContext _dbContext;
        public UpdateCategoryHandler(IRepositoryInterface<Category> repositoryInterface, MyDBContext dbContext)
        {
            _repositoryInterface = repositoryInterface;
            _dbContext = dbContext;
        }
        public async Task<string> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("The request has not been filled in with enough data");
                }
                var category = _dbContext.Categories.FirstOrDefault(x => x.Id == request.Id);
                if (category == null)
                {
                    throw new Exception("categoryId not found");
                }
                category.Name = request.Name;
                _repositoryInterface.Update(category);
                return await Task.FromResult("Update Successfully");
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while updating Category");
            }
        }
    }
}
