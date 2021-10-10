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
    }
}
