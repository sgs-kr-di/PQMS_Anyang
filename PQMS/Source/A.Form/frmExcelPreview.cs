using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;
using Spire.Doc.Documents;

namespace PQMS
{
    public partial class frmExcelPreview : Form
    {
        public frmExcelPreview(string path)
        {
            InitializeComponent();
            Preview(path);
        }

        public frmExcelPreview()
        {
            InitializeComponent();
        }

        public void Preview(string path)
        {
            officeViewer1.LoadFromFile(path);
        }
    }
}
