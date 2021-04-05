
namespace rmsid2
{
    partial class registerreporting
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridregisterreport = new System.Windows.Forms.DataGridView();
            this.groupBoxRegister = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dateTimePickerto = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.custaddress = new System.Windows.Forms.Label();
            this.custphone = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonclose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UserIDlabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelopeningtime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelclosetime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelusername = new System.Windows.Forms.Label();
            this.printRegisterDocument = new System.Drawing.Printing.PrintDocument();
            this.label8 = new System.Windows.Forms.Label();
            this.labelopeningamount = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridregisterreport)).BeginInit();
            this.groupBoxRegister.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridregisterreport);
            this.groupBox2.Location = new System.Drawing.Point(29, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 410);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Register  Report";
            // 
            // dataGridregisterreport
            // 
            this.dataGridregisterreport.AllowUserToAddRows = false;
            this.dataGridregisterreport.AllowUserToDeleteRows = false;
            this.dataGridregisterreport.AllowUserToResizeColumns = false;
            this.dataGridregisterreport.AllowUserToResizeRows = false;
            this.dataGridregisterreport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridregisterreport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridregisterreport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridregisterreport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridregisterreport.Location = new System.Drawing.Point(3, 19);
            this.dataGridregisterreport.Name = "dataGridregisterreport";
            this.dataGridregisterreport.ReadOnly = true;
            this.dataGridregisterreport.Size = new System.Drawing.Size(564, 388);
            this.dataGridregisterreport.TabIndex = 0;
            this.dataGridregisterreport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridregisterreport_CellClick);
            // 
            // groupBoxRegister
            // 
            this.groupBoxRegister.Controls.Add(this.buttonDelete);
            this.groupBoxRegister.Controls.Add(this.dateTimePickerto);
            this.groupBoxRegister.Controls.Add(this.dateTimePickerFrom);
            this.groupBoxRegister.Controls.Add(this.buttonPrint);
            this.groupBoxRegister.Controls.Add(this.buttonSearch);
            this.groupBoxRegister.Controls.Add(this.label3);
            this.groupBoxRegister.Controls.Add(this.label2);
            this.groupBoxRegister.Controls.Add(this.custaddress);
            this.groupBoxRegister.Controls.Add(this.custphone);
            this.groupBoxRegister.Controls.Add(this.customerName);
            this.groupBoxRegister.Controls.Add(this.label1);
            this.groupBoxRegister.Location = new System.Drawing.Point(29, 31);
            this.groupBoxRegister.Name = "groupBoxRegister";
            this.groupBoxRegister.Size = new System.Drawing.Size(994, 80);
            this.groupBoxRegister.TabIndex = 7;
            this.groupBoxRegister.TabStop = false;
            this.groupBoxRegister.Text = "Register Report Detail";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(841, 32);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(106, 30);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerto
            // 
            this.dateTimePickerto.CustomFormat = "DD-MM-YYYY";
            this.dateTimePickerto.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerto.Location = new System.Drawing.Point(370, 38);
            this.dateTimePickerto.Name = "dateTimePickerto";
            this.dateTimePickerto.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerto.TabIndex = 8;
            this.dateTimePickerto.Value = new System.DateTime(2021, 4, 2, 0, 0, 0, 0);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "DD-MM-YYYY";
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(93, 38);
            this.dateTimePickerFrom.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerFrom.TabIndex = 8;
            this.dateTimePickerFrom.Value = new System.DateTime(2021, 4, 2, 0, 0, 0, 0);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(723, 32);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(93, 30);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(594, 32);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(107, 30);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, -424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(298, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date To";
            // 
            // custaddress
            // 
            this.custaddress.AutoSize = true;
            this.custaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custaddress.Location = new System.Drawing.Point(661, 40);
            this.custaddress.Name = "custaddress";
            this.custaddress.Size = new System.Drawing.Size(0, 17);
            this.custaddress.TabIndex = 0;
            // 
            // custphone
            // 
            this.custphone.AutoSize = true;
            this.custphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custphone.Location = new System.Drawing.Point(416, 42);
            this.custphone.Name = "custphone";
            this.custphone.Size = new System.Drawing.Size(0, 17);
            this.custphone.TabIndex = 0;
            // 
            // customerName
            // 
            this.customerName.AutoSize = true;
            this.customerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerName.Location = new System.Drawing.Point(154, 43);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(0, 17);
            this.customerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From";
            // 
            // buttonclose
            // 
            this.buttonclose.Location = new System.Drawing.Point(901, 512);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(106, 30);
            this.buttonclose.TabIndex = 9;
            this.buttonclose.Text = "Close";
            this.buttonclose.UseVisualStyleBackColor = true;
            this.buttonclose.Click += new System.EventHandler(this.buttonclose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelopeningamount);
            this.groupBox1.Controls.Add(this.labelclosetime);
            this.groupBox1.Controls.Add(this.labelopeningtime);
            this.groupBox1.Controls.Add(this.labelusername);
            this.groupBox1.Controls.Add(this.UserIDlabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(623, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 379);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "User ID:";
            // 
            // UserIDlabel
            // 
            this.UserIDlabel.AutoSize = true;
            this.UserIDlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDlabel.Location = new System.Drawing.Point(163, 87);
            this.UserIDlabel.Name = "UserIDlabel";
            this.UserIDlabel.Size = new System.Drawing.Size(0, 17);
            this.UserIDlabel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Opening Time:";
            // 
            // labelopeningtime
            // 
            this.labelopeningtime.AutoSize = true;
            this.labelopeningtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelopeningtime.Location = new System.Drawing.Point(160, 188);
            this.labelopeningtime.Name = "labelopeningtime";
            this.labelopeningtime.Size = new System.Drawing.Size(0, 17);
            this.labelopeningtime.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Closing Time:";
            // 
            // labelclosetime
            // 
            this.labelclosetime.AutoSize = true;
            this.labelclosetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelclosetime.Location = new System.Drawing.Point(160, 254);
            this.labelclosetime.Name = "labelclosetime";
            this.labelclosetime.Size = new System.Drawing.Size(0, 17);
            this.labelclosetime.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Username:";
            // 
            // labelusername
            // 
            this.labelusername.AutoSize = true;
            this.labelusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelusername.Location = new System.Drawing.Point(163, 132);
            this.labelusername.Name = "labelusername";
            this.labelusername.Size = new System.Drawing.Size(0, 17);
            this.labelusername.TabIndex = 0;
            // 
            // printRegisterDocument
            // 
            this.printRegisterDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printRegisterDocument_PrintPage);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Opening Amount:";
            // 
            // labelopeningamount
            // 
            this.labelopeningamount.AutoSize = true;
            this.labelopeningamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelopeningamount.Location = new System.Drawing.Point(193, 296);
            this.labelopeningamount.Name = "labelopeningamount";
            this.labelopeningamount.Size = new System.Drawing.Size(0, 17);
            this.labelopeningamount.TabIndex = 0;
            // 
            // registerreporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonclose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxRegister);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "registerreporting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerreporting";
            this.Load += new System.EventHandler(this.registerreporting_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridregisterreport)).EndInit();
            this.groupBoxRegister.ResumeLayout(false);
            this.groupBoxRegister.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridregisterreport;
        private System.Windows.Forms.GroupBox groupBoxRegister;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DateTimePicker dateTimePickerto;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label custaddress;
        private System.Windows.Forms.Label custphone;
        private System.Windows.Forms.Label customerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelclosetime;
        private System.Windows.Forms.Label labelopeningtime;
        private System.Windows.Forms.Label labelusername;
        private System.Windows.Forms.Label UserIDlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printRegisterDocument;
        private System.Windows.Forms.Label labelopeningamount;
        private System.Windows.Forms.Label label8;
    }
}