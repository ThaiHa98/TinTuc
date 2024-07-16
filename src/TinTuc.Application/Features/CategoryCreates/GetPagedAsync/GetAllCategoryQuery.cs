using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;
using TinTuc.Domain.PagingRequest;

namespace TinTuc.Application.Features.CategoryCreates.GetPagedAsync
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
        public PagingRequestBase Request { get; }

        public GetAllCategoryQuery(PagingRequestBase request)
        {
            Request = request;
        }
    }
}
