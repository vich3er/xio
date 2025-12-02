using lab13;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using DataTablePrettyPrinter;
 

namespace lab13
{
    public partial class Form1 : Form
    {
        private TSklad MySklad;
        public static string GlStringParameter;  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySklad = new TSklad();

            DGSklad.DataSource = MySklad.SkladView;
            MySklad.ColumnPropSet(DGSklad);

            MySklad.CreateDovGrupa();
            MySklad.AddComboGrupa(DGSklad);

            CBGrupa.Items.Clear();
            foreach (DataRow r in MySklad.DovGrupa.Rows)
            {
                CBGrupa.Items.Add(r["Група"]);
            }
        }

        private void BAddRowToTable_Click(object sender, EventArgs e)
        {
            try
            {
                int pKilkist = Convert.ToInt32(TBKilkist.Text);
                decimal pCina = Convert.ToDecimal(TBCina.Text);

                MySklad.TSkladAddRow(CBGrupa.Text, TBNazva.Text, TBVyrobnyk.Text, pKilkist, pCina);

                MySklad.SetSumy(DGSkladSum);
            }
            catch
            {
                MessageBox.Show("Помилка вводу даних! Перевірте числові поля.");
            }
        }


        private void записатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ZapTabFile();
            MessageBox.Show("Таблиця записана");
        }

        private void зчитатиТаблицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySklad.ReadTabFile(DGSkladSum);
        }

        private void встановитиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FServ FiltrDialog = new FServ();
            FiltrDialog.Text = "Введіть критерій (напр: Група = 'Книги')";
            GlStringParameter = MySklad.FiltrCriteria;
            FiltrDialog.ShowDialog();

            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void знятиФільтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = "";
            MySklad.TSkladValFiltr(GlStringParameter, DGSklad);
        }

        private void встановитиСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FServ SortDialog = new FServ();
            SortDialog.Text = "Введіть критерій сортування (напр: Ціна DESC)";
            GlStringParameter = MySklad.SortCriteria;
            SortDialog.ShowDialog();

            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void сортуватиПоГрупіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlStringParameter = "Група, Назва";
            MySklad.TSkladValSort(GlStringParameter, DGSklad, DGSkladSum);
        }

        private void пошукПоНазвіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FServ SeekDialog = new FServ();
            SeekDialog.Text = "Введіть назву для пошуку:";
            GlStringParameter = "";
            SeekDialog.ShowDialog();

            MySklad.SeekNazva(GlStringParameter, DGSklad);
        }


        private void DGSklad_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = DGSklad.Columns[e.ColumnIndex].Name;

            if (colName == "Кількість" || colName == "Ціна")
            {
                try
                {
                    decimal cin = Convert.ToDecimal(DGSklad.Rows[e.RowIndex].Cells["Ціна"].Value);
                    int kilk = Convert.ToInt32(DGSklad.Rows[e.RowIndex].Cells["Кількість"].Value);

                    DGSklad.Rows[e.RowIndex].Cells["Вартість"].Value = kilk * cin;
                }
                catch { }

                MySklad.SetSumy(DGSkladSum);
            }
        }

        private void DGSklad_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DGSklad.Rows[e.RowIndex].IsNewRow) return;

            string colName = DGSklad.Columns[e.ColumnIndex].Name;

            if (colName == "Ціна")
            {
                decimal res;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out res))
                {
                    MessageBox.Show("Введіть числове значення ціни!");
                    e.Cancel = true;
                }
            }
            else if (colName == "Кількість")
            {
                int res;
                if (!int.TryParse(e.FormattedValue.ToString(), out res))
                {
                    MessageBox.Show("Введіть ціле число для кількості!");
                    e.Cancel = true;
                }
            }
        }

        private void DGSklad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void друкToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void роздрукуватиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();

            doc.PrintPage += (s, ev) =>
            {
                MySklad.TabSklad.TableName = "Товари на складі";
                string textToPrint = MySklad.TabSklad.ToPrettyPrintedString();

                string fullReport = "ЗВІТ ПО СКЛАДУ\n";
                fullReport += "Дата: " + DateTime.Now.ToString() + "\n\n";
                fullReport += textToPrint;

                Font printFont = new Font("Consolas", 9);

                ev.Graphics.DrawString(fullReport, printFont, Brushes.Black, 10, 10);
            };

            PrintDialog dialog = new PrintDialog();
            dialog.Document = doc;

            dialog.UseEXDialog = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

        }
    }
}