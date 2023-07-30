using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private CategoryService _categoryService;

    public CategoryController()
    {
        _categoryService = new CategoryService();
    }

    [HttpGet("GetCategories")]
    public List<CategoryDto> GetCategories()
    {
        return _categoryService.GetCategories();
    }

    [HttpGet("GetCategotyById")]
    public CategoryDto GeCategoryById(int id)
    {
        return _categoryService.GetCategoryById(id);
    }

    [HttpPost("AddCategory")]
    public CategoryDto AddCategory(CategoryDto categoryDto)
    {
        return _categoryService.AddCategory(categoryDto);
    }
    
    [HttpPut("UpdateCategory")]
    public CategoryDto UpdateCategory(CategoryDto categoryDto)
    {
        return _categoryService.UpdateCategory(categoryDto);
    }

    [HttpDelete("DeleteCategory")]
    public int DeleteCategory(int id)
    {
        return _categoryService.DeleteCategory(id);
    }
}