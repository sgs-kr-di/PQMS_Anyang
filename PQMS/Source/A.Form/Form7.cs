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
    public partial class Form7 : Form
    {
        private Form7DataSet Form7Set;

        public Form7()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Form7Set = new Form7DataSet(AppRes.DB.Connect, null, null);
        }

        private void btnStaffroleInsert_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form7Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form7Set.sSTAFF_ROLE_DATE = txtSTAFF_ROLE_DATE.Text;
                Form7Set.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                Form7Set.sSTAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_CODE = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_NAME = txtSTAFF_ROLE_NAME.Text;
                Form7Set.sSTAFF_ROLE_STATUS = txtSTAFF_ROLE_STATUS.Text;
                Form7Set.sSTAFF_ROLE_GIVEN_CLASS = txtSTAFF_ROLE_GIVEN_CLASS.Text;
                Form7Set.sSTAFF_ROLE_CERTI = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_INSTEAD = txtSTAFF_ROLE_INSTEAD.Text;

                Form7Set.Insert(trans);
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

        private void btnStaffroleUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form7Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
                Form7Set.sSTAFF_ROLE_DATE = txtSTAFF_ROLE_DATE.Text;
                Form7Set.sSTAFF_ROLE_CLASS = txtSTAFF_ROLE_CLASS.Text;
                Form7Set.sSTAFF_ROLE_ORG_CODE = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_CODE = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_NAME = txtSTAFF_ROLE_NAME.Text;
                Form7Set.sSTAFF_ROLE_STATUS = txtSTAFF_ROLE_STATUS.Text;
                Form7Set.sSTAFF_ROLE_GIVEN_CLASS = txtSTAFF_ROLE_GIVEN_CLASS.Text;
                Form7Set.sSTAFF_ROLE_CERTI = txtSTAFF_ROLE_CODE.Text;
                Form7Set.sSTAFF_ROLE_INSTEAD = txtSTAFF_ROLE_INSTEAD.Text;

                Form7Set.Update(trans);
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

        private void btnStaffroleDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = AppRes.DB.BeginTrans();

            try
            {
                Form7Set.sSTAFF_CODE = txtSTAFF_CODE.Text;

                Form7Set.Delete(trans);
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

        private void btnLookUpData_Click(object sender, EventArgs e)
        {
            Form7Set.sSTAFF_CODE = txtSTAFF_CODE.Text;
            try
            {
                Form7Set.Select();

                if (Form7Set.Empty == false)
                {
                    AppHelper.SetGridDataSource(PQMS_STAFF_ROLEGrid, Form7Set);
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

        private void PQMS_STAFF_ROLEGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            txtSTAFF_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_CODE"].ToString();
            txtSTAFF_ROLE_DATE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_DATE"].ToString();
            txtSTAFF_ROLE_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CLASS"].ToString();
            txtSTAFF_ROLE_ORG_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_ORG_CODE"].ToString();
            txtSTAFF_ROLE_CODE.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CODE"].ToString();
            txtSTAFF_ROLE_NAME.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_NAME"].ToString();
            txtSTAFF_ROLE_STATUS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_STATUS"].ToString();
            txtSTAFF_ROLE_GIVEN_CLASS.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_GIVEN_CLASS"].ToString();
            txtSTAFF_ROLE_CERTI.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_CERTI"].ToString();
            txtSTAFF_ROLE_INSTEAD.Text = PQMS_STAFF_ROLEGridView.GetFocusedDataRow()["STAFF_ROLE_INSTEAD"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_file(@"C:\Work\vs2019\PQMS\PQMS\Documents\FQP-11-F10(2)_임명장(공통).docx");
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
    }
}
