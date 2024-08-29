using AutoFixture;
using CyberTech.API.ModelViews.Tournament;

namespace CyberTech.API.UnitTests.AutoFixtureCustomizations
{
    public class TournamentCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<CreatingTournamentModel>(composer => composer
            .Without(x => x.DateTournamentInit)  
            .Without(x => x.DateTournamentEnd)    
            .Do(creatingTournament =>
            {
                var initDate = DateTime.Now.AddDays(fixture.Create<short>() % 10); 
                var endDate = initDate.AddDays(fixture.Create<short>() % 10); 

                creatingTournament.DateTournamentInit = initDate;
                creatingTournament.DateTournamentEnd = endDate;
            }));
        }
    }
}
