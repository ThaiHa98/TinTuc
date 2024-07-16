using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Application.Features.UserCreates.CreateUsers;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.CategoryCreates.CreatesCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Category>
    {
        private readonly IRepositoryInterface<Category> _repositoryInterface;
        public CreateCategoryHandler(IRepositoryInterface<Category> repositoryInterface) 
        {
            _repositoryInterface = repositoryInterface;
        }
        public Task<Category> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Name))
                {
                    throw new Exception("The request has not been filled in with enough data");
                }
                Category category = new Category(request.Name);

                var savedCategory = _repositoryInterface.AddAsync(category);
                return savedCategory;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error creating Category");
            }
        }
    }
}
