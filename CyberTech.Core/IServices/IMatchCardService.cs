using CyberTech.Core.Dto.MatchCard;
using System.Threading;

namespace CyberTech.Core.IServices
{
    public interface IMatchCardService
    {
        Task<ICollection<MatchCardDto>> GetMatchCard(CancellationToken cancellationToken);
    }
}