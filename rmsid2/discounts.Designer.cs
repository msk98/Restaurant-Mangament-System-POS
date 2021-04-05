
namespace rmsid2
{
    partial class disocunts
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxdisname = new System.Windows.Forms.TextBox();
            this.textBoxdispercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.discountsdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.disnametextBox = new System.Windows.Forms.TextBox();
            this.groupBoxaddProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountsdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxaddProducts
            // 
            this.groupBoxaddProducts.Controls.Add(this.buttonClose);
            this.groupBoxaddProducts.Controls.Add(this.buttonDelete);
            this.groupBoxaddProducts.Controls.Add(this.buttonAdd);
            this.groupBoxaddProducts.Controls.Add(this.buttonUpdate);
            this.groupBoxaddProducts.Controls.Add(this.textBoxdisname);
            this.groupBoxaddProducts.Controls.Add(this.textBoxdispercent);
            this.groupBoxaddProducts.Controls.Add(this.label3);
            this.groupBoxaddProducts.Controls.Add(this.label2);
            this.groupBoxaddProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxaddProducts.Location = new System.Drawing.Point(567, 20);
            this.groupBoxaddProducts.Name = "groupBoxaddProducts";
            this.groupBoxaddProducts.Size = new System.Drawing.Size(435, 339);
            this.groupBoxaddProducts.TabIndex = 12;
            this.groupBoxaddProducts.TabStop = false;
            this.groupBoxaddProducts.Text = "Add Discount";
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
            // textBoxdisname
            // 
            this.textBoxdisname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxdisname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdisname.Location = new System.Drawing.Point(168, 88);
            this.textBoxdisname.Name = "textBoxdisname";
            this.textBoxdisname.Size = new System.Drawing.Size(240, 26);
            this.textBoxdisname.TabIndex = 1;
            // 
            // textBoxdispercent
            // 
            this.textBoxdispercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxdispercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdispercent.Location = new System.Drawing.Point(172, 136);
            this.textBoxdispercent.Name = "textBoxdispercent";
            this.textBoxdispercent.Size = new System.Drawing.Size(240, 26);
            this.textBoxdispercent.TabIndex = 1;
            this.textBoxdispercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxdispercent_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Discount In Percent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // discountsdataGridView
            // 
            this.discountsdataGridView.AllowUserToAddRows = false;
            this.discountsdataGridView.AllowUserToDeleteRows = false;
            this.discountsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.discountsdataGridView.Location = new System.Drawing.Point(18, 76);
            this.discountsdataGridView.Name = "discountsdataGridView";
            this.discountsdataGridView.ReadOnly = true;
            this.discountsdataGridView.Size = new System.Drawing.Size(494, 283);
            this.discountsdataGridView.TabIndex = 11;
            this.discountsdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.discountsdataGridView_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.disnametextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(78, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Discounts  By Name";
            // 
            // disnametextBox
            // 
            this.disnametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disnametextBox.Location = new System.Drawing.Point(11, 22);
            this.disnametextBox.Name = "disnametextBox";
            this.disnametextBox.Size = new System.Drawing.Size(320, 23);
            this.disnametextBox.TabIndex = 1;
            this.disnametextBox.TextChanged += new System.EventHandler(this.disnametextBox_TextChanged);
            // 
            // disocunts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 374);
            this.Controls.Add(this.groupBoxaddProducts);
            this.Controls.Add(this.discountsdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "disocunts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "disocunts";
            this.Load += new System.EventHandler(this.disocunts_Load);
            this.groupBoxaddProducts.ResumeLayout(false);
            this.groupBoxaddProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discountsdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxaddProducts;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxdispercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView discountsdataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox disnametextBox;
        private System.Windows.Forms.TextBox textBoxdisname;
    }
}