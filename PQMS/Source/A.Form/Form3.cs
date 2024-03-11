using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Spire.Doc;
using System.IO;

namespace PQMS
{
    public partial class Form3 : Form
    {
        private Form3DataSet Form3Set;

        public Form3()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Form3Set = new Form3DataSet(AppRes.DB.Connect, null, null);
        }

        private void btnStaffEduInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form3Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form3Set.sSTAFF_EDU_CLASS = txtSTAFF_EDU_CLASS.Text;
                Form3Set.sSTAFF_EDU_ORG_CODE = txtSTAFF_EDU_ORG_CODE.Text;
                Form3Set.sSTAFF_EDU_CODE = txtSTAFF_EDU_CODE.Text;
                Form3Set.sSTAFF_EDU_EXEC_ORG = txtSTAFF_EDU_EXEC_ORG.Text;
                Form3Set.sSTAFF_EDU_FROM = txtSTAFF_EDU_FROM.Text;
                Form3Set.sSTAFF_EDU_TO = txtSTAFF_EDU_TO.Text;
                Form3Set.sSTAFF_EDU_HOURS = txtSTAFF_EDU_HOURS.Text;
                Form3Set.sSTAFF_EDU_COMP_CERTI = txtSTAFF_EDU_COMP_CERTI.Text;
                Form3Set.sSTAFF_EDU_PASS_CERTI = txtSTAFF_EDU_PASS_CERTI.Text;
                Form3Set.sSTAFF_EDU_REPORT = txtSTAFF_EDU_REPORT.Text;
                Form3Set.sSTAFF_EDU_APPROVE_DATE = txtSTAFF_EDU_APPROVE_DATE.Text;
                Form3Set.sSTAFF_EDU_APPRVAL = txtSTAFF_EDU_APPRVAL.Text;
                Form3Set.sSTAFF_EDU_APPROVE = txtSTAFF_EDU_APPROVE.Text;
                Form3Set.sSTAFF_EDU_STATUS = txtSTAFF_EDU_STATUS.Text;

                Form3Set.Insert(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("입력 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("입력 실패!");
            }
        }

        private void btnStaffEduUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form3Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form3Set.sSTAFF_EDU_CLASS = txtSTAFF_EDU_CLASS.Text;
                Form3Set.sSTAFF_EDU_ORG_CODE = txtSTAFF_EDU_ORG_CODE.Text;
                Form3Set.sSTAFF_EDU_CODE = txtSTAFF_EDU_CODE.Text;
                Form3Set.sSTAFF_EDU_EXEC_ORG = txtSTAFF_EDU_EXEC_ORG.Text;
                Form3Set.sSTAFF_EDU_FROM = txtSTAFF_EDU_FROM.Text;
                Form3Set.sSTAFF_EDU_TO = txtSTAFF_EDU_TO.Text;
                Form3Set.sSTAFF_EDU_HOURS = txtSTAFF_EDU_HOURS.Text;
                Form3Set.sSTAFF_EDU_COMP_CERTI = txtSTAFF_EDU_COMP_CERTI.Text;
                Form3Set.sSTAFF_EDU_PASS_CERTI = txtSTAFF_EDU_PASS_CERTI.Text;
                Form3Set.sSTAFF_EDU_REPORT = txtSTAFF_EDU_REPORT.Text;
                Form3Set.sSTAFF_EDU_APPROVE_DATE = txtSTAFF_EDU_APPROVE_DATE.Text;
                Form3Set.sSTAFF_EDU_APPRVAL = txtSTAFF_EDU_APPRVAL.Text;
                Form3Set.sSTAFF_EDU_APPROVE = txtSTAFF_EDU_APPROVE.Text;
                Form3Set.sSTAFF_EDU_STATUS = txtSTAFF_EDU_STATUS.Text;

                Form3Set.Update(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("수정 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("수정 실패!");
            }
        }

        private void btnStaffEduDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form3Set.sSTAFF_CODE = txtSTAFF_CODE.Text;

                Form3Set.Delete(trans);
                AppRes.DB.CommitTrans();

                MessageBox.Show("삭제 완료!");
            }
            catch (Exception f)
            {
                string test = f.ToString();
                AppRes.DB.RollbackTrans();
                MessageBox.Show("삭제 실패!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //show_file(@"C:\Work\vs2019\PQMS\PQMS\Documents\FQP-11-F1(2)_직무기술서.docx");
        }

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form3Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
            try
            {
                Form3Set.Select();

                if (Form3Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_EDUGrid, Form3Set);
                    MessageBox.Show("조회 성공!");
                }
                else
                {
                    MessageBox.Show("조회된 값이 없습니다.");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("조회 실패!" + Environment.NewLine + f.Message);
            }
        }

        private void PQMS_STAFF_EDUGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtSTAFF_CODE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_EDU_CLASS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_CLASS"].ToString();
            txtSTAFF_EDU_ORG_CODE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_ORG_CODE"].ToString();
            txtSTAFF_EDU_CODE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_CODE"].ToString();
            txtSTAFF_EDU_EXEC_ORG.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_EXEC_ORG"].ToString();
            txtSTAFF_EDU_FROM.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_FROM"].ToString();
            txtSTAFF_EDU_TO.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_TO"].ToString();
            txtSTAFF_EDU_HOURS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_HOURS"].ToString();
            txtSTAFF_EDU_COMP_CERTI.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_COMP_CERTI"].ToString();
            txtSTAFF_EDU_PASS_CERTI.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_PASS_CERTI"].ToString();
            txtSTAFF_EDU_REPORT.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_REPORT"].ToString();
            txtSTAFF_EDU_APPROVE_DATE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPROVE_DATE"].ToString();
            txtSTAFF_EDU_APPRVAL.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPRVAL"].ToString();
            txtSTAFF_EDU_APPROVE.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_APPROVE"].ToString();
            txtSTAFF_EDU_STATUS.Text = PQMS_STAFF_EDUGridView.GetFocusedDataRow()["STAFF_EDU_STATUS"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_file(@"C:\Work\vs2019\PQMS\PQMS\Documents\FQP-11-F4(2)_교육훈련 이력기록.docx");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //show_file(@"C:\Work\vs2019\PQMS\PQMS\Documents\FQP-11-F1(2)_직무기술서.docx");
        }

        private void show_file(string tFileNM)
        {
            string tPath = "";
            string tFile = "";
            string tPathFile = "";

            //tPath = "C:\\WORK\\FileServer";
            //tFile = lstAttached.SelectedItem.ToString();
            //txtSelected.Text = lstAttached.SelectedItem.ToString();

            //tPathFile = tPath + "\\" + tFile;
            tPathFile = tFileNM;

            //Create word document
            Document document = new Document();

            string ext = System.IO.Path.GetExtension(tFile);

            if (File.Exists(@tPathFile) == true)
            {
                //if (ext.Equals(".DOCX") || ext.Equals(".DOC") || ext.Equals(".docx") || ext.Equals(".doc"))
                //{
                //    document.LoadFromFile(@tPath + "\\" + tFile);
                //    //Launching the MS Word file.
                //    WordDocViewer(@tPath + "\\" + tFile);
                //}
                //else if (ext.Equals(".XLSX") || ext.Equals(".XLS") || ext.Equals(".xls") || ext.Equals(".xlsx"))
                //{
                //    Workbook workbook = new Workbook();

                //    //Load workbook from disk.
                //    workbook.LoadFromFile(@tPath + "\\" + tFile);

                //    ExcelDocViewer(workbook.FileName);
                //}
                //else if (ext.Equals(".PDF") || ext.Equals(".pdf"))
                //{
                //    //Create a pdf document.
                //    PdfDocument doc = new PdfDocument();

                //    //Launching the Pdf file.
                //    PDFDocumentViewer(@tPath + "\\" + tFile);
                //}
                //else
                {
                    try
                    {
                        //System.Diagnostics.Process.Start(@tPath + "\\" + tFile);
                        System.Diagnostics.Process.Start(@tPathFile);

                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("File not exist");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            show_file(@"C:\Work\vs2019\PQMS\PQMS\Documents\FQP-11-F3(2) 교육보고서.docx");
        }
    }
}
