using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo;
using RoboJo.Entities;
using Xunit;

namespace RoboJo.Tests
{
    public class DbTests
    {
        #region DB

        [Fact]
        public void Db_CanInstantiate()
        {
            try
            {
                // Arrange / Act
                IDAL _dal = Factory.OpenDB();

                // Assert
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }

        [Fact]
        public void Db_ReturnRecords()
        {
            // Arrange
            IDAL _dal = Factory.OpenDB();

            // Act
            var data = _dal.ReadFromDb();

            // Assert
            Assert.NotEqual(data.Count(), -1);
        }

        [Fact]
        public void Db_HasConnectionString()
        {
            // Arrange
            IDAL _dal = Factory.OpenDB();

            // Act
            string str = _dal.GetConnectionString();

            // Assert
            Assert.NotEmpty(str);
            Assert.NotNull(str);
        }

        #endregion

        #region FakeDB

        [Fact]
        public void FakeDb_ReturnsRecords()
        {
            // Arrange
            IDAL _dal = new FakeDb();

            // Act
            var data = _dal.ReadFromDb();

            // Assert
            Assert.NotEqual(data.Count(), -1);
        }

        [Fact]
        public void FakeDb_ReturnsEntries()
        {
            // Arrange
            IDAL _dal = new FakeDb();

            // Act
            var data = _dal.ReadFromDb();

            // Assert
            Assert.IsType<Entry>(data.FirstOrDefault());
        }

        #endregion

        #region FakeDb2

        [Fact]
        public void FakeDb2_HasConnectionString()
        {
            // Arrange
            IDAL _dal = new FakeDb2();

            // Act
            string str = _dal.GetConnectionString();

            // Assert
            Assert.NotEmpty(str);
            Assert.NotNull(str);
            Assert.True(str.Length > 0);
        }

        [Fact]
        public void FakeDb2_CanAddRecord()
        {
            // Arrange
            IDAL _dal = new FakeDb2();

            // Act
            var data = _dal.WriteToDb(new DateTime(2021, 10, 9, 9, 0, 0, 0), new DateTime(2021, 10, 9, 10, 0, 0, 0), "Starting the day", new TimeSpan(1, 0, 0), true);

            // Assert
            Assert.Equal(1, (data > 0 ? 1 : 0));
        }

        [Fact]
        public void FakeDb2_CanDeleteRecord()
        {
            // Arrange
            IDAL _dal = new FakeDb2();

            // Act
            long lngId = _dal.WriteToDb(new DateTime(2021, 10, 9, 9, 0, 0, 0), new DateTime(2021, 10, 9, 10, 0, 0, 0), "Starting the day", new TimeSpan(1, 0, 0), true);
            bool booDelete = _dal.DeleteFromDb((int)lngId);

            // Assert
            Assert.True(booDelete);
        }

        [Fact]
        public void FakeDb2_ClearRecords()
        {
            // Arrange
            IDAL _dal = new FakeDb2();

            // Act
            var data = _dal.WriteToDb(new DateTime(2021, 10, 9, 9, 0, 0, 0), new DateTime(2021, 10, 9, 10, 0, 0, 0), "Starting the day", new TimeSpan(1, 0, 0), true);
            var data2 = _dal.WriteToDb(new DateTime(2021, 10, 9, 10, 0, 0, 0), new DateTime(2021, 10, 9, 10, 30, 0, 0), "Standups", new TimeSpan(1, 0, 0), true);
            var data3 = _dal.WriteToDb(new DateTime(2021, 10, 9, 10, 30, 0, 0), new DateTime(2021, 10, 9, 12, 0, 0, 0), "Estimating", new TimeSpan(1, 0, 0), true);
            var data4 = _dal.WriteToDb(new DateTime(2021, 10, 9, 12, 0, 0, 0), new DateTime(2021, 10, 9, 12, 30, 0, 0), "Lunch", new TimeSpan(0, 30, 0), false);

            bool booClear = _dal.ClearDb();
            var records = _dal.ReadFromDb();

            // Assert
            Assert.True(booClear && records.Count() == 0);
        }

        #endregion
    }
}
