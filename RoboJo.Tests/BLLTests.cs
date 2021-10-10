using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboJo;
using Xunit;

namespace RoboJo.Tests
{
    public class BLLTests
    {
        [Fact]
        public void BLL_CanInstantiate()
        {
            try
            {
                // Arrange / Act
                IBLL _bll = Factory.OpenBLL();

                // Assert
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }

        [Fact]
        public void BLL_CalculateTotals_ReturnsTimeSpan()
        {
            try
            {
                // Arrange
                IBLL _bll = Factory.OpenBLL();

                // Act
                TimeSpan tsTotals = _bll.CalculateTotals();

                // Assert
                Assert.IsType<TimeSpan>(tsTotals);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }


        [Fact]
        public void BLL_CalculateTotals_NoException()
        {
            try
            {
                // Arrange
                IBLL _bll = Factory.OpenBLL();

                // Act
                TimeSpan tsTotals = _bll.CalculateTotals();

                // Assert
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.False(true);
            }
        }
    }
}
