using BlogApp.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record CategoryCreateDto
    {
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }
    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(c => c.Name)
              .NotNull()
              .NotEmpty()
              .WithMessage("Bos olmaz")
              .MaximumLength(55)
              .WithMessage("uzunluq 55den cox ola bilmez");
            RuleFor(c => c.Logo)
                .NotNull()
                .WithMessage("sekil bos olmaz");
        }
    }
}
