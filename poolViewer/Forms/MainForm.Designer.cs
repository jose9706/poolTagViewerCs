using System.ComponentModel;

namespace poolViewer.Forms;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
        Filter = new System.Windows.Forms.ToolStripMenuItem();
        filterClear = new System.Windows.Forms.ToolStripMenuItem();
        viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        IntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        second1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
        seconds2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
        seconds5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
        seconds10MenuItem = new System.Windows.Forms.ToolStripMenuItem();
        helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        dataGridView1 = new System.Windows.Forms.DataGridView();
        tagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        allocsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        freesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        diffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        bytesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        kBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        bAllocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        timer1 = new System.Windows.Forms.Timer(components);
        saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        currIntervalBox = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, toolStripMenuItem4, viewToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(1050, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image"));
        saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
        saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        saveToolStripMenuItem.Text = "&Save";
        saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        exitToolStripMenuItem.Text = "E&xit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { Filter, filterClear });
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new System.Drawing.Size(39, 20);
        toolStripMenuItem4.Text = "Edit";
        // 
        // Filter
        // 
        Filter.Name = "Filter";
        Filter.Size = new System.Drawing.Size(127, 22);
        Filter.Text = "Filter";
        Filter.Click += Filter_Click;
        // 
        // filterClear
        // 
        filterClear.Name = "filterClear";
        filterClear.Size = new System.Drawing.Size(127, 22);
        filterClear.Text = "ClearFilter";
        filterClear.Click += FilterClear_Click;
        // 
        // viewToolStripMenuItem
        // 
        viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { pauseToolStripMenuItem, RefreshToolStripMenuItem, IntervalMenuItem });
        viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        viewToolStripMenuItem.Text = "&View";
        // 
        // pauseToolStripMenuItem
        // 
        pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
        pauseToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
        pauseToolStripMenuItem.Text = "&Pause";
        pauseToolStripMenuItem.Click += PauseToolStripMenuItem_Click;
        // 
        // RefreshToolStripMenuItem
        // 
        RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
        RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
        RefreshToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
        RefreshToolStripMenuItem.Text = "&Refresh";
        RefreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
        // 
        // IntervalMenuItem
        // 
        IntervalMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { second1MenuItem, seconds2MenuItem, seconds5MenuItem, seconds10MenuItem });
        IntervalMenuItem.Name = "IntervalMenuItem";
        IntervalMenuItem.ShortcutKeyDisplayString = "";
        IntervalMenuItem.Size = new System.Drawing.Size(155, 22);
        IntervalMenuItem.Text = "Refresh Interval";
        // 
        // second1MenuItem
        // 
        second1MenuItem.Name = "second1MenuItem";
        second1MenuItem.Size = new System.Drawing.Size(132, 22);
        second1MenuItem.Text = "1 second";
        second1MenuItem.Click += Second1MenuItem_Click;
        // 
        // seconds2MenuItem
        // 
        seconds2MenuItem.Name = "seconds2MenuItem";
        seconds2MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds2MenuItem.Text = "2 seconds";
        seconds2MenuItem.Click += Seconds2MenuItem_Click;
        // 
        // seconds5MenuItem
        // 
        seconds5MenuItem.Name = "seconds5MenuItem";
        seconds5MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds5MenuItem.Text = "5 seconds";
        seconds5MenuItem.Click += Seconds5MenuItem_Click;
        // 
        // seconds10MenuItem
        // 
        seconds10MenuItem.Name = "seconds10MenuItem";
        seconds10MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds10MenuItem.Text = "10 seconds";
        seconds10MenuItem.Click += Seconds10MenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        helpToolStripMenuItem.Text = "&Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
        aboutToolStripMenuItem.Text = "&About...";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tagDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, allocsDataGridViewTextBoxColumn, freesDataGridViewTextBoxColumn, diffDataGridViewTextBoxColumn, bytesDataGridViewTextBoxColumn, kBDataGridViewTextBoxColumn, bAllocDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
        dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        dataGridView1.Location = new System.Drawing.Point(0, 24);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new System.Drawing.Size(1050, 580);
        dataGridView1.TabIndex = 1;
        dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        // 
        // tagDataGridViewTextBoxColumn
        // 
        tagDataGridViewTextBoxColumn.DataPropertyName = "Tag";
        tagDataGridViewTextBoxColumn.HeaderText = "Tag";
        tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
        tagDataGridViewTextBoxColumn.ReadOnly = true;
        tagDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        tagDataGridViewTextBoxColumn.Width = 105;
        // 
        // typeDataGridViewTextBoxColumn
        // 
        typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
        typeDataGridViewTextBoxColumn.HeaderText = "Type";
        typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
        typeDataGridViewTextBoxColumn.ReadOnly = true;
        typeDataGridViewTextBoxColumn.Width = 104;
        // 
        // allocsDataGridViewTextBoxColumn
        // 
        allocsDataGridViewTextBoxColumn.DataPropertyName = "Allocations";
        allocsDataGridViewTextBoxColumn.HeaderText = "Allocations";
        allocsDataGridViewTextBoxColumn.Name = "allocsDataGridViewTextBoxColumn";
        allocsDataGridViewTextBoxColumn.ReadOnly = true;
        allocsDataGridViewTextBoxColumn.Width = 105;
        // 
        // freesDataGridViewTextBoxColumn
        // 
        freesDataGridViewTextBoxColumn.DataPropertyName = "Frees";
        freesDataGridViewTextBoxColumn.HeaderText = "Frees";
        freesDataGridViewTextBoxColumn.Name = "freesDataGridViewTextBoxColumn";
        freesDataGridViewTextBoxColumn.ReadOnly = true;
        freesDataGridViewTextBoxColumn.Width = 105;
        // 
        // diffDataGridViewTextBoxColumn
        // 
        diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
        diffDataGridViewTextBoxColumn.HeaderText = "Diff";
        diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
        diffDataGridViewTextBoxColumn.ReadOnly = true;
        diffDataGridViewTextBoxColumn.Width = 104;
        // 
        // bytesDataGridViewTextBoxColumn
        // 
        bytesDataGridViewTextBoxColumn.DataPropertyName = "Bytes";
        bytesDataGridViewTextBoxColumn.HeaderText = "Bytes";
        bytesDataGridViewTextBoxColumn.Name = "bytesDataGridViewTextBoxColumn";
        bytesDataGridViewTextBoxColumn.ReadOnly = true;
        bytesDataGridViewTextBoxColumn.Width = 105;
        // 
        // kBDataGridViewTextBoxColumn
        // 
        kBDataGridViewTextBoxColumn.DataPropertyName = "Kb";
        kBDataGridViewTextBoxColumn.HeaderText = "Kb";
        kBDataGridViewTextBoxColumn.Name = "kBDataGridViewTextBoxColumn";
        kBDataGridViewTextBoxColumn.ReadOnly = true;
        kBDataGridViewTextBoxColumn.Width = 105;
        // 
        // bAllocDataGridViewTextBoxColumn
        // 
        bAllocDataGridViewTextBoxColumn.DataPropertyName = "BytesAllocated";
        bAllocDataGridViewTextBoxColumn.HeaderText = "BytesAllocated";
        bAllocDataGridViewTextBoxColumn.Name = "bAllocDataGridViewTextBoxColumn";
        bAllocDataGridViewTextBoxColumn.ReadOnly = true;
        bAllocDataGridViewTextBoxColumn.Width = 105;
        // 
        // sourceDataGridViewTextBoxColumn
        // 
        sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
        sourceDataGridViewTextBoxColumn.HeaderText = "Source";
        sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
        sourceDataGridViewTextBoxColumn.ReadOnly = true;
        sourceDataGridViewTextBoxColumn.Width = 104;
        // 
        // descriptionDataGridViewTextBoxColumn
        // 
        descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
        descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
        descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
        descriptionDataGridViewTextBoxColumn.ReadOnly = true;
        descriptionDataGridViewTextBoxColumn.Width = 105;
        // 
        // currIntervalBox
        // 
        currIntervalBox.Enabled = false;
        currIntervalBox.Location = new System.Drawing.Point(184, 0);
        currIntervalBox.Name = "currIntervalBox";
        currIntervalBox.ReadOnly = true;
        currIntervalBox.Size = new System.Drawing.Size(183, 23);
        currIntervalBox.TabIndex = 2;
        currIntervalBox.TabStop = false;
        currIntervalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.SystemColors.Control;
        button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        button1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.Red;
        button1.Location = new System.Drawing.Point(690, 0);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(136, 23);
        button1.TabIndex = 3;
        button1.Text = "Record";
        button1.UseVisualStyleBackColor = false;
        button1.Click += Button1_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1050, 604);
        Controls.Add(button1);
        Controls.Add(currIntervalBox);
        Controls.Add(dataGridView1);
        Controls.Add(menuStrip1);
        Font = new System.Drawing.Font("Segoe UI", 9F);
        Text = "MainForm";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox currIntervalBox;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.MenuStrip menuStrip1;

    #endregion

    private ToolStripMenuItem IntervalMenuItem;
    private System.Windows.Forms.ToolStripMenuItem second1MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds2MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds5MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds10MenuItem;
    private System.Windows.Forms.DataGridView dataGridView1;
    private DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn allocsDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn freesDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn diffDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn bytesDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn kBDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn bAllocDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    private System.Windows.Forms.Timer timer1;
    private SaveFileDialog saveFileDialog1;
    private ToolStripMenuItem toolStripMenuItem4;
    private ToolStripMenuItem Filter;
    private ToolStripMenuItem filterClear;
}