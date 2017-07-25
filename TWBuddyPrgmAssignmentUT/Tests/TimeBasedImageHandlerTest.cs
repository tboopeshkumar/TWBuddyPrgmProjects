using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smocks;
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
        [TestMethod]
        public void TestTimeValidatorWithAMValue()
        {
            Smock.Run(context =>
            {
                context.Setup(() => DateTime.Now).Returns(new DateTime(2015, 2, 20, 9, 0, 0));
                TimeBasedImageHandler timeHandler = new TimeBasedImageHandler();
                Assert.AreEqual(Constants.AMImageURL, timeHandler.GetImageBasedOnCurrentTime());
            });


        }

        [TestMethod]
        public void TestTimeValidatorWithPMValue()
        {
            Smock.Run(context =>
            {
                context.Setup(() => DateTime.Now).Returns(new DateTime(2015, 2, 20, 19, 0, 0));
                TimeBasedImageHandler timeHandler = new TimeBasedImageHandler();
                Assert.AreEqual(Constants.PMImageURL, timeHandler.GetImageBasedOnCurrentTime());
            });

        }
    }
}
