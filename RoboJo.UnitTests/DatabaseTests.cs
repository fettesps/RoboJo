using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RoboJo;

namespace RoboJo.UnitTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void Test_WriteToDb()
        {
            // Arrange
            DateTime? dtStart = DateTime.Now.AddHours(-1);
            DateTime? dtEnd = DateTime.Now;
            string strDescription = "This is a test";
            TimeSpan tsHours = new TimeSpan(1, 0, 0);
            bool booBillable = true;

            // Act
            DAL dal = new DAL();
            long lngResult = dal.WriteToDb(dtStart, dtEnd, strDescription, tsHours, booBillable);

            // Assert
            // Should return a long which is the inserted row's ID
            // Should return -1 if there are no results
            Assert.AreEqual(0, (lngResult > 0 ? 1 : 0));
        }


        public void Test_WriteToDbDal()
        {
            DAL _dal = Factory.OpenDB();
        }



        //bool ClearDb();
        //bool DeleteFromDb(int entry_id);
        //IEnumerable<Entry> ReadFromDb();
        //long WriteToDb(DateTime? dtStart, DateTime? dtEnd, string strDescription, TimeSpan tsHours, bool booBillable);
    }
}
