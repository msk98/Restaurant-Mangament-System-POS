
namespace rmsid2
{
    partial class Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.catpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttondown = new System.Windows.Forms.Button();
            this.buttonbuttom = new System.Windows.Forms.Button();
            this.buttontop = new System.Windows.Forms.Button();
            this.buttondel = new System.Windows.Forms.Button();
            this.buttonincrease = new System.Windows.Forms.Button();
            this.buttontopp = new System.Windows.Forms.Button();
            this.productdataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Productpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonKOT = new System.Windows.Forms.Button();
            this.kotprintDocument = new System.Drawing.Printing.PrintDocument();
            this.kotprintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productdataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1172, 678);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.catpanel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1146, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categories";
            // 
            // catpanel
            // 
            this.catpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catpanel.Location = new System.Drawing.Point(3, 16);
            this.catpanel.Name = "catpanel";
            this.catpanel.Size = new System.Drawing.Size(1140, 81);
            this.catpanel.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttondown);
            this.groupBox3.Controls.Add(this.buttonbuttom);
            this.groupBox3.Controls.Add(this.buttontop);
            this.groupBox3.Controls.Add(this.buttondel);
            this.groupBox3.Controls.Add(this.buttonincrease);
            this.groupBox3.Controls.Add(this.buttontopp);
            this.groupBox3.Controls.Add(this.productdataGridView);
            this.groupBox3.Location = new System.Drawing.Point(3, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 420);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill";
            // 
            // buttondown
            // 
            this.buttondown.BackgroundImage = global::rmsid2.Properties.Resources.img_5178211;
            this.buttondown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttondown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttondown.FlatAppearance.BorderSize = 0;
            this.buttondown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttondown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttondown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttondown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttondown.Location = new System.Drawing.Point(474, 257);
            this.buttondown.Name = "buttondown";
            this.buttondown.Size = new System.Drawing.Size(78, 38);
            this.buttondown.TabIndex = 1;
            this.buttondown.UseVisualStyleBackColor = true;
            this.buttondown.Click += new System.EventHandler(this.buttondown_Click);
            // 
            // buttonbuttom
            // 
            this.buttonbuttom.BackgroundImage = global::rmsid2.Properties.Resources.arrow_pointing_down_icon_24;
            this.buttonbuttom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonbuttom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonbuttom.FlatAppearance.BorderSize = 0;
            this.buttonbuttom.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonbuttom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonbuttom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonbuttom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonbuttom.Location = new System.Drawing.Point(474, 304);
            this.buttonbuttom.Name = "buttonbuttom";
            this.buttonbuttom.Size = new System.Drawing.Size(78, 38);
            this.buttonbuttom.TabIndex = 1;
            this.buttonbuttom.UseVisualStyleBackColor = true;
            this.buttonbuttom.Click += new System.EventHandler(this.buttonbuttom_Click);
            // 
            // buttontop
            // 
            this.buttontop.BackgroundImage = global::rmsid2.Properties.Resources._94_942845_small_right_angle_on_the_arrow_top_arrow;
            this.buttontop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttontop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttontop.FlatAppearance.BorderSize = 0;
            this.buttontop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttontop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttontop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttontop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttontop.Location = new System.Drawing.Point(474, 116);
            this.buttontop.Name = "buttontop";
            this.buttontop.Size = new System.Drawing.Size(78, 38);
            this.buttontop.TabIndex = 1;
            this.buttontop.UseVisualStyleBackColor = true;
            this.buttontop.Click += new System.EventHandler(this.buttontop_Click);
            // 
            // buttondel
            // 
            this.buttondel.BackgroundImage = global::rmsid2.Properties.Resources.Office__2851_29;
            this.buttondel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttondel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttondel.FlatAppearance.BorderSize = 0;
            this.buttondel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttondel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttondel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttondel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttondel.Location = new System.Drawing.Point(474, 210);
            this.buttondel.Name = "buttondel";
            this.buttondel.Size = new System.Drawing.Size(78, 38);
            this.buttondel.TabIndex = 1;
            this.buttondel.UseVisualStyleBackColor = true;
            this.buttondel.Click += new System.EventHandler(this.buttondel_Click);
            // 
            // buttonincrease
            // 
            this.buttonincrease.BackgroundImage = global::rmsid2.Properties.Resources.asterick_clipart_8;
            this.buttonincrease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonincrease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonincrease.FlatAppearance.BorderSize = 0;
            this.buttonincrease.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonincrease.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonincrease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonincrease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonincrease.Location = new System.Drawing.Point(474, 163);
            this.buttonincrease.Name = "buttonincrease";
            this.buttonincrease.Size = new System.Drawing.Size(78, 38);
            this.buttonincrease.TabIndex = 1;
            this.buttonincrease.UseVisualStyleBackColor = true;
            this.buttonincrease.Click += new System.EventHandler(this.buttonincrease_Click);
            // 
            // buttontopp
            // 
            this.buttontopp.BackgroundImage = global::rmsid2.Properties.Resources.images2;
            this.buttontopp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttontopp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttontopp.FlatAppearance.BorderSize = 0;
            this.buttontopp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttontopp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttontopp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttontopp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttontopp.Location = new System.Drawing.Point(474, 72);
            this.buttontopp.Name = "buttontopp";
            this.buttontopp.Size = new System.Drawing.Size(78, 38);
            this.buttontopp.TabIndex = 1;
            this.buttontopp.UseVisualStyleBackColor = true;
            this.buttontopp.Click += new System.EventHandler(this.buttontopp_Click);
            // 
            // productdataGridView
            // 
            this.productdataGridView.AllowUserToAddRows = false;
            this.productdataGridView.AllowUserToDeleteRows = false;
            this.productdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Itemname,
            this.Price,
            this.Quantity,
            this.TotalPrice,
            this.Discount});
            this.productdataGridView.Location = new System.Drawing.Point(9, 19);
            this.productdataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.productdataGridView.Name = "productdataGridView";
            this.productdataGridView.ReadOnly = true;
            this.productdataGridView.RowHeadersWidth = 20;
            this.productdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.productdataGridView.Size = new System.Drawing.Size(459, 379);
            this.productdataGridView.TabIndex = 0;
            this.productdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productdataGridView_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Productpanel);
            this.groupBox2.Location = new System.Drawing.Point(561, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 420);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Products";
            // 
            // Productpanel
            // 
            this.Productpanel.Location = new System.Drawing.Point(27, 19);
            this.Productpanel.Name = "Productpanel";
            this.Productpanel.Size = new System.Drawing.Size(552, 379);
            this.Productpanel.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxTotalAmount);
            this.groupBox4.Controls.Add(this.labelTotalAmount);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 535);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(552, 131);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Net Payment";
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalAmount.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxTotalAmount.Location = new System.Drawing.Point(206, 50);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.ReadOnly = true;
            this.textBoxTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxTotalAmount.Size = new System.Drawing.Size(100, 25);
            this.textBoxTotalAmount.TabIndex = 1;
            this.textBoxTotalAmount.Text = "0";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalAmount.Location = new System.Drawing.Point(28, 50);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(153, 26);
            this.labelTotalAmount.TabIndex = 0;
            this.labelTotalAmount.Text = "Total Amount";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonClose);
            this.groupBox5.Controls.Add(this.buttonKOT);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(561, 535);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(579, 131);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Actions";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(140, 50);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 30);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonKOT
            // 
            this.buttonKOT.Location = new System.Drawing.Point(27, 50);
            this.buttonKOT.Name = "buttonKOT";
            this.buttonKOT.Size = new System.Drawing.Size(104, 30);
            this.buttonKOT.TabIndex = 6;
            this.buttonKOT.Text = "KOT";
            this.buttonKOT.UseVisualStyleBackColor = true;
            this.buttonKOT.Click += new System.EventHandler(this.buttonKOT_Click);
            // 
            // kotprintDocument
            // 
            this.kotprintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.kotprintDocument_PrintPage);
            // 
            // kotprintPreviewDialog
            // 
            this.kotprintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.kotprintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.kotprintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.kotprintPreviewDialog.Enabled = true;
            this.kotprintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("kotprintPreviewDialog.Icon")));
            this.kotprintPreviewDialog.Name = "kotprintPreviewDialog";
            this.kotprintPreviewDialog.Visible = false;
            // 
            // Id
            // 
            this.Id.HeaderText = "id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Itemname
            // 
            this.Itemname.HeaderText = "Item Name";
            this.Itemname.Name = "Itemname";
            this.Itemname.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Total Price";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productdataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel catpanel;
        private System.Windows.Forms.FlowLayoutPanel Productpanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonbuttom;
        private System.Windows.Forms.Button buttontop;
        private System.Windows.Forms.Button buttondown;
        private System.Windows.Forms.Button buttontopp;
        private System.Windows.Forms.DataGridView productdataGridView;
        private System.Windows.Forms.Button buttondel;
        private System.Windows.Forms.Button buttonincrease;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonKOT;
        private System.Drawing.Printing.PrintDocument kotprintDocument;
        private System.Windows.Forms.PrintPreviewDialog kotprintPreviewDialog;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
    }
}