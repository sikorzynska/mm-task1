using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Categories;

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
        public async Task<CategoryResponse> AddAsync(CreateCategoryModel model)
        {
            var response = new CategoryResponse();

            var category = new Category
            {
                Name = model.Name
            };

            await _categoryRepository.AddAsync(category);

            response = new CategoryResponse(true,
                Messages.CategoryCreatedMessage,
                new GeneralCategoryModel
                {
                    Id = category.Id,
                    Name = model.Name,
                });

            return response;
        }

        //Delete
        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var response = new CategoryResponse();

            var category = await _categoryRepository.GetByIdAsync(id);

            if(category == null)
            {
                response = new CategoryResponse(false, Messages.CategoryNotFound);

                return response;
            }

            await _categoryRepository.DeleteAsync(category);

            response = new CategoryResponse(
                true,
                Messages.CategoryDeletedMessage,
                new GeneralCategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                });

            return response;
        }

        //Get all
        public async Task<IEnumerable<GeneralCategoryModel>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            
            var result = categories.Select(category => new GeneralCategoryModel
            {
                Id =category.Id,
                Name =category.Name,
            }).ToList();

            return result;
        }

        //Get by id
        public async Task<GeneralCategoryModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if(category == null)
            {
                return null;
            }

            var result = new GeneralCategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return result;
        }

        //Update
        public async Task<CategoryResponse> UpdateAsync(UpdateCategoryModel model)
        {
            var response = new CategoryResponse();

            var category = await _categoryRepository.GetByIdAsync(model.Id);

            if(category == null)
            {
                response = new CategoryResponse(false, Messages.CategoryNotFound);

                return response;
            }

            category.Name = model.Name;

            await _categoryRepository.UpdateAsync(category);

            response = new CategoryResponse(
                true,
                Messages.CategoryUpdatedMessage,
                new GeneralCategoryModel
                {
                    Id = category.Id,
                    Name = category.Name
                });

            return response;
        }
    }
}
