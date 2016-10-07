namespace UI
{
	partial class MainForm
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.BigTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.District = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.numProximitySensitivity = new System.Windows.Forms.NumericUpDown();
			this.cboDistricts = new System.Windows.Forms.ComboBox();
			this.txtCoord = new System.Windows.Forms.TextBox();
			this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.streetBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.streetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.streetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numProximitySensitivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(221, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(609, 24);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBox1.Location = new System.Drawing.Point(731, 57);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(99, 22);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Old names";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BigTitle,
            this.categoryDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn,
            this.District,
            this.Distance});
			this.dataGridView1.DataSource = this.streetBindingSource2;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(1034, 491);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// BigTitle
			// 
			this.BigTitle.DataPropertyName = "BigTitle";
			this.BigTitle.HeaderText = "BigTitle";
			this.BigTitle.Name = "BigTitle";
			this.BigTitle.ReadOnly = true;
			this.BigTitle.Width = 600;
			// 
			// District
			// 
			this.District.DataPropertyName = "District";
			this.District.HeaderText = "District";
			this.District.Name = "District";
			this.District.ReadOnly = true;
			// 
			// Distance
			// 
			this.Distance.DataPropertyName = "Distance";
			this.Distance.HeaderText = "Distance";
			this.Distance.Name = "Distance";
			this.Distance.ReadOnly = true;
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 26);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.numProximitySensitivity);
			this.splitContainer1.Panel1.Controls.Add(this.cboDistricts);
			this.splitContainer1.Panel1.Controls.Add(this.txtCoord);
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
			this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(1034, 612);
			this.splitContainer1.SplitterDistance = 117;
			this.splitContainer1.TabIndex = 5;
			// 
			// numProximitySensitivity
			// 
			this.numProximitySensitivity.Location = new System.Drawing.Point(577, 58);
			this.numProximitySensitivity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numProximitySensitivity.Name = "numProximitySensitivity";
			this.numProximitySensitivity.Size = new System.Drawing.Size(120, 20);
			this.numProximitySensitivity.TabIndex = 7;
			this.numProximitySensitivity.ValueChanged += new System.EventHandler(this.numProximitySensitivity_ValueChanged);
			// 
			// cboDistricts
			// 
			this.cboDistricts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cboDistricts.FormattingEnabled = true;
			this.cboDistricts.Location = new System.Drawing.Point(12, 57);
			this.cboDistricts.Name = "cboDistricts";
			this.cboDistricts.Size = new System.Drawing.Size(192, 26);
			this.cboDistricts.TabIndex = 6;
			this.cboDistricts.SelectedIndexChanged += new System.EventHandler(this.cboDistricts_SelectedIndexChanged);
			// 
			// txtCoord
			// 
			this.txtCoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtCoord.Location = new System.Drawing.Point(221, 57);
			this.txtCoord.Multiline = true;
			this.txtCoord.Name = "txtCoord";
			this.txtCoord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCoord.Size = new System.Drawing.Size(335, 48);
			this.txtCoord.TabIndex = 5;
			this.txtCoord.TextChanged += new System.EventHandler(this.txtCoord_TextChanged);
			// 
			// categoryDataGridViewTextBoxColumn
			// 
			this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
			this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
			this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
			this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
			this.categoryDataGridViewTextBoxColumn.Width = 80;
			// 
			// urlDataGridViewTextBoxColumn
			// 
			this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
			this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
			this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
			this.urlDataGridViewTextBoxColumn.ReadOnly = true;
			this.urlDataGridViewTextBoxColumn.Width = 280;
			// 
			// streetBindingSource2
			// 
			this.streetBindingSource2.DataSource = typeof(BgStreetParser.Street);
			// 
			// streetBindingSource
			// 
			this.streetBindingSource.DataSource = typeof(BgStreetParser.Street);
			// 
			// streetBindingSource1
			// 
			this.streetBindingSource1.DataSource = typeof(BgStreetParser.Street);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(577, 82);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "MAP";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1034, 612);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "Gugl Pro Edition";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numProximitySensitivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.streetBindingSource1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource streetBindingSource;
		private System.Windows.Forms.BindingSource streetBindingSource2;
		private System.Windows.Forms.BindingSource streetBindingSource1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtCoord;
		private System.Windows.Forms.DataGridViewTextBoxColumn BigTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn District;
		private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
		private System.Windows.Forms.ComboBox cboDistricts;
		private System.Windows.Forms.NumericUpDown numProximitySensitivity;
		private System.Windows.Forms.Button button1;
	}
}

