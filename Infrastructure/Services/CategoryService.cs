using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CategoryService
{
    private DapperContext _context;

    public CategoryService()
    {
        _context = new DapperContext();
    }

    public List<CategoryDto> GetCategories()
    {
        var conn = _context.Connection();
        var sql = @"select * from categories";
        return conn.Query<CategoryDto>(sql).ToList();
    }

    public CategoryDto GetCategoryById(int id)
    {
        var conn = _context.Connection();
        var sql = @"select * from categories where id = @id";
        return conn.QuerySingle<CategoryDto>(sql, new { id });
    }

    public CategoryDto AddCategory(CategoryDto categoryDto)
    {
        var conn = _context.Connection();
        var sql = @"insert into categories (id, name) values (@id, @name)";
        conn.Execute(sql, categoryDto);
        return categoryDto;
    }

    public CategoryDto UpdateCategory(CategoryDto categoryDto)
    {
        var conn = _context.Connection();
        var sql = @"update categories set name = @name where id = @id";
        conn.Execute(sql, categoryDto);
        return categoryDto;
    }

    public int DeleteCategory(int id)
    {
        var conn = _context.Connection();
        var sql = @"delete from categories where id = @id";
        return conn.Execute(sql, new { id });
    }
}