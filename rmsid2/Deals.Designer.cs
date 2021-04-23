
namespace rmsid2
{
    partial class Deals
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
            this.label = new System.Windows.Forms.Label();
            this.comboBoxDealsP = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonupdate = new System.Windows.Forms.Button();
            this.buttonadd = new System.Windows.Forms.Button();
            this.numericUpDownqty = new System.Windows.Forms.NumericUpDown();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewproducts = new System.Windows.Forms.ListView();
            this.productid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.dataGridViewdeals = new System.Windows.Forms.DataGridView();
            this.buttonclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownqty)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdeals)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.comboBoxDealsP);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deals";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(15, 43);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 15);
            this.label.TabIndex = 1;
            this.label.Text = "Select Deal";
            // 
            // comboBoxDealsP
            // 
            this.comboBoxDealsP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDealsP.FormattingEnabled = true;
            this.comboBoxDealsP.Location = new System.Drawing.Point(103, 40);
            this.comboBoxDealsP.Name = "comboBoxDealsP";
            this.comboBoxDealsP.Size = new System.Drawing.Size(132, 23);
            this.comboBoxDealsP.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonupdate);
            this.groupBox2.Controls.Add(this.buttonadd);
            this.groupBox2.Controls.Add(this.numericUpDownqty);
            this.groupBox2.Controls.Add(this.textBoxname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(266, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 92);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Detail";
            // 
            // buttonupdate
            // 
            this.buttonupdate.Location = new System.Drawing.Point(255, 53);
            this.buttonupdate.Name = "buttonupdate";
            this.buttonupdate.Size = new System.Drawing.Size(67, 28);
            this.buttonupdate.TabIndex = 2;
            this.buttonupdate.Text = "Update";
            this.buttonupdate.UseVisualStyleBackColor = true;
            this.buttonupdate.Click += new System.EventHandler(this.buttonupdate_Click);
            // 
            // buttonadd
            // 
            this.buttonadd.Location = new System.Drawing.Point(183, 53);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(67, 28);
            this.buttonadd.TabIndex = 2;
            this.buttonadd.Text = "Add";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // numericUpDownqty
            // 
            this.numericUpDownqty.Location = new System.Drawing.Point(69, 52);
            this.numericUpDownqty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownqty.Name = "numericUpDownqty";
            this.numericUpDownqty.Size = new System.Drawing.Size(107, 21);
            this.numericUpDownqty.TabIndex = 2;
            this.numericUpDownqty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(107, 27);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(143, 21);
            this.textBoxname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewproducts);
            this.groupBox3.Location = new System.Drawing.Point(612, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 341);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Products";
            // 
            // listViewproducts
            // 
            this.listViewproducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productid,
            this.categoryid,
            this.ProductName});
            this.listViewproducts.FullRowSelect = true;
            this.listViewproducts.GridLines = true;
            this.listViewproducts.HideSelection = false;
            this.listViewproducts.Location = new System.Drawing.Point(20, 29);
            this.listViewproducts.Name = "listViewproducts";
            this.listViewproducts.Size = new System.Drawing.Size(278, 286);
            this.listViewproducts.TabIndex = 0;
            this.listViewproducts.UseCompatibleStateImageBehavior = false;
            this.listViewproducts.View = System.Windows.Forms.View.Details;
            this.listViewproducts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewproducts_MouseClick);
            // 
            // productid
            // 
            this.productid.Text = "Pid";
            this.productid.Width = 40;
            // 
            // categoryid
            // 
            this.categoryid.Text = "Cid";
            this.categoryid.Width = 40;
            // 
            // ProductName
            // 
            this.ProductName.Text = "Product Name";
            this.ProductName.Width = 200;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonclose);
            this.groupBox4.Controls.Add(this.buttonDel);
            this.groupBox4.Controls.Add(this.dataGridViewdeals);
            this.groupBox4.Location = new System.Drawing.Point(12, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(580, 258);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Deals Detail";
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(475, 223);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(82, 29);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // dataGridViewdeals
            // 
            this.dataGridViewdeals.AllowUserToAddRows = false;
            this.dataGridViewdeals.AllowUserToDeleteRows = false;
            this.dataGridViewdeals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewdeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewdeals.Location = new System.Drawing.Point(12, 21);
            this.dataGridViewdeals.MultiSelect = false;
            this.dataGridViewdeals.Name = "dataGridViewdeals";
            this.dataGridViewdeals.ReadOnly = true;
            this.dataGridViewdeals.Size = new System.Drawing.Size(545, 198);
            this.dataGridViewdeals.TabIndex = 0;
            this.dataGridViewdeals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdeals_CellClick);
            // 
            // buttonclose
            // 
            this.buttonclose.Location = new System.Drawing.Point(387, 222);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(82, 29);
            this.buttonclose.TabIndex = 2;
            this.buttonclose.Text = "Close";
            this.buttonclose.UseVisualStyleBackColor = true;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // Deals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 387);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Deals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deals";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownqty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdeals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox comboBoxDealsP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonupdate;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.NumericUpDown numericUpDownqty;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.DataGridView dataGridViewdeals;
        private System.Windows.Forms.ListView listViewproducts;
        private System.Windows.Forms.ColumnHeader productid;
        private System.Windows.Forms.ColumnHeader categoryid;
        private System.Windows.Forms.ColumnHeader ProductName;
        private System.Windows.Forms.Button buttonclose;
    }
}