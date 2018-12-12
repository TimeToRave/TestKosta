namespace TestKOSTA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DepartamentsTreeView = new System.Windows.Forms.TreeView();
            this.EmployeeDataGridView = new System.Windows.Forms.DataGridView();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddButtonToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditButtonToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DepartamentsTreeView
            // 
            this.DepartamentsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DepartamentsTreeView.BackColor = System.Drawing.Color.AliceBlue;
            this.DepartamentsTreeView.Location = new System.Drawing.Point(12, 53);
            this.DepartamentsTreeView.Name = "DepartamentsTreeView";
            this.DepartamentsTreeView.Size = new System.Drawing.Size(325, 553);
            this.DepartamentsTreeView.TabIndex = 1;
            this.DepartamentsTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.DepartamentsTreeView_BeforeSelect);
            this.DepartamentsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DepartamentsTreeView_AfterSelect);
            // 
            // EmployeeDataGridView
            // 
            this.EmployeeDataGridView.AllowUserToAddRows = false;
            this.EmployeeDataGridView.AllowUserToDeleteRows = false;
            this.EmployeeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.EmployeeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.EmployeeDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.EmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.EmployeeDataGridView.Location = new System.Drawing.Point(349, 53);
            this.EmployeeDataGridView.Name = "EmployeeDataGridView";
            this.EmployeeDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmployeeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeDataGridView.Size = new System.Drawing.Size(1328, 553);
            this.EmployeeDataGridView.TabIndex = 2;
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.MintCream;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.AddButtonToolStrip,
            this.toolStripSeparator2,
            this.EditButtonToolStrip,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripSeparator4});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1689, 50);
            this.ToolStrip.TabIndex = 4;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // AddButtonToolStrip
            // 
            this.AddButtonToolStrip.AutoSize = false;
            this.AddButtonToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButtonToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddButtonToolStrip.Image")));
            this.AddButtonToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddButtonToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButtonToolStrip.Name = "AddButtonToolStrip";
            this.AddButtonToolStrip.Size = new System.Drawing.Size(48, 48);
            this.AddButtonToolStrip.Text = "toolStripButton1";
            this.AddButtonToolStrip.ToolTipText = "Добавить нового сотрудника";
            this.AddButtonToolStrip.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // EditButtonToolStrip
            // 
            this.EditButtonToolStrip.AutoSize = false;
            this.EditButtonToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditButtonToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("EditButtonToolStrip.Image")));
            this.EditButtonToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditButtonToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditButtonToolStrip.Name = "EditButtonToolStrip";
            this.EditButtonToolStrip.Size = new System.Drawing.Size(48, 48);
            this.EditButtonToolStrip.Text = "toolStripButton2";
            this.EditButtonToolStrip.ToolTipText = "Редактирование выбранного сотрудника";
            this.EditButtonToolStrip.Click += new System.EventHandler(this.EditButtonToolStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 49);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Удаление выбранного сотрудника";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 50);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1689, 618);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.EmployeeDataGridView);
            this.Controls.Add(this.DepartamentsTreeView);
            this.Name = "Form1";
            this.Text = "Фирма";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView DepartamentsTreeView;
        private System.Windows.Forms.DataGridView EmployeeDataGridView;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton AddButtonToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton EditButtonToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

