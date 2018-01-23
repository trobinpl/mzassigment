using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gitconnect.Model;
using System.Collections.Generic;
using System.Linq;

namespace gitconnect.Model.Tests
{
    [TestClass]
    public class RepositorySortTest
    {
        [TestMethod]
        public void GetRepositoresSortedByStargazerCount()
        {

            User user = new User("testuser", "Wroclaw, Poland", "http://sample.avatar.com", new List<Repository>()
            {
                new Repository("TestRepo", 0),
                new Repository("AnotherRepo", 100),
                new Repository("Lorem", 20),
                new Repository("Ipsum", 35),
                new Repository("Dolor", 5),
                new Repository("Sit", 9),
                new Repository("Amet", 900)
            });

            List<Repository> sortedRepositories = user.GetRepositoriesSortedBy(r => r.StargazerCount).ToList();

            List<Repository> expectedRepositories = new List<Repository>()
            {
                new Repository("Amet", 900),
                new Repository("AnotherRepo", 100),
                new Repository("Ipsum", 35),
                new Repository("Lorem", 20),
                new Repository("Sit", 9),
                new Repository("Dolor", 5),
                new Repository("TestRepo", 0)
            };

            CollectionAssert.AreEqual(expectedRepositories, sortedRepositories);
        }
    }
}
