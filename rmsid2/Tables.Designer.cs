
namespace rmsid2
{
    partial class Tables
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
            this.groupBoxadd = new System.Windows.Forms.GroupBox();
            this.comboBoxtables = new System.Windows.Forms.ComboBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TablesdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabletextBox = new System.Windows.Forms.TextBox();
            this.groupBoxadd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablesdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxadd
            // 
            this.groupBoxadd.Controls.Add(this.comboBoxtables);
            this.groupBoxadd.Controls.Add(this.buttonClose);
            this.groupBoxadd.Controls.Add(this.buttonDelete);
            this.groupBoxadd.Controls.Add(this.buttonAdd);
            this.groupBoxadd.Controls.Add(this.buttonUpdate);
            this.groupBoxadd.Controls.Add(this.textBoxname);
            this.groupBoxadd.Controls.Add(this.label3);
            this.groupBoxadd.Controls.Add(this.label1);
            this.groupBoxadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxadd.Location = new System.Drawing.Point(575, 39);
            this.groupBoxadd.Name = "groupBoxadd";
            this.groupBoxadd.Size = new System.Drawing.Size(435, 339);
            this.groupBoxadd.TabIndex = 12;
            this.groupBoxadd.TabStop = false;
            this.groupBoxadd.Text = "Add Table";
            // 
            // comboBoxtables
            // 
            this.comboBoxtables.FormattingEnabled = true;
            this.comboBoxtables.Items.AddRange(new object[] {
            "Available",
            "Unavailable"});
            this.comboBoxtables.Location = new System.Drawing.Point(168, 139);
            this.comboBoxtables.Name = "comboBoxtables";
            this.comboBoxtables.Size = new System.Drawing.Size(240, 24);
            this.comboBoxtables.TabIndex = 4;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new System.Drawing.Point(321, 212);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(87, 27);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDelete.Location = new System.Drawing.Point(225, 212);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(87, 27);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAdd.Location = new System.Drawing.Point(37, 212);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(87, 27);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonUpdate.Location = new System.Drawing.Point(131, 212);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(87, 27);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxname
            // 
            this.textBoxname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxname.Location = new System.Drawing.Point(168, 96);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(240, 23);
            this.textBoxname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // TablesdataGridView
            // 
            this.TablesdataGridView.AllowUserToAddRows = false;
            this.TablesdataGridView.AllowUserToDeleteRows = false;
            this.TablesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablesdataGridView.Location = new System.Drawing.Point(26, 95);
            this.TablesdataGridView.Name = "TablesdataGridView";
            this.TablesdataGridView.ReadOnly = true;
            this.TablesdataGridView.Size = new System.Drawing.Size(494, 283);
            this.TablesdataGridView.TabIndex = 11;
            this.TablesdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablesdataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabletextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(86, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Table  By Name";
            // 
            // tabletextBox
            // 
            this.tabletextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabletextBox.Location = new System.Drawing.Point(11, 22);
            this.tabletextBox.Name = "tabletextBox";
            this.tabletextBox.Size = new System.Drawing.Size(320, 23);
            this.tabletextBox.TabIndex = 1;
            this.tabletextBox.TextChanged += new System.EventHandler(this.tabletextBox_TextChanged);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 413);
            this.Controls.Add(this.groupBoxadd);
            this.Controls.Add(this.TablesdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tables";
            this.Load += new System.EventHandler(this.Tables_Load);
            this.groupBoxadd.ResumeLayout(false);
            this.groupBoxadd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablesdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxadd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TablesdataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tabletextBox;
        private System.Windows.Forms.ComboBox comboBoxtables;
    }
}