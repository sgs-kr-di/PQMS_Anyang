using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using Ulee.Database.SqlServer;
using Ulee.Utils;

namespace PQMS
{
    public class AppDatabase : UlSqlServer
    {
        public SqlConnection Connect { get { return connect; } }

        public AppDatabase(string connectString = null) : base(connectString)
        {
        }

        public new void Open()
        {
            base.Open();
        }

        public new void Close()
        {
            base.Close();
        }
    }

    public class Form2DataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_NAME { get; set; }

        public string sSTAFF_TEAM { get; set; }

        public string sSTAFF_JOIN_DATE { get; set; }

        public string sSTAFF_MAJOR { get; set; }

        public string sSTAFF_SCHOOL { get; set; }

        public Form2DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * FROM( " +
                $" SELECT " +
                $" a.STAFF_NAME, a.STAFF_TEAM, a.STAFF_CODE, b.STAFF_CERTI_ROLE, b.STAFF_CERTI_DATE, " +
                $" ROW_NUMBER() OVER (PARTITION BY a.STAFF_NAME ORDER BY b.STAFF_CERTI_DATE DESC) AS RankNo " +
                $" FROM PQMS_STAFF AS a " +
                $" inner join PQMS_STAFF_CERTI AS b " +
                $" on a.STAFF_CODE = b.STAFF_CODE " +
                $" ) T " +
                $" WHERE RankNo = 1 ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectSTAFF_EDU(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_EDU] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectSTAFF_CERTI(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_CERTI] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void SelectSTAFF_ROLE(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_ROLE] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_NAME}', '{sSTAFF_TEAM}', '{sSTAFF_JOIN_DATE}', '{sSTAFF_MAJOR}', '{sSTAFF_SCHOOL}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_STAFF set " +
                $" STAFF_NAME='{sSTAFF_NAME}', STAFF_TEAM='{sSTAFF_TEAM}', STAFF_JOIN_DATE='{sSTAFF_JOIN_DATE}', STAFF_MAJOR='{sSTAFF_MAJOR}', STAFF_SCHOOL='{sSTAFF_SCHOOL}'" +
                $" where STAFF_CODE='{sSTAFF_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF " +
                $" where STAFF_CODE={sSTAFF_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form2PQMS_STAFF_EDUDataSet : UlSqlDataSet
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

        public Form2PQMS_STAFF_EDUDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }        

        public void SelectSTAFF_EDU(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_EDU] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }
    }

    public class Form2PQMS_STAFF_CERTIGridDataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_CERTI_ROLE { get; set; }
        public string sSTAFF_CERTI_NAME { get; set; }
        public string sSTAFF_CERTI_DATE { get; set; }
        public string sSTAFF_CERTI_FILE { get; set; }

        public Form2PQMS_STAFF_CERTIGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_CERTI(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_CERTI] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }
    }

    public class Form2PQMS_STAFF_ROLEGridDataSet : UlSqlDataSet
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

        public Form2PQMS_STAFF_ROLEGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_ROLE(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS].[dbo].[PQMS_STAFF_ROLE] ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }
    }

    public class Form3DataSet : UlSqlDataSet
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

        public Form3DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_STAFF_EDU ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_EDU values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_EDU_CLASS}', '{sSTAFF_EDU_ORG_CODE}', '{sSTAFF_EDU_CODE}', '{sSTAFF_EDU_EXEC_ORG}'," +
                $" '{sSTAFF_EDU_FROM}', '{sSTAFF_EDU_TO}', '{sSTAFF_EDU_HOURS}', '{sSTAFF_EDU_COMP_CERTI}', '{sSTAFF_EDU_PASS_CERTI}'," +
                $" '{sSTAFF_EDU_REPORT}', '{sSTAFF_EDU_APPROVE_DATE}', '{sSTAFF_EDU_APPRVAL}', '{sSTAFF_EDU_APPROVE}', '{sSTAFF_EDU_STATUS}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_STAFF_EDU set " +
                $" STAFF_EDU_CLASS='{sSTAFF_EDU_CLASS}', STAFF_EDU_ORG_CODE='{sSTAFF_EDU_ORG_CODE}', STAFF_EDU_CODE='{sSTAFF_EDU_CODE}', STAFF_EDU_EXEC_ORG='{sSTAFF_EDU_EXEC_ORG}', " +
                $" STAFF_EDU_FROM='{sSTAFF_EDU_FROM}', STAFF_EDU_TO='{sSTAFF_EDU_TO}', STAFF_EDU_HOURS='{sSTAFF_EDU_HOURS}', STAFF_EDU_COMP_CERTI='{sSTAFF_EDU_COMP_CERTI}', " +
                $" STAFF_EDU_PASS_CERTI='{sSTAFF_EDU_PASS_CERTI}', STAFF_EDU_REPORT='{sSTAFF_EDU_REPORT}', STAFF_EDU_APPROVE_DATE='{sSTAFF_EDU_APPROVE_DATE}', " +
                $" STAFF_EDU_APPRVAL='{sSTAFF_EDU_APPRVAL}', STAFF_EDU_APPROVE='{sSTAFF_EDU_APPROVE}', STAFF_EDU_STATUS='{sSTAFF_EDU_STATUS}'" +
                $" where STAFF_CODE='{sSTAFF_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF_EDU " +
                $" where STAFF_CODE={sSTAFF_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form4DataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_CERTI_ROLE { get; set; }
        public string sSTAFF_CERTI_NAME { get; set; }
        public string sSTAFF_CERTI_DATE { get; set; }
        public string sSTAFF_CERTI_FILE { get; set; }

        public Form4DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_STAFF_CERTI ";

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_CERTI values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_CERTI_ROLE}', '{sSTAFF_CERTI_NAME}', '{sSTAFF_CERTI_DATE}', '{sSTAFF_CERTI_FILE}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_STAFF_CERTI set " +
                $" STAFF_CERTI_ROLE='{sSTAFF_CERTI_ROLE}', STAFF_CERTI_NAME='{sSTAFF_CERTI_NAME}', STAFF_CERTI_DATE='{sSTAFF_CERTI_DATE}', STAFF_CERTI_FILE='{sSTAFF_CERTI_FILE}'" +
                $" where STAFF_CODE='{sSTAFF_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF_CERTI " +
                $" where STAFF_CODE={sSTAFF_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form5DataSet : UlSqlDataSet
    {
        public string sORG_CODE { get; set; }

        public string sORG_NAME { get; set; }

        public Form5DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_ORG ";

            if (string.IsNullOrWhiteSpace(sORG_CODE) == false)
            {
                sql += $" where ORG_CODE='{sORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ORG values " +
                $" ('{sORG_CODE}', '{sORG_NAME}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_ORG set " +
                $" ORG_NAME='{sORG_NAME}'" +
                $" where ORG_CODE='{sORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_ORG " +
                $" where ORG_NAME={sORG_NAME} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form6DataSet : UlSqlDataSet
    {
        public string sEDU_ORG_CODE { get; set; }

        public string sEDU_CODE { get; set; }

        public string sEDU_NAME { get; set; }

        public Form6DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_EDU ";
            if (string.IsNullOrWhiteSpace(sEDU_ORG_CODE) == false)
            {
                sql += $" where EDU_ORG_CODE='{sEDU_ORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_EDU values " +
                $" ('{sEDU_ORG_CODE}', '{sEDU_CODE}', '{sEDU_NAME}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_EDU set " +
                $" EDU_CODE='{sEDU_CODE}', EDU_NAME='{sEDU_NAME}'" +
                $" where EDU_ORG_CODE='{sEDU_ORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_EDU " +
                $" where EDU_CODE={sEDU_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form7DataSet : UlSqlDataSet
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

        public Form7DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_STAFF_ROLE ";
            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where STAFF_CODE='{sSTAFF_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_ROLE values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_ROLE_DATE}', '{sSTAFF_ROLE_CLASS}', '{sSTAFF_ROLE_ORG_CODE}', '{sSTAFF_ROLE_CODE}'," +
                $" '{sSTAFF_ROLE_NAME}', '{sSTAFF_ROLE_STATUS}', '{sSTAFF_ROLE_GIVEN_CLASS}', '{sSTAFF_ROLE_CERTI}', '{sSTAFF_ROLE_INSTEAD}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);                
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_STAFF_ROLE set " +
                $" STAFF_ROLE_DATE='{sSTAFF_ROLE_DATE}', STAFF_ROLE_CLASS='{sSTAFF_ROLE_CLASS}', STAFF_ROLE_ORG_CODE='{sSTAFF_ROLE_ORG_CODE}', STAFF_ROLE_CODE='{sSTAFF_ROLE_CODE}', STAFF_ROLE_NAME='{sSTAFF_ROLE_NAME}'," +
                $" STAFF_ROLE_STATUS='{sSTAFF_ROLE_STATUS}', STAFF_ROLE_GIVEN_CLASS='{sSTAFF_ROLE_GIVEN_CLASS}', STAFF_ROLE_CERTI='{sSTAFF_ROLE_CERTI}', STAFF_ROLE_INSTEAD='{sSTAFF_ROLE_INSTEAD}'" +
                $" where STAFF_CODE='{sSTAFF_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF_ROLE " +
                $" where STAFF_CODE={sSTAFF_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form8DataSet : UlSqlDataSet
    {
        public string sEDU_ORG_CODE { get; set; }

        public string sVALI_PERIOD { get; set; }

        public string sVALI_DATE { get; set; }

        public string sVALI_ENABLE { get; set; }

        public Form8DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_EDU_VALI_DATE ";
            if (string.IsNullOrWhiteSpace(sEDU_ORG_CODE) == false)
            {
                sql += $" where EDU_ORG_CODE='{sEDU_ORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_EDU_VALI_DATE values " +
                $" ('{sEDU_ORG_CODE}', '{sVALI_PERIOD}', '{sVALI_DATE}', '{sVALI_ENABLE}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_EDU_VALI_DATE set " +
                $" VALI_PERIOD='{sVALI_PERIOD}', VALI_DATE='{sVALI_DATE}', VALI_ENABLE='{sVALI_ENABLE}'" +
                $" where EDU_ORG_CODE='{sEDU_ORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_EDU_VALI_DATE " +
                $" where EDU_ORG_CODE={sEDU_ORG_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form9DataSet : UlSqlDataSet
    {
        public string sGROUP1_ORG_CODE { get; set; }

        public string sGROUP1_CODE { get; set; }

        public string sGROUP1_NUM { get; set; }

        public string sGROUP1_NAME { get; set; }

        public Form9DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_GROUP1 ";
            if (string.IsNullOrWhiteSpace(sGROUP1_ORG_CODE) == false)
            {
                sql += $" where GROUP1_ORG_CODE='{sGROUP1_ORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_GROUP1 values " +
                $" ('{sGROUP1_ORG_CODE}', {sGROUP1_CODE}, '{sGROUP1_NUM}', '{sGROUP1_NAME}'); ";
                //$" select cast(scope_identity() as bigint); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_GROUP1 set " +
                $" GROUP1_CODE='{sGROUP1_CODE}', GROUP1_NUM='{sGROUP1_NUM}', GROUP1_NAME='{sGROUP1_NAME}'" +
                $" where GROUP1_ORG_CODE='{sGROUP1_ORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_GROUP1 " +
                $" where GROUP1_ORG_CODE={sGROUP1_ORG_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form10DataSet : UlSqlDataSet
    {
        public string sGROUP2_ORG_CODE { get; set; }

        public string sGROUP2_GROUP1_CODE { get; set; }

        public string sGROUP2_CODE { get; set; }

        public string sGROUP2_NAME { get; set; }

        public Form10DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_GROUP2 ";
            if (string.IsNullOrWhiteSpace(sGROUP2_ORG_CODE) == false)
            {
                sql += $" where GROUP2_ORG_CODE='{sGROUP2_ORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_GROUP2 values " +
                $" ('{sGROUP2_ORG_CODE}', {sGROUP2_GROUP1_CODE}, '{sGROUP2_CODE}', '{sGROUP2_NAME}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_GROUP2 set " +
                $" GROUP2_GROUP1_CODE='{sGROUP2_GROUP1_CODE}', GROUP2_CODE='{sGROUP2_CODE}', GROUP2_NAME='{sGROUP2_NAME}'" +
                $" where GROUP2_ORG_CODE='{sGROUP2_ORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_GROUP2 " +
                $" where GROUP2_ORG_CODE={sGROUP2_ORG_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form11DataSet : UlSqlDataSet
    {
        public string sTEAM_CODE { get; set; }

        public string sTEAM_NAME { get; set; }

        public string sTEAM_NAME2 { get; set; }

        public Form11DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_TEAM ";
            if (string.IsNullOrWhiteSpace(sTEAM_CODE) == false)
            {
                sql += $" where TEAM_CODE='{sTEAM_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_TEAM values " +
                $" ('{sTEAM_CODE}', '{sTEAM_NAME}', '{sTEAM_NAME2}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_TEAM set " +
                $" TEAM_NAME='{sTEAM_NAME}', TEAM_NAME2='{sTEAM_NAME2}'" +
                $" where TEAM_CODE='{sTEAM_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_TEAM " +
                $" where TEAM_CODE={sTEAM_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }

    public class Form13DataSet : UlSqlDataSet
    {
        public string sROLE_ORG_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sROLE_NAME { get; set; }

        public Form13DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_ROLE ";

            if (string.IsNullOrWhiteSpace(sROLE_ORG_CODE) == false)
            {
                sql += $" where ROLE_ORG_CODE='{sROLE_ORG_CODE}'";
            }
            else
            {

            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE values " +
                $" ('{sROLE_ORG_CODE}', '{sROLE_CODE}', '{sROLE_NAME}'); ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Update(SqlTransaction trans = null)
        {
            string sql =
                $" update PQMS_ROLE set " +
                $" ROLE_CODE='{sROLE_CODE}', ROLE_NAME='{sROLE_NAME}'" +
                $" where ROLE_ORG_CODE='{sROLE_ORG_CODE}' ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_ROLE " +
                $" where ROLE_ORG_CODE={sROLE_ORG_CODE} ";

            SetTrans(trans);

            try
            {
                BeginTrans(trans);
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CommitTrans(trans);
            }
            catch (Exception e)
            {
                RollbackTrans(trans, e);
            }
        }
    }
}