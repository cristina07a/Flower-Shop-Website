using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Create(category);
            _repositoryWrapper.Save();
        }

        public void DeleteCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Delete(category);
            _repositoryWrapper.Save();
        }

        public void UpdateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Update(category);
            _repositoryWrapper.Save();
        }

        public Category GetCategoryById(int id)
        {
            return _repositoryWrapper.CategoryRepository.FindByCondition(c => c.categoryID == id).FirstOrDefault()!;
        }

        public List<Category> GetCategoryByName(string Name)
        {
            return _repositoryWrapper.CategoryRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }

        public List<Category> GetCategories()
        {
            return _repositoryWrapper.CategoryRepository.FindAll().ToList();
        }


    }
}