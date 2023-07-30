using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class QuoteService
{
    private DapperContext _context;

    public QuoteService()
    {
        _context = new DapperContext();
    }

    public List<QuoteDto<string>> GetQuotes()
    {
        var conn = _context.Connection();
        var sql = @"select q.id, q.author, q.quote_text, c.name
                    from quotes as q
                    join categories as c
                    on q.category_id = c.id";
        var response = conn.Query<QuoteDto<string>>(sql).ToList();
        return response;
    }
    
    public QuoteDto<string> GetQuoteById(int id)
    {
        var conn = _context.Connection();
        var sql = @"select q.id, q.author, q.quote_text as quotetext, c.name as category
                    from quotes as q
                    join categories as c
                    on q.category_id = c.id
                    where q.id = @id";
        return conn.QuerySingle<QuoteDto<string>>(sql, new { id });
    }

    public QuoteDto<int> AddQuote(QuoteDto<int> quoteDto)
    {
        var conn = _context.Connection();
        var sql = @"insert into quotes (id, author, quote_text, category_id)
                    values (@id, @author, @quotetext, @category)";
        conn.Execute(sql, quoteDto);
        return quoteDto;
    }

    public QuoteDto<int> UpdateQuote(QuoteDto<int> quoteDto)
    {
        var conn = _context.Connection();
        var sql = @"update quotes
                    set author = @author,
                        quote_text = @quotetext,
                        category_id = @category
                        where id = @id";
        conn.Execute(sql, quoteDto);
        return quoteDto;
    }

    public int DeleteQuote(int id)
    {
        var conn = _context.Connection();
        var sql = @"delete from quotes where id = @id";
        return conn.ExecuteScalar<int>(sql, new { id });
    }
    
    public QuoteDto<string> GetQuoteByRandom()
    {
        var conn = _context.Connection();
        var sql = @"select q.id, q.author, q.quote_text as quotetext, c.name as category
                    from quotes as q
                    join categories as c
                    on q.category_id = c.id
                    order by random() limit 1";
        return conn.QuerySingle<QuoteDto<string>>(sql);
    }
    
    public QuoteDto<string> GetQuoteByCategoryId(int id)
    {
        var conn = _context.Connection();
        var sql = @"select q.id, q.author, q.quote_text as quotetext, c.name as category
                    from quotes as q
                    join categories as c
                    on q.category_id = c.id
                    where c.id = @id";
        return conn.QuerySingle<QuoteDto<string>>(sql, new { id });
    }
}