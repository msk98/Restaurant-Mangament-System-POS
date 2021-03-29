
namespace rmsid2
{
    partial class reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reports));
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridVieworderitems = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridorders = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dateTimePickerto = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.custaddress = new System.Windows.Forms.Label();
            this.custphone = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printReportPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printReportDocument = new System.Drawing.Printing.PrintDocument();
            this.printDocumentOrder = new System.Drawing.Printing.PrintDocument();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieworderitems)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridorders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(929, 508);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridVieworderitems);
            this.groupBox3.Location = new System.Drawing.Point(528, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 362);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Items Report";
            // 
            // dataGridVieworderitems
            // 
            this.dataGridVieworderitems.AllowUserToAddRows = false;
            this.dataGridVieworderitems.AllowUserToDeleteRows = false;
            this.dataGridVieworderitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVieworderitems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVieworderitems.Location = new System.Drawing.Point(3, 19);
            this.dataGridVieworderitems.Name = "dataGridVieworderitems";
            this.dataGridVieworderitems.ReadOnly = true;
            this.dataGridVieworderitems.Size = new System.Drawing.Size(490, 340);
            this.dataGridVieworderitems.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridorders);
            this.groupBox2.Location = new System.Drawing.Point(28, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 362);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order report";
            // 
            // dataGridorders
            // 
            this.dataGridorders.AllowUserToAddRows = false;
            this.dataGridorders.AllowUserToDeleteRows = false;
            this.dataGridorders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridorders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridorders.Location = new System.Drawing.Point(3, 19);
            this.dataGridorders.Name = "dataGridorders";
            this.dataGridorders.ReadOnly = true;
            this.dataGridorders.Size = new System.Drawing.Size(488, 340);
            this.dataGridorders.TabIndex = 0;
            this.dataGridorders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridorders_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDelete);
            this.groupBox1.Controls.Add(this.dateTimePickerto);
            this.groupBox1.Controls.Add(this.dateTimePickerFrom);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.buttonPrint);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.custaddress);
            this.groupBox1.Controls.Add(this.custphone);
            this.groupBox1.Controls.Add(this.customerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Detail";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(916, 31);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(74, 30);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dateTimePickerto
            // 
            this.dateTimePickerto.CustomFormat = "DD-MM-YYYY";
            this.dateTimePickerto.Location = new System.Drawing.Point(370, 38);
            this.dateTimePickerto.Name = "dateTimePickerto";
            this.dateTimePickerto.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerto.TabIndex = 8;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "DD-MM-YYYY";
            this.dateTimePickerFrom.Location = new System.Drawing.Point(93, 38);
            this.dateTimePickerFrom.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerFrom.TabIndex = 8;
            this.dateTimePickerFrom.Value = new System.DateTime(2021, 3, 23, 18, 12, 27, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(748, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Print Selected Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonprintselectedorders_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(665, 31);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 30);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(580, 31);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 30);
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
            // printReportPreviewDialog
            // 
            this.printReportPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printReportPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printReportPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printReportPreviewDialog.Enabled = true;
            this.printReportPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printReportPreviewDialog.Icon")));
            this.printReportPreviewDialog.Name = "printReportPreviewDialog";
            this.printReportPreviewDialog.Visible = false;
            // 
            // printReportDocument
            // 
            this.printReportDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printReportDocument_PrintPage_1);
            // 
            // printDocumentOrder
            // 
            this.printDocumentOrder.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentOrder_PrintPage);
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 554);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reports";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieworderitems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridorders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridVieworderitems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridorders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerto;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label custaddress;
        private System.Windows.Forms.Label custphone;
        private System.Windows.Forms.Label customerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printOrderDocument;
        private System.Drawing.Printing.PrintDocument printDocumentOrder;
        private System.Drawing.Printing.PrintDocument printReportDocument;
        private System.Windows.Forms.PrintPreviewDialog printReportPreviewDialog;
    }
}