using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    #endregion
}
