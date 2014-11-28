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

            Assert.Fail();
        }

        [TestMethod]
        public void DoesTournamentFailToCreateIfTournamentInProgress()
        {
            Assert.Fail();
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
