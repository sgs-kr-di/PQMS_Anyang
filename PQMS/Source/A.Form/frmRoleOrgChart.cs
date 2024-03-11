using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Collections;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Xls;
using Spire.Xls.Collections;
using Spire.Xls.Core.Spreadsheet.Shapes;
using System.Data.OleDb;
using System.Globalization;
using PQMS.C.Unit;
using DevExpress.Data;


namespace PQMS
{
    public partial class frmRoleOrgChart : MetroFramework.Forms.MetroForm
    {

        private UnitCommon unitCommon;
        private OleDbConnection Conn;

        private int MAX_idx;

        public string equip_query = "";
        public int j = 0;
        public int wRowNo = 0;
        public string wpwd;


        public frmRoleOrgChart()
        {
            InitializeComponent();
            unitCommon = new UnitCommon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get_Data();            
            if (dgvData.Rows.Count > 1)
            {
                Set_OrgChart_FileName();
                save_item();                
                OrgChart_All();               
            }
            else 
            {
                MessageBox.Show("DATA error");
            }            
        }

        private void save_item()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);
            string query = "";

            query = "INSERT INTO PQMS_STAFF_ORG_CHART (ORG_CODE, ORG_NAME, GROUP1_CODE, GROUP1_NAME, STAFF_CODE, RESULT_CHART_FILE) VALUES ( ";
            query = query + "'" + txtSTAFF_ROLE_ORG_CODE.Text.Trim() + "',";
            query = query + "N'" + txtOrgName.Text.Trim() + "',";
            query = query + "'" + txtGroup1Code.Text.Trim() + "',";
            query = query + "N'" + txtBig.Text.Trim() + "',";
            //query = query + "N'" + txtStaffName.Text.Trim() + "',";            
            query = query + "'',";
            query = query + "N'" + txtOrgChart.Text.Trim() + "')";

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();
            cmd.ExecuteNonQuery(); 
            Conn.Close();
        }


        private DataTable convertoDt(DataGridView dgv1)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Role");
            dt.Locale = CultureInfo.InvariantCulture;
           
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                dt.Rows.Add();
               
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1)  //체크박스, 사원코드 제외
                    {                        
                        dt.Rows[row.Index][cell.ColumnIndex - 2] = cell.Value.ToString(); // 2개의 cell을 제외했기 때문
                    }
                }
            }
            DataView dav1 = new DataView(dt);
            dt = dav1.ToTable();

            return dt;
        }

        private List<XlsRectangleShape> GetAllRectangle(Worksheet worksheet)
        {
            List<XlsRectangleShape> rectangleList = new List<XlsRectangleShape>();
            for (int i = 0; i < worksheet.RectangleShapes.Count; i++)
            {
                XlsRectangleShape shape = (XlsRectangleShape)worksheet.RectangleShapes[i];
                rectangleList.Add(shape);
            }
            return rectangleList;
        }

        private List<XlsTextBoxShape> GetAllTextBox(Worksheet worksheet)
        {
            List<XlsTextBoxShape> textboxList = new List<XlsTextBoxShape>();
            for (int i = 0; i < worksheet.TextBoxes.Count; i++)
            {
                XlsTextBoxShape shape = (XlsTextBoxShape)worksheet.TextBoxes[i];
                textboxList.Add(shape);
            }
            return textboxList;
        }



        private void Set_OrgChart_FileName()
        {
            string query = "";
            Conn = new OleDbConnection(unitCommon.connect_string);


            query = "select Max(IDX) from PQMS_STAFF_ORG_CHART";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        MAX_idx = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                    }
                }
            }
            txtIDX.Text = MAX_idx.ToString();


            if (cmbFolder.Text.Substring(0, 4) == "0001")
            {
                txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_KOLAS" + "(" + MAX_idx + ")" + ".xlsx";
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0002")
            {

                if (txtGroup1Code.Text != "")
                {
                    txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_식약처_" + txtBig.Text + "(" + MAX_idx + ")" + ".xlsx";
                }
                else
                {
                    txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_식약처" + "(" + MAX_idx + ")" + ".xlsx";
                }


            }
            else if (cmbFolder.Text.Substring(0, 4) == "0003")
            {

                if (txtGroup1Code.Text != "")
                {
                    txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_농산물품질관리원_" + txtBig.Text + "(" + MAX_idx + ")" + ".xlsx";
                }
                else
                {
                    txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_농산물품질관리원" + "(" + MAX_idx + ")" + ".xlsx";
                }
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0004")
            {
                txtOrgChart.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Report\OrgChart\조직도_HN_전체" + "(" + MAX_idx + ")" + ".xlsx";
            }
        }

        private void OrgChart_All()
        {
            //임의 데이터
            DataTable maindt = convertoDt(dgvData);
            maindt = maindt.AsEnumerable().OrderBy(r => r.Field<string>("Role")).CopyToDataTable();
            //같은 셀에 들어가야하는 데이터끼리 split dt
            List<DataTable> dtbyRole = maindt.AsEnumerable()
           .GroupBy(row => row.Field<string>("Role"))
           .Select(g => g.CopyToDataTable())
           .ToList();

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(txtTemplate.Text);
            Worksheet worksheet = workbook.Worksheets["Sheet1"];

            ExcelFont font = workbook.CreateFont();
            font.FontName = "Calibri (Body)";
            font.IsBold = true;
            font.Size = 18;
            font.Color = Color.Black;

            //GET ALL XLS SHAPES
            List<XlsRectangleShape> xlsRectangleShapes = GetAllRectangle(worksheet);
            List<XlsTextBoxShape> xlsTextBoxes = GetAllTextBox(worksheet);
            foreach (DataTable dt in dtbyRole)
            {
                string name = dt.Rows[0][1].ToString().Trim().ToLower().Replace(" ", "");
                if (xlsRectangleShapes.Where(r => r.Name.ToString().Trim().ToLower().Replace(" ", "") == name.ToString().Trim().ToLower().Replace(" ", "")).Count() > 0)
                {
                    XlsRectangleShape shape = xlsRectangleShapes.Where(r => r.Name.ToString().Trim().ToLower().Replace(" ", "") == name.ToString().Trim().ToLower().Replace(" ", "")).First();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows.Count > 1)
                        {
                            shape.Text += dt.Rows[j][0].ToString() + "\n";
                        }
                        else
                        {
                            shape.Text = dt.Rows[j][0].ToString();
                        }
                    } 
                    shape.Text = shape.Text.Trim();
                    (new RichText(shape.RichText)).SetFont(0, shape.Text.Length - 1, font);
                }

                if (xlsTextBoxes.Where(r => r.Name.ToString().Trim().ToLower().Replace(" ", "") == name.ToString().Trim().ToLower().Replace(" ", "")).Count() > 0)
                {
                    XlsTextBoxShape textbox = xlsTextBoxes.Where(r => r.Name.ToString().Trim().ToLower().Replace(" ", "") == name.ToString().Trim().ToLower().Replace(" ", "")).First();
                    if ((txtSTAFF_ROLE_ORG_CODE.Text == "0002" && textbox.Name.Trim() == "이화학시험검사원" && txtGroup1Code.Text == "" ) || (txtSTAFF_ROLE_ORG_CODE.Text == "0004" && textbox.Name.Trim() == "이화학시험검사원" && txtGroup1Code.Text == ""))
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {

                            if (j % 2 == 1) //홀수 임
                            {
                                if (dt.Rows.Count > 1)
                                {
                                    textbox.Text += dt.Rows[j][0].ToString() + "\n";
                                }
                                else
                                {
                                    textbox.Text = dt.Rows[j][0].ToString();
                                }
                            }
                            else
                            {
                                if (dt.Rows.Count > 1)
                                {
                                    textbox.Text += dt.Rows[j][0].ToString() + "          ";
                                }
                                else
                                {
                                    textbox.Text = dt.Rows[j][0].ToString();
                                }
                            }
                        }
                        textbox.Text = textbox.Text.Trim();
                        int rowcount = dt.Rows.Count / 2 + dt.Rows.Count % 2;
                        textbox.Height = 45 * rowcount;
                        (new RichText(textbox.RichText)).SetFont(0, textbox.Text.Length - 1, font);                        
                    }
                    else
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows.Count > 1)
                            {
                                textbox.Text += dt.Rows[j][0].ToString() + "\n";
                            }
                            else
                            {
                                textbox.Text = dt.Rows[j][0].ToString();
                            }
                        }
                        textbox.Text = textbox.Text.Trim();
                        int rowcount = dt.Rows.Count; //   / 2 + dt.Rows.Count % 2;
                        textbox.Height = 45 * rowcount;
                        (new RichText(textbox.RichText)).SetFont(0, textbox.Text.Length - 1, font);
                        
                    }
                }
            }

            //foreach (DataTable dt in dtbyRole)
            //{
            //    string name = dt.Rows[0][1].ToString().Trim().ToLower().Replace(" ", "");
            //    for (int i = 0; i < worksheet.RectangleShapes.Count; i++)
            //    {
            //        XlsRectangleShape shape = (XlsRectangleShape)worksheet.RectangleShapes[i];
            //        Debug.WriteLine(shape.Name);
            //        if (shape.Name.ToString().Trim().ToLower().Replace(" ", "") == name.ToString().Trim().ToLower().Replace(" ", ""))
            //        {
            //            if (txtSTAFF_ROLE_ORG_CODE.Text == "0002" && shape.Name == "이화학시험검사원") 
            //            {
            //                for (int j = 0; j < dt.Rows.Count; j++)
            //                {
            //                    if (j % 2 == 1) //홀수 임
            //                    {
            //                        if (dt.Rows.Count > 1)
            //                        {
            //                            shape.Text += dt.Rows[j][0].ToString() + "\n";
            //                        }
            //                        else
            //                        {
            //                            shape.Text = dt.Rows[j][0].ToString();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (dt.Rows.Count > 1)
            //                        {                                        
            //                            shape.Text += dt.Rows[j][0].ToString() + "          ";
            //                        }
            //                        else
            //                        {
            //                            shape.Text = dt.Rows[j][0].ToString();
            //                        }
            //                    }                                
            //                }
            //                shape.Text = shape.Text.Trim();                            
            //                (new RichText(shape.RichText)).SetFont(0, shape.Text.Length - 1, font);
            //                break;
            //            }
            //            else
            //            {
            //                for (int j = 0; j < dt.Rows.Count; j++)
            //                {
            //                    if (dt.Rows.Count > 1)
            //                    {
            //                        shape.Text += dt.Rows[j][0].ToString() + "\n";
            //                    }
            //                    else
            //                    {
            //                        shape.Text = dt.Rows[j][0].ToString();
            //                    }
            //                }
            //                shape.Text = shape.Text.Trim();
            //                (new RichText(shape.RichText)).SetFont(0, shape.Text.Length - 1, font);
            //                break;
            //            } 
            //        }
            //    }
            //}

           
            workbook.SaveToFile(txtOrgChart.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofDialog = new OpenFileDialog();
            //ofDialog.Filter = "All files|*.*|Microsoft Excel Files(*.xls;*.xlsx;*.ods;*.xlsb)|*.xls;*.xlsx;*.xlsb;*.ods";
            //if (ofDialog.ShowDialog() == DialogResult.OK) ;
            ////Form3 form3 = new Form3(ofDialog.FileName);

            //jhm
            System.Diagnostics.Process.Start(txtOrgChart.Text);

            //jhm
            //frmExcelPreview frmExcelPreview3 = new frmExcelPreview(txtOrgChart.Text);
            //frmExcelPreview3.Show();
        }

        private void rdbKOLAS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofDialog = new OpenFileDialog();
            //ofDialog.Filter = "All files|*.*|Microsoft Excel Files(*.xls;*.xlsx;*.ods;*.xlsb)|*.xls;*.xlsx;*.xlsb;*.ods";
            //if (ofDialog.ShowDialog() == DialogResult.OK) ;
            ////Form3 form3 = new Form3(ofDialog.FileName);
            frmPDFPreview frmPDFPreview3 = new frmPDFPreview(txtOrgChart.Text);
            frmPDFPreview3.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            file_open(txtTemplate);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            show_file(txtTemplate.Text.Trim());
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


        private string file_open(System.Windows.Forms.TextBox tb1)
        {
            string fileName = OpenFile();
            //string fileName = "E:\\T42\\WORK\\request\\오로라\\테스트\\복사본 KI2015019.xls";
            string plainText = string.Empty;
            string ext = System.IO.Path.GetExtension(fileName).ToUpper();
            string directoryPath = string.Empty;
            tb1.Text = fileName;
            //if (txtPhoto.Text != "")
            //{
            //    pic1.Load(txtPhoto.Text);
            //    pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            //}

            if (fileName.Length > 0)
            {
                return fileName;
            }

            return string.Empty;
        }

        private string OpenFile()
        {
            openFileDialog1.Filter = "*.*|*.*";
            //openFileDialog1.Filter = "Photo (*.jpeg*)|*.jpg*";
            openFileDialog1.Title = "Choose a photo";

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            file_open(txtOrgChart);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show_file(txtOrgChart.Text.Trim());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void Get_Data()
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            dgvData.Rows.Clear();

            string query = "";

            dgvData.Rows.Clear();

            if (txtSTAFF_ROLE_ORG_CODE.Text == "0004")
            {
                //query = " select distinct a.STAFF_CODE, b.STAFF_NAME, a.STAFF_ROLE_NAME ";
                //query = query + " from PQMS_STAFF_ROLE a inner join PQMS_STAFF b ON (a.STAFF_CODE = b.STAFF_CODE)";
                //query = query + "  where 1= 1 ";
                //query = query + "  and a.STAFF_ROLE_ORG_CODE <= '" + txtSTAFF_ROLE_ORG_CODE.Text + "'";
                //query = query + "      order by a.STAFF_ROLE_NAME ";

                query = " select distinct a.STAFF_CODE, b.STAFF_NAME, c.FOLDER_NAME + a.STAFF_ROLE_NAME  'STAFF_ROLE_NAME' ";
                query = query + " from PQMS_STAFF_ROLE a ";
                query = query + " inner join PQMS_STAFF b ON(a.STAFF_CODE = b.STAFF_CODE) ";
                query = query + " inner join K_WORKSPACE c on(b.STAFF_TEAM = c.SITE_CODE + '-' + c.REPOSITORY_CODE + '-' + c.WS_CODE + '-' + c.FOLDER_CODE) ";
                query = query + " where 1 = 1 ";
                query = query + " and a.STAFF_ROLE_ORG_CODE <= '" + txtSTAFF_ROLE_ORG_CODE.Text + "' ";
                query = query + " order by a.STAFF_CODE ";

            }
            else if (txtSTAFF_ROLE_ORG_CODE.Text == "0001")
            {
                query = " select distinct a.STAFF_CODE, b.STAFF_NAME,  a.STAFF_ROLE_NAME + a.STAFF_ROLE_CLASS  'STAFF_ROLE_NAME' ";
                query = query + " from PQMS_STAFF_ROLE a inner join PQMS_STAFF b ON (a.STAFF_CODE = b.STAFF_CODE)";
                query = query + "  where 1= 1 ";
                query = query + "  and a.STAFF_ROLE_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE.Text + "'";
                query = query + "      order by 3";
            }
            else if (txtSTAFF_ROLE_ORG_CODE.Text == "0002" || txtSTAFF_ROLE_ORG_CODE.Text =="0003")
            {
                query = " select distinct a.STAFF_CODE, b.STAFF_NAME, c.FOLDER_NAME + a.STAFF_ROLE_NAME  'STAFF_ROLE_NAME' ";
                query = query + " from PQMS_STAFF_ROLE a ";
                query = query + " inner join PQMS_STAFF b ON(a.STAFF_CODE = b.STAFF_CODE) ";
                query = query + " inner join K_WORKSPACE c on(b.STAFF_TEAM = c.SITE_CODE + '-' + c.REPOSITORY_CODE + '-' + c.WS_CODE + '-' + c.FOLDER_CODE) ";
                query = query + " where 1 = 1 ";
                query = query + " and a.STAFF_ROLE_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE.Text + "' ";

                if (txtGroup1Code.Text != "")
                {
                   query = query + " and SUBSTRING(a.STAFF_ROLE_CLASS, 1,4) = '"+ txtGroup1Code.Text + "' "; 
                }

                query = query + " order by a.STAFF_CODE ";
            }
            else
            {
                query = " select distinct a.STAFF_CODE, b.STAFF_NAME, a.STAFF_ROLE_NAME ";
                query = query + " from PQMS_STAFF_ROLE a inner join PQMS_STAFF b ON (a.STAFF_CODE = b.STAFF_CODE)";
                query = query + "  where 1= 1 ";
                query = query + "  and a.STAFF_ROLE_ORG_CODE = '" + txtSTAFF_ROLE_ORG_CODE.Text + "'";
                query = query + "      order by a.STAFF_ROLE_NAME ";
            }
           

            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();


            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    gridStaff.DataSource = dt;
                }
            }




            dgvData.RowCount = 400;

            int i;
            wRowNo = 0;

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dgvData.ColumnCount = reader.FieldCount + 1;

                    for (i = 1; i < reader.FieldCount + 1; i++)
                    {
                        dgvData.Columns[i].HeaderText = reader.GetName(i - 1).ToString();
                        if (i == 1)
                        {
                            
                            dgvData.Columns[i].Width = 100;
                            dgvData.Columns[i].Visible = true;
                        }
                        else
                        {
                            if (i == 2)
                            {
                                dgvData.Columns[i].Width = 100;
                            }
                            else
                            {
                                dgvData.Columns[i].Width = 100;
                            }
                        }
                    }
                    while (reader.Read())
                    {
                        dgvData.Rows[wRowNo].Cells[0].Value = false;
                        for (i = 0; i < reader.FieldCount; i++)
                        {
                            dgvData.Rows[wRowNo].Cells[i + 1].Value = reader.GetValue(i);
                        }
                        wRowNo = wRowNo + 1;
                        dgvData.Rows[wRowNo - 1].HeaderCell.Value = wRowNo.ToString();
                    }
                }
            }
            if (wRowNo > 0)
            {
                dgvData.RowCount = wRowNo ;
            }
            else
            {
                dgvData.RowCount = 1;
            }
            Conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_folder_data("PQMS_ORG", "ORG_CODE", "ORG_NAME", cmbFolder);
        }

        private void get_folder_data(string tTable, string tField1, string tField2, ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "      order by " + tField1 + "," + tField2;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSTAFF_ROLE_ORG_CODE.Text = cmbFolder.Text.Substring(0, 4);
            txtOrgName.Text = cmbFolder.Text.Substring(5, cmbFolder.Text.Length - 5);


            txtGroup1Code.Text = "";
            txtBig.Text = "";
            cmbGroup1.Items.Clear();

            if (cmbFolder.Text.Substring(0, 4) == "0001")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_KOLAS.xlsx";
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0002")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_식약처.xlsx";
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0003")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_농산물품질관리원.xlsx";
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0004")
            {
                txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_전체.xlsx";                
            }
        }

        private void frmRoleOrgChart_Load(object sender, EventArgs e)
        {
            dgvData.AllowUserToAddRows = false; 
        }

        private void btnGroup1_Click(object sender, EventArgs e)
        {
            get_folder_data2("PQMS_GROUP1", "GROUP1_CODE", "GROUP1_NAME", "GROUP1_ORG_CODE", txtSTAFF_ROLE_ORG_CODE.Text, cmbGroup1);
        }


        private void get_folder_data2(string tTable, string tField1, string tField2, string tField3, string tField4, System.Windows.Forms.ComboBox tCmb)
        //tField1 = 검색테이블
        //tField2 = 검색필드1
        //tField3 = 검색필드2
        {
            Conn = new OleDbConnection(unitCommon.connect_string);

            string query = "";

            query = " select distinct " + tField1 + "," + tField2 + " from " + tTable;
            query = query + "  where " + tField3 + " = '" + tField4 + "'";
            query = query + "      order by " + tField1 + "," + tField2;

            OleDbCommand cmd = new OleDbCommand(query, Conn);

            Conn.Open();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    tCmb.Items.Clear();

                    while (reader.Read())
                    {
                        tCmb.Items.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString());
                    }
                }
            }
            Conn.Close();
        }

        private void cmbGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGroup1Code.Text = cmbGroup1.Text.Substring(0, 4);
            txtBig.Text = cmbGroup1.Text.Substring(5, cmbGroup1.Text.Length - 5);

            if (cmbFolder.Text.Substring(0, 4) == "0002")
            {
                if (txtGroup1Code.Text != "" )
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_식약처_중분류.xlsx";
                }
            }
            else if (cmbFolder.Text.Substring(0, 4) == "0003")
            {
                if (txtGroup1Code.Text != "0001")
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_농산물품질관리원_안정성검사.xlsx";
                }
                if (txtGroup1Code.Text != "0002")
                {
                    txtTemplate.Text = @"\\" + unitCommon.sFileServerName + @"\DI\PQMS\Template\OrgChart\조직도_HN_농산물품질관리원_검정기관.xlsx";
                }
            }

        }

        private void btn_Chart_ApproveRequest_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "조직도";

            Form2_GridIdx.sIDX = txtIDX.Text;

            //Form2PQMS_LoginInfo.sloginId

            //Form2PQMS_StaffInfo.sStaffCode = "0002";

            //선택된 임명장의 사번의 팀 정보 가져오기 


            Form2PQMS_Staff_MenuInfo.sSTAFF_TEAM = "0001-0003-00001";// 의왕지점

            //if (string.IsNullOrEmpty(Form2PQMS_StaffInfo.sStaffCode) == true)
            //{
            //    MessageBox.Show("사원을 선택해주세요.");
            //    return;
            //}

            if (string.IsNullOrEmpty(Form2_GridIdx.sIDX) == true)
            {
                MessageBox.Show("표를 선택해주세요.");
                return;
            }

            string sFormName = "frmApproveRequest";
            frmApproveRequestVer2 childFrm = new frmApproveRequestVer2(null);

            if (unitCommon.YNFrom(sFormName))
            {
                childFrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childFrm.WindowState = FormWindowState.Normal;
                childFrm.ShowDialog();
            }
        }

        private void btn_Chart_ApproveReqSelect_Click(object sender, EventArgs e)
        {
            //Form2PQMS_StaffInfo.sStaffCode = txtStaffCode.Text;
            Form2_Tab_Info_Now.sMenuName = "부서관리";
            Form2_Tab_Info_Now.sTabName = "조직도";

            string sFormName = "frmApproveRequestCheck";
            frmApproveRequestCheckVer2 childFrm = new frmApproveRequestCheckVer2();

            if (unitCommon.YNFrom(sFormName))
            {
                childFrm.Dispose();     // 창 리소스 제거
            }
            else
            {
                childFrm.WindowState = FormWindowState.Normal;
                childFrm.ShowDialog();
            }
        }

        private void btn_Chart_Search_Click(object sender, EventArgs e)
        {
            string query = "";
            Conn = new OleDbConnection(unitCommon.connect_string);

            query = "select * ," +
                $" (CASE WHEN approveStatusCode IS NULL THEN '신청전' " +                                
                $" WHEN approveStatusCode = '0' THEN '승인대기' " +                                      
                $" WHEN approveStatusCode = '1' THEN '승인완료' " +                                      
                $" ELSE '반려' " +                                                                       
                $" END) AS 'approvedYN_Korea' " +                                                          
                "from PQMS_STAFF_ORG_CHART";
            OleDbCommand cmd = new OleDbCommand(query, Conn);
            Conn.Open();

            DataTable dt = new DataTable();

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows == true)
                {
                    dt.Load(reader);
                    gridChartList.DataSource = dt;                    
                }
            }
        }

        private void PQMS_PreSTAFFMainGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtIDX.Text = gridChartListView.GetFocusedDataRow()["IDX"].ToString();
            txtSTAFF_ROLE_ORG_CODE.Text = gridChartListView.GetFocusedDataRow()["ORG_CODE"].ToString();
            txtOrgName.Text = gridChartListView.GetFocusedDataRow()["ORG_NAME"].ToString();
            txtGroup1Code.Text = gridChartListView.GetFocusedDataRow()["GROUP1_CODE"].ToString();
            txtBig.Text = gridChartListView.GetFocusedDataRow()["GROUP1_NAME"].ToString();
            txtOrgChart.Text = gridChartListView.GetFocusedDataRow()["RESULT_CHART_FILE"].ToString();
        }

    }
}
