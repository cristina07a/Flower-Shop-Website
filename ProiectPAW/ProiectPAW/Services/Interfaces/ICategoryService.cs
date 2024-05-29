using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(Category category);

        void DeleteCategory(Category category);

        void UpdateCategory(Category category);

        Category GetCategoryById(int id);

        List<Category> GetCategories();
    }
}  