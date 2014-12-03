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
        public void DoesTournamentCreateIfNoTournamentInProgress()
        {

            //Arrange
            var RtnObj = new Tournament() { InProgress = true };
            var NewTournament = new Tournament(){ ID = 0, InProgress = false, Name="test"} ;
            var ProvResult = new ProviderResult<Tournament>(){ Status = ProviderStatusCode.OK, Value = NewTournament };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.RetrieveOne(It.IsAny<Func<Tournament, bool>>()))
                .Returns(RtnObj);
            Provider.Setup(x => x.Create(It.IsAny<Tournament>()))
                .Returns(ProvResult);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.CreateNewTournament(NewTournament);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DoesTournamentFailToCreateIfTournamentInProgress()
        {
            //Arrange

            var NewTournament = new Tournament() { ID = 0, InProgress = false, Name = "test" };
            var ProvResult = new ProviderResult<Tournament>() { Status = ProviderStatusCode.OK, Value = NewTournament };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.RetrieveOne(It.IsAny<Func<Tournament, bool>>()))
                .Returns<Tournament>(null);
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
            var RtnObj = new Tournament() { InProgress = true };

            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.RetrieveOne(It.IsAny<Func<Tournament, bool>>()))
                .Returns(RtnObj);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.GetTournamentInProgress();

            //Assert
            Assert.AreSame(RtnObj, result);
        }

        [TestMethod]
        public void DoesTournamentReturnNullIfNotInProgress()
        {
            //Arrange
            var Provider = new Mock<ITournamentProvider>();
            Provider.Setup(x => x.RetrieveOne(It.IsAny<Func<Tournament, bool>>()))
                .Returns<Tournament>(null);

            ITournamentService TournamentServ = new TournamentService(Provider.Object);

            //Act
            var result = TournamentServ.GetTournamentInProgress();

            //Assert
            Assert.IsNull(result);
        }
    }
}
