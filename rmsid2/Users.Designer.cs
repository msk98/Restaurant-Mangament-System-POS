
namespace rmsid2
{
    partial class Users
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
            this.groupBoxaddProducts = new System.Windows.Forms.GroupBox();
            this.checkBoxshow = new System.Windows.Forms.CheckBox();
            this.comboBoxpriv = new System.Windows.Forms.ComboBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxpass = new System.Windows.Forms.TextBox();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userssdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usertextBox = new System.Windows.Forms.TextBox();
            this.groupBoxaddProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userssdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxaddProducts
            // 
            this.groupBoxaddProducts.Controls.Add(this.checkBoxshow);
            this.groupBoxaddProducts.Controls.Add(this.comboBoxpriv);
            this.groupBoxaddProducts.Controls.Add(this.buttonClose);
            this.groupBoxaddProducts.Controls.Add(this.buttonDelete);
            this.groupBoxaddProducts.Controls.Add(this.buttonAdd);
            this.groupBoxaddProducts.Controls.Add(this.buttonUpdate);
            this.groupBoxaddProducts.Controls.Add(this.textBoxpass);
            this.groupBoxaddProducts.Controls.Add(this.textBoxname);
            this.groupBoxaddProducts.Controls.Add(this.label3);
            this.groupBoxaddProducts.Controls.Add(this.label2);
            this.groupBoxaddProducts.Controls.Add(this.label1);
            this.groupBoxaddProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxaddProducts.Location = new System.Drawing.Point(567, 20);
            this.groupBoxaddProducts.Name = "groupBoxaddProducts";
            this.groupBoxaddProducts.Size = new System.Drawing.Size(435, 339);
            this.groupBoxaddProducts.TabIndex = 12;
            this.groupBoxaddProducts.TabStop = false;
            this.groupBoxaddProducts.Text = "Add User";
            // 
            // checkBoxshow
            // 
            this.checkBoxshow.AutoSize = true;
            this.checkBoxshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxshow.Location = new System.Drawing.Point(168, 136);
            this.checkBoxshow.Name = "checkBoxshow";
            this.checkBoxshow.Size = new System.Drawing.Size(53, 17);
            this.checkBoxshow.TabIndex = 5;
            this.checkBoxshow.Text = "Show";
            this.checkBoxshow.UseVisualStyleBackColor = true;
            this.checkBoxshow.CheckedChanged += new System.EventHandler(this.checkBoxshow_CheckedChanged);
            // 
            // comboBoxpriv
            // 
            this.comboBoxpriv.FormattingEnabled = true;
            this.comboBoxpriv.Items.AddRange(new object[] {
            "Manager",
            "Counter"});
            this.comboBoxpriv.Location = new System.Drawing.Point(168, 163);
            this.comboBoxpriv.Name = "comboBoxpriv";
            this.comboBoxpriv.Size = new System.Drawing.Size(240, 24);
            this.comboBoxpriv.TabIndex = 4;
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
            // textBoxpass
            // 
            this.textBoxpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxpass.Location = new System.Drawing.Point(168, 98);
            this.textBoxpass.Name = "textBoxpass";
            this.textBoxpass.Size = new System.Drawing.Size(240, 23);
            this.textBoxpass.TabIndex = 1;
            this.textBoxpass.UseSystemPasswordChar = true;
            // 
            // textBoxname
            // 
            this.textBoxname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxname.Location = new System.Drawing.Point(168, 54);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(240, 23);
            this.textBoxname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Privilages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // userssdataGridView
            // 
            this.userssdataGridView.AllowUserToAddRows = false;
            this.userssdataGridView.AllowUserToDeleteRows = false;
            this.userssdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userssdataGridView.Location = new System.Drawing.Point(18, 76);
            this.userssdataGridView.Name = "userssdataGridView";
            this.userssdataGridView.ReadOnly = true;
            this.userssdataGridView.Size = new System.Drawing.Size(494, 283);
            this.userssdataGridView.TabIndex = 11;
            this.userssdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userssdataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usertextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(78, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search User By Name";
            // 
            // usertextBox
            // 
            this.usertextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usertextBox.Location = new System.Drawing.Point(11, 22);
            this.usertextBox.Name = "usertextBox";
            this.usertextBox.Size = new System.Drawing.Size(320, 23);
            this.usertextBox.TabIndex = 1;
            this.usertextBox.TextChanged += new System.EventHandler(this.InventextBox_TextChanged);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 374);
            this.Controls.Add(this.groupBoxaddProducts);
            this.Controls.Add(this.userssdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.groupBoxaddProducts.ResumeLayout(false);
            this.groupBoxaddProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userssdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxaddProducts;
        private System.Windows.Forms.ComboBox comboBoxpriv;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxpass;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView userssdataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox usertextBox;
        private System.Windows.Forms.CheckBox checkBoxshow;
    }
}