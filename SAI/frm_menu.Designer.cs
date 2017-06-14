namespace Frm_menu
{
    partial class frm_menu
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();

            this.tabOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.toolStripSQL = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();

            this.tabEditor = new System.Windows.Forms.TabPage();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.gridPacket = new System.Windows.Forms.DataGridView();
            this.gridColumn_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_opcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridColumn_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);

            this.gridPacket = new System.Windows.Forms.DataGridView();

            this.toolStripEdit = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxEntry = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabelEntry = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.createSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonLoadSniff = new System.Windows.Forms.ToolStripButton();
            this.smartAIWikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_Waypoint = new System.Windows.Forms.TabControl();
            this.tabOutput.SuspendLayout();
            this.toolStripSQL.SuspendLayout();
            this.tabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacket)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.toolStripEdit.SuspendLayout();
            this.tab_Waypoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.txtOutput);
            this.tabOutput.Controls.Add(this.toolStripSQL);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(1416, 672);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "SQL Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(3, 28);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(1410, 641);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // toolStripSQL
            // 
            this.toolStripSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStripSQL.Location = new System.Drawing.Point(3, 3);
            this.toolStripSQL.Name = "toolStripSQL";
            this.toolStripSQL.Size = new System.Drawing.Size(1410, 25);
            this.toolStripSQL.TabIndex = 1;
            this.toolStripSQL.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            //this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonSave.Text = "Write SQL";
            this.toolStripButtonSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButtonSave.ToolTipText = "Write textbox to SQL file.";
            //this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // tabEditor
            //
            this.tabEditor.Controls.Add(this.gridPacket);
            this.tabEditor.Controls.Add(this.listBox);
            this.tabEditor.Controls.Add(this.gridPacket);
            this.tabEditor.Controls.Add(this.textBox);
            this.tabEditor.Controls.Add(this.toolStripEdit);
            this.tabEditor.Location = new System.Drawing.Point(4, 22);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditor.Size = new System.Drawing.Size(1416, 672);
            this.tabEditor.TabIndex = 0;
            this.tabEditor.Text = "SAI Editor";
            this.tabEditor.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(470, 28);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(239, 641);
            this.listBox.TabIndex = 24;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // gridPacket
            // 
            this.gridPacket.AllowUserToAddRows = false;
            this.gridPacket.AllowUserToDeleteRows = false;
            this.gridPacket.AllowUserToResizeColumns = false;
            this.gridPacket.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.gridPacket.BackgroundColor = System.Drawing.Color.White;
            this.gridPacket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPacket.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

            this.gridPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPacket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridColumn_no,
            this.gridColumn_name,
            this.gridColumn_opcode,
            this.gridColumn_time,
            });

            this.gridPacket.ContextMenuStrip = this.contextMenuStrip;

            this.gridPacket.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridPacket.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridPacket.Location = new System.Drawing.Point(4, 28);
            this.gridPacket.Name = "gridPacket";
            this.gridPacket.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPacket.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridPacket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPacket.Size = new System.Drawing.Size(459, 641);
            this.gridPacket.TabIndex = 20;
            this.gridPacket.TabStop = false;
            this.gridPacket.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPacket_CellContentClick);
            // 
            // textBox
            // 
            this.textBox.ReadOnly = true;
            this.textBox.Multiline = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Location = new System.Drawing.Point(716, 28);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(694, 641);
            this.textBox.TabIndex = 24;
            // 
            // gridColumn_no
            // 
            this.gridColumn_no.HeaderText = "PID";
            this.gridColumn_no.Name = "gridColumn_no";
            this.gridColumn_no.ReadOnly = true;
            this.gridColumn_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridColumn_no.Width = 55;
            // 
            // gridColumn_name
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.gridColumn_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridColumn_name.HeaderText = "Name";
            this.gridColumn_name.MaxInputLength = 25;
            this.gridColumn_name.Name = "gridColumn_name";
            this.gridColumn_name.ReadOnly = true;
            this.gridColumn_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_name.Width = 220;
            // 
            // gridColumn_opcode
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.gridColumn_opcode.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridColumn_opcode.HeaderText = "Opcode";
            this.gridColumn_opcode.MaxInputLength = 25;
            this.gridColumn_opcode.Name = "gridColumn_opcode";
            this.gridColumn_opcode.ReadOnly = true;
            this.gridColumn_opcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gridColumn_opcode.Width = 60;
            // 
            // gridColumn_time
            // 
            this.gridColumn_time.HeaderText = "time";
            this.gridColumn_time.Name = "gridColumn_time";
            this.gridColumn_time.ReadOnly = true;
            this.gridColumn_time.Width = 60;
            // 
            // tab_Waypoint
            // 
            this.tab_Waypoint.Controls.Add(this.tabEditor);
            this.tab_Waypoint.Controls.Add(this.tabOutput);
            this.tab_Waypoint.Location = new System.Drawing.Point(0, 0);
            this.tab_Waypoint.Name = "tab_Waypoint";
            this.tab_Waypoint.SelectedIndex = 0;
            this.tab_Waypoint.Size = new System.Drawing.Size(1424, 698);
            this.tab_Waypoint.TabIndex = 20;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.cutToolStripMenuItem,
            //this.copyToolStripMenuItem,
            //this.pasteAboveToolStripMenuItem,
            //this.pasteBelowToolStripMenuItem,
            this.toolStripSeparator,
            this.createSQLToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(140, 120);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(136, 6);
            // 
            // createSQLToolStripMenuItem
            // 
            this.createSQLToolStripMenuItem.Name = "createSQLToolStripMenuItem";
            this.createSQLToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.createSQLToolStripMenuItem.Text = "Create SQL";
            this.createSQLToolStripMenuItem.Click += new System.EventHandler(this.createSQLToolStripMenuItem_Click);
            // 
            // toolStripEdit
            // 
            this.toolStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripTextBoxEntry,
            this.toolStripLabelEntry,
            this.toolStripSeparator,
            //this.toolStripButtonSettings,
            this.toolStripButtonLoadSniff,
            this.smartAIWikiToolStripMenuItem});
            this.toolStripEdit.Location = new System.Drawing.Point(3, 3);
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.Size = new System.Drawing.Size(1410, 25);
            this.toolStripEdit.TabIndex = 23;
            this.toolStripEdit.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonSearch.Enabled = false;
            //this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonSearch.Text = "Search";
            this.toolStripButtonSearch.ToolTipText = "Fill listbox with guids of\r\nselected entry or all entries.";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripTextBoxEntry
            // 
            this.toolStripTextBoxEntry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBoxEntry.Enabled = false;
            this.toolStripTextBoxEntry.MaxLength = 5;
            this.toolStripTextBoxEntry.Name = "toolStripTextBoxEntry";
            this.toolStripTextBoxEntry.Size = new System.Drawing.Size(70, 25);
            this.toolStripTextBoxEntry.Tag = "";
            this.toolStripTextBoxEntry.ToolTipText = "Input entry of creature or leave\r\nblank to fill listbox will all in sniff.";
            // 
            // toolStripLabelEntry
            // 
            this.toolStripLabelEntry.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelEntry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabelEntry.Name = "toolStripLabelEntry";
            this.toolStripLabelEntry.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabelEntry.Text = "Entry:";
            this.toolStripLabelEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripButtonLoadSniff
            // 
            //this.toolStripButtonLoadSniff.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadSniff.Image")));
            this.toolStripButtonLoadSniff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadSniff.Name = "toolStripButtonLoadSniff";
            this.toolStripButtonLoadSniff.Size = new System.Drawing.Size(90, 22);
            this.toolStripButtonLoadSniff.Text = "Import Sniff";
            this.toolStripButtonLoadSniff.ToolTipText = "Import a parsed wpp sniff file.";
            this.toolStripButtonLoadSniff.Click += new System.EventHandler(this.toolStripButtonLoadSniff_Click);
            // 
            // smartAIWikiToolStripMenuItem
            // 
            this.smartAIWikiToolStripMenuItem.Name = "smartAIWikiToolStripMenuItem";
            this.smartAIWikiToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.smartAIWikiToolStripMenuItem.Text = "SmartAI Wiki (TC)";
            this.smartAIWikiToolStripMenuItem.Click += new System.EventHandler(this.smartAIWikiToolStripMenuItem_Click);
            // 
            // frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 720);
            this.Controls.Add(this.tab_Waypoint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_menu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_menu_FormClosing);
            this.Load += new System.EventHandler(this.frm_menu_Load);
            this.tabEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPacket)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStripEdit.ResumeLayout(false);
            this.toolStripEdit.PerformLayout();
            this.tab_Waypoint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TabPage tabEditor;
        internal System.Windows.Forms.DataGridView gridPacket;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TabControl tab_Waypoint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_opcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridColumn_time;

        private System.Windows.Forms.ToolStripMenuItem createSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripSQL;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStrip toolStripEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxEntry;
        private System.Windows.Forms.ToolStripLabel toolStripLabelEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadSniff;
        public System.Windows.Forms.ToolStripMenuItem smartAIWikiToolStripMenuItem;
    }
}

