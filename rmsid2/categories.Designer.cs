
namespace rmsid2
{
    partial class categories
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
            this.groupBoxCat = new System.Windows.Forms.GroupBox();
            this.cattextBox = new System.Windows.Forms.TextBox();
            this.CatdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxaddcat = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.DiscomboBox = new System.Windows.Forms.ComboBox();
            this.CatnametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CatdataGridView)).BeginInit();
            this.groupBoxaddcat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCat
            // 
            this.groupBoxCat.Controls.Add(this.cattextBox);
            this.groupBoxCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCat.Location = new System.Drawing.Point(104, 24);
            this.groupBoxCat.Name = "groupBoxCat";
            this.groupBoxCat.Size = new System.Drawing.Size(272, 55);
            this.groupBoxCat.TabIndex = 0;
            this.groupBoxCat.TabStop = false;
            this.groupBoxCat.Text = "Search By Category";
            // 
            // cattextBox
            // 
            this.cattextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cattextBox.Location = new System.Drawing.Point(7, 23);
            this.cattextBox.Name = "cattextBox";
            this.cattextBox.Size = new System.Drawing.Size(260, 23);
            this.cattextBox.TabIndex = 0;
            this.cattextBox.TextChanged += new System.EventHandler(this.cattextBox_TextChanged);
            // 
            // CatdataGridView
            // 
            this.CatdataGridView.AllowUserToAddRows = false;
            this.CatdataGridView.AllowUserToDeleteRows = false;
            this.CatdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CatdataGridView.Location = new System.Drawing.Point(12, 86);
            this.CatdataGridView.Name = "CatdataGridView";
            this.CatdataGridView.ReadOnly = true;
            this.CatdataGridView.Size = new System.Drawing.Size(501, 275);
            this.CatdataGridView.TabIndex = 1;
            this.CatdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CatdataGridView_CellClick);
            // 
            // groupBoxaddcat
            // 
            this.groupBoxaddcat.Controls.Add(this.buttonClose);
            this.groupBoxaddcat.Controls.Add(this.buttonDelete);
            this.groupBoxaddcat.Controls.Add(this.buttonAdd);
            this.groupBoxaddcat.Controls.Add(this.buttonUpdate);
            this.groupBoxaddcat.Controls.Add(this.DiscomboBox);
            this.groupBoxaddcat.Controls.Add(this.CatnametextBox);
            this.groupBoxaddcat.Controls.Add(this.label2);
            this.groupBoxaddcat.Controls.Add(this.label1);
            this.groupBoxaddcat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxaddcat.Location = new System.Drawing.Point(568, 22);
            this.groupBoxaddcat.Name = "groupBoxaddcat";
            this.groupBoxaddcat.Size = new System.Drawing.Size(435, 339);
            this.groupBoxaddcat.TabIndex = 2;
            this.groupBoxaddcat.TabStop = false;
            this.groupBoxaddcat.Text = "Add Category";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Location = new System.Drawing.Point(324, 219);
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
            this.buttonDelete.Location = new System.Drawing.Point(228, 219);
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
            this.buttonAdd.Location = new System.Drawing.Point(40, 219);
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
            this.buttonUpdate.Location = new System.Drawing.Point(134, 219);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(87, 27);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // DiscomboBox
            // 
            this.DiscomboBox.FormattingEnabled = true;
            this.DiscomboBox.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.DiscomboBox.Location = new System.Drawing.Point(171, 146);
            this.DiscomboBox.Name = "DiscomboBox";
            this.DiscomboBox.Size = new System.Drawing.Size(240, 24);
            this.DiscomboBox.TabIndex = 2;
            // 
            // CatnametextBox
            // 
            this.CatnametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CatnametextBox.Location = new System.Drawing.Point(171, 109);
            this.CatnametextBox.Name = "CatnametextBox";
            this.CatnametextBox.Size = new System.Drawing.Size(240, 23);
            this.CatnametextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Discount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 413);
            this.Controls.Add(this.groupBoxaddcat);
            this.Controls.Add(this.CatdataGridView);
            this.Controls.Add(this.groupBoxCat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "categories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "categories";
            this.Load += new System.EventHandler(this.categories_Load);
            this.groupBoxCat.ResumeLayout(false);
            this.groupBoxCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CatdataGridView)).EndInit();
            this.groupBoxaddcat.ResumeLayout(false);
            this.groupBoxaddcat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCat;
        private System.Windows.Forms.TextBox cattextBox;
        private System.Windows.Forms.DataGridView CatdataGridView;
        private System.Windows.Forms.GroupBox groupBoxaddcat;
        private System.Windows.Forms.ComboBox DiscomboBox;
        private System.Windows.Forms.TextBox CatnametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
    }
}