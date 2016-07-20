using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoolTourn.Services;
using PoolTourn.Data.Providers;
using PoolTourn.Data.Result;
using PoolTourn.Domain.Models;
using Moq;

namespace PoolTourn.Test
{
    [TestClass]
    public class TournamentServiceTest
    {

        [TestMethod]
        public void DoesTournamentFailToCreateIfNoTournamentExists()
        {

            //Arrange
            var rtnObj = new Tournament() { InProgress = true };
            var returnResult = new ProviderResult<Tournament>() {Status = ProviderStatusCode.Ok, Value = rtnObj};

            var newTournament = new Tournament() { ID = 0, InProgress = false, Name = "test" };
            var provResult = new ProviderResult<Tournament>() { Status = ProviderStatusCode.NotFound, Value = null };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.GetTournamentInProgress())
                .Returns(returnResult);
            Provider.Setup(x => x.Create(It.IsAny<Tournament>()))
                .Returns(provResult);

            ITournamentService tournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = tournamentServ.CreateNewTournament(newTournament);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DoesTournamentFailToCreateIfTournamentInProgress()
        {

            //Arrange
            var rtnObj = new Tournament() { InProgress = true };
            var returnResult = new ProviderResult<Tournament>() { Status = ProviderStatusCode.Ok, Value = rtnObj };
            var NewTournament = new Tournament(){ ID = 0, InProgress = false, Name="test"} ;
            var ProvResult = new ProviderResult<Tournament>(){ Status = ProviderStatusCode.Ok, Value = NewTournament };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.GetTournamentInProgress())
                      .Returns(returnResult);
            Provider.Setup(x => x.Create(It.IsAny<Tournament>()))
                .Returns(ProvResult);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.CreateNewTournament(NewTournament);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DoesTournamentCreateIfNoTournamentInProgress()
        {
            //Arrange

            var NewTournament = new Tournament() { ID = 0, InProgress = false, Name = "test" };
            var ProvResult = new ProviderResult<Tournament>() { Status = ProviderStatusCode.Ok, Value = NewTournament };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.GetTournamentInProgress())
                      .Returns(new ProviderResult<Tournament>() { Status = ProviderStatusCode.NotFound});
            Provider.Setup(x => x.Create(It.IsAny<Tournament>()))
                .Returns(ProvResult);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.CreateNewTournament(NewTournament);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.InProgress); 
        }

        [TestMethod]
        public void DoesTournamentReturnIfInProgress()
        {
            //Arrange
            var RtnObj = new ProviderResult<Tournament>() {Status = ProviderStatusCode.Ok, Value = new Tournament(){ InProgress = true }};

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.GetTournamentInProgress())
                .Returns(RtnObj);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.GetTournamentInProgress();

            //Assert
            Assert.AreSame(RtnObj.Value, result);
        }

        [TestMethod]
        public void DoesTournamentReturnNullIfNotInProgress()
        {
            //Arrange
            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.GetTournamentInProgress())
                .Returns(new ProviderResult<Tournament>() {Status = ProviderStatusCode.NotFound, Value = null});

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.GetTournamentInProgress();

            //Assert
            Assert.IsNull(result);
        }
    }
}
