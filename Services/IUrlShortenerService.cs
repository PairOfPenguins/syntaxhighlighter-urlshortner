namespace pet2.Services
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrlAsync(string longUrl);
    }
}
