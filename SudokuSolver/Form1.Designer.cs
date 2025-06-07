namespace SudokuSolver
{
    partial class Form1
{
    private System.Windows.Forms.TableLayoutPanel tlpMain;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tlpMain = new TableLayoutPanel();
            Submit = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.BackColor = Color.LightSkyBlue;
            tlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpMain.Dock = DockStyle.Top;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Margin = new Padding(3, 2, 3, 2);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tlpMain.Size = new Size(420, 379);
            tlpMain.TabIndex = 0;
            // 
            // Submit
            // 
            Submit.BackColor = Color.CornflowerBlue;
            Submit.Font = new Font("Gadugi", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Submit.ForeColor = SystemColors.ButtonHighlight;
            Submit.Location = new Point(277, 384);
            Submit.Margin = new Padding(0);
            Submit.Name = "Submit";
            Submit.Size = new Size(131, 37);
            Submit.TabIndex = 1;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = false;
            Submit.Click += btnSolve_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(128, 64, 0);
            button1.Location = new Point(12, 384);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(86, 37);
            button1.TabIndex = 2;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(420, 428);
            Controls.Add(button1);
            Controls.Add(Submit);
            Controls.Add(tlpMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sudoku Solver";
            ResumeLayout(false);
        }


        private Button Submit;
        private Button button1;
    }





}
