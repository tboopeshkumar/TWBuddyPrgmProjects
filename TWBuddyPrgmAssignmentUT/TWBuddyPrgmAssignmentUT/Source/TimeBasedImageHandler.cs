using Common;
using System;

namespace TWBuddyPrgmAssignmentUT
{
    /// <summary>
    /// Class to handle time based image operations
    /// </summary>
    public class TimeBasedImageHandler
    {
        /// <summary>
        /// Returns the image url based on the current time value - AM : SunRise image, PM: MoonRise image. 
        /// </summary>
        /// <returns>The image url</returns>
        public string GetImageBasedOnCurrentTime()
        {
            string returnValue = "";
            if (DateTime.Now.ToString("tt") == "AM")
            {
                returnValue = Constants.AMImageURL;
            }
            else if (DateTime.Now.ToString("tt") == "PM")
            {
                returnValue = Constants.PMImageURL;
            }
            return returnValue;
        }
    }
}
