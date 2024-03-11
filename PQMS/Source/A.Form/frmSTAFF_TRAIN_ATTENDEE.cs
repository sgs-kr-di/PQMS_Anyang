using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PQMS.C.Unit;
using System.Data.OleDb;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace PQMS
{
    public partial class frmSTAFF_TRAIN_ATTENDEE : MetroFramework.Forms.MetroForm
    {
        private UnitCommon unitCommon;
        private OleDbConnection Conn;
        private Dictionary<string, string> comboBoxData = new Dictionary<string, string>();

        private DataTable dt_Attendee;


        public frmSTAFF_TRAIN_ATTENDEE()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void frmSTAFF_TRAIN_ATTENDEE_Load(object sender, EventArgs e)
        {

            // PQMS_STAFF_TRAIN_STAFFLISTGrid.PQMS_STAFF_TRAIN_STAFFLISTGridView.OptionsCustomization.AllowFilter = false;


            get_folder_data(cmb_Dept);
            cmb_Dept.SelectedIndex = 0;                  

            dt_Attendee = new DataTable();
            dt_Attendee.Columns.Add("STAFF_NAME", typeof(string));
            dt_Attendee.Columns.Add("STAFF_EMPNO", typeof(string));
            dt_Attendee.Columns.Add("FOLDER_NAME", typeof(string));
            dt_Attendee.Columns.Add("STAFF_CODE", typeof(string));


            if (Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE != null)
            {
                foreach (DataRow row in Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE.Rows)
                {
                    // GridView의 컬럼 이름에 따라 적절히 수정해야 합니다.
                    string name = row["STAFF_NAME"].ToString();
                    string empno = row["STAFF_EMPNO"].ToString();
                    string folder = row["FOLDER_NAME"].ToString();
                    string code = row["STAFF_CODE"].ToString();

                    dt_Attendee.Rows.Add(name, empno, folder, code);
                }

                PQMS_STAFF_TRAIN_ATTENDEEGrid.DataSource = dt_Attendee;
            }
            else
            {
                
                //참석자에 본인 임을 항상 입력하기 위해서
                string t_staff = Form2PQMS_StaffInfo.sStaffCode;

                string query = "SELECT A.STAFF_NAME, A.STAFF_EMPNO, B.FOLDER_NAME, A.STAFF_CODE FROM PQMS_STAFF A " +
                             " INNER JOIN( " +
                             " SELECT FOLDER_NAME, SITE_CODE+'-' + REPOSITORY_CODE + '-' + WS_CODE + '-' + FOLDER_CODE As 'STAFF_TEAM'   FROM K_WORKSPACE " +
                             " WHERE ISNULL(FOLDER_NAME, '') != '' " +
                             " GROUP BY  FOLDER_NAME,SITE_CODE + '-' + REPOSITORY_CODE + '-' + WS_CODE + '-' + FOLDER_CODE " +
                             " ) B on A.STAFF_TEAM = B.STAFF_TEAM " +
                             " WHERE A.STAFF_CODE = '" + t_staff + "' ";

                DataTable dt = new DataTable();
                OleDbCommand cmd = new OleDbCommand(query, Conn);
                Conn.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    dt_Attendee.Load(reader);
                }
                Conn.Close();

                PQMS_STAFF_TRAIN_ATTENDEEGrid.DataSource = dt_Attendee;

            }

            get_Staff_data();

        }

        private void get_folder_data(ComboBox tCmb) //jhm
        {                             
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";
            query = " SELECT FOLDER_NAME, SITE_CODE+'-'+REPOSITORY_CODE+'-'+WS_CODE+'-'+FOLDER_CODE As 'STAFF_TEAM'   FROM K_WORKSPACE ";
            query += " WHERE ISNULL(FOLDER_NAME, '') != '' ";
            query += " GROUP BY FOLDER_NAME,SITE_CODE+'-'+REPOSITORY_CODE+'-'+WS_CODE+'-'+FOLDER_CODE ";
            query += " ORDER BY SITE_CODE+'-'+REPOSITORY_CODE+'-'+WS_CODE+'-'+FOLDER_CODE ";

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());
                        //tCmb.Items.Add(reader.GetValue(0).ToString() + "/" + reader.GetValue(1).ToString() + "/" + reader.GetValue(2).ToString());

                        string text = reader.GetValue(0).ToString(); // 
                        string value = reader.GetValue(1).ToString(); //

                        comboBoxData[text] = value;
                        tCmb.Items.Add(text);
                    }
                }                
            }
            Conn.Close();
        }


        private void get_Staff_data()
        {
            string selectedText = cmb_Dept.SelectedItem.ToString();
            string selectedValue = "";
            if (comboBoxData.ContainsKey(selectedText))
            {
                selectedValue = comboBoxData[selectedText];                
            }          

            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = " SELECT A.STAFF_NAME, A.STAFF_CODE, A.STAFF_EMPNO, A.STAFF_TEAM, B.FOLDER_NAME, B.STAFF_TEAM FROM PQMS_STAFF A " +
                    " INNER JOIN( " +
                    " SELECT FOLDER_NAME, SITE_CODE+'-' + REPOSITORY_CODE + '-' + WS_CODE + '-' + FOLDER_CODE As 'STAFF_TEAM'   FROM K_WORKSPACE" +
                    " WHERE ISNULL(FOLDER_NAME, '') != '' " +
                    " GROUP BY  FOLDER_NAME,SITE_CODE + '-' + REPOSITORY_CODE + '-' + WS_CODE + '-' + FOLDER_CODE " +
                    " ) B on A.STAFF_TEAM = B.STAFF_TEAM " +
                    " WHERE A.STAFF_TEAM = '" + selectedValue.ToString() + "' AND A.STAFF_NAME != '' ";

                    if (txt_SearchName.Text != "")
                    {
                        query += " AND A.STAFF_NAME  like '%"+txt_SearchName.Text.Trim()+"%' ";
                    }
            query +=  " ORDER BY A.STAFF_NAME ";

            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            Conn.Close();

            string uniqueIdentifierColumnName = "STAFF_CODE";
            if (dt_Attendee != null)
            {
                foreach (DataRow rowB in dt_Attendee.Rows)
                {
                    // Get the unique identifier value from Table B
                    object identifierValue = rowB[uniqueIdentifierColumnName];

                    // Find corresponding row in Table A
                    DataRow rowA = dt.AsEnumerable()
                        .FirstOrDefault(r => object.Equals(r[uniqueIdentifierColumnName], identifierValue));

                    // If a corresponding row is found in Table A, remove it
                    if (rowA != null)
                    {
                        dt.Rows.Remove(rowA);
                    }
                }
            }


            if (dt.Rows.Count > 0)
            {
                PQMS_STAFF_TRAIN_STAFFLISTGrid.DataSource = dt;
            }
            else
            {
                PQMS_STAFF_TRAIN_STAFFLISTGrid.DataSource = null;
            }
        }

        private void cmb_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Staff_data();
        }

        private void btnPQMS_STAFF_TRAIN_ATTENDEE_IN_Click(object sender, EventArgs e)
        {   
            // 선택된 행을 반복하고 DataTable에 추가합니다.
            foreach (int rowHandle in PQMS_STAFF_TRAIN_STAFFLISTGridView.GetSelectedRows())
            {
                if (rowHandle >= 0)
                {
                    DataRowView row = (DataRowView)PQMS_STAFF_TRAIN_STAFFLISTGridView.GetRow(rowHandle);

                    // GridView의 컬럼 이름에 따라 적절히 수정해야 합니다.
                    string name = row["STAFF_NAME"].ToString();
                    string empno = row["STAFF_EMPNO"].ToString();
                    string folder = row["FOLDER_NAME"].ToString();
                    string code = row["STAFF_CODE"].ToString();

                    dt_Attendee.Rows.Add(name, empno, folder, code);
                }
            }
            PQMS_STAFF_TRAIN_ATTENDEEGrid.DataSource = dt_Attendee;

            get_Staff_data();
        }

        private void btnPQMS_STAFF_TRAIN_ATTENDEE_OUT_Click(object sender, EventArgs e)
        {  
            // 선택된 행을 반복하고 DataTable에 추가합니다.
            foreach (int rowHandle in PQMS_STAFF_TRAIN_ATTENDEEGridView.GetSelectedRows())
            {
                if (rowHandle >= 0)
                {
                    DataRowView row = (DataRowView)PQMS_STAFF_TRAIN_ATTENDEEGridView.GetRow(rowHandle);

                    // GridView의 컬럼 이름에 따라 적절히 수정해야 합니다.
                    string name = row["STAFF_NAME"].ToString();
                    string empno = row["STAFF_EMPNO"].ToString();
                    string folder = row["FOLDER_NAME"].ToString();
                    string code = row["STAFF_CODE"].ToString();

                    //DataRow dataRowToDelete = dt_Attendee.Rows.Find(code); // Assuming STAFF_EMPNO is a unique identifier

                    DataRow[] rowsToDelete = dt_Attendee.Select("STAFF_CODE = '" + code + "'");

                    //참석자에 본인은 뺄수 없음
                    if (code != Form2PQMS_StaffInfo.sStaffCode)
                    {
                        foreach (DataRow rowToDelete in rowsToDelete)
                        {
                            dt_Attendee.Rows.Remove(rowToDelete);
                        }
                    }                                                         
                }
            }

            PQMS_STAFF_TRAIN_ATTENDEEGrid.DataSource = null;
            PQMS_STAFF_TRAIN_ATTENDEEGrid.DataSource = dt_Attendee;

            get_Staff_data();
        }

        private void btnInsertTrain_ATTENDEE_Metro_Click(object sender, EventArgs e)
        {

            string s_Attendee_Names = "";
            if (dt_Attendee.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Attendee.Rows.Count; i++)
                {
                    s_Attendee_Names += dt_Attendee.Rows[i]["STAFF_NAME"].ToString() + ",";
                }                
            }
            
            if (!string.IsNullOrEmpty(s_Attendee_Names)) // 마지막 이름의 , 를 제거 
            {
                s_Attendee_Names = s_Attendee_Names.Remove(s_Attendee_Names.Length - 1);
            }

            Form2STAFF_TRAIN_ATTENDEE.sSTAFF_TRAINING_ATTENDEE = s_Attendee_Names;
            Form2STAFF_TRAIN_ATTENDEE.dt_STAFF_TRAIN_ATTENDEE = dt_Attendee;
            this.Close();
        }


     

        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void txt_SearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true; // Prevent adding a new line in a multiline TextBox

                // Call your function here, for example:
                get_Staff_data();
            }
        }
    }
}
