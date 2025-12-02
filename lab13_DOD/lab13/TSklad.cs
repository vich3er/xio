using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace lab13
{
    class TSklad
    {
        public DataTable TabSklad = new DataTable();
        public DataView SkladView;
        public DataTable DovGrupa = new DataTable();  

        public string FiltrCriteria = "";
        public string SortCriteria = "";

        public DataGridViewComboBoxColumn CGrupaCB;

        public TSklad()
        {
            DataColumn cNpp = new DataColumn("N_pp");
            DataColumn cNameGroup = new DataColumn("Група");
            DataColumn cNameProduct = new DataColumn("Назва");
            DataColumn cProduser = new DataColumn("Виробник");
            DataColumn cCount = new DataColumn("Кількість");
            DataColumn cPrise = new DataColumn("Ціна");
            DataColumn cVartist = new DataColumn("Вартість");

            cNpp.DataType = System.Type.GetType("System.Int32");
            cNameGroup.DataType = System.Type.GetType("System.String");
            cNameProduct.DataType = System.Type.GetType("System.String");
            cProduser.DataType = System.Type.GetType("System.String");
            cCount.DataType = System.Type.GetType("System.Int32");
            cPrise.DataType = System.Type.GetType("System.Decimal");
            cVartist.DataType = System.Type.GetType("System.Decimal");

            TabSklad.Columns.Add(cNpp);
            TabSklad.Columns.Add(cNameGroup);
            TabSklad.Columns.Add(cNameProduct);
            TabSklad.Columns.Add(cProduser);
            TabSklad.Columns.Add(cCount);
            TabSklad.Columns.Add(cPrise);
            TabSklad.Columns.Add(cVartist);

            SkladView = new DataView(TabSklad);
        }

        public void TSkladAddRow(string pNameGroup, string pNameProduct, string pProduser, int pCount, decimal pPrise)
        {
            DataRow row = TabSklad.NewRow();
            row["N_pp"] = TabSklad.Rows.Count + 1;  
            row["Група"] = pNameGroup;
            row["Назва"] = pNameProduct;
            row["Виробник"] = pProduser;
            row["Кількість"] = pCount;
            row["Ціна"] = pPrise;
            row["Вартість"] = pCount * pPrise;
            TabSklad.Rows.Add(row);
        }

        public void ColumnPropSet(DataGridView DGV)
        {
            DGV.Columns["N_pp"].HeaderText = "№ п/п";
            DGV.Columns["Група"].HeaderText = "Група";
            DGV.Columns["Назва"].HeaderText = "Назва";
            DGV.Columns["Виробник"].HeaderText = "Виробник";
            DGV.Columns["Кількість"].HeaderText = "Кількість";
            DGV.Columns["Ціна"].HeaderText = "Ціна";
            DGV.Columns["Вартість"].HeaderText = "Вартість";
        }

        public void ZapTabFile()
        {
            string sdir = Directory.GetCurrentDirectory();
            string sNameFile = sdir + @"\FTabSklad.txt";

            try
            {
                if (File.Exists(sNameFile)) File.Delete(sNameFile);

                using (StreamWriter sw = new StreamWriter(sNameFile))
                {
                    foreach (DataRow rr in TabSklad.Rows)
                    {
                        string textRow = rr["Група"] + ";" + rr["Назва"] + ";" + rr["Виробник"] + ";" +
                                         rr["Кількість"] + ";" + rr["Ціна"];
                        sw.WriteLine(textRow);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Помилка запису файлу!");
            }
        }

        public void ReadTabFile(DataGridView DGS)
        {
            TabSklad.Rows.Clear();
            string sdir = Directory.GetCurrentDirectory();
            string sNameFile = sdir + @"\FTabSklad.txt";

            if (!File.Exists(sNameFile)) return;

            using (StreamReader sr = new StreamReader(sNameFile))
            {
                while (sr.Peek() >= 0)
                {
                    string textRow = sr.ReadLine();
                    string[] parts = textRow.Split(';');  

                    if (parts.Length >= 5)
                    {
                        string pGrupa = parts[0];
                        string pNazva = parts[1];
                        string pVyrobnyk = parts[2];
                        int pKilkist = int.Parse(parts[3]);
                        decimal pCina = decimal.Parse(parts[4]);

                        TSkladAddRow(pGrupa, pNazva, pVyrobnyk, pKilkist, pCina);
                    }
                }
            }
            SetSumy(DGS);  
        }

        public void TSkladValFiltr(string PFilter, DataGridView DGV)
        {
            try
            {
                SkladView.RowFilter = PFilter;
                FiltrCriteria = PFilter;
                DGV.DataSource = SkladView;
            }
            catch
            {
                MessageBox.Show("Невірний критерій фільтрування!");
            }
        }

        public void TSkladValSort(string PSort, DataGridView DGV, DataGridView DGVSum)
        {
            try
            {
                SkladView.Sort = PSort;
                SortCriteria = PSort;
                DGV.DataSource = SkladView;
                DGV.Refresh();
            }
            catch
            {
                MessageBox.Show("Невірний критерій сортування!");
            }
        }

        public void SeekNazva(string sNazva, DataGridView DGV)
        {
            int nn = -1;
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (DGV.Rows[i].Cells["Назва"].Value != null &&
                    DGV.Rows[i].Cells["Назва"].Value.ToString() == sNazva)
                {
                    nn = i;
                    break;
                }
            }

            if (nn >= 0)
            {
                DGV.FirstDisplayedScrollingRowIndex = nn;
                DGV.Rows[nn].Selected = true;
                if (DGV.Columns["Назва"].Visible)
                    DGV.CurrentCell = DGV.Rows[nn].Cells["Назва"];
            }
            else
            {
                MessageBox.Show("Значення не знайдено");
            }
        }

        public void SetSumy(DataGridView DGV)
        {
            DataTable TabSkladSum = new DataTable();
            TabSkladSum.Columns.Add(new DataColumn("Група", typeof(string)));
            TabSkladSum.Columns.Add(new DataColumn("Вартість", typeof(decimal)));

            string savedSort = SkladView.Sort;
            SkladView.Sort = "Група";  

            int i = 0;
            while (i < SkladView.Count)
            {
                string sGrupa = Convert.ToString(SkladView[i]["Група"]);

                if (string.IsNullOrEmpty(sGrupa))
                {
                    MessageBox.Show($"Помилка даних: У рядку №{i + 1} відсутня назва групи!\nЗаповніть групу перед розрахунком підсумків.",
                                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    SkladView.Sort = savedSort;
                    return; 
                }

                decimal DSuma = 0.0M;

                while (i < SkladView.Count && Convert.ToString(SkladView[i]["Група"]) == sGrupa)
                {
                    try
                    {
                        DSuma += Convert.ToDecimal(SkladView[i]["Вартість"]);
                    }
                    catch { }
                    i++;
                }

                DataRow row = TabSkladSum.NewRow();
                row["Група"] = sGrupa;
                row["Вартість"] = DSuma;
                TabSkladSum.Rows.Add(row);
            }

            DGV.DataSource = TabSkladSum;
            SkladView.Sort = savedSort;
        }

        public void CreateDovGrupa()
        {
            DovGrupa.Columns.Add(new DataColumn("Група", typeof(string)));

            string[] groups = { "Книги", "CD", "DVD", "Мобілки", "Плеєри", "Аксесуари", "Дисплеї", "Корпуси", "Блоки живлення", "Клавіатури" };

            foreach (var g in groups)
            {
                DataRow r = DovGrupa.NewRow();
                r["Група"] = g;
                DovGrupa.Rows.Add(r);
            }
        }

        public void AddComboGrupa(DataGridView DGV)
        {
            CGrupaCB = new DataGridViewComboBoxColumn();
            CGrupaCB.DataPropertyName = "Група";
            CGrupaCB.Name = "cNameGroupComb";  
            CGrupaCB.HeaderText = "Група";
            CGrupaCB.DropDownWidth = 120;
            CGrupaCB.Width = 100;
            CGrupaCB.FlatStyle = FlatStyle.Flat;

            foreach (DataRow r in DovGrupa.Rows)
            {
                CGrupaCB.Items.Add(r["Група"]);
            }

            DGV.Columns.Add(CGrupaCB);

            foreach (DataGridViewRow r in DGV.Rows)
            {
                if (r.Cells["Група"].Value != null)
                {
                    r.Cells["cNameGroupComb"].Value = r.Cells["Група"].Value;
                }
            }

            DGV.Columns.Remove("Група");
            DGV.Columns["cNameGroupComb"].Name = "Група";
            DGV.Columns["Група"].DisplayIndex = 1;
        }
    }
}