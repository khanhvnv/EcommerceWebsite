using System;

using EcommerceShared.Models;

namespace EcommerceShared.Services
{
    public class CategoryService
    {
        private readonly List<Category> _categories = new();

        public IEnumerable<Category> GetCategories() => _categories;

        public Category? GetCategoryById(int id) =>
            _categories.FirstOrDefault(c => c.Id == id);

        public void AddCategory(Category category) => _categories.Add(category);
    }
}
