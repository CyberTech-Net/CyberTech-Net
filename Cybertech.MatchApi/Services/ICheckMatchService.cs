namespace Cybertech.MatchApi.Services
{
    public interface ICheckMatchService
    {
        Task CheckMatchAsync(Guid MatchId, DateTime dt);
    }
}