
namespace rmsid2
{
    partial class SelectDiscount
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
            this.groupBoxselect = new System.Windows.Forms.GroupBox();
            this.radioButtonCode = new System.Windows.Forms.RadioButton();
            this.radioButtonpercentage = new System.Windows.Forms.RadioButton();
            this.radioButtoncash = new System.Windows.Forms.RadioButton();
            this.groupBoxcash = new System.Windows.Forms.GroupBox();
            this.textBoxdisamnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxpercen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttoncancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDiscountPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.comboBoxpromo = new System.Windows.Forms.ComboBox();
            this.groupBoxselect.SuspendLayout();
            this.groupBoxcash.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxselect
            // 
            this.groupBoxselect.Controls.Add(this.radioButtonCode);
            this.groupBoxselect.Controls.Add(this.radioButtonpercentage);
            this.groupBoxselect.Controls.Add(this.radioButtoncash);
            this.groupBoxselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxselect.Location = new System.Drawing.Point(12, 12);
            this.groupBoxselect.Name = "groupBoxselect";
            this.groupBoxselect.Size = new System.Drawing.Size(490, 69);
            this.groupBoxselect.TabIndex = 0;
            this.groupBoxselect.TabStop = false;
            this.groupBoxselect.Text = "Select Discount";
            // 
            // radioButtonCode
            // 
            this.radioButtonCode.AutoSize = true;
            this.radioButtonCode.Location = new System.Drawing.Point(330, 35);
            this.radioButtonCode.Name = "radioButtonCode";
            this.radioButtonCode.Size = new System.Drawing.Size(140, 21);
            this.radioButtonCode.TabIndex = 0;
            this.radioButtonCode.Text = "Promo Discount";
            this.radioButtonCode.UseVisualStyleBackColor = true;
            this.radioButtonCode.Click += new System.EventHandler(this.radioButtonCode_Click);
            // 
            // radioButtonpercentage
            // 
            this.radioButtonpercentage.AutoSize = true;
            this.radioButtonpercentage.Location = new System.Drawing.Point(149, 35);
            this.radioButtonpercentage.Name = "radioButtonpercentage";
            this.radioButtonpercentage.Size = new System.Drawing.Size(177, 21);
            this.radioButtonpercentage.TabIndex = 0;
            this.radioButtonpercentage.Text = "Percentage Discount";
            this.radioButtonpercentage.UseVisualStyleBackColor = true;
            this.radioButtonpercentage.Click += new System.EventHandler(this.radioButtonpercentage_Click);
            // 
            // radioButtoncash
            // 
            this.radioButtoncash.AutoSize = true;
            this.radioButtoncash.Checked = true;
            this.radioButtoncash.Location = new System.Drawing.Point(17, 35);
            this.radioButtoncash.Name = "radioButtoncash";
            this.radioButtoncash.Size = new System.Drawing.Size(130, 21);
            this.radioButtoncash.TabIndex = 0;
            this.radioButtoncash.TabStop = true;
            this.radioButtoncash.Text = "Cash Discount";
            this.radioButtoncash.UseVisualStyleBackColor = true;
            this.radioButtoncash.Click += new System.EventHandler(this.radioButtoncash_Click);
            // 
            // groupBoxcash
            // 
            this.groupBoxcash.Controls.Add(this.textBoxdisamnt);
            this.groupBoxcash.Controls.Add(this.label1);
            this.groupBoxcash.Location = new System.Drawing.Point(13, 88);
            this.groupBoxcash.Name = "groupBoxcash";
            this.groupBoxcash.Size = new System.Drawing.Size(496, 52);
            this.groupBoxcash.TabIndex = 1;
            this.groupBoxcash.TabStop = false;
            // 
            // textBoxdisamnt
            // 
            this.textBoxdisamnt.Location = new System.Drawing.Point(196, 20);
            this.textBoxdisamnt.Name = "textBoxdisamnt";
            this.textBoxdisamnt.Size = new System.Drawing.Size(148, 23);
            this.textBoxdisamnt.TabIndex = 1;
            this.textBoxdisamnt.TextChanged += new System.EventHandler(this.textBoxdisamnt_TextChanged);
            this.textBoxdisamnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Discount Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxpercen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // textBoxpercen
            // 
            this.textBoxpercen.Location = new System.Drawing.Point(207, 20);
            this.textBoxpercen.Name = "textBoxpercen";
            this.textBoxpercen.Size = new System.Drawing.Size(148, 23);
            this.textBoxpercen.TabIndex = 1;
            this.textBoxpercen.TextChanged += new System.EventHandler(this.textBoxpercen_TextChanged);
            this.textBoxpercen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter Discount Percentage";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxpromo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select Promo";
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(303, 302);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 32);
            this.buttoncancel.TabIndex = 2;
            this.buttoncancel.Text = "Cancel";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(395, 302);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(118, 32);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Add Discount";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxprice
            // 
            this.textBoxprice.Location = new System.Drawing.Point(161, 336);
            this.textBoxprice.Name = "textBoxprice";
            this.textBoxprice.ReadOnly = true;
            this.textBoxprice.Size = new System.Drawing.Size(96, 23);
            this.textBoxprice.TabIndex = 1;
            this.textBoxprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "After Discount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Discount Price";
            // 
            // textBoxDiscountPrice
            // 
            this.textBoxDiscountPrice.Location = new System.Drawing.Point(161, 307);
            this.textBoxDiscountPrice.Name = "textBoxDiscountPrice";
            this.textBoxDiscountPrice.ReadOnly = true;
            this.textBoxDiscountPrice.Size = new System.Drawing.Size(96, 23);
            this.textBoxDiscountPrice.TabIndex = 1;
            this.textBoxDiscountPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Price";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(161, 274);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(96, 23);
            this.textBoxTotalPrice.TabIndex = 1;
            this.textBoxTotalPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBoxpromo
            // 
            this.comboBoxpromo.FormattingEnabled = true;
            this.comboBoxpromo.Location = new System.Drawing.Point(183, 23);
            this.comboBoxpromo.Name = "comboBoxpromo";
            this.comboBoxpromo.Size = new System.Drawing.Size(121, 24);
            this.comboBoxpromo.TabIndex = 0;
            this.comboBoxpromo.SelectedIndexChanged += new System.EventHandler(this.comboBoxpromo_SelectedIndexChanged_1);
            // 
            // SelectDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 377);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.textBoxDiscountPrice);
            this.Controls.Add(this.textBoxprice);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxcash);
            this.Controls.Add(this.groupBoxselect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectDiscount";
            this.Load += new System.EventHandler(this.SelectDiscount_Load);
            this.groupBoxselect.ResumeLayout(false);
            this.groupBoxselect.PerformLayout();
            this.groupBoxcash.ResumeLayout(false);
            this.groupBoxcash.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxselect;
        private System.Windows.Forms.RadioButton radioButtonCode;
        private System.Windows.Forms.RadioButton radioButtonpercentage;
        private System.Windows.Forms.RadioButton radioButtoncash;
        private System.Windows.Forms.GroupBox groupBoxcash;
        private System.Windows.Forms.TextBox textBoxdisamnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxpercen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttoncancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDiscountPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.ComboBox comboBoxpromo;
    }
}