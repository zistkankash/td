using TaskDesigner;
namespace Psychophysics
{
    partial class TaskPreviewM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_tasktablesbackground = new System.Windows.Forms.Panel();
            this.GridVu = new System.Windows.Forms.DataGridView();
            this.btn_preview = new MetroFramework.Controls.MetroButton();
            this.t_edit = new MetroFramework.Controls.MetroTile();
            this.t_delete = new MetroFramework.Controls.MetroTile();
            this.txbx_saveto = new MetroFramework.Controls.MetroTextBox();
            this.l_save = new MetroFramework.Controls.MetroLabel();
            this.chbx_showrandom = new MetroFramework.Controls.MetroCheckBox();
            this.t_load = new MetroFramework.Controls.MetroTile();
            this.t_new = new MetroFramework.Controls.MetroTile();
            this.pnl_tasktablesbackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridVu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_tasktablesbackground
            // 
            this.pnl_tasktablesbackground.AutoScroll = true;
            this.pnl_tasktablesbackground.BackColor = System.Drawing.Color.Transparent;
            this.pnl_tasktablesbackground.Controls.Add(this.GridVu);
            this.pnl_tasktablesbackground.Location = new System.Drawing.Point(106, 40);
            this.pnl_tasktablesbackground.Name = "pnl_tasktablesbackground";
            this.pnl_tasktablesbackground.Size = new System.Drawing.Size(503, 366);
            this.pnl_tasktablesbackground.TabIndex = 1;
            // 
            // GridVu
            // 
            this.GridVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridVu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridVu.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridVu.GridColor = System.Drawing.Color.White;
            this.GridVu.Location = new System.Drawing.Point(0, 0);
            this.GridVu.Name = "GridVu";
            this.GridVu.ReadOnly = true;
            this.GridVu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.GridVu.RowHeadersVisible = false;
            this.GridVu.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GridVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridVu.Size = new System.Drawing.Size(503, 366);
            this.GridVu.TabIndex = 5;
            this.GridVu.Visible = false;
            this.GridVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVu_CellClick);
            this.GridVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVu_CellContentClick);
            this.GridVu.SelectionChanged += new System.EventHandler(this.GridVu_SelectionChanged);
            // 
            // btn_preview
            // 
            this.btn_preview.Location = new System.Drawing.Point(23, 412);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(75, 23);
            this.btn_preview.TabIndex = 5;
            this.btn_preview.Text = "Preview";
            this.btn_preview.UseSelectable = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // t_edit
            // 
            this.t_edit.ActiveControl = null;
            this.t_edit.Location = new System.Drawing.Point(23, 225);
            this.t_edit.Name = "t_edit";
            this.t_edit.Size = new System.Drawing.Size(77, 76);
            this.t_edit.TabIndex = 3;
            this.t_edit.TileImage = Resource.Edit;
            this.t_edit.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_edit.UseSelectable = true;
            this.t_edit.UseTileImage = true;
            this.t_edit.Click += new System.EventHandler(this.t_edit_Click);
            // 
            // t_delete
            // 
            this.t_delete.ActiveControl = null;
            this.t_delete.Location = new System.Drawing.Point(23, 319);
            this.t_delete.Name = "t_delete";
            this.t_delete.Size = new System.Drawing.Size(77, 76);
            this.t_delete.Style = MetroFramework.MetroColorStyle.Red;
            this.t_delete.TabIndex = 5;
            this.t_delete.TileImage = Resource.delete;
            this.t_delete.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_delete.UseSelectable = true;
            this.t_delete.UseTileImage = true;
            this.t_delete.Click += new System.EventHandler(this.t_delete_Click);
            // 
            // txbx_saveto
            // 
            // 
            // 
            // 
            this.txbx_saveto.CustomButton.Image = null;
            this.txbx_saveto.CustomButton.Location = new System.Drawing.Point(225, 1);
            this.txbx_saveto.CustomButton.Name = "";
            this.txbx_saveto.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbx_saveto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbx_saveto.CustomButton.TabIndex = 1;
            this.txbx_saveto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbx_saveto.CustomButton.UseSelectable = true;
            this.txbx_saveto.CustomButton.Visible = false;
            this.txbx_saveto.Lines = new string[0];
            this.txbx_saveto.Location = new System.Drawing.Point(80, 451);
            this.txbx_saveto.MaxLength = 32767;
            this.txbx_saveto.Name = "txbx_saveto";
            this.txbx_saveto.PasswordChar = '\0';
            this.txbx_saveto.WaterMark = "choose address";
            this.txbx_saveto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbx_saveto.SelectedText = "";
            this.txbx_saveto.SelectionLength = 0;
            this.txbx_saveto.SelectionStart = 0;
            this.txbx_saveto.ShortcutsEnabled = true;
            this.txbx_saveto.Size = new System.Drawing.Size(247, 23);
            this.txbx_saveto.TabIndex = 6;
            this.txbx_saveto.UseSelectable = true;
            this.txbx_saveto.WaterMark = "choose address";
            this.txbx_saveto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbx_saveto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbx_saveto.Click += new System.EventHandler(this.txbx_saveto_Click);
            // 
            // l_save
            // 
            this.l_save.AutoSize = true;
            this.l_save.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.l_save.Location = new System.Drawing.Point(11, 451);
            this.l_save.Name = "l_save";
            this.l_save.Size = new System.Drawing.Size(63, 19);
            this.l_save.TabIndex = 5;
            this.l_save.Text = "Save to ";
            // 
            // chbx_showrandom
            // 
            this.chbx_showrandom.AutoSize = true;
            this.chbx_showrandom.Location = new System.Drawing.Point(513, 455);
            this.chbx_showrandom.Name = "chbx_showrandom";
            this.chbx_showrandom.Size = new System.Drawing.Size(96, 15);
            this.chbx_showrandom.TabIndex = 7;
            this.chbx_showrandom.Text = "show random";
            this.chbx_showrandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbx_showrandom.UseSelectable = true;
            // 
            // t_load
            // 
            this.t_load.ActiveControl = null;
            this.t_load.Location = new System.Drawing.Point(23, 133);
            this.t_load.Name = "t_load";
            this.t_load.Size = new System.Drawing.Size(77, 76);
            this.t_load.Style = MetroFramework.MetroColorStyle.Lime;
            this.t_load.TabIndex = 2;
            this.t_load.TileImage = Resource.Load;
            this.t_load.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_load.UseSelectable = true;
            this.t_load.UseTileImage = true;
            this.t_load.Click += new System.EventHandler(this.t_load_Click);
            // 
            // t_new
            // 
            this.t_new.ActiveControl = null;
            this.t_new.Location = new System.Drawing.Point(23, 40);
            this.t_new.Name = "t_new";
            this.t_new.Size = new System.Drawing.Size(77, 76);
            this.t_new.Style = MetroFramework.MetroColorStyle.Green;
            this.t_new.TabIndex = 0;
            this.t_new.TileImage = Resource.add;
            this.t_new.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_new.UseSelectable = true;
            this.t_new.UseTileImage = true;
            this.t_new.Click += new System.EventHandler(this.t_new_Click);
            // 
            // TaskPreviewM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 485);
            this.Controls.Add(this.btn_preview);
            this.Controls.Add(this.chbx_showrandom);
            this.Controls.Add(this.l_save);
            this.Controls.Add(this.txbx_saveto);
            this.Controls.Add(this.t_delete);
            this.Controls.Add(this.t_edit);
            this.Controls.Add(this.t_load);
            this.Controls.Add(this.pnl_tasktablesbackground);
            this.Controls.Add(this.t_new);
            this.Name = "TaskPreviewM";
            this.pnl_tasktablesbackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel l_save;
        public MetroFramework.Controls.MetroTile t_edit;
        public MetroFramework.Controls.MetroTile t_delete;
        public MetroFramework.Controls.MetroTextBox txbx_saveto;
        public MetroFramework.Controls.MetroCheckBox chbx_showrandom;
        public MetroFramework.Controls.MetroTile t_new;
        public MetroFramework.Controls.MetroTile t_load;
        public System.Windows.Forms.Panel pnl_tasktablesbackground;
        public MetroFramework.Controls.MetroButton btn_preview;
        public System.Windows.Forms.DataGridView GridVu;
    }
}