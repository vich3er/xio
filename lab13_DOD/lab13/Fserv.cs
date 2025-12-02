using lab13;
using System;
using System.Windows.Forms;

namespace lab13
{
    public partial class FServ : Form
    {
        public FServ()
        {
            InitializeComponent();
        }

        private void FServ_Load(object sender, EventArgs e)
        {
            FServTB.Text = Form1.GlStringParameter;
        }

        private void FServBOk_Click(object sender, EventArgs e)
        {
            Form1.GlStringParameter = FServTB.Text;
            this.Close();
        }
    }
}