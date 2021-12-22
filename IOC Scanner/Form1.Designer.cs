
namespace IOC_Scanner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.logFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.ColumnIOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbEnhanced = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(13, 13);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(864, 396);
            this.inputBox.TabIndex = 0;
            this.inputBox.Text = "";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(13, 415);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(279, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Load...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(299, 415);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(279, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = ">>";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(584, 416);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(279, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // logFileDialog
            // 
            this.logFileDialog.FileName = "openFileDialog1";
            this.logFileDialog.Multiselect = true;
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.AllowUserToDeleteRows = false;
            this.dataGridViewOutput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOutput.ColumnHeadersHeight = 34;
            this.dataGridViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIOC,
            this.ColumnPath});
            this.dataGridViewOutput.Location = new System.Drawing.Point(881, 13);
            this.dataGridViewOutput.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.ReadOnly = true;
            this.dataGridViewOutput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewOutput.RowHeadersVisible = false;
            this.dataGridViewOutput.RowHeadersWidth = 62;
            this.dataGridViewOutput.RowTemplate.Height = 33;
            this.dataGridViewOutput.ShowEditingIcon = false;
            this.dataGridViewOutput.Size = new System.Drawing.Size(877, 425);
            this.dataGridViewOutput.TabIndex = 9;
            // 
            // ColumnIOC
            // 
            this.ColumnIOC.HeaderText = "IOC";
            this.ColumnIOC.MinimumWidth = 8;
            this.ColumnIOC.Name = "ColumnIOC";
            this.ColumnIOC.ReadOnly = true;
            this.ColumnIOC.Width = 250;
            // 
            // ColumnPath
            // 
            this.ColumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ColumnPath.HeaderText = "Path";
            this.ColumnPath.MinimumWidth = 1000;
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Width = 1000;
            // 
            // cbEnhanced
            // 
            this.cbEnhanced.AutoSize = true;
            this.cbEnhanced.Enabled = false;
            this.cbEnhanced.Location = new System.Drawing.Point(550, 346);
            this.cbEnhanced.Margin = new System.Windows.Forms.Padding(2);
            this.cbEnhanced.Name = "cbEnhanced";
            this.cbEnhanced.Size = new System.Drawing.Size(81, 19);
            this.cbEnhanced.TabIndex = 10;
            this.cbEnhanced.Text = "Deep Scan";
            this.cbEnhanced.UseVisualStyleBackColor = true;
            this.cbEnhanced.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1768, 451);
            this.Controls.Add(this.cbEnhanced);
            this.Controls.Add(this.dataGridViewOutput);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.inputBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IOC Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.OpenFileDialog logFileDialog;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.CheckBox cbEnhanced;
    }
}

