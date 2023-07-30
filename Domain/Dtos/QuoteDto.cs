namespace Domain.Dtos;

public class QuoteDto<T>
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string QuoteText { get; set; }
    public T Category { get; set; }
}