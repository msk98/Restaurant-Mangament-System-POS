
namespace rmsid2
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonTakeAway = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonDelivery = new System.Windows.Forms.Button();
            this.dataGridViewOrderlist = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.timerfunc = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.buttonHome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTakeAway, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.button6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.button7, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelivery, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.Location = new System.Drawing.Point(3, 3);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(142, 94);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            // 
            // buttonTakeAway
            // 
            this.buttonTakeAway.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTakeAway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTakeAway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTakeAway.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTakeAway.Location = new System.Drawing.Point(151, 3);
            this.buttonTakeAway.Name = "buttonTakeAway";
            this.buttonTakeAway.Size = new System.Drawing.Size(142, 94);
            this.buttonTakeAway.TabIndex = 0;
            this.buttonTakeAway.Text = "Take Away";
            this.buttonTakeAway.UseVisualStyleBackColor = false;
            this.buttonTakeAway.Click += new System.EventHandler(this.buttonTakeAway_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(595, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 94);
            this.button4.TabIndex = 0;
            this.button4.Text = "Dine In";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(485, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(66, 27);
            this.menuStrip1.TabIndex = 1;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemsToolStripMenuItem,
            this.incredientsToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.inventoryToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // menuItemsToolStripMenuItem
            // 
            this.menuItemsToolStripMenuItem.Name = "menuItemsToolStripMenuItem";
            this.menuItemsToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.menuItemsToolStripMenuItem.Text = "Menu Items";
            this.menuItemsToolStripMenuItem.Click += new System.EventHandler(this.menuItemsToolStripMenuItem_Click);
            // 
            // incredientsToolStripMenuItem
            // 
            this.incredientsToolStripMenuItem.Name = "incredientsToolStripMenuItem";
            this.incredientsToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.incredientsToolStripMenuItem.Text = "Incredients";
            this.incredientsToolStripMenuItem.Click += new System.EventHandler(this.incredientsToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(743, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 94);
            this.button5.TabIndex = 0;
            this.button5.Text = "Incredients";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(891, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 94);
            this.button6.TabIndex = 0;
            this.button6.Text = "Report";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(1039, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 94);
            this.button7.TabIndex = 0;
            this.button7.Text = "Close Register";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // buttonDelivery
            // 
            this.buttonDelivery.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelivery.Location = new System.Drawing.Point(299, 3);
            this.buttonDelivery.Name = "buttonDelivery";
            this.buttonDelivery.Size = new System.Drawing.Size(142, 94);
            this.buttonDelivery.TabIndex = 0;
            this.buttonDelivery.Text = "Delivery";
            this.buttonDelivery.UseVisualStyleBackColor = false;
            this.buttonDelivery.Click += new System.EventHandler(this.buttonDelivery_Click);
            // 
            // dataGridViewOrderlist
            // 
            this.dataGridViewOrderlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderlist.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewOrderlist.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewOrderlist.Name = "dataGridViewOrderlist";
            this.dataGridViewOrderlist.Size = new System.Drawing.Size(441, 581);
            this.dataGridViewOrderlist.TabIndex = 1;
            this.dataGridViewOrderlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderlist_CellClick);
            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(755, 100);
            this.dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(429, 581);
            this.dataGridViewOrderItems.TabIndex = 1;
            // 
            // timerfunc
            // 
            this.timerfunc.Enabled = true;
            this.timerfunc.Interval = 10;
            this.timerfunc.Tick += new System.EventHandler(this.timerfunc_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.dataGridViewOrderlist);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonTakeAway;
        private System.Windows.Forms.Button buttonDelivery;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dataGridViewOrderlist;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Timer timerfunc;
    }
}