using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo;
using Xunit;
using System.Windows;
using RoboJo.Entities;

namespace RoboJo.Tests
{
    public class FormsTests
    {

        // Arrange
        // Act
        // Assert

        [Fact]
        public void FormShould_LoadRecords()
        {
            // Arrange
            frmMain main = new frmMain();

            // Act
            var data = main.LoadRecords();

            // Assert
            Assert.NotEqual(data.Count(), -1);
        }

        [Fact]
        public void FormShould_LoadRecords_ReturnsEntries()
        {
            // Arrange
            frmMain main = new frmMain();

            // Act
            var data = main.LoadRecords();

            // Assert
            Assert.IsType<Entry>(data.FirstOrDefault());
        }
    }
}
