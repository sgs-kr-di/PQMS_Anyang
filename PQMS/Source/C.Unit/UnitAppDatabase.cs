using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Ulee.Database.SqlServer;
using Ulee.Utils;
using PQMS.C.Unit;


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
        public string sSTAFF_RESIGNATION_DATE { get; set; }
        public string sSTAFF_ROLE_NAME { get; set; }
        public string sSTAFF_ROLE_CLASS { get; set; }
        public string sSTAFF_EDU_TO { get; set; }
        public string sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY { get; set; }
        public string sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION { get; set; }
        public string sSTAFF_EDU_TO_VALIDATION { get; set; }
        public string sSTAFF_ACCOUNTNO { get; set; }//jhm0711
        public string sSTAFF_EMPNO { get; set; }//jhm0711

        public string sSTAFF_FILE { get; set; }

        public Form2DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select_StaffKolasTopTeam(string sTreeName = "", string srdbValue = "", bool bRdbStaffResignationValue = false, string sGroupCode1 = "", string sSort = "", SqlTransaction trans = null)
        {
            string sql = $"SELECT a.*, f.*, g.*, e.*, h.*, " +
                $" B.FROM_DATE AS 'STAFF_EDU_FROM_1', B.TO_DATE AS 'STAFF_EDU_TO_1',  C.FROM_DATE AS 'STAFF_EDU_FROM_2', C.TO_DATE AS 'STAFF_EDU_TO_2', D.TRAIN_DATE AS 'STAFF_EDU_TO_3' " +
                //$" CASE " +
                //$" WHEN D.STAFF_EDU_TO IS NOT NULL AND D.STAFF_EDU_TO <> '' THEN DATEADD(year,3,convert(date, D.STAFF_EDU_TO, 20)) " +
                //$" WHEN(D.STAFF_EDU_TO IS NULL OR  D.STAFF_EDU_TO = '') AND(B.STAFF_EDU_TO > C.STAFF_EDU_TO) THEN DATEADD(year,3,convert(date, B.STAFF_EDU_TO, 20)) " +
                //$" ELSE DATEADD(year,3,convert(date, B.STAFF_EDU_TO, 20)) " +
                //$" END AS NEXTEDU " +
                $" FROM PQMS_STAFF A " +
                $" LEFT OUTER JOIN(" +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E001' GROUP BY staff_code " +
                $" union all " +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E004' GROUP BY staff_code " +
                $") AS B ON(A.STAFF_CODE = B.STAFF_CODE) " +
                $" LEFT OUTER JOIN(" +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E002' GROUP BY staff_code " +
                $") AS C ON(A.STAFF_CODE = C.STAFF_CODE) " +
                $" LEFT OUTER JOIN( " +
                $" select staff_code, Max(STAFF_TRAIN_DATE)TRAIN_DATE  from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E003' GROUP BY staff_code" +
                $") AS D ON(A.STAFF_CODE = D.STAFF_CODE) " +
                $" LEFT OUTER JOIN(select * from ( " +
                $" select * " +
                $" , Row_number() " +
                $" OVER( " +
                $" partition BY STAFF_CODE " +
                $" ORDER BY STAFF_ROLE_DATE) AS RowNum " +
                $" from pqms_staff_role " +
                $" ) T " +
                $" where T.rownum = '1') AS E " +
                $" on (a.STAFF_CODE = e.STAFF_CODE) " +
                $" INNER JOIN [PQMS_STAFF_ROLE] AS g " +
                $" ON ( a.STAFF_CODE = g.STAFF_CODE) " +
                $" INNER JOIN [PQMS_GROUP2] AS F " +
                $" on (F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = g.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = g.STAFF_ROLE_ORG_CODE " +
                $" AND A.SITE_CODE = F.SITE_CODE AND A.REPOSITORY_CODE = F.REPOSITORY_CODE AND A.WS_CODE = F.WS_CODE " +
                $" INNER JOIN[PQMS_GROUP1] AS h " +
                $" ON F.group2_group1_code = h.GROUP1_CODE and f.GROUP2_ORG_CODE = h.GROUP1_ORG_CODE " +
                $" AND A.SITE_CODE = h.SITE_CODE AND A.REPOSITORY_CODE = h.REPOSITORY_CODE AND A.WS_CODE = h.WS_CODE " +
                $" WHERE (replace(a.STAFF_TEAM,'-','') LIKE '%' + Replace(" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + sTreeName + ",'-', '') + '%') ";

            if (srdbValue != "")
            {
                sql += $" AND g.[STAFF_ROLE_ORG_CODE] = '" + srdbValue + "' ";
            }

            if (sGroupCode1 != "")
            {
                sql += $" AND SUBSTRING(g.[STAFF_ROLE_CLASS],1,4)='" + sGroupCode1 + "'";
            }

            if (bRdbStaffResignationValue == false)
            {
                sql += $" and (a.staff_resignation_date is null or a.staff_resignation_date = ' ') "; //재직자
            }
            else
            {
                sql += $"and (a.staff_resignation_date is not null and a.staff_resignation_date <> '')"; // 퇴사자
            }

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("DEPT"))
            {
                sql += "and Replace(a.staff_team, '-', '') = '" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + Form1PQMS_Repo.sWS + Form1PQMS_Repo.sSTAFF_Folder + "'";
            }

            if (sSort == "") //정렬조건이 없으면 
            {
                sql += $" order by a.STAFF_CODE asc ";
            }
            else
            {
                sql += $" order by a." + sSort + " asc ";
            }
                       


            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select_StaffFoodTopTeam(string sTreeName = "", string srdbValue = "", bool bRdbStaffResignationValue = false, string sGroupCode1 = "", string sSort = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT a.*, f.*, g.*, D.STAFF_EDU_TO AS 'STAFF_EDU_TO_1', e.*, h.*, " +
                $" CASE " +
                $" WHEN D.STAFF_EDU_TO IS NOT NULL AND D.STAFF_EDU_TO <> '' THEN DATEADD(ms, -3, DATEADD(yy, DATEDIFF(yy, 0, D.staff_edu_to) + 2, 0)) " +
                $" END AS NEXTEDU " +
                $" FROM PQMS_STAFF A " +
                $" LEFT OUTER JOIN(SELECT STAFF_CODE, MAX(STAFF_EDU_TO) AS STAFF_EDU_TO FROM PQMS_STAFF_EDU WHERE STAFF_EDU_ORG_CODE = '0002' AND STAFF_EDU_CODE = 'E001' GROUP BY STAFF_CODE) AS D " +
                $" ON(A.STAFF_CODE = D.STAFF_CODE) " +
                $" LEFT OUTER JOIN(select * from ( " +
                $" select * " +
                $" , Row_number() " +
                $" OVER( " +
                $" partition BY STAFF_CODE " +
                $" ORDER BY STAFF_ROLE_DATE) AS RowNum " +
                $" from pqms_staff_role " +
                $" ) T " +
                $" where T.rownum = '1') AS E " +
                $" on (a.STAFF_CODE = e.STAFF_CODE) " +
                $" INNER JOIN [PQMS_STAFF_ROLE] AS g " +
                $" ON ( a.STAFF_CODE = g.STAFF_CODE) " +
                $" INNER JOIN [PQMS_GROUP2] AS F " +
                $" on (F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = g.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = g.STAFF_ROLE_ORG_CODE " +
                $" AND A.SITE_CODE = F.SITE_CODE AND A.REPOSITORY_CODE = F.REPOSITORY_CODE AND A.WS_CODE = F.WS_CODE " +
                $" INNER JOIN[PQMS_GROUP1] AS h " +
                $" ON F.group2_group1_code = h.GROUP1_CODE and f.GROUP2_ORG_CODE = h.GROUP1_ORG_CODE " +
                $" AND A.SITE_CODE = h.SITE_CODE AND A.REPOSITORY_CODE = h.REPOSITORY_CODE AND A.WS_CODE = h.WS_CODE " +
                $" WHERE (replace(a.STAFF_TEAM,'-','') LIKE '%' + Replace(" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + sTreeName + ",'-', '') + '%') ";
            if (srdbValue != "")
            {
                sql += $" AND g.[STAFF_ROLE_ORG_CODE] = '" + srdbValue + "' ";
            }

            if (sGroupCode1 != "")
            {
                sql += $" AND SUBSTRING(g.[STAFF_ROLE_CLASS],1,4)='" + sGroupCode1 + "'";
            }

            if (bRdbStaffResignationValue == false)
            {
                sql += $" and (a.staff_resignation_date is null or a.staff_resignation_date = '') ";
            }
            else
            {
                sql += $"and (a.staff_resignation_date is not null and a.staff_resignation_date <> '')";
            }

            if (Form2PQMS_LoginInfo.sGroupName.ToUpper().Contains("DEPT"))
            {
                sql += "and Replace(a.staff_team, '-', '') = '" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + Form1PQMS_Repo.sWS + Form1PQMS_Repo.sSTAFF_Folder + "'";
            }


            if (sSort == "") //정렬조건이 없으면 
            {
                sql += $" order by a.STAFF_CODE asc ";
            }
            else
            {
                sql += $" order by a." + sSort + " asc ";
            }


            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select_StaffKolasTopTeam_User(string sTreeName = "", string srdbValue = "", bool bRdbStaffResignationValue = false, string sGroupCode1 = "", string sSort = "", SqlTransaction trans = null)
        {
            string sql = $"SELECT a.*, f.*, g.*, e.*, h.*, " +
                $" B.FROM_DATE AS 'STAFF_EDU_FROM_1', B.TO_DATE AS 'STAFF_EDU_TO_1',  C.FROM_DATE AS 'STAFF_EDU_FROM_2', C.TO_DATE AS 'STAFF_EDU_TO_2', D.TRAIN_DATE AS 'STAFF_EDU_TO_3' " +
                //$" CASE " +
                //$" WHEN D.STAFF_EDU_TO IS NOT NULL AND D.STAFF_EDU_TO <> '' THEN DATEADD(year,3,convert(date, D.STAFF_EDU_TO, 20)) " +
                //$" WHEN(D.STAFF_EDU_TO IS NULL OR  D.STAFF_EDU_TO = '') AND(B.STAFF_EDU_TO > C.STAFF_EDU_TO) THEN DATEADD(year,3,convert(date, B.STAFF_EDU_TO, 20)) " +
                //$" ELSE DATEADD(year,3,convert(date, C.STAFF_EDU_TO, 20)) " +
                //$" END AS NEXTEDU " +
                $" FROM PQMS_STAFF A " +
                $" LEFT OUTER JOIN(" +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E001' GROUP BY staff_code " +
                $" union all " +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E004' GROUP BY staff_code " +
                $") AS B ON(A.STAFF_CODE = B.STAFF_CODE) " +
                $" LEFT OUTER JOIN(" +
                $" select staff_code, Max(STAFF_TRAIN_DATE) FROM_DATE , Max(STAFF_TRAIN_DATE_TO) TO_DATE from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E002' GROUP BY staff_code " +
                $") AS C ON(A.STAFF_CODE = C.STAFF_CODE) " +
                $" LEFT OUTER JOIN( " +
                $" select staff_code, Max(STAFF_TRAIN_DATE)TRAIN_DATE  from PQMS_STAFF_TRAINING where STAFF_TRAIN_COURSE = '0001/E003' GROUP BY staff_code" +
                $") AS D ON(A.STAFF_CODE = D.STAFF_CODE) " +
                $" LEFT OUTER JOIN(select * from ( " +
                $" select * " +
                $" , Row_number() " +
                $" OVER( " +
                $" partition BY STAFF_CODE " +
                $" ORDER BY STAFF_ROLE_DATE) AS RowNum " +
                $" from pqms_staff_role " +
                $" ) T " +
                $" where T.rownum = '1') AS E " +
                $" on (a.STAFF_CODE = e.STAFF_CODE) " +
                $" INNER JOIN [PQMS_STAFF_ROLE] AS g " +
                $" ON ( a.STAFF_CODE = g.STAFF_CODE) " +
                $" INNER JOIN [PQMS_GROUP2] AS F " +
                $" on (F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = g.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = g.STAFF_ROLE_ORG_CODE " +
                $" AND A.SITE_CODE = F.SITE_CODE AND A.REPOSITORY_CODE = F.REPOSITORY_CODE AND A.WS_CODE = F.WS_CODE " +
                $" INNER JOIN[PQMS_GROUP1] AS h " +
                $" ON F.group2_group1_code = h.GROUP1_CODE and f.GROUP2_ORG_CODE = h.GROUP1_ORG_CODE " +
                $" AND A.SITE_CODE = h.SITE_CODE AND A.REPOSITORY_CODE = h.REPOSITORY_CODE AND A.WS_CODE = h.WS_CODE " +
                $" WHERE (replace(a.STAFF_TEAM,'-','') LIKE '%' + Replace(" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + sTreeName + ",'-', '') + '%') ";

            if (srdbValue != "")
            {
                sql += $" AND g.[STAFF_ROLE_ORG_CODE] = '" + srdbValue + "' ";
            }

            if (sGroupCode1 != "")
            {
                sql += $" AND SUBSTRING(g.[STAFF_ROLE_CLASS],1,4)='" + sGroupCode1 + "'";
            }

            if (bRdbStaffResignationValue == false)
            {
                sql += $" and (a.staff_resignation_date is null or a.staff_resignation_date = '') ";
            }
            else
            {
                sql += $" and (a.staff_resignation_date is not null and a.staff_resignation_date <> '')";
            }

            if (string.IsNullOrWhiteSpace(Form2PQMS_LoginInfo.sAccountNo) == false)
            {
                sql += $" and a.ACCOUNT_NO='{Form2PQMS_LoginInfo.sAccountNo}'";
            }

            if (sSort == "") //정렬조건이 없으면
            {
                sql += $" order by a.STAFF_CODE asc ";
            }
            else
            {
                sql += $" order by a." + sSort + " asc ";
            }



            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Select_StaffFoodTopTeam_User(string sTreeName = "", string srdbValue = "", bool bRdbStaffResignationValue = false, string sGroupCode1 = "", string sSort = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT a.*, f.*, g.*, D.STAFF_EDU_TO AS 'STAFF_EDU_TO_1', e.*, h.*, " +
                $" CASE " +
                $" WHEN D.STAFF_EDU_TO IS NOT NULL AND D.STAFF_EDU_TO <> '' THEN DATEADD(ms, -3, DATEADD(yy, DATEDIFF(yy, 0, D.staff_edu_to) + 2, 0)) " +
                $" END AS NEXTEDU " +
                $" FROM PQMS_STAFF A " +
                $" LEFT OUTER JOIN(SELECT STAFF_CODE, MAX(STAFF_EDU_TO) AS STAFF_EDU_TO FROM PQMS_STAFF_EDU WHERE STAFF_EDU_ORG_CODE = '0002' AND STAFF_EDU_CODE = 'E001' GROUP BY STAFF_CODE) AS D " +
                $" ON(A.STAFF_CODE = D.STAFF_CODE) " +
                $" LEFT OUTER JOIN(select * from ( " +
                $" select * " +
                $" , Row_number() " +
                $" OVER( " +
                $" partition BY STAFF_CODE " +
                $" ORDER BY STAFF_ROLE_DATE) AS RowNum " +
                $" from pqms_staff_role " +
                $" ) T " +
                $" where T.rownum = '1') AS E " +
                $" on (a.STAFF_CODE = e.STAFF_CODE) " +
                $" INNER JOIN [PQMS_STAFF_ROLE] AS g " +
                $" ON ( a.STAFF_CODE = g.STAFF_CODE) " +
                $" INNER JOIN [PQMS_GROUP2] AS F " +
                $" on (F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = g.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = g.STAFF_ROLE_ORG_CODE " +
                $" AND A.SITE_CODE = F.SITE_CODE AND A.REPOSITORY_CODE = F.REPOSITORY_CODE AND A.WS_CODE = F.WS_CODE " +
                $" INNER JOIN[PQMS_GROUP1] AS h " +
                $" ON F.group2_group1_code = h.GROUP1_CODE and f.GROUP2_ORG_CODE = h.GROUP1_ORG_CODE " +
                $" AND A.SITE_CODE = h.SITE_CODE AND A.REPOSITORY_CODE = h.REPOSITORY_CODE AND A.WS_CODE = h.WS_CODE " +
                $" WHERE (replace(a.STAFF_TEAM,'-','') LIKE '%' + Replace(" + Form1PQMS_Repo.sSiteCode + Form1PQMS_Repo.sRepo + sTreeName + ",'-', '') + '%') ";

            if (srdbValue != "")
            {
                sql += $" AND g.[STAFF_ROLE_ORG_CODE] = '" + srdbValue + "' ";
            }

            if (sGroupCode1 != "")
            {
                sql += $" AND SUBSTRING(g.[STAFF_ROLE_CLASS],1,4)='" + sGroupCode1 + "'";
            }

            if (bRdbStaffResignationValue == false)
            {
                sql += $" and (a.staff_resignation_date is null or a.staff_resignation_date = '') ";
            }
            else
            {
                sql += $"and (a.staff_resignation_date is not null and a.staff_resignation_date <> '')";
            }

            if (string.IsNullOrWhiteSpace(Form2PQMS_LoginInfo.sAccountNo) == false)
            {
                sql += $" and a.ACCOUNT_NO='{Form2PQMS_LoginInfo.sAccountNo}'";
            }


            if (sSort == "") //정렬조건이 없으면
            {
                sql += $" order by a.STAFF_CODE asc ";
            }
            else
            {
                sql += $" order by a." + sSort + " asc ";
            }


            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }


        public void Insert(SqlTransaction trans = null)
        {
            string sql = "";

            if (sSTAFF_CODE == "")
            {

                sql = $"insert into PQMS_STAFF  (SITE_CODE, REPOSITORY_CODE, WS_CODE, STAFF_CODE, STAFF_EMPNO, STAFF_NAME, STAFF_TEAM, STAFF_JOIN_DATE, STAFF_MAJOR, STAFF_SCHOOL, STAFF_RESIGNATION_DATE, ACCOUNT_NO, STAFF_POSITION, STAFF_FILE	)  values " +
                      $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}', ( select  (FORMAT(max(STAFF_CODE) + 1, '0000')) from  PQMS_STAFF ) ,'{sSTAFF_EMPNO}', '{sSTAFF_NAME}', '{sSTAFF_TEAM}', '{sSTAFF_JOIN_DATE}', '{sSTAFF_MAJOR}', '{sSTAFF_SCHOOL}', '{sSTAFF_RESIGNATION_DATE}','{sSTAFF_ACCOUNTNO}','','{sSTAFF_FILE}')  "; //jhm0711

                string tmp_orgcode = "0000";

                if (Form1PQMS_Repo.sRepo == "0003") //의왕
                {
                    tmp_orgcode = "0005";
                }
                else
                {
                    tmp_orgcode = "0007";
                }

                sql = sql +
                      $" insert into PQMS_STAFF_ROLE " +
                      $" (STAFF_CODE,	STAFF_ROLE_DATE,	STAFF_ROLE_CLASS,	STAFF_ROLE_ORG_CODE,	STAFF_ROLE_CODE,	STAFF_ROLE_NAME	,STAFF_ROLE_STATUS,  STAFF_ROLE_GIVEN_CLASS,	STAFF_ROLE_CERTI,	STAFF_ROLE_INSTEAD,	STAFF_ROLE_UPPER_REPORT ,STAFF_ROLE_NOTE,	STAFF_ROLE_QUALITY_SCORE,	STAFF_ROLE_TEST_SCORE, STAFF_ROLE_QUALITY_DIR_FILE,	STAFF_ROLE_TEST_DIR_FILE )" +
                      $" values " +
                      $" ( (select  STAFF_CODE from  PQMS_STAFF where STAFF_EMPNO='{sSTAFF_EMPNO}'), '{sSTAFF_JOIN_DATE}', '1001-2001', '" + tmp_orgcode + "', 'R001'," +
                      $" 'SGS_Korea 직원', 'Y', 'Y', 'Y', '', '', " +
                      $" '', '', '', '', ''); ";
            }
            else
            {

                sql = $" insert into PQMS_STAFF_HIS ( SITE_CODE,REPOSITORY_CODE,WS_CODE,STAFF_CODE,STAFF_EMPNO,STAFF_NAME,STAFF_TEAM,STAFF_JOIN_DATE,STAFF_MAJOR,STAFF_SCHOOL,STAFF_RESIGNATION_DATE,ACCOUNT_NO,STAFF_POSITION,STAFF_FILE,MODIFYDATE )" +
                      $" Select SITE_CODE,REPOSITORY_CODE,WS_CODE,STAFF_CODE,STAFF_EMPNO,STAFF_NAME,STAFF_TEAM,STAFF_JOIN_DATE,STAFF_MAJOR,STAFF_SCHOOL,STAFF_RESIGNATION_DATE,ACCOUNT_NO,STAFF_POSITION,STAFF_FILE, Getdate() " +
                      $" from PQMS_STAFF " +
                      $" where STAFF_CODE='{sSTAFF_CODE}' ";

                sql +=
                    $" update PQMS_STAFF set " +
                    $" STAFF_NAME='{sSTAFF_NAME}', STAFF_TEAM='{sSTAFF_TEAM}', STAFF_JOIN_DATE='{sSTAFF_JOIN_DATE}', STAFF_MAJOR='{sSTAFF_MAJOR}', STAFF_SCHOOL='{sSTAFF_SCHOOL}', STAFF_RESIGNATION_DATE='{sSTAFF_RESIGNATION_DATE}', ACCOUNT_NO='{sSTAFF_ACCOUNTNO}', STAFF_FILE='{sSTAFF_FILE}'" +
                    $" where STAFF_CODE='{sSTAFF_CODE}' ";


                string sFolder = sSTAFF_TEAM.Substring(16, 5); //부서가 변경되면 accountmaster테이블도 수정해야함 ㅋㅋ
                sql +=
                    $" Update [accountMaster].[dbo].[accountStaffDept] set " +
                    $" FOLDER_CODE ='" + sFolder + "', " +
                    $" modifiedBy = '{sSTAFF_ACCOUNTNO}', " +
                    $" ModifiedDate = getdate() " +
                    $" where accountNo = '{sSTAFF_ACCOUNTNO}'";
            }

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
                $" STAFF_NAME='{sSTAFF_NAME}', STAFF_TEAM='{sSTAFF_TEAM}', STAFF_JOIN_DATE='{sSTAFF_JOIN_DATE}', STAFF_MAJOR='{sSTAFF_MAJOR}', STAFF_SCHOOL='{sSTAFF_SCHOOL}', STAFF_RESIGNATION_DATE='{sSTAFF_RESIGNATION_DATE}', ACCOUNT_NO='{sSTAFF_ACCOUNTNO}', STAFF_FILE='{sSTAFF_FILE}'" +
                $" where STAFF_CODE='{sSTAFF_CODE}' ";


            string sFolder = sSTAFF_TEAM.Substring(16, 5); //부서가 변경되면 accountmaster테이블도 수정해야함 ㅋㅋ
            sql +=
                $" Update [accountMaster].[dbo].[accountStaffDept] set " +
                $" FOLDER_CODE ='" + sFolder + "', " +
                $" modifiedBy = '{sSTAFF_ACCOUNTNO}', " +
                $" ModifiedDate = getdate() " +
                $" where accountNo = '{sSTAFF_ACCOUNTNO}'";

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

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sSTAFF_CODE = "";
                sSTAFF_TEAM = "";
                sSTAFF_NAME = "";
                sSTAFF_ROLE_NAME = "";
                sSTAFF_ROLE_CLASS = "";
                sSTAFF_EDU_TO = "";
                sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY = "";
                sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sSTAFF_CODE = row["STAFF_CODE"].ToString();
            sSTAFF_TEAM = row["STAFF_TEAM"].ToString();
            sSTAFF_NAME = row["STAFF_NAME"].ToString();
            sSTAFF_ROLE_NAME = row["STAFF_ROLE_NAME"].ToString();
            sSTAFF_ROLE_CLASS = row["STAFF_ROLE_CLASS"].ToString();
            sSTAFF_EDU_TO = row["staff_edu_to"].ToString();
            sSTAFF_EDU_TO_MEASUREMENT_UNCERTAINTY = row["STAFF_EDU_TO_MEASUREMENT_UNCERTAINTY"].ToString();
            sSTAFF_EDU_TO_CONSERVATIVE_EDUCATION = row["STAFF_EDU_TO_CONSERVATIVE_EDUCATION"].ToString();
        }
    }

    public class Form2_MEASUREMENT_UNCERTAINTY_DataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_EDU_TO { get; set; }

        public Form2_MEASUREMENT_UNCERTAINTY_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select_Top_MEASUREMENT_UNCERTAINTY(string sSTAFF_CODE = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM(select a.STAFF_CODE, d.STAFF_EDU_TO, " +
                $" Row_number() " +
                $" OVER( " +
                $" partition BY a.staff_name " +
                $" ORDER BY d.STAFF_EDU_TO DESC) AS RankNo " +
                $" from pqms_staff as a " +
                $" INNER JOIN pqms_staff_edu AS d " +
                $" ON a.staff_code = d.staff_code " +
                $" where staff_edu_code = 'E002' " +
                $" ) T " +
                $" WHERE  rankno = 1 ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sSTAFF_CODE = "";
                sSTAFF_EDU_TO = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sSTAFF_CODE = row["staff_code"].ToString();
            sSTAFF_EDU_TO = row["staff_edu_to"].ToString();
        }
    }

    public class Form2_CONSERVATIVE_EDUCATION_DataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_EDU_TO { get; set; }

        public Form2_CONSERVATIVE_EDUCATION_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select_Top_CONSERVATIVE_EDUCATION(string sSTAFF_CODE = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM(select a.STAFF_CODE, d.STAFF_EDU_TO, " +
                $" Row_number() " +
                $" OVER( " +
                $" partition BY a.staff_name " +
                $" ORDER BY d.STAFF_EDU_TO DESC) AS RankNo " +
                $" from pqms_staff as a " +
                $" INNER JOIN pqms_staff_edu AS d " +
                $" ON a.staff_code = d.staff_code " +
                $" where staff_edu_code = 'E003' " +
                $" ) T " +
                $" WHERE  rankno = 1 ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sSTAFF_CODE = "";
                sSTAFF_EDU_TO = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sSTAFF_CODE = row["staff_code"].ToString();
            sSTAFF_EDU_TO = row["staff_edu_to"].ToString();
        }
    }

    public class Form2PQMS_STAFF_Workspace_DataSet : UlSqlDataSet
    {
        public string sFOLDERNAME { get; set; }

        public string sSTAFF_NAME { get; set; }

        public string sSTAFF_TEAM { get; set; }

        public Form2PQMS_STAFF_Workspace_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_STAFFTEAM(SqlTransaction trans = null)
        {

            string sql = $"SELECT SITE_CODE +'-'+ REPOSITORY_CODE+'-'+ WS_CODE+'-'+FOLDER_CODE as STAFF_TEAM, FOLDER_NAME FROM K_WORKSPACE " +
                         $" where FOLDER_NAME = '{sFOLDERNAME}'" +
                         $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "'" +
                         $" and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'" +
                         $" and WS_CODE = '" + Form1PQMS_Repo.sWS + "' and isnull(BOARD_CODE,'') ='' ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sFOLDERNAME = "";
                //sSTAFF_NAME = "";
                sSTAFF_TEAM = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sFOLDERNAME = row["FOLDER_NAME"].ToString();
            //sSTAFF_NAME = row["STAFF_NAME"].ToString();
            sSTAFF_TEAM = row["STAFF_TEAM"].ToString();
        }
    }

    public class Form2PQMS_STAFF_STAFFDataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_NAME { get; set; }

        public string sSTAFF_TEAM { get; set; }

        public string sSTAFF_JOIN_DATE { get; set; }

        public string sSTAFF_MAJOR { get; set; }

        public string sSTAFF_SCHOOL { get; set; }

        public Form2PQMS_STAFF_STAFFDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_STAFF(string sStaff_code = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [PQMS_STAFF] AS a " +
                $" inner join K_WORKSPACE AS b " +
                $" on a.STAFF_TEAM = (b.SITE_CODE + '-' + b.REPOSITORY_CODE + '-' + b.WS_CODE + '-' + b.FOLDER_CODE) and isnull(b.BOARD_CODE, '') ='' ";

            if (string.IsNullOrWhiteSpace(sStaff_code) == false)
            {
                sql += $" where a.STAFF_CODE='{sStaff_code}'";
            }


            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }
    }

    public class Form2PQMS_STAFF_PreSTAFFDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_PRE_REPOSITORY_NAME { get; set; }

        public string sSTAFF_PRE_WS_NAME { get; set; }

        public string sSTAFF_PRE_WORK_DATE { get; set; }

        public Form2PQMS_STAFF_PreSTAFFDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_PreSTAFF(string sStaff_code = "", SqlTransaction trans = null)
        {

            string sql = $" select * from  PQMS_STAFF_PRE_JOB_INFO a " +
                         $" inner join[PQMS_STAFF] AS b on a.STAFF_CODE = b.STAFF_CODE " +
                         $" inner join K_WORKSPACE AS c on b.STAFF_TEAM = (c.SITE_CODE + '-' + c.REPOSITORY_CODE + '-' + c.WS_CODE + '-' + c.FOLDER_CODE) and isnull(c.BOARD_CODE, '') = '' ";

            if (string.IsNullOrWhiteSpace(sStaff_code) == false)
            {
                sql += $" where a.STAFF_CODE='{sStaff_code}'";
            }

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }
    }

    public class Form2PQMS_STAFF_EDUDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }
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
            $" FROM [PQMS_STAFF_EDU] AS a " +
            $" INNER JOIN PQMS_ORG AS b " +
            $" ON a.STAFF_EDU_ORG_CODE = b.[ORG_CODE] " +
            $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" INNER JOIN PQMS_EDU AS c " +
            $" ON a.STAFF_EDU_CODE = c.EDU_CODE and a.STAFF_EDU_ORG_CODE = c.EDU_ORG_CODE ";

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
                $" where IDX = '{iIDX}' AND STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" where IDX = '{iIDX}' AND STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_STAFF_EDUMainDataSet : UlSqlDataSet
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

        public Form2PQMS_STAFF_EDUMainDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_EDU(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [PQMS_STAFF_EDU] AS a " +
                $" INNER JOIN PQMS_ORG AS b " +
                $" ON a.STAFF_EDU_ORG_CODE = b.[ORG_CODE] " +
                $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
                $" INNER JOIN PQMS_EDU AS c " +
                $" ON a.STAFF_EDU_CODE = c.EDU_CODE and a.STAFF_EDU_ORG_CODE = c.EDU_ORG_CODE " +
                $" and c.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and c.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and c.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";



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
        public int iIDX { get; set; }
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_ROLE_ORG_CODE { get; set; }
        public string sROLE_CODE { get; set; }
        public string sSTAFF_ROLE_CLASS { get; set; }
        public string sSTAFF_CERTI_ROLE { get; set; }
        public string sSTAFF_CERTI_NAME { get; set; }
        public string sSTAFF_CERTI_NUMBER { get; set; }
        public string sSTAFF_CERTI_DATE { get; set; }
        public string sSTAFF_CERTI_FILE { get; set; }

        public Form2PQMS_STAFF_CERTIGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_CERTI(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS_STAFF_CERTI] AS A " +
            $" LEFT OUTER JOIN PQMS_ORG AS b " +
            $" ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE " +
            $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_GROUP2] AS F " +
            $" on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
            $" and F.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and F.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and F.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_GROUP1] AS g " +
            $" ON f.GROUP2_ORG_CODE = g.GROUP1_ORG_CODE and f.GROUP2_GROUP1_CODE = g.GROUP1_CODE " +
            $" and g.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and g.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and g.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_ROLE] AS h " +
            $" ON a.STAFF_ROLE_ORG_CODE = h.[ROLE_ORG_CODE] and a.[ROLE_CODE] = h.[ROLE_CODE] " +
            $" and h.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and h.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and h.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";


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
                $" insert into PQMS_STAFF_CERTI (STAFF_CODE, STAFF_ROLE_ORG_CODE, ROLE_CODE, STAFF_ROLE_CLASS, STAFF_CERTI_ROLE, STAFF_CERTI_NAME, STAFF_CERTI_NUMBER, STAFF_ROLE_DATE, STAFF_CERTI_FILE ) values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_ROLE_ORG_CODE}', '{sROLE_CODE}', '{sSTAFF_ROLE_CLASS}', '{sSTAFF_CERTI_ROLE}', '{sSTAFF_CERTI_NAME}', '{sSTAFF_CERTI_NUMBER}', '{sSTAFF_CERTI_DATE}', '{sSTAFF_CERTI_FILE}'); ";

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
                $" STAFF_ROLE_ORG_CODE='{sSTAFF_ROLE_ORG_CODE}', ROLE_CODE='{sROLE_CODE}', STAFF_ROLE_CLASS='{sSTAFF_ROLE_CLASS}', STAFF_CERTI_ROLE='{sSTAFF_CERTI_ROLE}', STAFF_CERTI_NAME='{sSTAFF_CERTI_NAME}', STAFF_CERTI_NUMBER='{sSTAFF_CERTI_NUMBER}' , STAFF_ROLE_DATE='{sSTAFF_CERTI_DATE}', STAFF_CERTI_FILE='{sSTAFF_CERTI_FILE}'" +
                $" where IDX='{iIDX}' AND STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" where IDX='{iIDX}' AND STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_STAFF_CERTIMainDataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sSTAFF_CERTI_ROLE { get; set; }
        public string sSTAFF_CERTI_NAME { get; set; }
        public string sSTAFF_CERTI_DATE { get; set; }
        public string sSTAFF_CERTI_FILE { get; set; }

        public Form2PQMS_STAFF_CERTIMainDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_CERTI(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
            $" FROM [PQMS_STAFF_CERTI] AS A " +
            $" LEFT OUTER JOIN PQMS_ORG AS b " +
            $" ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE " +
            $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_GROUP2] AS F " +
            $" on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
            $" and F.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and F.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and F.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_GROUP1] AS g " +
            $" ON f.GROUP2_ORG_CODE = g.GROUP1_ORG_CODE and f.GROUP2_GROUP1_CODE = g.GROUP1_CODE " +
            $" and g.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and g.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and g.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            $" LEFT OUTER JOIN[PQMS_ROLE] AS h " +
            $" ON a.STAFF_ROLE_ORG_CODE = h.[ROLE_ORG_CODE] and a.[ROLE_CODE] = h.[ROLE_CODE] " +
            $" and h.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and h.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and h.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";


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
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_ROLE_DATE { get; set; }

        public string sSTAFF_ROLE_CLASS { get; set; }
        public string sSTAFF_ROLE_CLASS_2 { get; set; }
        public string sSTAFF_ROLE_CLASS_3 { get; set; }
        public string sSTAFF_ROLE_CLASS_4 { get; set; }
        public string sSTAFF_ROLE_CLASS_5 { get; set; }
        public string sSTAFF_ROLE_CLASS_6 { get; set; }
        public string sSTAFF_ROLE_ORG_CODE { get; set; }
        public string sSTAFF_ROLE_CODE { get; set; }
        public string sSTAFF_ROLE_NAME { get; set; }
        public string sSTAFF_ROLE_STATUS { get; set; }
        public string sSTAFF_ROLE_GIVEN_CLASS { get; set; }
        public string sSTAFF_ROLE_CERTI { get; set; }
        public string sSTAFF_ROLE_INSTEAD { get; set; }
        public string sSTAFF_ROLE_UPPER_REPORT { get; set; }
        public string sSTAFF_ROLE_NOTE { get; set; }
        public string sSTAFF_ROLE_QUALITY_SCORE { get; set; }
        public string sSTAFF_ROLE_TEST_SCORE { get; set; }
        public string sSTAFF_ROLE_QUALITY_DIR_FILE { get; set; }
        public string sSTAFF_ROLE_TEST_DIR_FILE { get; set; }
        public string sSTAFF_ROLE_FILE { get; set; }



        public Form2PQMS_STAFF_ROLEGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_ROLE(SqlTransaction trans = null)
        {
            //string sql = $" SELECT *, " +                                                                  // 0714_hiel
            //    $" (CASE WHEN a.approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
            //    $" WHEN a.approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
            //    $" WHEN a.approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
            //    $" ELSE '반려' " +                                                                       // 0714_hiel
            //    $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
            //    $" ,(case WHEN x.LOP_No is null Then 'N' else 'Y' end ) AS 'LOP_PAPER_YN' " +                    //0720JHM
            //    $" ,x.STAFF_ROLE_FILE " +                    //0720JHM
            //    $" FROM [PQMS_STAFF_ROLE] as a " +
            //    $" INNER JOIN PQMS_ORG AS b " +
            //    $" ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE " +
            //    $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" INNER JOIN [PQMS_GROUP2] AS F " +
            //    $" on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
            //    $" and F.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and F.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and F.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" INNER JOIN [PQMS_GROUP1] AS g " +
            //    $" ON f.GROUP2_ORG_CODE = g.GROUP1_ORG_CODE and f.GROUP2_GROUP1_CODE = g.GROUP1_CODE " +
            //    $" and g.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and g.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and g.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" left outer join PQMS_STAFF_ROLE_APPOINT x on a.idx = x.LOP_No ";
            //$" INNER JOIN [PQMS_STAFF_ROLE_APPROVE_LOG] AS h " +   // 0714_hiel
            //$" ON(a.IDX = h.IDX) ";                                // 0714_hiel


            string sql = $" SELECT a.IDX, a.STAFF_CODE, a.STAFF_ROLE_CLASS, a.STAFF_ROLE_ORG_CODE, a.STAFF_ROLE_CODE, a.STAFF_ROLE_DATE,  b.ORG_NAME, a.STAFF_ROLE_NAME, a.STAFF_ROLE_FILE,  a.approveStatusCode, g.GROUP1_NAME,g.GROUP1_CODE, " +
                         $" a.STAFF_ROLE_CLASS,	a.STAFF_ROLE_CLASS_2,	a.STAFF_ROLE_CLASS_3,	a.STAFF_ROLE_CLASS_4,	a.STAFF_ROLE_CLASS_5, 	a.STAFF_ROLE_CLASS_6, " +
                         $" f.GROUP2_CODE,                  COALESCE(f.GROUP2_NAME, '') AS GROUP2_NAME, " +
                         $" d2.GROUP2_CODE AS GROUP2_CODE_2, COALESCE(d2.GROUP2_NAME, '') AS GROUP2_NAME_2, " +
                         $" d3.GROUP2_CODE AS GROUP2_CODE_3, COALESCE(d3.GROUP2_NAME, '') AS GROUP2_NAME_3, " +
                         $" d4.GROUP2_CODE AS GROUP2_CODE_4, COALESCE(d4.GROUP2_NAME, '') AS GROUP2_NAME_4, " +
                         $" d5.GROUP2_CODE AS GROUP2_CODE_5, COALESCE(d5.GROUP2_NAME, '') AS GROUP2_NAME_5, " +
                         $" d6.GROUP2_CODE AS GROUP2_CODE_6, COALESCE(d6.GROUP2_NAME, '') AS GROUP2_NAME_6, " +
                         $" CONCAT( g.GROUP1_NAME + ' / ', NULLIF(f.GROUP2_NAME, ''), NULLIF(', ' + d2.GROUP2_NAME, ''), NULLIF(', ' + d3.GROUP2_NAME, ''), NULLIF(', ' + d4.GROUP2_NAME, ''), NULLIF(', ' + d5.GROUP2_NAME, ''), NULLIF(', ' + d6.GROUP2_NAME, '') ) AS 'GROUP_NAME', " +
                         $" (CASE WHEN a.approveStatusCode IS NULL THEN '신청전'  WHEN a.approveStatusCode = '0' THEN '승인대기'  WHEN a.approveStatusCode = '1' THEN '승인완료'  ELSE '반려'  END) AS 'approvedYN_Korea' " +
                         $" FROM[PQMS_STAFF_ROLE] as a " +
                         $" INNER JOIN PQMS_ORG AS b ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE  and b.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and b.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and b.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" INNER JOIN[PQMS_GROUP1] AS g  ON a.STAFF_ROLE_ORG_CODE = g.GROUP1_ORG_CODE and left(a.STAFF_ROLE_CLASS,4) = g.GROUP1_CODE  and g.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and g.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and g.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" INNER JOIN[PQMS_GROUP2] AS F  on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE  and F.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and F.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and F.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" left outer join PQMS_GROUP2 d2 on a.STAFF_ROLE_ORG_CODE = d2.GROUP2_ORG_CODE and g.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d2.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d2.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" left outer join PQMS_GROUP2 d3 on a.STAFF_ROLE_ORG_CODE = d3.GROUP2_ORG_CODE and g.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d3.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d3.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" left outer join PQMS_GROUP2 d4 on a.STAFF_ROLE_ORG_CODE = d4.GROUP2_ORG_CODE and g.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d4.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d4.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" left outer join PQMS_GROUP2 d5 on a.STAFF_ROLE_ORG_CODE = d5.GROUP2_ORG_CODE and g.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d5.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d5.WS_CODE = '"+Form1PQMS_Repo.sWS+"' " +
                         $" left outer join PQMS_GROUP2 d6 on a.STAFF_ROLE_ORG_CODE = d6.GROUP2_ORG_CODE and g.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_ROLE_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '"+Form1PQMS_Repo.sSiteCode+"' and d6.REPOSITORY_CODE = '"+Form1PQMS_Repo.sRepo+"' and d6.WS_CODE = '"+Form1PQMS_Repo.sWS+"' ";
                                    
            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where a.STAFF_CODE='{sSTAFF_CODE}'";         // 0714_hiel
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
                $" insert into PQMS_STAFF_ROLE " +
                $" (STAFF_CODE,	STAFF_ROLE_DATE,	STAFF_ROLE_CLASS, STAFF_ROLE_CLASS_2, STAFF_ROLE_CLASS_3, STAFF_ROLE_CLASS_4, STAFF_ROLE_CLASS_5, STAFF_ROLE_CLASS_6,	STAFF_ROLE_ORG_CODE,	STAFF_ROLE_CODE,	STAFF_ROLE_NAME	,STAFF_ROLE_STATUS,  STAFF_ROLE_GIVEN_CLASS,	STAFF_ROLE_CERTI,	STAFF_ROLE_INSTEAD,	STAFF_ROLE_UPPER_REPORT ,STAFF_ROLE_NOTE,	STAFF_ROLE_QUALITY_SCORE,	STAFF_ROLE_TEST_SCORE, STAFF_ROLE_QUALITY_DIR_FILE,	STAFF_ROLE_TEST_DIR_FILE )" +
                $" values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_ROLE_DATE}', '{sSTAFF_ROLE_CLASS}','{sSTAFF_ROLE_CLASS_2}','{sSTAFF_ROLE_CLASS_3}','{sSTAFF_ROLE_CLASS_4}','{sSTAFF_ROLE_CLASS_5}','{sSTAFF_ROLE_CLASS_6}', '{sSTAFF_ROLE_ORG_CODE}', '{sSTAFF_ROLE_CODE}'," +
                $" '{sSTAFF_ROLE_NAME}', '{sSTAFF_ROLE_STATUS}', '{sSTAFF_ROLE_GIVEN_CLASS}', '{sSTAFF_ROLE_CERTI}', '{sSTAFF_ROLE_INSTEAD}', '{sSTAFF_ROLE_UPPER_REPORT}', " +
                $" '{sSTAFF_ROLE_NOTE}', '{sSTAFF_ROLE_QUALITY_SCORE}', '{sSTAFF_ROLE_TEST_SCORE}', '{sSTAFF_ROLE_QUALITY_DIR_FILE}', '{sSTAFF_ROLE_TEST_DIR_FILE}'); ";

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
                $" STAFF_ROLE_DATE='{sSTAFF_ROLE_DATE}', STAFF_ROLE_CLASS='{sSTAFF_ROLE_CLASS}', STAFF_ROLE_CLASS_2='{sSTAFF_ROLE_CLASS_2}',STAFF_ROLE_CLASS_3='{sSTAFF_ROLE_CLASS_3}',STAFF_ROLE_CLASS_4='{sSTAFF_ROLE_CLASS_4}',STAFF_ROLE_CLASS_5='{sSTAFF_ROLE_CLASS_5}',STAFF_ROLE_CLASS_6='{sSTAFF_ROLE_CLASS_6}', STAFF_ROLE_ORG_CODE='{sSTAFF_ROLE_ORG_CODE}', STAFF_ROLE_CODE='{sSTAFF_ROLE_CODE}', STAFF_ROLE_NAME='{sSTAFF_ROLE_NAME}'," +
                $" STAFF_ROLE_STATUS='{sSTAFF_ROLE_STATUS}', STAFF_ROLE_GIVEN_CLASS='{sSTAFF_ROLE_GIVEN_CLASS}', STAFF_ROLE_CERTI='{sSTAFF_ROLE_CERTI}', STAFF_ROLE_INSTEAD='{sSTAFF_ROLE_INSTEAD}', STAFF_ROLE_UPPER_REPORT ='{sSTAFF_ROLE_UPPER_REPORT}', " +
                $" STAFF_ROLE_NOTE ='{sSTAFF_ROLE_NOTE}', STAFF_ROLE_QUALITY_SCORE ='{sSTAFF_ROLE_QUALITY_SCORE}', " +
                $" STAFF_ROLE_TEST_SCORE ='{sSTAFF_ROLE_TEST_SCORE}', STAFF_ROLE_QUALITY_DIR_FILE ='{sSTAFF_ROLE_QUALITY_DIR_FILE}', STAFF_ROLE_TEST_DIR_FILE ='{sSTAFF_ROLE_TEST_DIR_FILE}'" +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_STAFF_ROLEGridInfoDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

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

        public string sSTAFF_ROLE_UPPER_REPORT { get; set; }

        public string sSTAFF_ROLE_NOTE { get; set; }

        public string sSTAFF_ROLE_QUALITY_SCORE { get; set; }

        public string sSTAFF_ROLE_TEST_SCORE { get; set; }

        public string sSTAFF_ROLE_QUALITY_DIR_FILE { get; set; }

        public string sSTAFF_ROLE_TEST_DIR_FILE { get; set; }

        public Form2PQMS_STAFF_ROLEGridInfoDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void SelectSTAFF_ROLE(SqlTransaction trans = null)
        {

            //string sql = $" SELECT *, " +                                                                  // 0714_hiel
            //    $" (CASE WHEN a.approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
            //    $" WHEN a.approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
            //    $" WHEN a.approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
            //    $" ELSE '반려' " +                                                                       // 0714_hiel
            //    $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
            //    $" ,(case WHEN x.LOP_No is null Then 'N' else 'Y' end ) AS 'LOP_PAPER_YN' " +                    //0720JHM
            //    $" ,x.STAFF_ROLE_FILE " +                    //0720JHM
            //    $" FROM [PQMS_STAFF_ROLE] as a " +
            //    $" INNER JOIN PQMS_ORG AS b " +
            //    $" ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE " +
            //    $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" INNER JOIN [PQMS_GROUP2] AS F " +
            //    $" on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
            //    $" and F.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and F.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and F.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" INNER JOIN [PQMS_GROUP1] AS g " +
            //    $" ON f.GROUP2_ORG_CODE = g.GROUP1_ORG_CODE and f.GROUP2_GROUP1_CODE = g.GROUP1_CODE " +
            //    $" and g.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and g.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and g.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
            //    $" left outer join PQMS_STAFF_ROLE_APPOINT x on a.idx = x.LOP_No ";

            string sql = $" SELECT *, " +                                                                  // 0714_hiel
                $" (CASE WHEN a.approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
                $" WHEN a.approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
                $" WHEN a.approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
                $" ELSE '반려' " +                                                                       // 0714_hiel
                $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel                
                $" FROM [PQMS_STAFF_ROLE] as a " +
                $" INNER JOIN PQMS_ORG AS b " +
                $" ON a.STAFF_ROLE_ORG_CODE = b.ORG_CODE " +
                $" and b.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and b.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and b.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
                $" INNER JOIN [PQMS_GROUP2] AS F " +
                $" on(F.GROUP2_GROUP1_CODE + '-' + F.GROUP2_CODE) = a.STAFF_ROLE_CLASS and f.[GROUP2_ORG_CODE] = a.STAFF_ROLE_ORG_CODE " +
                $" and F.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and F.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and F.WS_CODE='" + Form1PQMS_Repo.sWS + "' " +
                $" INNER JOIN [PQMS_GROUP1] AS g " +
                $" ON f.GROUP2_ORG_CODE = g.GROUP1_ORG_CODE and f.GROUP2_GROUP1_CODE = g.GROUP1_CODE " +
                $" and g.SITE_CODE='" + Form1PQMS_Repo.sSiteCode + "' and g.REPOSITORY_CODE ='" + Form1PQMS_Repo.sRepo + "' and g.WS_CODE='" + Form1PQMS_Repo.sWS + "' ";                

            if (string.IsNullOrWhiteSpace(sSTAFF_CODE) == false)
            {
                sql += $" where a.STAFF_CODE='{sSTAFF_CODE}'";
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
                $" '{sSTAFF_ROLE_NAME}', '{sSTAFF_ROLE_STATUS}', '{sSTAFF_ROLE_GIVEN_CLASS}', '{sSTAFF_ROLE_CERTI}', '{sSTAFF_ROLE_INSTEAD}', '{sSTAFF_ROLE_UPPER_REPORT}', " +
                $" '{sSTAFF_ROLE_NOTE}', '{sSTAFF_ROLE_QUALITY_SCORE}', '{sSTAFF_ROLE_TEST_SCORE}', '{sSTAFF_ROLE_QUALITY_DIR_FILE}', '{sSTAFF_ROLE_TEST_DIR_FILE}'); ";

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
                $" STAFF_ROLE_STATUS='{sSTAFF_ROLE_STATUS}', STAFF_ROLE_GIVEN_CLASS='{sSTAFF_ROLE_GIVEN_CLASS}', STAFF_ROLE_CERTI='{sSTAFF_ROLE_CERTI}', STAFF_ROLE_INSTEAD='{sSTAFF_ROLE_INSTEAD}', STAFF_ROLE_UPPER_REPORT ='{sSTAFF_ROLE_UPPER_REPORT}', " +
                $" STAFF_ROLE_NOTE ='{sSTAFF_ROLE_NOTE}', STAFF_ROLE_QUALITY_SCORE ='{sSTAFF_ROLE_QUALITY_SCORE}', " +
                $" STAFF_ROLE_TEST_SCORE ='{sSTAFF_ROLE_TEST_SCORE}', STAFF_ROLE_QUALITY_DIR_FILE ='{sSTAFF_ROLE_QUALITY_DIR_FILE}', STAFF_ROLE_TEST_DIR_FILE ='{sSTAFF_ROLE_TEST_DIR_FILE}'" +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_STAFF_ROLEMainDataSet : UlSqlDataSet
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

        public Form2PQMS_STAFF_ROLEMainDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

    }

    public class  PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridDataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public int iIDX { get; set; }
        public string sFINAL_FILE { get; set; }
        public string sRP_CODE { get; set; }

        public PQMS_ROLE_PAPER_TRANING_FOLDER_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
           : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +                                   
                $" FROM [PQMS_STAFF_ROLEPAPER_TRANING_FOLDER] a  " +
                $" inner join PQMS_ROLE2_CODE  b on b.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and b.WS_CODE='{Form1PQMS_Repo.sWS}' and a.ROLE_CODE = b.ROLE_CODE " +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";     

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF_ROLEPAPER_TRANING_FOLDER " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_ROLE2_EACH_LIST_MainGridDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sLIST_NO { get; set; }

        public string sLIST_WORKDATE { get; set; }

        public string sLIST_GROUP1 { get; set; }

        public string sLIST_GROUP2 { get; set; }

        public string sLIST_CONTENTS1 { get; set; }

        public string sLIST_CHKDATE { get; set; }

        public string sLIST_CHKSIGN { get; set; }

        public string sLIST_TECHNICAL_MANAGER { get; set; }

        public string sLIST_REMARK { get; set; }
        public string sTest_FIELD { get; set; } //jhm0711

        public string sATTACH_FILE { get; set; }

        public string sLIST_MOTHODS { get; set; } //평가방법
        public string sLIST_RESULT { get; set; }//평가결과
        public string sLIST_CHAGE { get; set; } //자격부여 또는 변경
        public string sROLE_PAPER { get; set; } //직무기술서에 사용여부체크

        public string sEACHLIST_PAPER { get; set; } //수행평가이력에 표시 사용여부체크

        public Form2PQMS_ROLE2_EACH_LIST_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select_RP(SqlTransaction trans = null)
        {
            string sql = $" SELECT *, " +                                                                  // 0714_hiel
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
                $" ELSE '반려' " +                                                                       // 0714_hiel
                $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
                $" FROM [PQMS_STAFF_RP_EACH_LIST] AS A " +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}' "+                                                   // 0714_hiel
                $" AND ROLE_PAPER='Y' ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }


        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT *, " +                                                                  // 0714_hiel
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
                $" ELSE '반려' " +                                                                       // 0714_hiel
                $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
                $" FROM [PQMS_STAFF_RP_EACH_LIST] AS A " +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";                                                   // 0714_hiel

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_RP_EACH_LIST ( STAFF_CODE,SITE_CODE,REPOSITORY_CODE,WS_CODE,ROLE_CODE,LIST_NO,LIST_WORKDATE,LIST_GROUP1,LIST_GROUP2,LIST_CONTENTS1,LIST_CHKDATE,LIST_CHKSIGN,LIST_TECHNICAL_MANAGER,LIST_REMARK,TEST_FIELD,ATTACH_FILE, LIST_METHODS, LIST_RESULT, LIST_CHANGE, ROLE_PAPER, EACHLIST_PAPER) values " +
                $" ('{sSTAFF_CODE}', '{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sLIST_NO}', '{sLIST_WORKDATE}', '{sLIST_GROUP1}', '{sLIST_GROUP2}', '{sLIST_CONTENTS1}', " +
                $" '{sLIST_CHKDATE}', '{sLIST_CHKSIGN}', '{sLIST_TECHNICAL_MANAGER}', '{sLIST_REMARK}', '{sTest_FIELD}','{sATTACH_FILE}','{sLIST_MOTHODS}','{sLIST_RESULT}','{sLIST_CHAGE}','{sROLE_PAPER}', '{sEACHLIST_PAPER}'); "; //jhm0711

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
                $" update PQMS_STAFF_RP_EACH_LIST set " +
                $" ROLE_CODE='{sROLE_CODE}', LIST_NO='{sLIST_NO}'," +
                $" LIST_WORKDATE='{sLIST_WORKDATE}', LIST_GROUP1='{sLIST_GROUP1}', LIST_GROUP2='{sLIST_GROUP2}', LIST_CONTENTS1='{sLIST_CONTENTS1}', LIST_CHKDATE ='{sLIST_CHKDATE}', " +
                $" LIST_CHKSIGN='{sLIST_CHKSIGN}', LIST_TECHNICAL_MANAGER='{sLIST_TECHNICAL_MANAGER}', LIST_REMARK='{sLIST_REMARK}', TEST_FIELD='{sTest_FIELD}'" + //jhm0711
                $" ,LIST_METHODS='{sLIST_MOTHODS}', LIST_RESULT='{sLIST_RESULT}', LIST_CHANGE='{sLIST_CHAGE}' " +
                $" ,ROLE_PAPER ='{sROLE_PAPER}', EACHLIST_PAPER='{sEACHLIST_PAPER}' " +
                $", ATTACH_FILE = '{sATTACH_FILE}' " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" delete from PQMS_STAFF_RP_EACH_LIST " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_ROLE2_EACH_LIST_InfoGridDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sLIST_NO { get; set; }

        public string sLIST_WORKDATE { get; set; }

        public string sLIST_GROUP1 { get; set; }

        public string sLIST_GROUP2 { get; set; }

        public string sLIST_CONTENTS1 { get; set; }

        public string sLIST_CHKDATE { get; set; }

        public string sLIST_CHKSIGN { get; set; }

        public string sLIST_TECHNICAL_MANAGER { get; set; }

        public string sLIST_REMARK { get; set; }

        public Form2PQMS_ROLE2_EACH_LIST_InfoGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * ," +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
                $" ELSE '반려' " +                                                                       // 0714_hiel
                $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
                $" FROM [PQMS_STAFF_RP_EACH_LIST] AS A " +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_RP_EACH_LIST values " +
                $" ('{sSTAFF_CODE}', '{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sLIST_NO}', '{sLIST_WORKDATE}', '{sLIST_GROUP1}', '{sLIST_GROUP2}', '{sLIST_CONTENTS1}', " +
                $" '{sLIST_CHKDATE}', '{sLIST_CHKSIGN}', '{sLIST_TECHNICAL_MANAGER}', '{sLIST_REMARK}'); ";

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
                $" update PQMS_STAFF_RP_EACH_LIST set " +
                $" ROLE_CODE='{sROLE_CODE}', LIST_NO='{sLIST_NO}'," +
                $" LIST_WORKDATE='{sLIST_WORKDATE}', LIST_GROUP1='{sLIST_GROUP1}', LIST_GROUP2='{sLIST_GROUP2}', LIST_CONTENTS1='{sLIST_CONTENTS1}', LIST_CHKDATE ='{sLIST_CHKDATE}', " +
                $" LIST_CHKSIGN='{sLIST_CHKSIGN}', LIST_TECHNICAL_MANAGER='{sLIST_TECHNICAL_MANAGER}', LIST_REMARK='{sLIST_REMARK}'" +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" delete from PQMS_STAFF_RP_EACH_LIST " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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


    public class Form2PQMS_PQMS_STAFF_TRAINING_MainGridDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_TRAIN_COURSE { get; set; }

        public string sSTAFF_TRAIN_GUBUN { get; set; }

        public string sSTAFF_TRAIN_ORG { get; set; }

        public string sSTAFF_TRAIN_EDU { get; set; }

        public string sSTAFF_TRAIN_TRAINER { get; set; }

        public string sSTAFF_TRAIN_DATE { get; set; }

        public string sSTAFF_TRAIN_DATE_TO { get; set; }

        public string sSTAFF_TRAIN_HOUR { get; set; }

        public string sSTAFF_TRAIN_ATTENDEE { get; set; }

        public string sSTAFF_TRAIN_GOAL { get; set; }

        public string sSTAFF_TRAIN_SUMMARY { get; set; }

        public string sSTAFF_TRAIN_CONTENTS { get; set; }

        public string sSTAFF_TRAIN_RESULT { get; set; }

        public string sSTAFF_TRAIN_REVIEW { get; set; }

        public string sSTAFF_TRAIN_WRITER { get; set; }

        public string sSTAFF_TRAIN_WRITE_DATE { get; set; }

        public string sSTAFF_TRAIN_REVIEWER { get; set; }

        public string sSTAFF_TRAIN_REVIEW_DATE { get; set; }

        public string sSTAFF_TRAIN_APPROVER { get; set; }

        public string sSTAFF_TRAIN_APPROVAL_DATE { get; set; }

        public string sSTAFF_TRAIN_RESULT_DIR_FILE { get; set; }

        public string s_STAFF_TRAIN_ATTENDEE_STAFF_NAME { get; set; }
        public string s_STAFF_TRAIN_ATTENDEE_STAFF_EMPNO { get; set; }
        public string s_STAFF_TRAIN_ATTENDEE_FOLDER_NAME { get; set; }        
        public string s_STAFF_TRAIN_ATTENDEE_STAFF_CODE { get; set; }

        public Form2PQMS_PQMS_STAFF_TRAINING_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT *, " +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +
                $" ELSE '반려' " +
                $" END) AS 'approvedYN_Korea' " +
                $" FROM [PQMS_STAFF_TRAINING] as a" +                       // 0714_hiel
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'" +
                $" Order By a.STAFF_TRAIN_DATE ";

       SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Delete_Attendee(SqlTransaction trans = null)
        {
            string sql =
                $" delete PQMS_STAFF_TRAINING_ATTENDEE " +
                $" where H_IDX= '{iIDX}' ";

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


        public void Insert_Attendee(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_TRAINING_ATTENDEE " +
                $" (H_IDX ,STAFF_NAME ,STAFF_EMPNO ,FOLDER_NAME ,STAFF_CODE) " + 
                $" values " +
                $"( '{iIDX}', '{s_STAFF_TRAIN_ATTENDEE_STAFF_NAME}','{s_STAFF_TRAIN_ATTENDEE_STAFF_EMPNO}','{s_STAFF_TRAIN_ATTENDEE_FOLDER_NAME}','{s_STAFF_TRAIN_ATTENDEE_STAFF_CODE}' )";
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


        public void Insert(SqlTransaction trans = null)
        {
            //DH 20220707
            string sql =
                $" insert into PQMS_STAFF_TRAINING " +
                $" (STAFF_CODE, STAFF_TRAIN_COURSE, STAFF_TRAIN_GUBUN, STAFF_TRAIN_ORG, STAFF_TRAIN_EDU, STAFF_TRAIN_TRAINER, STAFF_TRAIN_DATE " +
                $", STAFF_TRAIN_DATE_TO, STAFF_TRAIN_HOUR, STAFF_TRAIN_ATTENDEE, STAFF_TRAIN_GOAL, STAFF_TRAIN_SUMMARY " +
                $", STAFF_TRAIN_CONTENTS, STAFF_TRAIN_RESULT, STAFF_TRAIN_RESULT_DIR_FILE, STAFF_TRAIN_REVIEW, STAFF_TRAIN_WRITER " +
                $", STAFF_TRAIN_WRITE_DATE, STAFF_TRAIN_REVIEWER, STAFF_TRAIN_REVIEW_DATE, STAFF_TRAIN_APPROVER, STAFF_TRAIN_APPROVAL_DATE) " +
                $" values " +
                $" ('{sSTAFF_CODE}', '{sSTAFF_TRAIN_COURSE}', '{sSTAFF_TRAIN_GUBUN}', '{sSTAFF_TRAIN_ORG}', '{sSTAFF_TRAIN_EDU}', '{sSTAFF_TRAIN_TRAINER}', '{sSTAFF_TRAIN_DATE}', "+
                $" '{sSTAFF_TRAIN_DATE_TO}', '{sSTAFF_TRAIN_HOUR}', '{sSTAFF_TRAIN_ATTENDEE}', '{sSTAFF_TRAIN_GOAL}', '{sSTAFF_TRAIN_SUMMARY}', " +
                $" '{sSTAFF_TRAIN_CONTENTS}', '{sSTAFF_TRAIN_RESULT}', '{sSTAFF_TRAIN_RESULT_DIR_FILE}', '{sSTAFF_TRAIN_REVIEW}', '{sSTAFF_TRAIN_WRITER}', "+
                $" '{sSTAFF_TRAIN_WRITE_DATE}', '{sSTAFF_TRAIN_REVIEWER}', '{sSTAFF_TRAIN_REVIEW_DATE}', '{sSTAFF_TRAIN_APPROVER}', ' {sSTAFF_TRAIN_APPROVAL_DATE}'); ";

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
                $" update PQMS_STAFF_TRAINING set " +
                $" STAFF_TRAIN_COURSE='{sSTAFF_TRAIN_COURSE}', STAFF_TRAIN_GUBUN='{sSTAFF_TRAIN_GUBUN}'," +
                $" STAFF_TRAIN_EDU ='{sSTAFF_TRAIN_EDU}' ," +
                $" STAFF_TRAIN_ORG='{sSTAFF_TRAIN_ORG}', STAFF_TRAIN_TRAINER='{sSTAFF_TRAIN_TRAINER}', STAFF_TRAIN_DATE='{sSTAFF_TRAIN_DATE}', STAFF_TRAIN_DATE_TO='{sSTAFF_TRAIN_DATE_TO}' , STAFF_TRAIN_HOUR='{sSTAFF_TRAIN_HOUR}'," +
                $" STAFF_TRAIN_ATTENDEE ='{sSTAFF_TRAIN_ATTENDEE}', STAFF_TRAIN_GOAL ='{sSTAFF_TRAIN_GOAL}', STAFF_TRAIN_SUMMARY ='{sSTAFF_TRAIN_SUMMARY}', STAFF_TRAIN_CONTENTS ='{sSTAFF_TRAIN_CONTENTS}', " +
                $" STAFF_TRAIN_RESULT ='{sSTAFF_TRAIN_RESULT}', STAFF_TRAIN_RESULT_DIR_FILE ='{sSTAFF_TRAIN_RESULT_DIR_FILE}', " +
                $" STAFF_TRAIN_REVIEW='{sSTAFF_TRAIN_REVIEW}', STAFF_TRAIN_WRITER='{sSTAFF_TRAIN_WRITER}', STAFF_TRAIN_WRITE_DATE='{sSTAFF_TRAIN_WRITE_DATE}', " +
                $" STAFF_TRAIN_REVIEWER='{sSTAFF_TRAIN_REVIEWER}', STAFF_TRAIN_REVIEW_DATE='{sSTAFF_TRAIN_REVIEW_DATE}', STAFF_TRAIN_APPROVER='{sSTAFF_TRAIN_APPROVER}', " +
                $" STAFF_TRAIN_APPROVAL_DATE='{sSTAFF_TRAIN_APPROVAL_DATE}'" +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                $" delete from PQMS_STAFF_TRAINING " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' "+
                $" delete from  PQMS_STAFF_TRAINING_ATTENDEE " +
                $" where H_IDX= '{iIDX}'  ";

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

    public class Form2PQMS_PQMS_STAFF_TRAINING_InfoGridDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_TRAIN_COURSE { get; set; }

        public string sSTAFF_TRAIN_GUBUN { get; set; }

        public string sSTAFF_TRAIN_ORG { get; set; }

        public string sSTAFF_TRAIN_EDU { get; set; }

        public string sSTAFF_TRAIN_TRAINER { get; set; }

        public string sSTAFF_TRAIN_DATE { get; set; }

        public string sSTAFF_TRAIN_DATE_TO { get; set; }

        public string sSTAFF_TRAIN_HOUR { get; set; }

        public string sSTAFF_TRAIN_ATTENDEE { get; set; }

        public string sSTAFF_TRAIN_GOAL { get; set; }

        public string sSTAFF_TRAIN_SUMMARY { get; set; }

        public string sSTAFF_TRAIN_CONTENTS { get; set; }

        public string sSTAFF_TRAIN_RESULT { get; set; }

        public string sSTAFF_TRAIN_REVIEW { get; set; }

        public string sSTAFF_TRAIN_WRITER { get; set; }

        public string sSTAFF_TRAIN_WRITE_DATE { get; set; }

        public string sSTAFF_TRAIN_REVIEWER { get; set; }

        public string sSTAFF_TRAIN_REVIEW_DATE { get; set; }

        public string sSTAFF_TRAIN_APPROVER { get; set; }

        public string sSTAFF_TRAIN_APPROVAL_DATE { get; set; }

        public string sSTAFF_TRAIN_RESULT_DIR_FILE { get; set; }

        public Form2PQMS_PQMS_STAFF_TRAINING_InfoGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT *, " +                                                                  // 0714_hiel
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                  // 0714_hiel
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                        // 0714_hiel
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                        // 0714_hiel
                $" ELSE '반려' " +                                                                       // 0714_hiel
                $" END) AS 'approvedYN_Korea' " +                                                          // 0714_hiel
                $" FROM [PQMS_STAFF_TRAINING] as a" +                                         // 0714_hiel
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

    }


    public class Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet : UlSqlDataSet
    {
        public string sMenuNo { get; set; }

        public string sAppID { get; set; }

        public string sMenuID { get; set; }

        public string sParentMenuID { get; set; }

        public string smenuName { get; set; }

        public string stabName { get; set; }

        public string sregisteredBy { get; set; }

        public string sregisteredDate { get; set; }

        public string smodifiedBy { get; set; }

        public string sModifiedDate { get; set; }

        public string sDisuse { get; set; }

        public string sDisusedBy { get; set; }

        public string sDisusedDate { get; set; }

        public Form2PQMS_PQMS_STAFF_EACH_LIST_Approve_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [accountMaster].[dbo].[menuMaster]" +
                $" where menuName = '{smenuName}' and appID = '{sAppID}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sMenuNo = "";
                sAppID = "";
                sMenuID = "";
                sParentMenuID = "";
                smenuName = "";
                sregisteredBy = "";
                sregisteredDate = "";
                smodifiedBy = "";
                sModifiedDate = "";
                sDisuse = "";
                sDisusedBy = "";
                sDisusedDate = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sMenuNo = row["menuNo"].ToString();
            smenuName = row["menuName"].ToString();
        }
    }


    public class Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet : UlSqlDataSet
    {
        public string sMenuNo { get; set; }

        public string sAppID { get; set; }

        public string sMenuID { get; set; }

        public string sParentMenuID { get; set; }

        public string smenuName { get; set; }

        public string stabName { get; set; }

        public string sregisteredBy { get; set; }

        public string sregisteredDate { get; set; }

        public string smodifiedBy { get; set; }

        public string sModifiedDate { get; set; }

        public string sDisuse { get; set; }

        public string sDisusedBy { get; set; }

        public string sDisusedDate { get; set; }

        public Form2PQMS_PQMS_STAFF_ROLE_Approve_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [accountMaster].[dbo].[menuMaster]" +
                $" where menuName = '{smenuName}' and appID = '{sAppID}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sMenuNo = "";
                sAppID = "";
                sMenuID = "";
                sParentMenuID = "";
                smenuName = "";
                sregisteredBy = "";
                sregisteredDate = "";
                smodifiedBy = "";
                sModifiedDate = "";
                sDisuse = "";
                sDisusedBy = "";
                sDisusedDate = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sMenuNo = row["menuNo"].ToString();
            smenuName = row["menuName"].ToString();
        }
    }

    public class Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet : UlSqlDataSet
    {
        public string sMenuNo { get; set; }

        public string sAppID { get; set; }

        public string sMenuID { get; set; }

        public string sParentMenuID { get; set; }

        public string smenuName { get; set; }

        public string stabName { get; set; }

        public string sregisteredBy { get; set; }

        public string sregisteredDate { get; set; }

        public string smodifiedBy { get; set; }

        public string sModifiedDate { get; set; }

        public string sDisuse { get; set; }

        public string sDisusedBy { get; set; }

        public string sDisusedDate { get; set; }

        public Form2PQMS_PQMS_STAFF_ROLE_PAPER_Approve_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [accountMaster].[dbo].[menuMaster]" +
                $" where menuName = '{smenuName}' and appID = '{sAppID}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sMenuNo = "";
                sAppID = "";
                sMenuID = "";
                sParentMenuID = "";
                smenuName = "";
                sregisteredBy = "";
                sregisteredDate = "";
                smodifiedBy = "";
                sModifiedDate = "";
                sDisuse = "";
                sDisusedBy = "";
                sDisusedDate = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sMenuNo = row["menuNo"].ToString();
            smenuName = row["menuName"].ToString();
        }
    }


    public class Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridDataSet : UlSqlDataSet
    {
        public string sMenuNo { get; set; }

        public string sAppID { get; set; }

        public string sMenuID { get; set; }

        public string sParentMenuID { get; set; }

        public string smenuName { get; set; }

        public string stabName { get; set; }

        public string sregisteredBy { get; set; }

        public string sregisteredDate { get; set; }

        public string smodifiedBy { get; set; }

        public string sModifiedDate { get; set; }

        public string sDisuse { get; set; }

        public string sDisusedBy { get; set; }

        public string sDisusedDate { get; set; }

        public Form2PQMS_PQMS_STAFF_TRAINING_Approve_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [accountMaster].[dbo].[menuMaster]" +
                $" where menuName = '{smenuName}' and appID = '{sAppID}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sMenuNo = "";
                sAppID = "";
                sMenuID = "";
                sParentMenuID = "";
                smenuName = "";
                sregisteredBy = "";
                sregisteredDate = "";
                smodifiedBy = "";
                sModifiedDate = "";
                sDisuse = "";
                sDisusedBy = "";
                sDisusedDate = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sMenuNo = row["menuNo"].ToString();
            smenuName = row["menuName"].ToString();
        }
    }

    public class Form2PQMS_STAFF_ASSESSMENT_MainGridDataSet : UlSqlDataSet
    {

        public int iIDX { get; set; }
        public string sSTAFF_CODE { get; set; }
        public string sFINAL_FILE { get; set; }


        public Form2PQMS_STAFF_ASSESSMENT_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT *, " +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +
                $" ELSE '반려' " +
                $" END) AS 'approvedYN_Korea' " +
                $" FROM [PQMS_STAFF_ASSESSMENT_REPORT] AS a" +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Delete(SqlTransaction trans = null)
        {
            string sql =
                $" delete from PQMS_STAFF_ASSESSMENT_REPORT " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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

    public class Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridDataSet : UlSqlDataSet
    {
        public string sMenuNo { get; set; }

        public string sAppID { get; set; }

        public string sMenuID { get; set; }

        public string sParentMenuID { get; set; }

        public string smenuName { get; set; }

        public string stabName { get; set; }

        public string sregisteredBy { get; set; }

        public string sregisteredDate { get; set; }

        public string smodifiedBy { get; set; }

        public string sModifiedDate { get; set; }

        public string sDisuse { get; set; }

        public string sDisusedBy { get; set; }

        public string sDisusedDate { get; set; }

        public Form2PQMS_PQMS_STAFF_ASSESSMENT_Approve_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM [accountMaster].[dbo].[menuMaster]" +
                $" where menuName = '{smenuName}' and appID = '{sAppID}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sMenuNo = "";
                sAppID = "";
                sMenuID = "";
                sParentMenuID = "";
                smenuName = "";
                sregisteredBy = "";
                sregisteredDate = "";
                smodifiedBy = "";
                sModifiedDate = "";
                sDisuse = "";
                sDisusedBy = "";
                sDisusedDate = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sMenuNo = row["menuNo"].ToString();
            smenuName = row["menuName"].ToString();
        }
    }

    public class Form2_ApproveInfo_DataSet : UlSqlDataSet
    {
        public string smenuNo { get; set; }

        public Form2_ApproveInfo_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Insert_approveMaster(string sTabName = "", string sWorkNo = "", SqlTransaction trans = null)
        {
            string sql =
                $" insert into [accountMaster].[dbo].[approveMaster] values " +
                $" ('{Form2PQMS_LoginInfo.sloginId}', '{Form2PQMS_LoginInfo.sUserId}', '{Form2PQMS_LoginInfo.sAppId}', '{smenuNo}'," +
                $" '{sTabName}', '{sWorkNo}', 'request', '{Form2PQMS_LoginInfo.sloginId}', getdate(), '', getdate() ); ";

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

        public void Insert_ApproveInfo(SqlTransaction trans = null)
        {
            string sql =
                $" insert into [accountMaster].[dbo].[approveInfo] values " +
                $" ('{Form2PQMS_LoginInfo.sUserId}', '{Form2PQMS_LoginInfo.sloginId}', '{Form2PQMS_LoginInfo.sAppId}', '{smenuNo}'," +
                $" @@identity, '0', NULL, '{Form2PQMS_LoginInfo.sloginId}', getdate()); ";

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

    public class Form2PQMS_STAFF_ROLE_PAPER_FinalGridDataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }

        public Form2PQMS_STAFF_ROLE_PAPER_FinalGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT a.RP_ORG_CODE, b.ORG_NAME, a.RP_FINAL_FILE, 'V' + a.RP_VERSION  +'.0' RP_VERSION, a.STAFF_CODE , a.PQMS_STAFF_ROLE_PAPER_IDX , a.IDX  , c.ROLE_NAME, a.RP_REASON , a.approveStatusCode " +
                $" FROM PQMS_STAFF_ROLE_PAPER_FINAL a " +
                $" inner join PQMS_ORG b on a.RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and b.WS_CODE='{Form1PQMS_Repo.sWS}' " +
                $" inner join PQMS_ROLE2_CODE c on  c.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and c.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and c.WS_CODE='{Form1PQMS_Repo.sWS}'  and a.rp_code = c.ROLE_CODE" +
                $" where a.STAFF_CODE = '{sSTAFF_CODE}'";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

    }

    public class Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_DataSet : UlSqlDataSet
    {
        public string sSTAFF_CODE { get; set; }
        public string sIDX { get; set; }
        public string sAPPROVE_STATUS_CODE { get; set; }
        public string sRPIDX { get; set; }
        public string sRP_FINAL_FILE { get; set; }
        public Form2PQMS_STAFF_ROLE_PAPER_PERIODICINSPECTION_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Delete_ROLE_PAPER_FINAL(SqlTransaction trans = null)
        {
            //string[] RPIDX = sRPIDX.Split(',');

            //for (int i = 0; i < RPIDX.Length; i++)
            //{

            //}

            string sql = "";

            sql = " UPDATE PQMS_STAFF_ROLE_PAPER SET " +
            $" STAFF_RP_FILE = '', " +
            $" STAFF_RP_FINAL = '' " +
            $" WHERE IDX in ({sRPIDX})";

            sql += " DELETE FROM PQMS_STAFF_ROLE_PAPER_FINAL " +
                $"  WHERE PQMS_STAFF_ROLE_PAPER_IDX =  " +
                $" ( select PQMS_STAFF_ROLE_PAPER_IDX from PQMS_STAFF_ROLE_PAPER_FINAL where idx='{sIDX}' )";

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

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_ROLE_PAPER_FINAL " +
                $" (STAFF_CODE,	PQMS_STAFF_ROLE_PAPER_IDX,	RP_ORG_CODE,	RP_CODE,	RP_FINAL_FILE,	RP_VERSION,	RP_CREATE_DATE	,RP_REASON,	RP_GROUP_NAME2,	appNo	,DeptNo,	WorkNo,	MenuNo,	requestStatusCode	,approveStatusCode	,approveComment) " +
                $" select STAFF_CODE,	PQMS_STAFF_ROLE_PAPER_IDX,	RP_ORG_CODE,	RP_CODE,	RP_FINAL_FILE,	RP_VERSION, " +
                $" FORMAT(cast(getdate() as datetime), 'yyyy-MM-dd HH:mm:ss'),'정기점검 / 확인자 - {Form2PQMS_LoginInfo.sUserId}',	RP_GROUP_NAME2,	appNo	,DeptNo,	WorkNo,	MenuNo,	requestStatusCode	,approveStatusCode	,approveComment " +
                $" from PQMS_STAFF_ROLE_PAPER_FINAL" +
                $" where idx='{sIDX}'";

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


    public class Form2PQMS_STAFF_ROLE_PAPER_MainGridDataSet : UlSqlDataSet
    {
        public int iIDX { get; set; }

        public string sSTAFF_CODE { get; set; }

        public string sSTAFF_RP_DATE { get; set; }

        public string sSTAFF_RP_CLASS { get; set; }
        public string sSTAFF_RP_CLASS_2 { get; set; }
        public string sSTAFF_RP_CLASS_3 { get; set; }
        public string sSTAFF_RP_CLASS_4 { get; set; }
        public string sSTAFF_RP_CLASS_5 { get; set; }
        public string sSTAFF_RP_CLASS_6 { get; set; }

        public string sSTAFF_RP_ORG_CODE { get; set; }
        public string sSTAFF_RP_CODE { get; set; }
        public string sSTAFF_RP_CODE_NAME { get; set; }

        public string sSTAFF_RP_APPROVER { get; set; }

        public string sSTAFF_RP_APPROVE_DATE { get; set; }

        public string sSTAFF_RP_SUPPORTER { get; set; }

        public string sSTAFF_RP_WRITER { get; set; } //jhm0708

        public string sSTAFF_RP_WRITE_DATE { get; set; } //jhm0708

        public string sSTAFF_RP_FIRSTDATE { get; set; }// 최초개정일
        public string sSTAFF_RP_CAREER { get; set; }//주요경력
        public string sSTAFF_RP_REASON { get; set; }//개정사유

        public string sSTAFF_RP_EACHLIST_IDX { get; set; }//시험수행능력평가이력 IDX

        public string sSTAFF_RP_TRANING_IDX { get; set; }//교육보고서 IDX

        public string sSTAFF_RP_FILE { get; set; } // 직무기술서 파일 



        public Form2PQMS_STAFF_ROLE_PAPER_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            //string sql = $" SELECT *, " +
            //    $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +
            //    $" WHEN approveStatusCode = '0' THEN '승인대기' " +
            //    $" WHEN approveStatusCode = '1' THEN '승인완료' " +
            //    $" ELSE '반려' " +
            //    $" END) AS 'approvedYN_Korea' " +
            //    $" , b.ORG_NAME, c.GROUP1_NAME + ' / ' + d.GROUP2_NAME as 'GROUP_NAME', a.STAFF_RP_FINAL, e.ROLE_NAME " +
            //    $" FROM [PQMS_STAFF_ROLE_PAPER] AS a" +
            //    $" inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and b.WS_CODE='{Form1PQMS_Repo.sWS}' " +
            //    $" inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and c.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and c.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            //    $" inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
            //    $" inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE='{Form1PQMS_Repo.sSiteCode}' and e.REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and e.WS_CODE='{Form1PQMS_Repo.sWS}'" +
            //    $" where a.STAFF_CODE = '{sSTAFF_CODE}'";

            string sql =$" SELECT a.*, b.*,c.*, " +
                        $"(CASE WHEN approveStatusCode IS NULL THEN '신청전'" +
                        $" WHEN approveStatusCode = '0' THEN '승인대기' " +
                        $" WHEN approveStatusCode = '1' THEN '승인완료'  ELSE '반려'   END) AS 'approvedYN_Korea' " +
                        $" , b.ORG_NAME, a.STAFF_RP_FINAL, e.ROLE_NAME " +
                        $" , d.GROUP2_CODE, COALESCE(d.GROUP2_NAME, '') AS GROUP2_NAME " +
                        $" , d2.GROUP2_CODE AS GROUP2_CODE_2, COALESCE(d2.GROUP2_NAME, '') AS GROUP2_NAME_2 " +
                        $" , d3.GROUP2_CODE AS GROUP2_CODE_3, COALESCE(d3.GROUP2_NAME, '') AS GROUP2_NAME_3 " +
                        $" , d4.GROUP2_CODE AS GROUP2_CODE_4, COALESCE(d4.GROUP2_NAME, '') AS GROUP2_NAME_4 " +
                        $" , d5.GROUP2_CODE AS GROUP2_CODE_5, COALESCE(d5.GROUP2_NAME, '') AS GROUP2_NAME_5 " +
                        $" , d6.GROUP2_CODE AS GROUP2_CODE_6, COALESCE(d6.GROUP2_NAME, '') AS GROUP2_NAME_6 " +
                        $" , CONCAT( c.GROUP1_NAME + ' / '," +
                        $"     NULLIF(d.GROUP2_NAME, '')," +
                        $"     NULLIF(', ' + d2.GROUP2_NAME, '')," +
                        $"     NULLIF(', ' + d3.GROUP2_NAME, '')," +
                        $"     NULLIF(', ' + d4.GROUP2_NAME, '')," +
                        $"     NULLIF(', ' + d5.GROUP2_NAME, '')," +
                        $"     NULLIF(', ' + d6.GROUP2_NAME, '')" +
                        $" ) AS 'GROUP_NAME', x.RP_VERSION  " +
                        $" FROM[PQMS_STAFF_ROLE_PAPER] AS a " +
                        $" inner join PQMS_ORG b on a.STAFF_RP_ORG_CODE = b.ORG_CODE and b.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and b.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and b.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" inner join PQMS_GROUP1 c on a.STAFF_RP_ORG_CODE = c.GROUP1_ORG_CODE and left(a.STAFF_RP_CLASS,4) = c.GROUP1_CODE and c.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and c.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and c.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" inner join PQMS_GROUP2 d on a.STAFF_RP_ORG_CODE = d.GROUP2_ORG_CODE and c.GROUP1_CODE = d.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS,4)= d.GROUP2_CODE   and d.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" left outer join PQMS_GROUP2 d2 on a.STAFF_RP_ORG_CODE = d2.GROUP2_ORG_CODE and c.GROUP1_CODE = d2.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_2,4)= d2.GROUP2_CODE   and d2.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d2.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d2.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" left outer join PQMS_GROUP2 d3 on a.STAFF_RP_ORG_CODE = d3.GROUP2_ORG_CODE and c.GROUP1_CODE = d3.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_3,4)= d3.GROUP2_CODE   and d3.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d3.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d3.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" left outer join PQMS_GROUP2 d4 on a.STAFF_RP_ORG_CODE = d4.GROUP2_ORG_CODE and c.GROUP1_CODE = d4.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_4,4)= d4.GROUP2_CODE   and d4.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d4.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d4.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" left outer join PQMS_GROUP2 d5 on a.STAFF_RP_ORG_CODE = d5.GROUP2_ORG_CODE and c.GROUP1_CODE = d5.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_5,4)= d5.GROUP2_CODE   and d5.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d5.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d5.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" left outer join PQMS_GROUP2 d6 on a.STAFF_RP_ORG_CODE = d6.GROUP2_ORG_CODE and c.GROUP1_CODE = d6.GROUP2_GROUP1_CODE and right(a.STAFF_RP_CLASS_6,4)= d6.GROUP2_CODE   and d6.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and d6.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and d6.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" inner join PQMS_ROLE2_CODE e on a.STAFF_RP_CODE = e.ROLE_CODE and e.SITE_CODE = '{Form1PQMS_Repo.sSiteCode}' and e.REPOSITORY_CODE = '{Form1PQMS_Repo.sRepo}' and e.WS_CODE = '{Form1PQMS_Repo.sWS}' " +
                        $" inner join PQMS_STAFF_ROLE_PAPER_VER x on a.STAFF_CODE = x.STAFF_CODE and a. STAFF_RP_ORG_CODE = x.RP_ORG_CODE and a.STAFF_RP_CODE = x.RP_CODE and a.idx = x.RP_IDX " +
                        $" where a.STAFF_CODE = '{sSTAFF_CODE}'";
            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_STAFF_ROLE_PAPER ( STAFF_CODE, STAFF_RP_DATE, STAFF_RP_CLASS, STAFF_RP_CLASS_2, STAFF_RP_CLASS_3, STAFF_RP_CLASS_4, STAFF_RP_CLASS_5, STAFF_RP_CLASS_6, STAFF_RP_ORG_CODE, STAFF_RP_CODE, STAFF_RP_APPROVER, STAFF_RP_APPROVE_DATE, STAFF_RP_WRITER, STAFF_RP_WRITE_DATE, STAFF_RP_SUPPORTER, STAFF_RP_FRISTDATE, STAFF_RP_CAREER, STAFF_RP_REASON,STAFF_RP_EACHLIST_IDX, STAFF_RP_TRANING_IDX )values " + //jhm0708
                $" ('{sSTAFF_CODE}', '{sSTAFF_RP_DATE}', '{sSTAFF_RP_CLASS}', '{sSTAFF_RP_CLASS_2}', '{sSTAFF_RP_CLASS_3}', '{sSTAFF_RP_CLASS_4}', '{sSTAFF_RP_CLASS_5}', '{sSTAFF_RP_CLASS_6}', '{sSTAFF_RP_ORG_CODE}', '{sSTAFF_RP_CODE}', '{sSTAFF_RP_APPROVER}', '{sSTAFF_RP_APPROVE_DATE}', " +
                $"'{sSTAFF_RP_WRITER}','{sSTAFF_RP_WRITE_DATE}', " + //jhm0708
                $"'{sSTAFF_RP_SUPPORTER}', '{sSTAFF_RP_FIRSTDATE}','{sSTAFF_RP_CAREER}','{sSTAFF_RP_REASON}', " +
                $" '{sSTAFF_RP_EACHLIST_IDX}', '{sSTAFF_RP_TRANING_IDX}' ); ";

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
                $" update PQMS_STAFF_ROLE_PAPER set " +
                $" STAFF_RP_DATE='{sSTAFF_RP_DATE}', STAFF_RP_CLASS='{sSTAFF_RP_CLASS}'," +
                $" STAFF_RP_CLASS_2='{sSTAFF_RP_CLASS_2}', STAFF_RP_CLASS_3='{sSTAFF_RP_CLASS_3}', STAFF_RP_CLASS_4='{sSTAFF_RP_CLASS_4}', STAFF_RP_CLASS_5='{sSTAFF_RP_CLASS_5}', STAFF_RP_CLASS_6='{sSTAFF_RP_CLASS_6}'," +
                $" STAFF_RP_ORG_CODE='{sSTAFF_RP_ORG_CODE}', STAFF_RP_CODE='{sSTAFF_RP_CODE}', STAFF_RP_APPROVER='{sSTAFF_RP_APPROVER}', STAFF_RP_APPROVE_DATE='{sSTAFF_RP_APPROVE_DATE}'," +
                $" STAFF_RP_SUPPORTER ='{sSTAFF_RP_SUPPORTER}'," +
                $" STAFF_RP_WRITER='{sSTAFF_RP_WRITER}', 	STAFF_RP_WRITE_DATE='{sSTAFF_RP_WRITE_DATE}', " + //jhm0708
                $" STAFF_RP_FRISTDATE ='{sSTAFF_RP_FIRSTDATE}'," +
                $" STAFF_RP_CAREER ='{sSTAFF_RP_CAREER}'," +
                $" STAFF_RP_EACHLIST_IDX ='{sSTAFF_RP_EACHLIST_IDX}'," +
                $" STAFF_RP_TRANING_IDX ='{sSTAFF_RP_TRANING_IDX}'," +
                $" STAFF_RP_REASON ='{sSTAFF_RP_REASON}'" +                
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
            //직무기술서 삭제할때 버전정보도 같이 삭제해야함.
            string sql =
                $" delete from PQMS_STAFF_ROLE_PAPER " +
                $" where IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' "+
                $" delete from PQMS_STAFF_ROLE_PAPER_VER " +
                $" where RP_IDX= '{iIDX}' and STAFF_CODE='{sSTAFF_CODE}' ";

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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }

            sql = sql + "order by ORG_CODE";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ORG values " +
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}','{sORG_CODE}', '{sORG_NAME}'); ";

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
                $" where ORG_CODE='{sORG_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where ORG_CODE={sORG_CODE} " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}', '{sEDU_ORG_CODE}', '{sEDU_CODE}', '{sEDU_NAME}'); ";

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
                //$" EDU_CODE='{sEDU_CODE}', EDU_NAME='{sEDU_NAME}'" + //jhm0708
                $" EDU_NAME='{sEDU_NAME}'" +
                $" where EDU_ORG_CODE='{sEDU_ORG_CODE}' and EDU_CODE='{sEDU_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where EDU_ORG_CODE='{sEDU_ORG_CODE}' and EDU_CODE='{sEDU_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
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
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}','{sEDU_ORG_CODE}', '{sVALI_PERIOD}', '{sVALI_DATE}', '{sVALI_ENABLE}'); ";

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
                $" where EDU_ORG_CODE='{sEDU_ORG_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where EDU_ORG_CODE={sEDU_ORG_CODE} " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

            }
            sql = sql + " order by GROUP1_ORG_CODE,	GROUP1_CODE ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_GROUP1 values " +
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}','{sGROUP1_ORG_CODE}', '{sGROUP1_CODE}', '{sGROUP1_NUM}', '{sGROUP1_NAME}'); ";

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
                $" where GROUP1_ORG_CODE='{sGROUP1_ORG_CODE}' and GROUP1_CODE='{sGROUP1_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where GROUP1_ORG_CODE='{sGROUP1_ORG_CODE}' and GROUP1_CODE='{sGROUP1_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";


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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }

            sql = sql + " order by  GROUP2_ORG_CODE,	GROUP2_GROUP1_CODE,	GROUP2_CODE ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_GROUP2 values " +
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}','{sGROUP2_ORG_CODE}', '{sGROUP2_GROUP1_CODE}', '{sGROUP2_CODE}', '{sGROUP2_NAME}'); ";

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
                $" where GROUP2_ORG_CODE='{sGROUP2_ORG_CODE}' and GROUP2_GROUP1_CODE='{sGROUP2_GROUP1_CODE}' and GROUP2_CODE='{sGROUP2_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where GROUP2_ORG_CODE='{sGROUP2_ORG_CODE}' and GROUP2_GROUP1_CODE='{sGROUP2_GROUP1_CODE}' and GROUP2_CODE='{sGROUP2_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                sql += $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }
            else
            {
                sql += $" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";
            }

            sql = sql + " order by ROLE_ORG_CODE,	ROLE_CODE ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE values " +
                $" ('{Form1PQMS_Repo.sSiteCode}','{Form1PQMS_Repo.sRepo}','{Form1PQMS_Repo.sWS}','{sROLE_ORG_CODE}', '{sROLE_CODE}', '{sROLE_NAME}'); ";

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
                // $" ROLE_CODE='{sROLE_CODE}', ROLE_NAME='{sROLE_NAME}'" + //jhm0708
                $" ROLE_NAME='{sROLE_NAME}'" +
                $" where ROLE_ORG_CODE='{sROLE_ORG_CODE}' and ROLE_CODE='{sROLE_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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
                $" where ROLE_ORG_CODE='{sROLE_ORG_CODE}' and ROLE_CODE='{sROLE_CODE}' " +
                $" and SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' and REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "'  and WS_CODE = '" + Form1PQMS_Repo.sWS + "'";

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

    public class Form2PQMS_ORG_Form5_DataSet : UlSqlDataSet
    {
        public string sORG_CODE { get; set; }

        public string sORG_NAME { get; set; }

        public Dictionary<string, string> listPQMS_ORG_CODE { get; set; }

        public Dictionary<string, string> listPQMS_ORG_NAME { get; set; }

        public Form2PQMS_ORG_Form5_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_ORG ";

            if (string.IsNullOrWhiteSpace(sORG_CODE) == false)
            {
                sql += $" where ORG_CODE='{sORG_CODE}'";
                sql += $" and SITE_CODE=  '{Form1PQMS_Repo.sSiteCode}' and  REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and WS_CODE='{Form1PQMS_Repo.sWS}'";

            }
            else
            {
                sql += $" where SITE_CODE=  '{Form1PQMS_Repo.sSiteCode}' and  REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and WS_CODE='{Form1PQMS_Repo.sWS}'";
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

        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sORG_CODE = "";
                sORG_NAME = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sORG_CODE = row["ORG_CODE"].ToString();
            sORG_NAME = row["ORG_NAME"].ToString();
        }
    }

    public class Form2PQMS_STAFF_ROLE_Form13_DataSet : UlSqlDataSet
    {
        public string sROLE_ORG_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sROLE_NAME { get; set; }

        public Dictionary<string, string> listSTAFF_ROLE { get; set; }

        public Form2PQMS_STAFF_ROLE_Form13_DataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" select * from PQMS_ROLE ";

            if (string.IsNullOrWhiteSpace(sROLE_ORG_CODE) == false)
            {
                sql += $" where ROLE_ORG_CODE='{sROLE_ORG_CODE}'";
                sql += $" and SITE_CODE=  '{Form1PQMS_Repo.sSiteCode}' and  REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and WS_CODE='{Form1PQMS_Repo.sWS}'";
            }
            else
            {
                sql += $" where SITE_CODE=  '{Form1PQMS_Repo.sSiteCode}' and  REPOSITORY_CODE='{Form1PQMS_Repo.sRepo}' and WS_CODE='{Form1PQMS_Repo.sWS}'";
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



        public void Fetch(int index = 0, int tableNo = 0)
        {
            if (index < GetRowCount(tableNo))
            {
                Fetch(dataSet.Tables[tableNo].Rows[index]);
            }
            else
            {
                sROLE_ORG_CODE = "";
                sROLE_CODE = "";
                sROLE_NAME = "";
            }
        }

        public void Fetch(DataRow row)
        {
            sROLE_ORG_CODE = row["ROLE_ORG_CODE"].ToString();
            sROLE_CODE = row["ROLE_CODE"].ToString();
            sROLE_NAME = row["ROLE_NAME"].ToString();
        }
    }

    public class FormJobDesc_ROLE2_AllGridDataSet : UlSqlDataSet
    {
        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sROLE_DEPT_CODE { get; set; }

        public string sROLE_NAME { get; set; }

        public string sROLE_VERSION { get; set; }
        public string sSTAFF_ROLE_CLASS { get; set; }

        public FormJobDesc_ROLE2_AllGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(string sSITE_CODE = "", string sREPOSITORY_CODE = "", string sWS_CODE = "", SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM PQMS_ROLE2_CODE " +
                $" where SITE_CODE = '" + sSITE_CODE + "' AND REPOSITORY_CODE = '" + sREPOSITORY_CODE + "' AND WS_CODE = '" + sWS_CODE + "' ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE2_CODE values " +
                $" ('{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sROLE_DEPT_CODE}', '{sROLE_NAME}', '{sROLE_VERSION}', '{sSTAFF_ROLE_CLASS}'); ";

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

    public class FormJobDesc_ROLE2_MainGridDataSet : UlSqlDataSet
    {
        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sROLE_DEPT_CODE { get; set; }

        public string sROLE_NAME { get; set; }

        public string sROLE_VERSION { get; set; }

        public FormJobDesc_ROLE2_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM PQMS_ROLE2_CODE " +
                //$" where SITE_CODE = '" + Form1PQMS_Repo.sSiteCode + "' AND REPOSITORY_CODE = '" + Form1PQMS_Repo.sRepo + "' AND WS_CODE = '" + Form1PQMS_Repo.sWS + "' ";
                $" where SITE_CODE = '{sSITE_CODE}' AND REPOSITORY_CODE = '{sREPOSITORY_CODE}' AND WS_CODE='{sWS_CODE}'  ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE2_CODE values " +
                $" ('{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sROLE_DEPT_CODE}', '{sROLE_NAME}', '{sROLE_VERSION}'); ";

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

        public void Update(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" update PQMS_ROLE2_CODE set " +
                $" ROLE_DEPT_CODE='{sROLE_DEPT_CODE}',	ROLE_NAME='{sROLE_NAME}', " +
                $" ROLE_VERSION='{sROLE_VERSION}'" +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and 	WS_CODE='{sWS_CODE}' and	ROLE_CODE='{sROLE_CODE}'";

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

        public void Delete(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" delete from PQMS_ROLE2_CODE " +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and 	WS_CODE='{sWS_CODE}' and	ROLE_CODE='{sROLE_CODE}'";

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

    public class FormJobDesc_ROLE2_RNR_MainGridDataSet : UlSqlDataSet
    {
        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sROLE_NO { get; set; }

        public string sROLE_CONTENTS { get; set; }

        public FormJobDesc_ROLE2_RNR_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM PQMS_ROLE2_RNR " +
                 //$" where SITE_CODE = '{sSITE_CODE}'";
                 $" where SITE_CODE = '{sSITE_CODE}' AND REPOSITORY_CODE = '{sREPOSITORY_CODE}' AND WS_CODE='{sWS_CODE}'  ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE2_RNR values " +
                $" ('{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sROLE_NO}', '{sROLE_CONTENTS}'); ";

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

        public void Update(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" update PQMS_ROLE2_RNR set  " +
                $" ROLE_CONTENTS ='{sROLE_CONTENTS}'" +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}'" +
                $" and WS_CODE='{sWS_CODE}' and 	ROLE_CODE='{sROLE_CODE}' and 	ROLE_NO='{sROLE_NO}'";

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

        public void Delete(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" delete from PQMS_ROLE2_RNR " +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}'" +
                $" and WS_CODE='{sWS_CODE}' and 	ROLE_CODE='{sROLE_CODE}' and 	ROLE_NO='{sROLE_NO}'";

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

    public class FormJobDesc_ROLE2_DOCU_MainGridDataSet : UlSqlDataSet
    {
        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sDOCU_NO { get; set; }

        public string sDOCU_CODE { get; set; }

        public string sDOCU_CODENAME { get; set; }

        public string sDOCU_CONTENTS1 { get; set; }

        public string sDOCU_CONTENTS2 { get; set; }

        public string sDOCU_CONTENTS3 { get; set; }

        public string sDOCU_CONTENTS4 { get; set; }

        public string sDOCU_CONTENTS5 { get; set; }

        public string sDOCU_CONTENTS6 { get; set; }

        public string sDOCU_CONTENTS7 { get; set; }

        public string sDOCU_CONTENTS8 { get; set; }

        public string sDOCU_CONTENTS9 { get; set; }

        public string sDOCU_CONTENTS10 { get; set; }

        public FormJobDesc_ROLE2_DOCU_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM PQMS_ROLE2_DOCU " +
                 //$" where SITE_CODE = '{sSITE_CODE}'";
                 $" where SITE_CODE = '{sSITE_CODE}' AND REPOSITORY_CODE = '{sREPOSITORY_CODE}' AND WS_CODE='{sWS_CODE}'  ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE2_DOCU values " +
                $" ('{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sDOCU_NO}', '{sDOCU_CODE}', '{sDOCU_CODENAME}', '{sDOCU_CONTENTS1}', '{sDOCU_CONTENTS2}', " +
                $" '{sDOCU_CONTENTS3}', '{sDOCU_CONTENTS4}', '{sDOCU_CONTENTS5}', '{sDOCU_CONTENTS6}', '{sDOCU_CONTENTS7}', '{sDOCU_CONTENTS8}', '{sDOCU_CONTENTS9}', " +
                $" '{sDOCU_CONTENTS10}'); ";

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

        public void Update(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" update PQMS_ROLE2_DOCU set  " +
                $" DOCU_CODENAME='{sDOCU_CODENAME}', 	DOCU_CONTENTS1='{sDOCU_CONTENTS1}',	DOCU_CONTENTS2='{sDOCU_CONTENTS2}'," +
                $" DOCU_CONTENTS3='{sDOCU_CONTENTS3}',	DOCU_CONTENTS4='{sDOCU_CONTENTS4}',	DOCU_CONTENTS5='{sDOCU_CONTENTS5}', " +
                $" DOCU_CONTENTS6='{sDOCU_CONTENTS6}',	DOCU_CONTENTS7='{sDOCU_CONTENTS7}',	DOCU_CONTENTS8='{sDOCU_CONTENTS8}', " +
                $" DOCU_CONTENTS9='{sDOCU_CONTENTS9}',	DOCU_CONTENTS10='{sDOCU_CONTENTS10}' " +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and WS_CODE='{sWS_CODE}' " +
                $" and ROLE_CODE='{sROLE_CODE}' and DOCU_NO='{sDOCU_NO}' and DOCU_CODE='{sDOCU_CODE}'";

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
        public void Delete(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" Delete from PQMS_ROLE2_DOCU   " +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and WS_CODE='{sWS_CODE}' " +
                $" and ROLE_CODE='{sROLE_CODE}' and DOCU_NO='{sDOCU_NO}' and DOCU_CODE='{sDOCU_CODE}'";

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

    public class FormJobDesc_ROLE2_EACH_LIST_MainGridDataSet : UlSqlDataSet
    {
        public string sSITE_CODE { get; set; }

        public string sREPOSITORY_CODE { get; set; }

        public string sWS_CODE { get; set; }

        public string sROLE_CODE { get; set; }

        public string sLIST_NO { get; set; }

        public string sLIST_WORKDATE { get; set; }

        public string sLIST_GROUP1 { get; set; }

        public string sLIST_GROUP2 { get; set; }

        public string sLIST_CONTENTS1 { get; set; }

        public string sLIST_CHKDATE { get; set; }

        public string sLIST_CHKSIGN { get; set; }

        public string sLIST_TECHNICAL_MANAGER { get; set; }

        public string sLIST_REMARK { get; set; }

        public FormJobDesc_ROLE2_EACH_LIST_MainGridDataSet(SqlConnection connect, SqlCommand command, SqlDataAdapter adapter)
            : base(connect, command, adapter)
        {
        }

        public void Select(SqlTransaction trans = null)
        {
            string sql = $" SELECT * " +
                $" FROM PQMS_ROLE2_EACH_LIST " +
                 //$" where SITE_CODE = '{sSITE_CODE}'";
                 $" where SITE_CODE = '{sSITE_CODE}' AND REPOSITORY_CODE = '{sREPOSITORY_CODE}' AND WS_CODE='{sWS_CODE}'  ";

            SetTrans(trans);
            command.CommandText = sql;
            dataSet.Clear();
            dataAdapter.Fill(dataSet);
        }

        public void Insert(SqlTransaction trans = null)
        {
            string sql =
                $" insert into PQMS_ROLE2_EACH_LIST values " +
                $" ('{sSITE_CODE}', '{sREPOSITORY_CODE}', '{sWS_CODE}', '{sROLE_CODE}', '{sLIST_NO}', '{sLIST_WORKDATE}', '{sLIST_GROUP1}', '{sLIST_GROUP2}', '{sLIST_CONTENTS1}', " +
                $" '{sLIST_CHKDATE}', '{sLIST_CHKSIGN}', '{sLIST_TECHNICAL_MANAGER}', '{sLIST_REMARK}'); ";

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

        public void Update(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" update PQMS_ROLE2_EACH_LIST set " +
                $" LIST_WORKDATE='{sLIST_WORKDATE}',	LIST_GROUP1='{sLIST_GROUP1}',	LIST_GROUP2='{sLIST_GROUP2}',	" +
                $" LIST_CONTENTS1='{sLIST_CONTENTS1}',	LIST_CHKDATE='{sLIST_CHKDATE}',	LIST_CHKSIGN='{sLIST_CHKSIGN}', " +
                $" LIST_TECHNICAL_MANAGER='{sLIST_TECHNICAL_MANAGER}',	LIST_REMARK='{sLIST_REMARK}'" +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and	WS_CODE='{sWS_CODE}'" +
                $" and ROLE_CODE='{sROLE_CODE}' and	LIST_NO='{sLIST_NO}'";

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

        public void Delete(SqlTransaction trans = null) //jhm0708
        {
            string sql =
                $" Delete from PQMS_ROLE2_EACH_LIST  " +
                $" where SITE_CODE='{sSITE_CODE}' and 	REPOSITORY_CODE='{sREPOSITORY_CODE}' and	WS_CODE='{sWS_CODE}'" +
                $" and ROLE_CODE='{sROLE_CODE}' and	LIST_NO='{sLIST_NO}'";

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