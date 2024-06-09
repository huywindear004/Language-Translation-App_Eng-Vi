namespace Translator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.Panel panel1;
            this.afterTB = new System.Windows.Forms.TextBox();
            this.beforeTB = new System.Windows.Forms.TextBox();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.btnDichSelection = new System.Windows.Forms.Button();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.btnDichAll = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.cbWrap2 = new System.Windows.Forms.CheckBox();
            this.cbWrap = new System.Windows.Forms.CheckBox();
            this.btnChuanHoa = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            tableLayoutPanel1.Controls.Add(this.afterTB, 2, 0);
            tableLayoutPanel1.Controls.Add(this.beforeTB, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1167, 696);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // afterTB
            // 
            this.afterTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.afterTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.afterTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.afterTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterTB.ForeColor = System.Drawing.Color.White;
            this.afterTB.HideSelection = false;
            this.afterTB.Location = new System.Drawing.Point(750, 16);
            this.afterTB.Margin = new System.Windows.Forms.Padding(15);
            this.afterTB.Multiline = true;
            this.afterTB.Name = "afterTB";
            this.afterTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.afterTB.Size = new System.Drawing.Size(401, 664);
            this.afterTB.TabIndex = 1;
            this.afterTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_KeyDown);
            // 
            // beforeTB
            // 
            this.beforeTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.beforeTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.beforeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beforeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeTB.ForeColor = System.Drawing.Color.White;
            this.beforeTB.HideSelection = false;
            this.beforeTB.Location = new System.Drawing.Point(16, 16);
            this.beforeTB.Margin = new System.Windows.Forms.Padding(15);
            this.beforeTB.Multiline = true;
            this.beforeTB.Name = "beforeTB";
            this.beforeTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.beforeTB.Size = new System.Drawing.Size(400, 664);
            this.beforeTB.TabIndex = 3;
            this.beforeTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_KeyDown);
            this.beforeTB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.beforeTB_MouseDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(this.tbWord, 0, 0);
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(442, 11);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new System.Drawing.Size(282, 674);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // tbWord
            // 
            this.tbWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tbWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWord.ForeColor = System.Drawing.Color.White;
            this.tbWord.Location = new System.Drawing.Point(3, 3);
            this.tbWord.Multiline = true;
            this.tbWord.Name = "tbWord";
            this.tbWord.ReadOnly = true;
            this.tbWord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWord.Size = new System.Drawing.Size(276, 398);
            this.tbWord.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(this.btnDichSelection);
            panel1.Controls.Add(this.cbTo);
            panel1.Controls.Add(this.cbFrom);
            panel1.Controls.Add(this.btnDichAll);
            panel1.Controls.Add(this.btnSwap);
            panel1.Controls.Add(this.cbWrap2);
            panel1.Controls.Add(this.cbWrap);
            panel1.Controls.Add(this.btnChuanHoa);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 407);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(276, 264);
            panel1.TabIndex = 14;
            // 
            // btnDichSelection
            // 
            this.btnDichSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDichSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDichSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDichSelection.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDichSelection.Location = new System.Drawing.Point(0, 126);
            this.btnDichSelection.Name = "btnDichSelection";
            this.btnDichSelection.Size = new System.Drawing.Size(273, 36);
            this.btnDichSelection.TabIndex = 27;
            this.btnDichSelection.Text = "Dịch (đoạn: F3 | từ: F4) bôi đen";
            this.btnDichSelection.UseVisualStyleBackColor = false;
            this.btnDichSelection.Click += new System.EventHandler(this.btnDichSelection_Click);
            // 
            // cbTo
            // 
            this.cbTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTo.ForeColor = System.Drawing.Color.White;
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Items.AddRange(new object[] {
            "vi",
            "en"});
            this.cbTo.Location = new System.Drawing.Point(145, 45);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(128, 33);
            this.cbTo.TabIndex = 26;
            // 
            // cbFrom
            // 
            this.cbFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFrom.ForeColor = System.Drawing.Color.White;
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Items.AddRange(new object[] {
            "en",
            "vi"});
            this.cbFrom.Location = new System.Drawing.Point(0, 45);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(125, 33);
            this.cbFrom.TabIndex = 25;
            // 
            // btnDichAll
            // 
            this.btnDichAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDichAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDichAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDichAll.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDichAll.Location = new System.Drawing.Point(0, 84);
            this.btnDichAll.Name = "btnDichAll";
            this.btnDichAll.Size = new System.Drawing.Size(273, 36);
            this.btnDichAll.TabIndex = 24;
            this.btnDichAll.Text = "Dịch tất cả (F2)";
            this.btnDichAll.UseVisualStyleBackColor = false;
            this.btnDichAll.Click += new System.EventHandler(this.btnDichAll_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSwap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSwap.Location = new System.Drawing.Point(0, 168);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(273, 33);
            this.btnSwap.TabIndex = 23;
            this.btnSwap.Text = "<=> (F5)";
            this.btnSwap.UseVisualStyleBackColor = false;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // cbWrap2
            // 
            this.cbWrap2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWrap2.AutoSize = true;
            this.cbWrap2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbWrap2.Checked = true;
            this.cbWrap2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWrap2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWrap2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbWrap2.Location = new System.Drawing.Point(191, 207);
            this.cbWrap2.Name = "cbWrap2";
            this.cbWrap2.Size = new System.Drawing.Size(82, 29);
            this.cbWrap2.TabIndex = 22;
            this.cbWrap2.Text = "Wrap";
            this.cbWrap2.UseVisualStyleBackColor = true;
            this.cbWrap2.CheckedChanged += new System.EventHandler(this.cbWrap2_CheckedChanged);
            // 
            // cbWrap
            // 
            this.cbWrap.AutoSize = true;
            this.cbWrap.Checked = true;
            this.cbWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWrap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbWrap.Location = new System.Drawing.Point(0, 207);
            this.cbWrap.Name = "cbWrap";
            this.cbWrap.Size = new System.Drawing.Size(82, 29);
            this.cbWrap.TabIndex = 21;
            this.cbWrap.Text = "Wrap";
            this.cbWrap.UseVisualStyleBackColor = true;
            this.cbWrap.CheckedChanged += new System.EventHandler(this.cbWrap_CheckedChanged);
            // 
            // btnChuanHoa
            // 
            this.btnChuanHoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChuanHoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnChuanHoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuanHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuanHoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChuanHoa.Location = new System.Drawing.Point(0, 3);
            this.btnChuanHoa.Name = "btnChuanHoa";
            this.btnChuanHoa.Size = new System.Drawing.Size(273, 36);
            this.btnChuanHoa.TabIndex = 20;
            this.btnChuanHoa.Text = "Chuẩn hóa (F1)";
            this.btnChuanHoa.UseVisualStyleBackColor = false;
            this.btnChuanHoa.Click += new System.EventHandler(this.btnChuanHoa_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1167, 696);
            this.Controls.Add(tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Translator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox afterTB;
        private System.Windows.Forms.TextBox beforeTB;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Button btnDichSelection;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Button btnDichAll;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.CheckBox cbWrap2;
        private System.Windows.Forms.CheckBox cbWrap;
        private System.Windows.Forms.Button btnChuanHoa;
    }
}

