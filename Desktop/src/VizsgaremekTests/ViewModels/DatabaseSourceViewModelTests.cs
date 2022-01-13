using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizsgaremek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels.Tests
{
    [TestClass()]
    public class DatabaseSourceViewModelTests
    {
        [TestMethod()]
        public void DatabaseSourceViewModelTestLocalhost()
        {
            DatabaseSourceViewModel databaseSourceViewModel = new DatabaseSourceViewModel();
            // Felhasználó "rákkattintott a "localhost" szóra
            databaseSourceViewModel.SelectedDatabaseSource = "localhost";
            DbSource expectedDbSource = DbSource.LOCALHOST;

            DbSource actualDbSource = databaseSourceViewModel.DbSource;

            Assert.AreEqual(expectedDbSource, actualDbSource, "A kiválasztott adatbázis a 'localhost', de nem váltott át DbSource.LOCALHOST-ra");
        }

        [TestMethod()]
        public void DatabaseSourceViewModelTestDevops()
        {
        }

        [TestMethod()]
        public void DatabaseSourceViewModelTestNone()
        {
        }
    }