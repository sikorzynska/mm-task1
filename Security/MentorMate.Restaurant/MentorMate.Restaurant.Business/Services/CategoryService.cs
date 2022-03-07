using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.General;

namespace MentorMate.Restaurant.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        //Add
        public async Task<Response> CreateAsync(CreateCategoryModel model)
        {
            var response = new Response();

            if(model.ParentId != null)
            {
                var parent = await _categoryRepository.GetByIdAsync(model.ParentId);

                if(parent == null)
                {
                    response = new Response(false, Messages.CategoryParentInvalidId);

                    return response;
                }
            }

            var category = new Category
            {
                Name = model.Name,
                ParentId = model.ParentId,
            };

            await _categoryRepository.CreateAsync(category);

            response = new Response(true, Messages.CategoryCreated, category.Id);

            return response;
        }

        //Delete
        public async Task<Response> DeleteAsync(string id)
        {
            var response = new Response();

            var category = await _categoryRepository.GetByIdAsync(id);

            if(category == null)
            {
                response = new Response(false, Messages.CategoryNotFound);

                return response;
            }

            //Get category's subcategories
            var children = category.Children;

            //Remove their parentId foreign keys
            children.ToList().ForEach(x => x.ParentId = null);

            //Update the children
            await _categoryRepository.UpdateRangeAsync(children);

            //Delete category
            await _categoryRepository.DeleteAsync(category);

            response = new Response(true, Messages.CategoryDeleted);

            return response;
        }

        //Get all
        public async Task<ICollection<Category>> GetAllAsync() =>
            await _categoryRepository.GetAllAsync();

        //Get by id
        public async Task<Category> GetByIdAsync(string id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            return result;
        }

        //Update
        public async Task<Response> UpdateAsync(string categoryId, UpdateCategoryModel model)
        {
            var response = new Response();

            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if(category == null)
            {
                response = new Response(false, Messages.CategoryNotFound);

                return response;
            }

            category.Name = model.Name ?? category.Name;
            category.ParentId = model.ParentId ?? category.ParentId;

            await _categoryRepository.UpdateAsync(category);

            response = new Response(true, Messages.CategoryUpdated);

            return response;
        }
    }
}
