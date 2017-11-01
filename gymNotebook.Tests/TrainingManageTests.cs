using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using gymNotebook.Abstract;
using gymNotebook.Models;
using gymNotebook.Controllers;
using System.Web.Mvc;

namespace gymNotebook.Tests
{
    [TestClass]
    public class TrainingManageTests
    {
        [TestMethod]
        public void Can_Delete_Valid_Training_With_Sessions()
        {
            Training tran = new Training { TrainingID = 1, TrainingName = "Push-Pull", UserId = "test" };

            Mock<ITrainingManageRepository> mock = new Mock<ITrainingManageRepository>();
            mock.Setup(m => m.Trainings).Returns(new Training[]
            {
                tran
            });

            TrainingSession session = new TrainingSession { SessionID = 1, SessionName = "Monday", TrainingID = 1 };

            TrainingController target = new TrainingController(mock.Object);

            target.DeleteTrainig(tran.TrainingID);
        }
    }
}
