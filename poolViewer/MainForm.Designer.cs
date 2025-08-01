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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
        saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
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
        toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
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
        poolTagInfoBindingSource = new System.Windows.Forms.BindingSource(components);
        timer1 = new System.Windows.Forms.Timer(components);
        saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        textBox1 = new System.Windows.Forms.TextBox();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)poolTagInfoBindingSource).BeginInit();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(1050, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // newToolStripMenuItem
        // 
        newToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("newToolStripMenuItem.Image"));
        newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        newToolStripMenuItem.Name = "newToolStripMenuItem";
        newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
        newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        newToolStripMenuItem.Text = "&New";
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image"));
        openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
        openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        openToolStripMenuItem.Text = "&Open";
        // 
        // toolStripSeparator
        // 
        toolStripSeparator.Name = "toolStripSeparator";
        toolStripSeparator.Size = new System.Drawing.Size(143, 6);
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image"));
        saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
        saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        saveToolStripMenuItem.Text = "&Save";
        saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
        // 
        // saveAsToolStripMenuItem
        // 
        saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        saveAsToolStripMenuItem.Text = "Save &As";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        exitToolStripMenuItem.Text = "E&xit";
        // 
        // editToolStripMenuItem
        // 
        editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { copyToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem, toolStripMenuItem4 });
        editToolStripMenuItem.Name = "editToolStripMenuItem";
        editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        editToolStripMenuItem.Text = "&Edit";
        // 
        // copyToolStripMenuItem
        // 
        copyToolStripMenuItem.Image = ((System.Drawing.Image)resources.GetObject("copyToolStripMenuItem.Image"));
        copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
        copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C));
        copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        copyToolStripMenuItem.Text = "&Copy";
        // 
        // toolStripSeparator4
        // 
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
        // 
        // selectAllToolStripMenuItem
        // 
        selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
        selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
        selectAllToolStripMenuItem.Text = "Select &All";
        // 
        // toolStripMenuItem4
        // 
        toolStripMenuItem4.Name = "toolStripMenuItem4";
        toolStripMenuItem4.Size = new System.Drawing.Size(144, 22);
        toolStripMenuItem4.Text = "Filter";
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
        pauseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        pauseToolStripMenuItem.Text = "&Pause";
        pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
        // 
        // RefreshToolStripMenuItem
        // 
        RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
        RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
        RefreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        RefreshToolStripMenuItem.Text = "&Refresh";
        RefreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
        // 
        // IntervalMenuItem
        // 
        IntervalMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { second1MenuItem, seconds2MenuItem, seconds5MenuItem, seconds10MenuItem });
        IntervalMenuItem.Name = "IntervalMenuItem";
        IntervalMenuItem.ShortcutKeyDisplayString = "";
        IntervalMenuItem.Size = new System.Drawing.Size(180, 22);
        IntervalMenuItem.Text = "Refresh Interval";
        // 
        // second1MenuItem
        // 
        second1MenuItem.Name = "second1MenuItem";
        second1MenuItem.Size = new System.Drawing.Size(132, 22);
        second1MenuItem.Text = "1 second";
        second1MenuItem.Click += second1MenuItem_Click;
        // 
        // seconds2MenuItem
        // 
        seconds2MenuItem.Name = "seconds2MenuItem";
        seconds2MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds2MenuItem.Text = "2 seconds";
        seconds2MenuItem.Click += seconds2MenuItem_Click;
        // 
        // seconds5MenuItem
        // 
        seconds5MenuItem.Name = "seconds5MenuItem";
        seconds5MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds5MenuItem.Text = "5 seconds";
        seconds5MenuItem.Click += seconds5MenuItem_Click;
        // 
        // seconds10MenuItem
        // 
        seconds10MenuItem.Name = "seconds10MenuItem";
        seconds10MenuItem.Size = new System.Drawing.Size(132, 22);
        seconds10MenuItem.Text = "10 seconds";
        seconds10MenuItem.Click += seconds10MenuItem_Click;
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
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AllowUserToOrderColumns = true;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { tagDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, allocsDataGridViewTextBoxColumn, freesDataGridViewTextBoxColumn, diffDataGridViewTextBoxColumn, bytesDataGridViewTextBoxColumn, kBDataGridViewTextBoxColumn, bAllocDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
        dataGridView1.DataSource = poolTagInfoBindingSource;
        dataGridView1.Location = new System.Drawing.Point(4, 25);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Size = new System.Drawing.Size(1044, 577);
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
        tagDataGridViewTextBoxColumn.Width = 100;
        // 
        // typeDataGridViewTextBoxColumn
        // 
        typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
        typeDataGridViewTextBoxColumn.HeaderText = "Type";
        typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
        typeDataGridViewTextBoxColumn.ReadOnly = true;
        typeDataGridViewTextBoxColumn.Width = 100;
        // 
        // allocsDataGridViewTextBoxColumn
        // 
        allocsDataGridViewTextBoxColumn.DataPropertyName = "Allocs";
        allocsDataGridViewTextBoxColumn.HeaderText = "Allocs";
        allocsDataGridViewTextBoxColumn.Name = "allocsDataGridViewTextBoxColumn";
        allocsDataGridViewTextBoxColumn.ReadOnly = true;
        allocsDataGridViewTextBoxColumn.Width = 100;
        // 
        // freesDataGridViewTextBoxColumn
        // 
        freesDataGridViewTextBoxColumn.DataPropertyName = "Frees";
        freesDataGridViewTextBoxColumn.HeaderText = "Frees";
        freesDataGridViewTextBoxColumn.Name = "freesDataGridViewTextBoxColumn";
        freesDataGridViewTextBoxColumn.ReadOnly = true;
        freesDataGridViewTextBoxColumn.Width = 100;
        // 
        // diffDataGridViewTextBoxColumn
        // 
        diffDataGridViewTextBoxColumn.DataPropertyName = "Diff";
        diffDataGridViewTextBoxColumn.HeaderText = "Diff";
        diffDataGridViewTextBoxColumn.Name = "diffDataGridViewTextBoxColumn";
        diffDataGridViewTextBoxColumn.ReadOnly = true;
        diffDataGridViewTextBoxColumn.Width = 100;
        // 
        // bytesDataGridViewTextBoxColumn
        // 
        bytesDataGridViewTextBoxColumn.DataPropertyName = "Bytes";
        bytesDataGridViewTextBoxColumn.HeaderText = "Bytes";
        bytesDataGridViewTextBoxColumn.Name = "bytesDataGridViewTextBoxColumn";
        bytesDataGridViewTextBoxColumn.ReadOnly = true;
        bytesDataGridViewTextBoxColumn.Width = 100;
        // 
        // kBDataGridViewTextBoxColumn
        // 
        kBDataGridViewTextBoxColumn.DataPropertyName = "KB";
        kBDataGridViewTextBoxColumn.HeaderText = "KB";
        kBDataGridViewTextBoxColumn.Name = "kBDataGridViewTextBoxColumn";
        kBDataGridViewTextBoxColumn.ReadOnly = true;
        kBDataGridViewTextBoxColumn.Width = 100;
        // 
        // bAllocDataGridViewTextBoxColumn
        // 
        bAllocDataGridViewTextBoxColumn.DataPropertyName = "B_Alloc";
        bAllocDataGridViewTextBoxColumn.HeaderText = "B_Alloc";
        bAllocDataGridViewTextBoxColumn.Name = "bAllocDataGridViewTextBoxColumn";
        bAllocDataGridViewTextBoxColumn.ReadOnly = true;
        bAllocDataGridViewTextBoxColumn.Width = 100;
        // 
        // sourceDataGridViewTextBoxColumn
        // 
        sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
        sourceDataGridViewTextBoxColumn.HeaderText = "Source";
        sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
        sourceDataGridViewTextBoxColumn.ReadOnly = true;
        sourceDataGridViewTextBoxColumn.Width = 100;
        // 
        // descriptionDataGridViewTextBoxColumn
        // 
        descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
        descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
        descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
        descriptionDataGridViewTextBoxColumn.ReadOnly = true;
        descriptionDataGridViewTextBoxColumn.Width = 100;
        // 
        // poolTagInfoBindingSource
        // 
        poolTagInfoBindingSource.DataSource = typeof(poolViewer.Pool.PoolTagInfo);
        // 
        // textBox1
        // 
        textBox1.Enabled = false;
        textBox1.Location = new System.Drawing.Point(184, 0);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new System.Drawing.Size(183, 23);
        textBox1.TabIndex = 2;
        textBox1.TabStop = false;
        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1050, 604);
        Controls.Add(textBox1);
        Controls.Add(dataGridView1);
        Controls.Add(menuStrip1);
        Text = "MainForm";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)poolTagInfoBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;

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
    private System.Windows.Forms.ToolStripMenuItem second1MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds2MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds5MenuItem;
    private System.Windows.Forms.ToolStripMenuItem seconds10MenuItem;
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
    private SaveFileDialog saveFileDialog1;
}