using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.General;
using Microsoft.EntityFrameworkCore;

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
                var parent = await _categoryRepository.GetByIdAsync(model.ParentId.Value);

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

            response = new Response(true, Messages.CategoryCreated);

            return response;
        }

        //Delete
        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response();

            var category = await _categoryRepository.GetByIdAsync(id);

            if(category == null)
            {
                response = new Response(false, Messages.CategoryNotFound);

                return response;
            }

            await _categoryRepository.DeleteAsync(category);

            response = new Response(true, Messages.CategoryDeleted);

            return response;
        }

        //Get all
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = await _categoryRepository.GetAll().Include(x => x.Children).Where(x => x.ParentId == null).ToListAsync();

            return result;
        }

        //Get by id
        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            return result;
        }

        //Update
        public async Task<Response> UpdateAsync(int categoryId, UpdateCategoryModel model)
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
