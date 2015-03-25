using System;

namespace Mechsoft.GeneralUtilities
{
    /// <summary>
    /// Summary description for Cls_Constant
    /// </summary>
    public class Cls_Constant
    {
        //ViewState Constant variables 
        public const string VIEWSTATE_SORTDIRECTION = "sortdirection";
        public const string VIEWSTATE_SORTEXPRESSION = "sortexpression";
        public const string VIEWSTATE_SORTEXPRESSION1 = "sortexpression1";
        public const string VIEWSTATE_SORTDIRECTION1 = "sortdirection1";
        public const string VIEWSTATE_SORTEXPRESSION2 = "sortexpression2";
        public const string VIEWSTATE_SORTDIRECTION2 = "sortdirection2";
        //public const string VIEWSTATE_SORTEXPRESSION2 = "sortexpression2";

        public const string VIEWSTATE_DESC = "desc";
        public const string VIEWSTATE_ASC = "asc";
        public const string VIEWSTATE_ORGID = "orgid";
        public const string VIEWSTATE_INSTITUTEID = "instid";
        public const string VIEWSTATE_SARCHNAME = "sarchname";

        public const string EMPLOYEE_PHOTO_PATH = "~/UserPhotos/EmployeePhoto/";
        public const string EMPLOYEE_NO_PHOTO_PATH = "~/Images/no_photo.png";
        public const string BOOK_IMAGE_PATH = "~/Book Image/";

        public const string STUDENT_PHOTO_PATH = "~/Documents/Photo/";
        public const string STUDENT_DOCUMENT_PATH = "~/UserDoc/StudDoc/";
        public const string STUDENT_NO_PHOTO_PATH = "~/Student Photo/no_photo.png";

        public const string SYLLABUS_PATH = "~/Documents/SyllabusDoc/";

        public const string VIEWSTATE_Employee_SORTDIRECTION = "empsortdirection";
        public const string VIEWSTATE_Employee_SORTEXPRESSION = "empsortexpression";

        public const string VIEWSTATE_Parents_SORTDIRECTION = "prsortdirection";
        public const string VIEWSTATE_Parents_SORTEXPRESSION = "prsortexpression";

        public const string VIEWSTATE_Employee_DESC = "desc";
        public const string VIEWSTATE_Employee_ASC = "asc";

        public const string VIEWSTATE_Parents_DESC = "desc";
        public const string VIEWSTATE_Parents_ASC = "asc";

        public const string FREQUENCY_QUARTERLY = "quarterly";
        public const string FREQUENCY_SEMESTER = "half yearly";
        public const string FREQUENCY_YEARLY = "yearly";
        public const string FREQUENCY_MONTHLY = "monthly";

        public const string SETTING_TEACHERCOMMENTS = "teachercomments";
        public const string SETTING_SELFASSESSMENT = "selfassessment";
        public const string SETTING_STUDSEECOMMENTS = "StudSeeComments";

        public const string MODE_STUDENT = "student";
        public const string MODE_EMPLOYEE = "employee";

        public const string MODE_SELF = "self";
        public const string MODE_OTHER = "other";

        public const string VIEWSTATE_ORDERITEMTABLE = "orderitemtable";

        //CSS Class Name
        public const string Css_Class_WeekEnd = "weekend";
        public const string Css_Class_HolyDay = "holyday";
        public const string Css_Class_Present = "present";
        public const string Css_Class_Absent = "absent";
        public const string Css_Class_NoAttendance = "noattendance";

        public const string Css_Class_stdNameColumn = "stdAttendance";
        public const string Css_Class_studentName = "AssStudentName";

        //Tool Tip Constant
        public const string ToolTip_WeekEnd = "Week End";
        public const string ToolTip_HolyDay = "HolyDay";
        public const string ToolTip_Present = "Present";
        public const string ToolTip_Absent = "Absent";
        public const string ToolTip_NoAttendance = "No Attendance";
       
        //Session Veriable 
        public const string sessionOrganizationId = "OrganizationId";
        public const string sessionOrganizationName = "OrganizationName";
        public const string sessionInstituteId = "InstituteId";
        public const string sessionUserId = "UserId";
        public const string StudentUserId = "StudentUserId";
        public const string sessionAllowToInstall = "AllowToInstall";

        //Get Document Course type
        public const string Doc_Cat_Course_Material = "1";
        public const string Doc_Cat_Class_Notes = "2";
        public const string Doc_Cat_Assignments = "3";
        public const string Doc_Cat_QandA_Set = "4";
        public const string Doc_Cat_Help = "Help";
        public const string Doc_Cat_Feedback = "Feedback";
        public const string Doc_Cat_FAQ = "FAQ's";

        ///GET Table ID's for Customized field
        public const Int64 StudentMaster = 4;
        public const Int64 StudentGuardian = 5;
        public const Int64 StudentContact = 6;
        public const Int64 StudentPhysicalDtls = 7;
        public const Int64 StudentCourse = 8;

        public const String Currency = "Indian Rupee";
        public const String CurrencyAbbrivation = "INR";

        /**************************Table Names******************************/
        public const String strOrganization = "tbl_Organization_Master";
        public const String strInstitute = "tbl_Institute_Master";
        public const String strStream = "tbl_Stream_Master";
        public const String strDepartment = "tbl_Department_Master";
        public const String strCourseType = "tbl_CourseType_Master";
        public const String strCourse = "tbl_Course_Master";
        public const String strCourseYear = "tbl_CourseYears";
        public const String strBatch = "tbl_BatchDetails";
        public const String strBatchDivision = "tbl_BatchDivisionMapping";
        public const String strQuata = "Quotas";
        public const String strGender = "Gender";

        public enum CandidateStatus
        {
            Select = 1,
            Reject = 2,
            Next = 3

        }


        //this status is also used in manpower request for is canceleed
        public const string MANPOWER_REQUEST_STATUS_YES = "Y";
        //this status is also used in manpower request for is canceleed
        public const string MANPOWER_REQUEST_STATUS_NO = "N";

        public const string INTERVIEW_STATUS_YES = "S";

        public const string APPROVED_YES = "Y";
        public const string APPROVED_NO = "N";

        public const int Action_View = 2;
        public const int Action_Add = 1;


        public const string Entity_OrgId = "OrganizationId";
        public const string Entity_SemesterId = "SemesterId";

        // Constants For Alert Types
        public const Int16 MailAlert = 2;   //Send Alert Through Mail
        public const Int16 SMSAlert = 1;     // Send Alert Through SMS
        public const Int16 DashBoardAlert = 3;   //Show Alert on Dashboard

        #region New Development

        // Added By Rupali

        public const string Level1 = "Organization";
        public const string Level2 = "University";
        public const string Level3 = "Institute";

        // Default Role Of Knocean.
        public const Int32 SuperadminRole = 1;
        public const Int32 BranchadminRole = 2;
        public const Int32 EmployeeRole = 3;
        public const Int32 StudentRole = 4;
        public const Int32 ParentRole = 5;

        public const string ModuleDisscussionBoard = "DisscussionBoard";
        public const string ModuleEventANDSchedular = "EventANDSchedular";

        #endregion

        #region Worksheet
        public enum ParameterDataType
        {
            Select = 0,
            TEXT = 1,
            RADIO = 2,
            LIST = 3,
            CHECKBOX = 4
        }

        public enum CategoryStatus
        {
            Select = 0,
            Active = 1,
            Deactive = 2,

        }

        public enum DocumentStatus
        {
            Select = 0,
            Lock = 1,
            Unlock = 2,

        }
        public enum WorksheetStatus
        {
            Select = 0,
            Completed = 2,
            Pending = 1,
            InProcess = 3
        }
        public enum QuestionType
        {
            Select = 0,
            Automatic = 1,
            WordProblem = 2,
            Manual = 3,
            Graphical = 4
        }
        public enum Culture
        {
            Select = 0,
            en = 1,
            de = 2,
            fr = 3,
            jp = 4
        }
        public enum Alignment
        {
            Select = 0,
            left = 1,
            right = 2,
            center = 3
        }

        public enum DocumentType
        {
            Select = 0,
            doc = 1,
            excel = 2,
            images = 3,
            audioVideo = 4,
            link = 5,
            txt = 6

        }
        public const string SESSION_DisplayResult = "DisplayResult";
        public const string MODE_YES = "true";
        public const string MODE_NO = "false";
        public const string SESSION_CANDIDATEID = "candidateid";
        public const string SESSION_TESTMODE = "testMode";
        public const string TESTMODE_SERIALIZE = "S";
        public const string SESSION_ATTEMPTID = "attemptid";
        public const string PATH_DoneAnswer = "img/done.gif";
        public const string PATH_SkipAnswer = "img/skip.gif";
        public const int WIDTH_QUESTIONIMAGE = 150;
        public const int HEIGHT_QUESTIONIMAGE = 150;
        public const string PATH_QUESTIONIMAGE = "img/Question Images/";
        public const string PREFIX_QUESTIONIMAGE = "Qu_";
        public const string PREFIX_OPTIONIMAGE = "_Opt";
        public const string MODE_INSERT = "insert";
        public const string MODE_UPDATE = "update";
        //public const string VIEWSTATE_SORTEXPRESSION = "sortexpression";
        //public const string VIEWSTATE_SORTDIRECTION = "sortdirection";
        //public const string VIEWSTATE_ASC = "asc";
        //public const string VIEWSTATE_DESC = "desc";
        public const string PATH_GRAPHICALIMAGE = "img/Graphical.png";
        public const string PATH_NONGRAPHICALIMAGE = "img/NoGrapgical.png";
        public const string SESSION_TESTTIMESECOND = "testsecond";
        public const string SESSION_QuestionTime = "QuestionDuration";
        public const string SESSION_IsQuestLevelTime = "IsQuestionLevelTime";
        public const string SESSION_IsQuestAttemptAllow = "IsQueAttemptAllow";
        public const string SESSION_NoOfQuetAttempt = "NoOfQueAttempt";
        public const string SESSION_IsWorksheetLevelTime = "IsWorksheetLevelTime";
        public const string SESSION_WorksheetTimeDuration = "WorksheetDuration";
        public const string SESSION_WorksheetAttemptId = "WorksheetAttemptId";
        public const string SESSION_WorksheetAttemptCount = "AttemptCount";
        public const string SESSION_WorksheetId = "WorksheetID";
        public const string SESSION_StudAssignId = "StudAssignId";
        public const string PATH_BlankImage = "img/blank.png";
        public const int Manual_QuestionMode = 2;
        public const int Automatic_QuestionMode = 1;
        public const Int64 FileMaxLength = 2097151; //2MB
        public const Int64 IconSize = 1048576; //1MB
        public const Int64 IconHeight = 50; //1MB
        public const Int64 IconWidth = 50; //1MB
        public static string SERVER_URL = System.Configuration.ConfigurationManager.AppSettings["SERVER_URL"].ToString();
        public const int WIDTH_GraphicalQUESTION = 800;
        public const int HEIGHT_GraphicalQUESTION = 500;
        public string GetFraction(string dVal)
        {
            string sRetrun = "";
            switch (dVal)
            {
                case "0.1":
                    sRetrun = "&#189;";
                    break;
                case "0.2":
                    sRetrun = "&#189;";
                    break;
                case "0.3":
                    sRetrun = "&#189;";
                    break;
                case "0.4":
                    sRetrun = "&#189;";
                    break;
                case "0.5":
                    sRetrun = "&#189;";
                    break;
                case "0.3333":
                    sRetrun = "&#8531;";
                    break;

                default:
                    break;
            }
            return sRetrun;
        }
        public const string MinimumDate = "1753/01/01";
        public const string MaximumDate = "9999/12/31";
        #endregion
    }
}
