
namespace rmsid2
{
    partial class excelexportcs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxfiletext = new System.Windows.Forms.TextBox();
            this.buttonbrowse = new System.Windows.Forms.Button();
            this.comboBoxsheet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttoninsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(688, 300);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name";
            // 
            // textBoxfiletext
            // 
            this.textBoxfiletext.Location = new System.Drawing.Point(130, 324);
            this.textBoxfiletext.Name = "textBoxfiletext";
            this.textBoxfiletext.Size = new System.Drawing.Size(490, 20);
            this.textBoxfiletext.TabIndex = 2;
            // 
            // buttonbrowse
            // 
            this.buttonbrowse.Location = new System.Drawing.Point(640, 322);
            this.buttonbrowse.Name = "buttonbrowse";
            this.buttonbrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonbrowse.TabIndex = 3;
            this.buttonbrowse.Text = "....";
            this.buttonbrowse.UseVisualStyleBackColor = true;
            this.buttonbrowse.Click += new System.EventHandler(this.buttonbrowse_Click);
            // 
            // comboBoxsheet
            // 
            this.comboBoxsheet.FormattingEnabled = true;
            this.comboBoxsheet.Location = new System.Drawing.Point(130, 364);
            this.comboBoxsheet.Name = "comboBoxsheet";
            this.comboBoxsheet.Size = new System.Drawing.Size(121, 21);
            this.comboBoxsheet.TabIndex = 4;
            this.comboBoxsheet.SelectedIndexChanged += new System.EventHandler(this.comboBoxsheet_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sheet:";
            // 
            // buttoninsert
            // 
            this.buttoninsert.Location = new System.Drawing.Point(276, 363);
            this.buttoninsert.Name = "buttoninsert";
            this.buttoninsert.Size = new System.Drawing.Size(75, 23);
            this.buttoninsert.TabIndex = 5;
            this.buttoninsert.Text = "buttoninsert";
            this.buttoninsert.UseVisualStyleBackColor = true;
            this.buttoninsert.Click += new System.EventHandler(this.buttoninsert_Click);
            // 
            // excelexportcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttoninsert);
            this.Controls.Add(this.comboBoxsheet);
            this.Controls.Add(this.buttonbrowse);
            this.Controls.Add(this.textBoxfiletext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "excelexportcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "excelexportcs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxfiletext;
        private System.Windows.Forms.Button buttonbrowse;
        private System.Windows.Forms.ComboBox comboBoxsheet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttoninsert;
    }
}