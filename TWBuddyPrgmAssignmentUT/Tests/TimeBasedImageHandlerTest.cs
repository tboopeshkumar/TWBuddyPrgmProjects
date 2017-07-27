using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWBuddyPrgmAssignmentUT;
using Common;

/**
 * Test for @{@link TimeBasedImageHandler}
 * Problem statement : Implement a time based image handler which will return images specific to current system time.
 *
 * A correct implementation will pass all the tests.
 */
namespace Tests
{
    [TestClass]
    public class TimeBasedImageHandlerTest
    {
        /// <summary>
        /// Method to test the AM time value output. 
        /// </summary>
        [TestMethod]
        public void TestTimeValidatorWithAMValue()
        {
            var mockDateTimeProvider = new Moq.Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(dp => dp.Now).Returns(new DateTime(2015, 2, 20, 9, 0, 0));
            TimeBasedImageHandler timeHandler = new TimeBasedImageHandler(mockDateTimeProvider.Object);
            Assert.AreEqual(Constants.AMImageURL, timeHandler.GetImageBasedOnCurrentTime());
        }

        /// <summary>
        /// Method to test the PM time value output. 
        /// </summary>
        [TestMethod]
        public void TestTimeValidatorWithPMValue()
        {
            var mockDateTimeProvider = new Moq.Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(dp => dp.Now).Returns(new DateTime(2015, 2, 20, 19, 0, 0));
            TimeBasedImageHandler timeHandler = new TimeBasedImageHandler(mockDateTimeProvider.Object);
            Assert.AreEqual(Constants.PMImageURL, timeHandler.GetImageBasedOnCurrentTime());
        }

        /// <summary>
        /// Method to test the null input exception. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),Constants.DateTimeNotInitializedErrorMessage)]
        public void TestTimeValidatorWithNullValue()
        {
           TimeBasedImageHandler timeHandler = new TimeBasedImageHandler(null);
            timeHandler.GetImageBasedOnCurrentTime();
        }
    }
}
