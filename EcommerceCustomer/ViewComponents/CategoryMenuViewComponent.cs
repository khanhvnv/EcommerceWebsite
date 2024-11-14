using System;
using Microsoft.AspNetCore.Mvc;
using EcommerceShared.Models;
using EcommerceCustomer.Services;

namespace EcommerceCustomer.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly CategoryService _categoryService;

        public CategoryMenuViewComponent(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);  // Returns the View with categories
        }
    }
}
