using System.ComponentModel;
using poolViewer.Pool;

namespace poolViewer;

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
        components = new Container();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        newToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator = new ToolStripSeparator();
        saveToolStripMenuItem = new ToolStripMenuItem();
        saveAsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem4 = new ToolStripMenuItem();
        Filter = new ToolStripMenuItem();
        filterClear = new ToolStripMenuItem();
        CopyAll = new ToolStripMenuItem();
        viewToolStripMenuItem = new ToolStripMenuItem();
        pauseToolStripMenuItem = new ToolStripMenuItem();
        RefreshToolStripMenuItem = new ToolStripMenuItem();
        IntervalMenuItem = new ToolStripMenuItem();
        second1MenuItem = new ToolStripMenuItem();
        seconds2MenuItem = new ToolStripMenuItem();
        seconds5MenuItem = new ToolStripMenuItem();
        seconds10MenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        dataGridView1 = new DataGridView();
        tagDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        allocsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        freesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        diffDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        bytesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        kBDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        bAllocDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        sourceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        timer1 = new System.Windows.Forms.Timer(components);
        saveFileDialog1 = new SaveFileDialog();
        currIntervalBox = new TextBox();
        menuStrip1.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolStripMenuItem4, viewToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1050, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // newToolStripMenuItem
        // 
        newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
        newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
        newToolStripMenuItem.Name = "newToolStripMenuItem";
        newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        newToolStripMenuItem.Size = new Size(146, 22);
        newToolStripMenuItem.Text = "&New";
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
        openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openToolStripMenuItem.Size = new Size(146, 22);
        openToolStripMenuItem.Text = "&Open";
        // 
        // toolStripSeparator
        // 
        toolStripSeparator.Name = "toolStripSeparator";
        toolStripSeparator.Size = new Size(143, 6);
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
        saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        saveToolStripMenuItem.Size = new Size(146, 22);
        saveToolStripMenuItem.Text = "&Save";
        saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.Size = new Size(146, 22);
        saveAsToolStripMenuItem.Text = "Save &As";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(143, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(146, 22);
        exitToolStripMenuItem.Text = "E&xit";
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { Filter, filterClear, CopyAll });
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new Size(39, 20);
        toolStripMenuItem4.Text = "Edit";
        // 
        // Filter
        // 
        Filter.Name = "Filter";
        Filter.Size = new Size(126, 22);
        Filter.Text = "Filter";
        Filter.Click += Filter_Click;
        // 
        // filterClear
        // 
        filterClear.Name = "filterClear";
        filterClear.Size = new Size(126, 22);
        filterClear.Text = "ClearFilter";
        filterClear.Click += FilterClear_Click;
        // 
        // CopyAll
        // 
        CopyAll.Name = "CopyAll";
        CopyAll.Size = new Size(126, 22);
        CopyAll.Text = "CopyAll";
        // 
        // viewToolStripMenuItem
        // 
        viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pauseToolStripMenuItem, RefreshToolStripMenuItem, IntervalMenuItem });
        viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        viewToolStripMenuItem.Size = new Size(44, 20);
        viewToolStripMenuItem.Text = "&View";
        // 
        // pauseToolStripMenuItem
        // 
        pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
        pauseToolStripMenuItem.Size = new Size(155, 22);
        pauseToolStripMenuItem.Text = "&Pause";
        pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
        // 
        // RefreshToolStripMenuItem
        // 
        RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
        RefreshToolStripMenuItem.ShortcutKeys = Keys.F5;
        RefreshToolStripMenuItem.Size = new Size(155, 22);
        RefreshToolStripMenuItem.Text = "&Refresh";
        RefreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
        // 
        // IntervalMenuItem
        // 
        IntervalMenuItem.DropDownItems.AddRange(new ToolStripItem[] { second1MenuItem, seconds2MenuItem, seconds5MenuItem, seconds10MenuItem });
        IntervalMenuItem.Name = "IntervalMenuItem";
        IntervalMenuItem.ShortcutKeyDisplayString = "";
        IntervalMenuItem.Size = new Size(155, 22);
        IntervalMenuItem.Text = "Refresh Interval";
        // 
        // second1MenuItem
        // 
        second1MenuItem.Name = "second1MenuItem";
        second1MenuItem.Size = new Size(132, 22);
        second1MenuItem.Text = "1 second";
        second1MenuItem.Click += second1MenuItem_Click;
        // 
        // seconds2MenuItem
        // 
        seconds2MenuItem.Name = "seconds2MenuItem";
        seconds2MenuItem.Size = new Size(132, 22);
        seconds2MenuItem.Text = "2 seconds";
        seconds2MenuItem.Click += seconds2MenuItem_Click;
        // 
        // seconds5MenuItem
        // 
        seconds5MenuItem.Name = "seconds5MenuItem";
        seconds5MenuItem.Size = new Size(132, 22);
        seconds5MenuItem.Text = "5 seconds";
        seconds5MenuItem.Click += seconds5MenuItem_Click;
        // 
        // seconds10MenuItem
        // 
        seconds10MenuItem.Name = "seconds10MenuItem";
        seconds10MenuItem.Size = new Size(132, 22);
        seconds10MenuItem.Text = "10 seconds";
        seconds10MenuItem.Click += seconds10MenuItem_Click;
        // 
        // helpToolStripMenuItem
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(44, 20);
        helpToolStripMenuItem.Text = "&Help";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(116, 22);
        aboutToolStripMenuItem.Text = "&About...";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tagDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, allocsDataGridViewTextBoxColumn, freesDataGridViewTextBoxColumn, diffDataGridViewTextBoxColumn, bytesDataGridViewTextBoxColumn, kBDataGridViewTextBoxColumn, bAllocDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 24);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new Size(1050, 580);
        dataGridView1.TabIndex = 1;
        dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        // 
        // tagDataGridViewTextBoxColumn
        // 
        tagDataGridViewTextBoxColumn.DataPropertyName = "Tag";
        tagDataGridViewTextBoxColumn.HeaderText = "Tag";
        tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
        tagDataGridViewTextBoxColumn.ReadOnly = true;
        tagDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
        // 
        // typeDataGridViewTextBoxColumn
        // 
        typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
        typeDataGridViewTextBoxColumn.HeaderText = "Type";
        typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
        typeDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // allocsDataGridViewTextBoxColumn
        // 
        allocsDataGridViewTextBoxColumn.DataPropertyName = "Allocs";
        allocsDataGridViewTextBoxColumn.HeaderText = "Allocs";
        allocsDataGridViewTextBoxColumn.Name = "allocsDataGridViewTextBoxColumn";
        allocsDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // freesDataGridViewTextBoxColumn
        // 
        freesDataGridViewTextBoxColumn.DataPropertyName = "Frees";
        freesDataGridViewTextBoxColumn.HeaderText = "Frees";
        freesDataGridViewTextBoxColumn.Name = "freesDataGridViewTextBoxColumn";
        freesDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // diffDataGridViewTextBoxColumn
        // 
        diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
        diffDataGridViewTextBoxColumn.HeaderText = "Diff";
        diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
        diffDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // bytesDataGridViewTextBoxColumn
        // 
        bytesDataGridViewTextBoxColumn.DataPropertyName = "Bytes";
        bytesDataGridViewTextBoxColumn.HeaderText = "Bytes";
        bytesDataGridViewTextBoxColumn.Name = "bytesDataGridViewTextBoxColumn";
        bytesDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // kBDataGridViewTextBoxColumn
        // 
        kBDataGridViewTextBoxColumn.DataPropertyName = "KB";
        kBDataGridViewTextBoxColumn.HeaderText = "KB";
        kBDataGridViewTextBoxColumn.Name = "kBDataGridViewTextBoxColumn";
        kBDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // bAllocDataGridViewTextBoxColumn
        // 
        bAllocDataGridViewTextBoxColumn.DataPropertyName = "B_Alloc";
        bAllocDataGridViewTextBoxColumn.HeaderText = "B_Alloc";
        bAllocDataGridViewTextBoxColumn.Name = "bAllocDataGridViewTextBoxColumn";
        bAllocDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // sourceDataGridViewTextBoxColumn
        // 
        sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
        sourceDataGridViewTextBoxColumn.HeaderText = "Source";
        sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
        sourceDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // descriptionDataGridViewTextBoxColumn
        // 
        descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
        descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
        descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
        descriptionDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // currIntervalBox
        // 
        currIntervalBox.Enabled = false;
        currIntervalBox.Location = new Point(184, 0);
        currIntervalBox.Name = "currIntervalBox";
        currIntervalBox.ReadOnly = true;
        currIntervalBox.Size = new Size(183, 23);
        currIntervalBox.TabIndex = 2;
        currIntervalBox.TabStop = false;
        currIntervalBox.TextAlign = HorizontalAlignment.Center;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1050, 604);
        Controls.Add(currIntervalBox);
        Controls.Add(dataGridView1);
        Controls.Add(menuStrip1);
        Name = "MainForm";
        Text = "MainForm";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox currIntervalBox;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;

    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
    private ToolStripMenuItem CopyAll;
    private ToolStripMenuItem filterClear;
}