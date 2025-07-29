using System.ComponentModel;

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
        editToolStripMenuItem = new ToolStripMenuItem();
        copyToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator4 = new ToolStripSeparator();
        selectAllToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem4 = new ToolStripMenuItem();
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
        toolStripMenuItem1 = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripMenuItem();
        toolStripMenuItem3 = new ToolStripMenuItem();
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
        poolTagInfoBindingSource = new BindingSource(components);
        timer1 = new System.Windows.Forms.Timer(components);
        menuStrip1.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        ((ISupportInitialize)poolTagInfoBindingSource).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
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
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem, toolStripMenuItem4 });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new Size(39, 20);
        editToolStripMenuItem.Text = "&Edit";
        // 
        // copyToolStripMenuItem
        // 
        copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
        copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
        copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        copyToolStripMenuItem.Size = new Size(144, 22);
        copyToolStripMenuItem.Text = "&Copy";
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(141, 6);
        // 
        // selectAllToolStripMenuItem
        // 
        selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
        selectAllToolStripMenuItem.Size = new Size(144, 22);
        selectAllToolStripMenuItem.Text = "Select &All";
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new Size(144, 22);
        toolStripMenuItem4.Text = "Filter";
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
        // 
        // RefreshToolStripMenuItem
        // 
        RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
        RefreshToolStripMenuItem.ShortcutKeys = Keys.F5;
        RefreshToolStripMenuItem.Size = new Size(155, 22);
        RefreshToolStripMenuItem.Text = "&Refresh";
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
        second1MenuItem.CheckOnClick = true;
        second1MenuItem.Name = "second1MenuItem";
        second1MenuItem.Size = new Size(132, 22);
        second1MenuItem.Text = "1 second";
        // 
        // seconds2MenuItem
        // 
        seconds2MenuItem.CheckOnClick = true;
        seconds2MenuItem.Name = "seconds2MenuItem";
        seconds2MenuItem.Size = new Size(132, 22);
        seconds2MenuItem.Text = "2 seconds";
        // 
        // seconds5MenuItem
        // 
        seconds5MenuItem.Name = "seconds5MenuItem";
        seconds5MenuItem.Size = new Size(132, 22);
        seconds5MenuItem.Text = "5 seconds";
        // 
        // seconds10MenuItem
        // 
        seconds10MenuItem.CheckOnClick = true;
        seconds10MenuItem.Name = "seconds10MenuItem";
        seconds10MenuItem.Size = new Size(132, 22);
        seconds10MenuItem.Text = "10 seconds";
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
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(32, 19);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new Size(32, 19);
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new Size(32, 19);
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { tagDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, allocsDataGridViewTextBoxColumn, freesDataGridViewTextBoxColumn, diffDataGridViewTextBoxColumn, bytesDataGridViewTextBoxColumn, kBDataGridViewTextBoxColumn, bAllocDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
        dataGridView1.DataSource = poolTagInfoBindingSource;
        dataGridView1.Location = new Point(4, 25);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new Size(1044, 577);
        dataGridView1.TabIndex = 1;
        dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
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
        // poolTagInfoBindingSource
        // 
        poolTagInfoBindingSource.DataSource = typeof(PoolTagInfo);
        // 
        // timer1
        // 
        timer1.Enabled = true;
        timer1.Interval = 1000;
        timer1.Tick += timer1_Tick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1050, 604);
        Controls.Add(dataGridView1);
        Controls.Add(menuStrip1);
        Name = "MainForm";
        Text = "MainForm";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        ((ISupportInitialize)poolTagInfoBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

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
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

    private System.Windows.Forms.MenuStrip menuStrip1;

    #endregion

    private ToolStripMenuItem toolStripMenuItem4;
    private ToolStripMenuItem IntervalMenuItem;
    private ToolStripMenuItem second1MenuItem;
    private ToolStripMenuItem seconds2MenuItem;
    private ToolStripMenuItem seconds5MenuItem;
    private ToolStripMenuItem seconds10MenuItem;
    private DataGridView dataGridView1;
    private BindingSource poolTagInfoBindingSource;
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
}