using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Ulee.Utils;


namespace PQMS.C.Unit
{
    #region Class
    public class Form9PagePQMS_GROUP1Rows
    {
        public string sGROUP1_ORG_CODE { get; set; }

        public string sGROUP1_CODE { get; set; }

        public string sGROUP1_NUM { get; set; }

        public string sGROUP1_NAME { get; set; }

        public Form9PagePQMS_GROUP1Rows()
        {
            sGROUP1_ORG_CODE = "";
            sGROUP1_CODE = "";
            sGROUP1_NUM = "";
            sGROUP1_NAME = "";
        }
    }

    public class Form2PQMS_STAFF_EDUPageRow
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_EDU_CLASS { get; set; }
        public string sSTAFF_EDU_ORG_CODE { get; set; }
        public string sSTAFF_EDU_CODE { get; set; }
        public string sSTAFF_EDU_EXEC_ORG { get; set; }
        public string sSTAFF_EDU_FROM { get; set; }
        public string sSTAFF_EDU_TO { get; set; }
        public string sSTAFF_EDU_HOURS { get; set; }
        public string sSTAFF_EDU_COMP_CERTI { get; set; }
        public string sSTAFF_EDU_PASS_CERTI { get; set; }
        public string sSTAFF_EDU_REPORT { get; set; }
        public string sSTAFF_EDU_APPROVE_DATE { get; set; }
        public string sSTAFF_EDU_APPRVAL { get; set; }
        public string sSTAFF_EDU_APPROVE { get; set; }
        public string sSTAFF_EDU_STATUS { get; set; }

        public Form2PQMS_STAFF_EDUPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_EDU_CLASS = "";
            sSTAFF_EDU_ORG_CODE = "";
            sSTAFF_EDU_CODE = "";
            sSTAFF_EDU_EXEC_ORG = "";
            sSTAFF_EDU_FROM = "";
            sSTAFF_EDU_TO = "";
            sSTAFF_EDU_HOURS = "";
            sSTAFF_EDU_COMP_CERTI = "";
            sSTAFF_EDU_PASS_CERTI = "";
            sSTAFF_EDU_REPORT = "";
            sSTAFF_EDU_APPROVE_DATE = "";
            sSTAFF_EDU_APPRVAL = "";
            sSTAFF_EDU_APPROVE = "";
            sSTAFF_EDU_STATUS = "";
        }
    }

    public class Form2PQMS_STAFF_CERTIPageRow
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_CERTI_ROLE { get; set; }
        public string sSTAFF_CERTI_NAME { get; set; }
        public string sSTAFF_CERTI_DATE { get; set; }
        public string sSTAFF_CERTI_FILE { get; set; }

        public Form2PQMS_STAFF_CERTIPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_CERTI_ROLE = "";
            sSTAFF_CERTI_NAME = "";
            sSTAFF_CERTI_DATE = "";
            sSTAFF_CERTI_FILE = "";
        }
    }

    public class Form2PQMS_STAFF_ROLEPageRow
    {
        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_ROLE_DATE { get; set; }

        public string sSTAFF_ROLE_CLASS { get; set; }

        public string sSTAFF_ROLE_ORG_CODE { get; set; }

        public string sSTAFF_ROLE_CODE { get; set; }

        public string sSTAFF_ROLE_NAME { get; set; }

        public string sSTAFF_ROLE_STATUS { get; set; }

        public string sSTAFF_ROLE_GIVEN_CLASS { get; set; }

        public string sSTAFF_ROLE_CERTI { get; set; }

        public string sSTAFF_ROLE_INSTEAD { get; set; }

        public Form2PQMS_STAFF_ROLEPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_ROLE_DATE = "";
            sSTAFF_ROLE_CLASS = "";
            sSTAFF_ROLE_ORG_CODE = "";
            sSTAFF_ROLE_CODE = "";
            sSTAFF_ROLE_NAME = "";
            sSTAFF_ROLE_STATUS = "";
            sSTAFF_ROLE_GIVEN_CLASS = "";
            sSTAFF_ROLE_CERTI = "";
            sSTAFF_ROLE_INSTEAD = "";
        }
    }

    public class Form2PQMS_STAFF_MainPageRow
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_TEAM { get; set; }
        public string sSTAFF_NAME { get; set; }
        public string sSTAFF_ROLE_NAME { get; set; }
        public string sSTAFF_ROLE_CLASS { get; set; }
        public string sPQMS_STAFF_EDU_TO { get; set; }
        public string sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY { get; set; }
        public string sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION { get; set; }
        public string sSTAFF_EDU_TO_VALIDATION { get; set; }

        public Form2PQMS_STAFF_MainPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_TEAM = "";
            sSTAFF_NAME = "";
            sSTAFF_ROLE_NAME = "";
            sSTAFF_ROLE_CLASS = "";
            sPQMS_STAFF_EDU_TO = "";
            sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY = "";
            sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION = "";
            sSTAFF_EDU_TO_VALIDATION = "";
        }
    }

    public class Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_EDU_TO { get; set; }

        public Form2PQMS_STAFF_MEASUREMENT_UNCERTAINTY_MainPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_EDU_TO = "";
        }
    }

    public class Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_EDU_TO { get; set; }
        public Form2PQMS_STAFF_CONSERVATIVE_EDUCATION_MainPageRow()
        {
            sSTAFF_CODE = "";
            sSTAFF_EDU_TO = "";
        }
    }

    public static class Form1PQMS_Repo 
    {
        public static string sSiteCode { get; set; }

        public static string sRepo { get; set; }

        public static string sWS { get; set; }

        public static string sSiteCode_Name { get; set; }

        public static string sRepo_Name { get; set; }

        public static string sWS_Name { get; set; }

        public static string sSTAFF_Folder { get; set; }

        //public Form1PQMS_Repo()
        //{
        //    sSiteCode = "";
        //    sRepo = "";
        //    sWS = "";
        //}
    }

    public static class Form2PQMS_StaffInfo
    {
        public static string sStaffCode { get; set; }
        public static string sStaffName { get; set; }
        public static string sPQMS_STAFF_TRAINING_IDX { get; set; }

        public static string sPQMS_STAFF_ROLE_PAPER_IDX { get; set; }

        public static string sPMQ_STAFF_ROLE_PAPER_ORG_CODE { get; set; }

        public static string sPQMS_STAFF_ROLE_IDX { get; set; }

        public static string sPQMS_STAFF_ROLE_ORG_CODE { get; set; }

        public static string sPQMS_STAFF_ROLE_CODE { get; set; }

        public static string sPQMS_STAFF_TEAM { get; set; }

        public static string sPQMS_STAFF_TR_FILE { get; set; }
        public static string sPQMS_STAFF_EDU_FILE { get; set; }

        public static string sPQMS_STAFF_RP_FILE { get; set; }

        public static string sPQMS_STAFF_RP_CODE { get; set; }
    }

    public static class Form2PQMS_LoginInfo
    {
        public static string sloginId { get; set; }

        public static string sAccountNo { get; set; }

        public static string sUserId { get; set; }

        public static string sAppId { get; set; }

        public static string sGroupName { get; set; }

        public static string sEmpNo { get; set; }

        
    }

    public static class Form2PQMS_Staff_MenuInfo
    {
        public static string sSTAFF_TEAM { get; set; }
    }

    public static class Form2_GridIdx
    {
        public static string sIDX { get; set; }
        public static string sRPIDX { get; set; }
    }

    public static class Form2_Tab_Info_Now
    {
        public static string sMenuName { get; set; }
        public static string sTabName { get; set; }
    }

    public static class FormRepositoryInfoPQMS_TreeName
    {
        public static string sSearchJaryoNodeName { get; set; }
        public static string sSearchGibonNodeName { get; set; }
        public static string sSearch_ROLE2_SITE_CODE_NodeName { get; set; }
        public static string sSearch_ROLE2_REPOSITORY_CODE_NodeName { get; set; }
        public static string sSearch_ROLE2_WS_CODE_NodeName { get; set; }
        public static string sSearch_Org_Group_Code { get; set; }
    }

    public  class Form2STAFF_TRAIN_ATTENDEE
    {
        public static string sSTAFF_TRAINING_ATTENDEE { get; set; }
        public static DataTable dt_STAFF_TRAIN_ATTENDEE { get; set; }
        //public Form2STAFF_TRAIN_ATTENDEE()
        //{
        //    if (dt_STAFF_TRAIN_ATTENDEE == null)
        //    {
        //        dt_STAFF_TRAIN_ATTENDEE = new DataTable();

        //        // Add columns to the DataTable, if needed
        //        dt_STAFF_TRAIN_ATTENDEE.Columns.Add("STAFF_NAME", typeof(string));
        //        dt_STAFF_TRAIN_ATTENDEE.Columns.Add("STAFF_EMPNO", typeof(string));
        //        dt_STAFF_TRAIN_ATTENDEE.Columns.Add("FOLDER_NAME", typeof(string));
        //        dt_STAFF_TRAIN_ATTENDEE.Columns.Add("STAFF_CODE", typeof(string));

        //    }
        //}
    }

    public static class Form2STAFF_EACHLIST_REMARK
    {
        public static string sSTAFF_EACHLIST_REMARK { get; set; }

    }


    public static class Form2STAFF_TRAIN_CONTENTS
    {
        public static string sSTAFF_TRAIN_CONTENTS { get; set; }

    }

    public static class Form2STAFF_TRAIN_OBJECTIVE
    {
        public static string sSTAFF_TRAIN_OBJECTIVE { get; set; }

    }

    public static class Form2STAFF_TRAIN_GOAL
    {
        public static string sSTAFF_TRAIN_GOAL { get; set; }
    }

    public static class Form2PQMS_TabName
    {
        public static string sTabName { get; set; }
    }

    public static class FormStaffInfoAll
    {
      
    }

    public static class Form2PQMS_STAFF_APPROVE_STATE
    {
        public static string sSTAFF_ROLE_APPROVE_STATUS { get; set; }
        public static string sSTAFF_ROLE_PAPER_APPROVE_STATUS { get; set; }
        public static string sSTAFF_EACHLIST_APPROVE_STATUS { get; set; }
        public static string sSTAFF_EDU_APPROVE_STATUS { get; set; }
    }

    #endregion
}
