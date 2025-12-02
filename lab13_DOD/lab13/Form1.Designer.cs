namespace lab13
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записатиТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зчитатиТаблицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фільтруватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem встановитиФільтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem знятиФільтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem встановитиСортуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуватиПоГрупіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукПоНазвіToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BAddRowToTable;
        private System.Windows.Forms.TextBox TBKilkist;
        private System.Windows.Forms.TextBox TBCina;
        private System.Windows.Forms.TextBox TBVyrobnyk;
        private System.Windows.Forms.TextBox TBNazva;
        private System.Windows.Forms.ComboBox CBGrupa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView DGSklad;
        private System.Windows.Forms.DataGridView DGSkladSum;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            записатиТаблицюToolStripMenuItem = new ToolStripMenuItem();
            зчитатиТаблицюToolStripMenuItem = new ToolStripMenuItem();
            фільтруватиToolStripMenuItem = new ToolStripMenuItem();
            встановитиФільтрToolStripMenuItem = new ToolStripMenuItem();
            знятиФільтрToolStripMenuItem = new ToolStripMenuItem();
            сортуватиToolStripMenuItem = new ToolStripMenuItem();
            встановитиСортуванняToolStripMenuItem = new ToolStripMenuItem();
            сортуватиПоГрупіToolStripMenuItem = new ToolStripMenuItem();
            пошукToolStripMenuItem = new ToolStripMenuItem();
            пошукПоНазвіToolStripMenuItem = new ToolStripMenuItem();
            друкToolStripMenuItem = new ToolStripMenuItem();
            роздрукуватиФайлToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            DGSklad = new DataGridView();
            panel1 = new Panel();
            BAddRowToTable = new Button();
            TBKilkist = new TextBox();
            label5 = new Label();
            TBCina = new TextBox();
            label4 = new Label();
            TBVyrobnyk = new TextBox();
            label3 = new Label();
            TBNazva = new TextBox();
            label2 = new Label();
            CBGrupa = new ComboBox();
            label1 = new Label();
            labelHeader = new Label();
            DGSkladSum = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGSklad).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGSkladSum).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фільтруватиToolStripMenuItem, сортуватиToolStripMenuItem, пошукToolStripMenuItem, друкToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1594, 28);
            menuStrip1.Stretch = false;
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { записатиТаблицюToolStripMenuItem, зчитатиТаблицюToolStripMenuItem });
            файлToolStripMenuItem.Image = (Image)resources.GetObject("файлToolStripMenuItem.Image");
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(34, 24);
            // 
            // записатиТаблицюToolStripMenuItem
            // 
            записатиТаблицюToolStripMenuItem.Name = "записатиТаблицюToolStripMenuItem";
            записатиТаблицюToolStripMenuItem.Size = new Size(221, 26);
            записатиТаблицюToolStripMenuItem.Text = "Записати таблицю";
            записатиТаблицюToolStripMenuItem.Click += записатиТаблицюToolStripMenuItem_Click;
            // 
            // зчитатиТаблицюToolStripMenuItem
            // 
            зчитатиТаблицюToolStripMenuItem.Name = "зчитатиТаблицюToolStripMenuItem";
            зчитатиТаблицюToolStripMenuItem.Size = new Size(221, 26);
            зчитатиТаблицюToolStripMenuItem.Text = "Зчитати таблицю";
            зчитатиТаблицюToolStripMenuItem.Click += зчитатиТаблицюToolStripMenuItem_Click;
            // 
            // фільтруватиToolStripMenuItem
            // 
            фільтруватиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { встановитиФільтрToolStripMenuItem, знятиФільтрToolStripMenuItem });
            фільтруватиToolStripMenuItem.Image = (Image)resources.GetObject("фільтруватиToolStripMenuItem.Image");
            фільтруватиToolStripMenuItem.Name = "фільтруватиToolStripMenuItem";
            фільтруватиToolStripMenuItem.Size = new Size(47, 24);
            фільтруватиToolStripMenuItem.Text = " ";
            // 
            // встановитиФільтрToolStripMenuItem
            // 
            встановитиФільтрToolStripMenuItem.Name = "встановитиФільтрToolStripMenuItem";
            встановитиФільтрToolStripMenuItem.Size = new Size(221, 26);
            встановитиФільтрToolStripMenuItem.Text = "Встановити фільтр";
            встановитиФільтрToolStripMenuItem.Click += встановитиФільтрToolStripMenuItem_Click;
            // 
            // знятиФільтрToolStripMenuItem
            // 
            знятиФільтрToolStripMenuItem.Name = "знятиФільтрToolStripMenuItem";
            знятиФільтрToolStripMenuItem.Size = new Size(221, 26);
            знятиФільтрToolStripMenuItem.Text = "Зняти фільтр";
            знятиФільтрToolStripMenuItem.Click += знятиФільтрToolStripMenuItem_Click;
            // 
            // сортуватиToolStripMenuItem
            // 
            сортуватиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { встановитиСортуванняToolStripMenuItem, сортуватиПоГрупіToolStripMenuItem });
            сортуватиToolStripMenuItem.Image = (Image)resources.GetObject("сортуватиToolStripMenuItem.Image");
            сортуватиToolStripMenuItem.Name = "сортуватиToolStripMenuItem";
            сортуватиToolStripMenuItem.Size = new Size(34, 24);
            // 
            // встановитиСортуванняToolStripMenuItem
            // 
            встановитиСортуванняToolStripMenuItem.Name = "встановитиСортуванняToolStripMenuItem";
            встановитиСортуванняToolStripMenuItem.Size = new Size(237, 26);
            встановитиСортуванняToolStripMenuItem.Text = "Встановити критерій";
            встановитиСортуванняToolStripMenuItem.Click += встановитиСортуванняToolStripMenuItem_Click;
            // 
            // сортуватиПоГрупіToolStripMenuItem
            // 
            сортуватиПоГрупіToolStripMenuItem.Name = "сортуватиПоГрупіToolStripMenuItem";
            сортуватиПоГрупіToolStripMenuItem.Size = new Size(237, 26);
            сортуватиПоГрупіToolStripMenuItem.Text = "Сортувати по групі";
            сортуватиПоГрупіToolStripMenuItem.Click += сортуватиПоГрупіToolStripMenuItem_Click;
            // 
            // пошукToolStripMenuItem
            // 
            пошукToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { пошукПоНазвіToolStripMenuItem });
            пошукToolStripMenuItem.Image = (Image)resources.GetObject("пошукToolStripMenuItem.Image");
            пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            пошукToolStripMenuItem.Size = new Size(34, 24);
            // 
            // пошукПоНазвіToolStripMenuItem
            // 
            пошукПоНазвіToolStripMenuItem.Name = "пошукПоНазвіToolStripMenuItem";
            пошукПоНазвіToolStripMenuItem.Size = new Size(200, 26);
            пошукПоНазвіToolStripMenuItem.Text = "Пошук по назві";
            пошукПоНазвіToolStripMenuItem.Click += пошукПоНазвіToolStripMenuItem_Click;
            // 
            // друкToolStripMenuItem
            // 
            друкToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { роздрукуватиФайлToolStripMenuItem });
            друкToolStripMenuItem.Image = (Image)resources.GetObject("друкToolStripMenuItem.Image");
            друкToolStripMenuItem.Name = "друкToolStripMenuItem";
            друкToolStripMenuItem.Size = new Size(34, 24);
            друкToolStripMenuItem.Click += друкToolStripMenuItem_Click;
            // 
            // роздрукуватиФайлToolStripMenuItem
            // 
            роздрукуватиФайлToolStripMenuItem.Name = "роздрукуватиФайлToolStripMenuItem";
            роздрукуватиФайлToolStripMenuItem.Size = new Size(224, 26);
            роздрукуватиФайлToolStripMenuItem.Text = "Роздрукувати файл";
            роздрукуватиФайлToolStripMenuItem.Click += роздрукуватиФайлToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 28);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(DGSklad);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DGSkladSum);
            splitContainer1.Size = new Size(1594, 625);
            splitContainer1.SplitterDistance = 437;
            splitContainer1.TabIndex = 1;
            // 
            // DGSklad
            // 
            DGSklad.ColumnHeadersHeight = 29;
            DGSklad.Dock = DockStyle.Fill;
            DGSklad.Location = new Point(0, 123);
            DGSklad.Name = "DGSklad";
            DGSklad.RowHeadersWidth = 51;
            DGSklad.Size = new Size(1594, 314);
            DGSklad.TabIndex = 0;
            DGSklad.CellContentClick += DGSklad_CellContentClick;
            DGSklad.CellValidating += DGSklad_CellValidating;
            DGSklad.CellValueChanged += DGSklad_CellValueChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(BAddRowToTable);
            panel1.Controls.Add(TBKilkist);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TBCina);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TBVyrobnyk);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TBNazva);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(CBGrupa);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1594, 123);
            panel1.TabIndex = 0;
            // 
            // BAddRowToTable
            // 
            BAddRowToTable.Location = new Point(1070, 39);
            BAddRowToTable.Name = "BAddRowToTable";
            BAddRowToTable.Size = new Size(100, 40);
            BAddRowToTable.TabIndex = 0;
            BAddRowToTable.Text = "Додати рядок до таблиці Склад";
            BAddRowToTable.Click += BAddRowToTable_Click;
            // 
            // TBKilkist
            // 
            TBKilkist.Location = new Point(946, 50);
            TBKilkist.Name = "TBKilkist";
            TBKilkist.Size = new Size(60, 27);
            TBKilkist.TabIndex = 1;
            // 
            // label5
            // 
            label5.Location = new Point(946, 30);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 2;
            label5.Text = "Кількість";
            // 
            // TBCina
            // 
            TBCina.Location = new Point(876, 50);
            TBCina.Name = "TBCina";
            TBCina.Size = new Size(60, 27);
            TBCina.TabIndex = 3;
            // 
            // label4
            // 
            label4.Location = new Point(876, 30);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 4;
            label4.Text = "Ціна";
            // 
            // TBVyrobnyk
            // 
            TBVyrobnyk.Location = new Point(629, 50);
            TBVyrobnyk.Name = "TBVyrobnyk";
            TBVyrobnyk.Size = new Size(100, 27);
            TBVyrobnyk.TabIndex = 5;
            // 
            // label3
            // 
            label3.Location = new Point(629, 30);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 6;
            label3.Text = "Виробник";
            // 
            // TBNazva
            // 
            TBNazva.Location = new Point(519, 50);
            TBNazva.Name = "TBNazva";
            TBNazva.Size = new Size(100, 27);
            TBNazva.TabIndex = 7;
            // 
            // label2
            // 
            label2.Location = new Point(519, 30);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 8;
            label2.Text = "Назва";
            // 
            // CBGrupa
            // 
            CBGrupa.Location = new Point(26, 46);
            CBGrupa.Name = "CBGrupa";
            CBGrupa.Size = new Size(471, 28);
            CBGrupa.TabIndex = 9;
            // 
            // label1
            // 
            label1.Location = new Point(26, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 10;
            label1.Text = "Група";
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Location = new Point(699, 5);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(247, 20);
            labelHeader.TabIndex = 11;
            labelHeader.Text = "Введіть нові дані у таблицю Склад";
            // 
            // DGSkladSum
            // 
            DGSkladSum.ColumnHeadersHeight = 29;
            DGSkladSum.Dock = DockStyle.Fill;
            DGSkladSum.Location = new Point(0, 0);
            DGSkladSum.Name = "DGSkladSum";
            DGSkladSum.RowHeadersWidth = 51;
            DGSkladSum.Size = new Size(1594, 184);
            DGSkladSum.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(1594, 653);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Дослідження класів DataTable, DataGridView";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGSklad).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGSkladSum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripMenuItem друкToolStripMenuItem;
        private ToolStripMenuItem роздрукуватиФайлToolStripMenuItem;
    }
}