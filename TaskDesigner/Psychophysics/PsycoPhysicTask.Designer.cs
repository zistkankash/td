using System.Windows.Forms;

namespace Psychophysics
{
	partial class PsycoPhysicTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PsycoPhysicTask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvConds = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._repeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewTask = new System.Windows.Forms.Button();
            this.btnEditCond = new System.Windows.Forms.Button();
            this.btnRemCond = new System.Windows.Forms.Button();
            this.btnAddCond = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPreStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvConds)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.dtgvConds);
            this.panel1.Location = new System.Drawing.Point(71, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 394);
            this.panel1.TabIndex = 0;
            // 
            // dtgvConds
            // 
            this.dtgvConds.AllowUserToAddRows = false;
            this.dtgvConds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvConds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvConds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._name,
            this._repeat,
            this._frame,
            this._time});
            this.dtgvConds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvConds.Location = new System.Drawing.Point(0, 0);
            this.dtgvConds.MultiSelect = false;
            this.dtgvConds.Name = "dtgvConds";
            this.dtgvConds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvConds.Size = new System.Drawing.Size(472, 394);
            this.dtgvConds.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEditCond);
            this.panel2.Controls.Add(this.btnRemCond);
            this.panel2.Controls.Add(this.btnAddCond);
            this.panel2.Location = new System.Drawing.Point(4, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(61, 394);
            this.panel2.TabIndex = 6;
            // 
            // _name
            // 
            this._name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._name.HeaderText = "Name";
            this._name.Name = "_name";
            // 
            // _repeat
            // 
            this._repeat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._repeat.HeaderText = "Repeats";
            this._repeat.Name = "_repeat";
            // 
            // _frame
            // 
            this._frame.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._frame.HeaderText = "Frames";
            this._frame.Name = "_frame";
            this._frame.ReadOnly = true;
            // 
            // _time
            // 
            this._time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._time.HeaderText = "Time";
            this._time.Name = "_time";
            this._time.ReadOnly = true;
            // 
            // btnNewTask
            // 
            this.btnNewTask.BackColor = System.Drawing.Color.Transparent;
            this.btnNewTask.BackgroundImage = global::TaskDesigner.Resource.New;
            this.btnNewTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewTask.Enabled = false;
            this.btnNewTask.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnNewTask.FlatAppearance.BorderSize = 0;
            this.btnNewTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNewTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTask.Location = new System.Drawing.Point(306, 403);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(44, 45);
            this.btnNewTask.TabIndex = 130;
            this.toolTip1.SetToolTip(this.btnNewTask, "New Task");
            this.btnNewTask.UseVisualStyleBackColor = false;
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnEditCond
            // 
            this.btnEditCond.BackColor = System.Drawing.Color.Transparent;
            this.btnEditCond.BackgroundImage = global::TaskDesigner.Resource.Edit;
            this.btnEditCond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditCond.Enabled = false;
            this.btnEditCond.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnEditCond.FlatAppearance.BorderSize = 0;
            this.btnEditCond.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditCond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCond.Location = new System.Drawing.Point(3, 69);
            this.btnEditCond.Name = "btnEditCond";
            this.btnEditCond.Size = new System.Drawing.Size(55, 55);
            this.btnEditCond.TabIndex = 131;
            this.toolTip1.SetToolTip(this.btnEditCond, "Edit Condition");
            this.btnEditCond.UseVisualStyleBackColor = false;
            // 
            // btnRemCond
            // 
            this.btnRemCond.BackColor = System.Drawing.Color.Transparent;
            this.btnRemCond.BackgroundImage = global::TaskDesigner.Resource.delete;
            this.btnRemCond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemCond.Enabled = false;
            this.btnRemCond.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnRemCond.FlatAppearance.BorderSize = 0;
            this.btnRemCond.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemCond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemCond.Location = new System.Drawing.Point(3, 138);
            this.btnRemCond.Name = "btnRemCond";
            this.btnRemCond.Size = new System.Drawing.Size(55, 55);
            this.btnRemCond.TabIndex = 130;
            this.toolTip1.SetToolTip(this.btnRemCond, "Remove Condition");
            this.btnRemCond.UseVisualStyleBackColor = false;
            // 
            // btnAddCond
            // 
            this.btnAddCond.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCond.BackgroundImage = global::TaskDesigner.Resource.add;
            this.btnAddCond.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddCond.Enabled = false;
            this.btnAddCond.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAddCond.FlatAppearance.BorderSize = 0;
            this.btnAddCond.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddCond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCond.ForeColor = System.Drawing.Color.White;
            this.btnAddCond.Location = new System.Drawing.Point(3, 3);
            this.btnAddCond.Name = "btnAddCond";
            this.btnAddCond.Size = new System.Drawing.Size(55, 55);
            this.btnAddCond.TabIndex = 129;
            this.btnAddCond.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = global::TaskDesigner.Resource.Save2;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(432, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 44);
            this.btnSave.TabIndex = 129;
            this.toolTip1.SetToolTip(this.btnSave, "Save Task");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BackgroundImage = global::TaskDesigner.Resource.Open1;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpen.Enabled = false;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(368, 404);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(45, 45);
            this.btnOpen.TabIndex = 128;
            this.toolTip1.SetToolTip(this.btnOpen, "Open Task");
            this.btnOpen.UseVisualStyleBackColor = false;
            // 
            // btnPreStart
            // 
            this.btnPreStart.AutoEllipsis = true;
            this.btnPreStart.BackColor = System.Drawing.Color.Transparent;
            this.btnPreStart.BackgroundImage = global::TaskDesigner.Resource.Run2;
            this.btnPreStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPreStart.FlatAppearance.BorderSize = 0;
            this.btnPreStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPreStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPreStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreStart.Location = new System.Drawing.Point(495, 402);
            this.btnPreStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreStart.Name = "btnPreStart";
            this.btnPreStart.Size = new System.Drawing.Size(48, 48);
            this.btnPreStart.TabIndex = 2;
            this.btnPreStart.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPreStart, "Preview of Task");
            this.btnPreStart.UseMnemonic = false;
            this.btnPreStart.UseVisualStyleBackColor = false;
            this.btnPreStart.Click += new System.EventHandler(this.Start_PB_Click);
            // 
            // PsycoPhysicTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(545, 455);
            this.Controls.Add(this.btnNewTask);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPreStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PsycoPhysicTask";
            this.Tag = "TaskP";
            this.Text = "TaskPreview";
            this.Load += new System.EventHandler(this.TaskPreview_Load);
            this.VisibleChanged += new System.EventHandler(this.TaskPreview_VisibleChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvConds)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPreStart;
		private ToolTip toolTip1;
        private Button btnOpen;
        private Button btnSave;
        private Panel panel2;
        private DataGridView dtgvConds;
        private Button btnRemCond;
        private Button btnAddCond;
        private Button btnNewTask;
        private Button btnEditCond;
        private DataGridViewTextBoxColumn _name;
        private DataGridViewTextBoxColumn _repeat;
        private DataGridViewTextBoxColumn _frame;
        private DataGridViewTextBoxColumn _time;
    }
}