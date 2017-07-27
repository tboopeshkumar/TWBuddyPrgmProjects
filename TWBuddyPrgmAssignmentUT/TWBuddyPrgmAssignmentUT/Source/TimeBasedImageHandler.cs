using Common;
using System;

namespace TWBuddyPrgmAssignmentUT
{
    /// <summary>
    /// Class to handle time based image operations
    /// </summary>
    public class TimeBasedImageHandler
    {
        private IDateTimeProvider dateTimeProvider;

        public TimeBasedImageHandler(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }
        
        /// <summary>
        /// Returns the image url based on the current time value - AM : SunRise image, PM: MoonRise image. 
        /// </summary>
        /// <returns>The image url</returns>
        public string GetImageBasedOnCurrentTime()
        {
            string returnValue = "";
            if (dateTimeProvider != null)
            {
                if (dateTimeProvider.Now.ToString("tt") == "AM")
                {
                    returnValue = Constants.AMImageURL;
                }
                else if (dateTimeProvider.Now.ToString("tt") == "PM")
                {
                    returnValue = Constants.PMImageURL;
                }
            }
            else
                throw new Exception(Constants.DateTimeNotInitializedErrorMessage);
            return returnValue;
        }
    }
}
