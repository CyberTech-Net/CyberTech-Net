namespace CyberTech.MessagesContracts.TournamentMeets
{
    /// <summary>
    /// Событие запланированной встречи
    /// </summary>
    public class MatchPlanned
    {
        public Guid Id { get; set; }

        public DateTime StartDateTime { get; set; }
    }
}
