﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinTuc.Domain.Model;

namespace TinTuc.Application.Features.CategoryCreates.CreatesCategory
{
    public class CreateCategoryRequest : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
