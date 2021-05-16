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

namespace MoviesInTheaters.Test
{
    public class MovieServiceUnitTests
    {
        List<Movie> movieList;
        MovieService movieService;
        [SetUp]
        public void Setup()
        {
            //Arrange
            movieList = new List<Movie>()
                                         {
                                             new Movie(){Id = 1,Name = "UnitTest1",Status=EntityStatus.Values.ACTIVE, CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()},
                                             new Movie(){Id = 2,Name = "UnitTest2",Status=EntityStatus.Values.ACTIVE, CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()},
                                             new Movie(){Id = 3,Name = "UnitTest3",Status=EntityStatus.Values.ACTIVE, CreateTime = DateTimeUtils.GetCurrentTicks(),Modifier = "Unittest",Owner = "Unittest",UpdateTime=  DateTimeUtils.GetCurrentTicks()}

                                         };

            Mock<IRepository<Movie>> mock = new Mock<IRepository<Movie>>();



            Mock<IUnitOfWork> unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.Setup(m => m.Movies).Returns(mock.Object as IMovieRepository);
            //Here we are going to mock repository GetAll method 
            unitOfWork.Setup(m => m.Movies.GetAllAsync().Result).Returns(movieList);
            unitOfWork.Setup(m => m.Movies.Find(_ => _.Status == EntityStatus.Values.ACTIVE)).Returns(movieList);
            unitOfWork.Setup(m => m.Movies.GetMoviesByName(It.IsAny<string>()).Result).Returns((string target) =>
            {
                return movieList.Where(_ => _.Name.Contains(target)).ToList();
            });
            //Here we are going to mock repository Add method
            unitOfWork.Setup(m => m.Movies.AddAsync(It.IsAny<Movie>()).Result).Returns((Movie target) =>
            {
                var original = movieList.FirstOrDefault(
                    q => q.Id == target.Id);

                if (original != null)
                {
                    return original;
                }

                movieList.Add(target);

                return target;
            });

            unitOfWork.Setup(m => m.Movies.DeleteMovie(It.IsAny<Movie>()).Result).Returns((Movie target) =>
            {
                var original = movieList.FirstOrDefault(
                    q => q.Id == target.Id);

                original.Status = EntityStatus.Values.DELETED;
                return original;
            });

            unitOfWork.Setup(m => m.Movies.Update(It.IsAny<Movie>()).Result).Returns((Movie target) =>
            {
                var original = movieList.FirstOrDefault(
                    q => q.Id == target.Id);

                original.Name = target.Name;
                return true;
            });

            movieService = new MovieService(unitOfWork.Object);
        }

        [Test]
        public void CreateMovie()
        {

            var movieName = "UnitTest4";
            var movie = movieService.CreateMovie(new Movie
            {
                Id = 4,
                CreateTime = DateTimeUtils.GetCurrentTicks(),
                UpdateTime = DateTimeUtils.GetCurrentTicks(),
                Modifier = "Unittest",
                Owner = "Unittest",
                Name = movieName,
                Status = EntityStatus.Values.ACTIVE
            }).Result;
            var result = movieService.GetMoviesByName(movieName).Result;
            Assert.True(result.Count > 0);
        }


        [Test]
        public void GetActiveMovielist()
        {
            var result = (List<Movie>)movieService.GetActiveMovies().Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void UpdateMovie()
        {
            var movieName = "UnitTest2";
            var updateMovieName = "UnitTest5";
            var movie = movieService.GetMoviesByName(movieName).Result[0];
            movie.Name = updateMovieName;
            var result = movieService.UpdateMovie(movie).Result;
            Assert.AreEqual(updateMovieName, result.Name);
        }


        [Test]
        public void GetMovielist()
        {
            var result = (List<Movie>)movieService.GetAllMovies().Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void GetMovieByName()
        {
            var movieName = "UnitTest3";
            var result = movieService.GetMoviesByName(movieName).Result;
            Assert.True(result.Count > 0);
        }

        [Test]
        public void DeleteMovie()
        {
            var movieName = "UnitTest3";
            var movie = movieService.GetMoviesByName(movieName).Result[0];
            var result = movieService.DeleteMovie(movie).Result;
            Assert.AreEqual(EntityStatus.Values.DELETED, result.Status);
        }
    }
}
