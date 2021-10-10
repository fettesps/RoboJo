using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo;
using Xunit;
using System.Windows;
using RoboJo.Entities;
using System.Windows.Forms;

namespace RoboJo.Tests
{
    public class FormsTests
    {
        #region Main
        
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

        #endregion

        #region Prompt

        [Fact]
        public void Prompt_ReturnsInput()
        {
            // Arrange
            frmPrompt timePrompt = new frmPrompt
            {
                UserInput = "Hello world!",
                Billable = false,
                RunEndTimer = true,
                StartTime = DateTime.Now.AddHours(-1),
                EndTime = DateTime.Now,
                StartPosition = FormStartPosition.WindowsDefaultLocation
            };

            // Act
            timePrompt.Close();

            // Assert
            Assert.NotNull(timePrompt.UserInput);
        }

        #endregion
    }
}
