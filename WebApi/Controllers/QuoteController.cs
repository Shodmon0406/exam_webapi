using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController
{
    private QuoteService _quoteService;

    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpGet("GetQuotes")]
    public List<QuoteDto<string>> GetQuotes()
    {
        return _quoteService.GetQuotes();
    }

    [HttpGet("GetQuoteById")]
    public QuoteDto<string> GetQuoteById(int id)
    {
        return _quoteService.GetQuoteById(id);
    }

    [HttpPost("AddQuote")]
    public QuoteDto<int> AddQuote(QuoteDto<int> quoteDto)
    {
        return _quoteService.AddQuote(quoteDto);
    }

    [HttpPut("UpdateQuote")]
    public QuoteDto<int> UpdateQuote(QuoteDto<int> quoteDto)
    {
        return _quoteService.UpdateQuote(quoteDto);
    }

    [HttpDelete("DeleteQuote")]
    public int DeleteQuote(int id)
    {
        return _quoteService.DeleteQuote(id);
    }
    
    [HttpGet("GetQuoteByRandom")]
    public QuoteDto<string> GetQuoteByRandom()
    {
        return _quoteService.GetQuoteByRandom();
    }
    
    [HttpGet("GetQuoteByCategoryId")]
    public List<QuoteDto<string>> GetQuoteByCategoryId(int id)
    {
        return _quoteService.GetQuoteByCategoryId(id);
    }
}