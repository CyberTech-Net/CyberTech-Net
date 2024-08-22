namespace CyberTech.Application.Services
{
    public interface IGenMatchResultService
    {
        Task CreateMatchResultAsync(Guid MatchId);
    }
}