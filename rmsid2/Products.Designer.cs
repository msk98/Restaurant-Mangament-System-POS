
namespace rmsid2
{
    partial class Products
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProdtextBox = new System.Windows.Forms.TextBox();
            this.ProductsdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxaddProducts = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.catscomboBox = new System.Windows.Forms.ComboBox();
            this.prodPricetextBox = new System.Windows.Forms.TextBox();
            this.PnametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsdataGridView)).BeginInit();
            this.groupBoxaddProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProdtextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(94, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search product";
            // 
            // ProdtextBox
            // 
            this.ProdtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProdtextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProdtextBox.Location = new System.Drawing.Point(14, 22);
            this.ProdtextBox.Name = "ProdtextBox";
            this.ProdtextBox.Size = new System.Drawing.Size(292, 23);
            this.ProdtextBox.TabIndex = 1;
            this.ProdtextBox.TextChanged += new System.EventHandler(this.ProdtextBox_TextChanged);
            // 
            // ProductsdataGridView
            // 
            this.ProductsdataGridView.AllowUserToAddRows = false;
            this.ProductsdataGridView.AllowUserToDeleteRows = false;
            this.ProductsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsdataGridView.Location = new System.Drawing.Point(20, 89);
            this.ProductsdataGridView.Name = "ProductsdataGridView";
            this.ProductsdataGridView.ReadOnly = true;
            this.ProductsdataGridView.Size = new System.Drawing.Size(494, 283);
            this.ProductsdataGridView.TabIndex = 1;
            this.ProductsdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductsdataGridView_CellClick);
            // 
            // groupBoxaddProducts
            // 
            this.groupBoxaddProducts.Controls.Add(this.buttonClose);
            this.groupBoxaddProducts.Controls.Add(this.buttonDelete);
            this.groupBoxaddProducts.Controls.Add(this.buttonAdd);
            this.groupBoxaddProducts.Controls.Add(this.buttonUpdate);
            this.groupBoxaddProducts.Controls.Add(this.catscomboBox);
            this.groupBoxaddProducts.Controls.Add(this.prodPricetextBox);
            this.groupBoxaddProducts.Controls.Add(this.PnametextBox);
            this.groupBoxaddProducts.Controls.Add(this.label2);
            this.groupBoxaddProducts.Controls.Add(this.label3);
            this.groupBoxaddProducts.Controls.Add(this.label1);
            this.groupBoxaddProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxaddProducts.Location = new System.Drawing.Point(569, 33);
            this.groupBoxaddProducts.Name = "groupBoxaddProducts";
            this.groupBoxaddProducts.Size = new System.Drawing.Size(435, 339);
            this.groupBoxaddProducts.TabIndex = 3;
            this.groupBoxaddProducts.TabStop = false;
            this.groupBoxaddProducts.Text = "Add Products";
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
            // catscomboBox
            // 
            this.catscomboBox.FormattingEnabled = true;
            this.catscomboBox.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.catscomboBox.Location = new System.Drawing.Point(171, 91);
            this.catscomboBox.Name = "catscomboBox";
            this.catscomboBox.Size = new System.Drawing.Size(240, 24);
            this.catscomboBox.TabIndex = 2;
            // 
            // prodPricetextBox
            // 
            this.prodPricetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prodPricetextBox.Location = new System.Drawing.Point(171, 130);
            this.prodPricetextBox.Name = "prodPricetextBox";
            this.prodPricetextBox.Size = new System.Drawing.Size(240, 23);
            this.prodPricetextBox.TabIndex = 1;
            // 
            // PnametextBox
            // 
            this.PnametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnametextBox.Location = new System.Drawing.Point(171, 56);
            this.PnametextBox.Name = "PnametextBox";
            this.PnametextBox.Size = new System.Drawing.Size(240, 23);
            this.PnametextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Product Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1036, 413);
            this.Controls.Add(this.groupBoxaddProducts);
            this.Controls.Add(this.ProductsdataGridView);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsdataGridView)).EndInit();
            this.groupBoxaddProducts.ResumeLayout(false);
            this.groupBoxaddProducts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ProductsdataGridView;
        private System.Windows.Forms.TextBox ProdtextBox;
        private System.Windows.Forms.GroupBox groupBoxaddProducts;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox catscomboBox;
        private System.Windows.Forms.TextBox PnametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox prodPricetextBox;
    }
}