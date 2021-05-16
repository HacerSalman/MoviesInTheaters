using Moq;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Data.Utils;
using MoviesInTheaters.Shared.Repositories;
using MoviesInTheaters.Shared.Services;
using MoviesInTheaters.Shared.UnitOfWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Test
{
    public class CinemaServiceUnitTests
    {
        List<Cinema> cinemaList;
        CinemaService cinemaService;
        [SetUp]
        public void Setup()
        {
            //Arrange
            cinemaList = new List<Cinema>()
                                         {
                                             new Cinema(){Id = 1,Name = "UnitTest1",Status=EntityStatus.Values.ACTIVE, Address ="address",CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()},
                                             new Cinema(){Id = 2,Name = "UnitTest2",Status=EntityStatus.Values.ACTIVE, Address ="address",CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()},
                                             new Cinema(){Id = 3,Name = "UnitTest3",Status=EntityStatus.Values.ACTIVE, Address ="address",CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()}
                                             
                                         };

            Mock<IRepository<Cinema>> mock = new Mock<IRepository<Cinema>>();



            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.Setup(m => m.Cinemas).Returns(mock.Object as ICinemaRepository);
            //Here we are going to mock repository GetAll method 
            unitOfWork.Setup(m => m.Cinemas.GetAllAsync().Result).Returns(cinemaList);
            unitOfWork.Setup(m => m.Cinemas.Find(_ => _.Status == EntityStatus.Values.ACTIVE)).Returns(cinemaList);
            unitOfWork.Setup(m => m.Cinemas.GetCinemasByName(It.IsAny<string>()).Result).Returns((string target) =>
            {
                return cinemaList.Where(_ => _.Name.Contains(target)).ToList();
            });
            //Here we are going to mock repository Add method
            unitOfWork.Setup(m => m.Cinemas.AddAsync(It.IsAny<Cinema>()).Result).Returns((Cinema target) =>
            {
                var original = cinemaList.FirstOrDefault(
                    q => q.Id == target.Id);

                if (original != null)
                {
                    return original;
                }

                cinemaList.Add(target);

                return target;
            });

            unitOfWork.Setup(m => m.Cinemas.DeleteCinema(It.IsAny<Cinema>()).Result).Returns((Cinema target) =>
            {
                var original = cinemaList.FirstOrDefault(
                    q => q.Id == target.Id);

                original.Status = EntityStatus.Values.DELETED;
                return original;
            });

            unitOfWork.Setup(m => m.Cinemas.Update(It.IsAny<Cinema>()).Result).Returns((Cinema target) =>
            {
                var original = cinemaList.FirstOrDefault(
                    q => q.Id == target.Id);

                original.Name = target.Name;
                return true;
            });

            cinemaService = new CinemaService(unitOfWork.Object);
        }

        [Test]
        public void CreateCinema()
        {

            var cinemaName = "UnitTest4";
            var cinema = cinemaService.CreateCinema(new Cinema
            {
                Id = 4,
                Address="address",
                CreateTime = DateTimeUtils.GetCurrentTicks(),
                UpdateTime = DateTimeUtils.GetCurrentTicks(),
                Modifier = "Unittest",
                Owner= "Unittest",
                Name = cinemaName,
                Status = EntityStatus.Values.ACTIVE
            }).Result;
            var result = cinemaService.GetCinemasByName(cinemaName).Result;
            Assert.True(result.Count > 0);
        }


        [Test]
        public void GetActiveCinemalist()
        {
            var result = (List<Cinema>)cinemaService.GetActiveCinemas().Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void UpdateCinema()
        {
            var cinemaName = "UnitTest2";
            var updateCinemaName = "UnitTest5";
            var cinema = cinemaService.GetCinemasByName(cinemaName).Result[0];
            cinema.Name = updateCinemaName;
            var result = cinemaService.UpdateCinema(cinema).Result;
            Assert.AreEqual(updateCinemaName, result.Name);
        }


        [Test]
        public void GetCinemalist()
        {
            var result = (List<Cinema>)cinemaService.GetAllCinemas().Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void GetCinemaByName()
        {
            var cinemaName = "UnitTest3";
            var result = cinemaService.GetCinemasByName(cinemaName).Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void DeleteCinema()
        {
            var cinemaName = "UnitTest3";
            var cinema = cinemaService.GetCinemasByName(cinemaName).Result[0];
            var result = cinemaService.DeleteCinema(cinema).Result;
            Assert.AreEqual(EntityStatus.Values.DELETED, result.Status);
        }
    }
}
