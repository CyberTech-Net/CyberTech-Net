using AutoFixture.AutoNSubstitute;
using AutoFixture;
using CyberTech.Api.Controllers;
using NSubstitute;
using CyberTech.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using CyberTech.Core.Dto.Tournament;
using FluentAssertions;
using CyberTech.API.ModelViews.Tournament;
using FluentValidation;
using CyberTech.API.Validators.Tournament;
using CyberTech.API.UnitTests.AutoFixtureCustomizations;

namespace CyberTech.API.UnitTests.Controllers
{
    public class TournamentControllerTests
    {
        private readonly ITournamentService _tournamentService;
        private readonly TournamentController _tournamentController;
        private readonly IFixture _fixture;

        public TournamentControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _fixture.Customize(new TournamentCustomization());
            _tournamentService = Substitute.For<ITournamentService>();
            IValidator<CreatingTournamentModel> createValidator = new CreatingTournamentModelValidator();
            _fixture.Inject(_tournamentService);
            _fixture.Inject(createValidator);
            _tournamentController = _fixture.Build<TournamentController>().OmitAutoProperties().Create();
        }

        [Fact]
        public async Task IfTournamentDoesNotExist_ReturnsNotFound()
        {
            //Arrnge
            var tournamentId = Guid.NewGuid();
            _tournamentService.GetByIdAsync(tournamentId).Returns((TournamentDto?)null);

            //Act
            var result = await _tournamentController.GetAsync(tournamentId);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task IfTournamentExist_ReturnsValue()
        {
            //Arrnge
            var tournamentId = Guid.NewGuid();
            _tournamentService.GetByIdAsync(tournamentId).Returns(new TournamentDto());

            //Act
            var result = await _tournamentController.GetAsync(tournamentId);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task IfCreatingTournamentModelNotValid_ReturnsBadRequest()
        {
            //Arrnge
            var tournament = new CreatingTournamentModel()
            {
                DateTournamentInit = DateTime.Now,
                DateTournamentEnd = DateTime.Now.AddDays(-1),
            };

            //Act
            var result = await _tournamentController.AddAsync(tournament);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task IfCreatingTournamentIsValid_ReturnsBadRequest()
        {
            //Arrnge
            var tournament = _fixture.Create<CreatingTournamentModel>(); ;

            //Act
            var result = await _tournamentController.AddAsync(tournament);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
