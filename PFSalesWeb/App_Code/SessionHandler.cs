using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace Mechsoft.GeneralUtilities
{
    /// <summary>
    /// This clss contails all session keys used in application
    /// </summary>
    public static class SessionKeys
    {
        // to store logged in user information i.e. instance of UserSessionInfo class
        public const string USER_SESSION_OBJECT_KEY = "UserSessionInfoObject";

        public const string Profile_SESSION_OBJECT_KEY = "ProfileInfoObject";

        public const string TIME_TABLE_STRUCTURE_KEY = "TimeTableStructure";
    }

    /// <summary>
    /// This class is used to Handle session operations.
    /// e.g. Add/Retrieval of objects.
    /// </summary>
    public class SessionHandler
    {
        /// <summary>
        /// Returns object stored in session according to session key
        /// </summary>
        /// <param name="key">Key of session</param>
        /// <returns></returns>
        public static object GetSessionValue(string key)
        {
            if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session[key] != null)
                return System.Web.HttpContext.Current.Session[key];
            return null;
        }

        /// <summary>
        /// Add value in session for a key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSessionValue(string key, object value)
        {
            if (System.Web.HttpContext.Current.Session != null)
                System.Web.HttpContext.Current.Session.Add(key, value);
        }
    }
}
