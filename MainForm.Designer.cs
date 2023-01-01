
namespace FileExplorer
{
    partial class MainForm
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
            this.BT_process_files = new System.Windows.Forms.Button();
            this.DGV_repo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_move_back = new System.Windows.Forms.Button();
            this.DGV_process_files = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_current_path = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_repo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_process_files)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_process_files
            // 
            this.BT_process_files.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_process_files.Location = new System.Drawing.Point(403, 313);
            this.BT_process_files.Name = "BT_process_files";
            this.BT_process_files.Size = new System.Drawing.Size(100, 30);
            this.BT_process_files.TabIndex = 0;
            this.BT_process_files.Text = "Обработать";
            this.BT_process_files.UseVisualStyleBackColor = true;
            this.BT_process_files.Click += new System.EventHandler(this.BT_process_files_Click);
            // 
            // DGV_repo
            // 
            this.DGV_repo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_repo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_repo.ColumnHeadersVisible = false;
            this.DGV_repo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.DGV_repo.Location = new System.Drawing.Point(12, 43);
            this.DGV_repo.Name = "DGV_repo";
            this.DGV_repo.RowHeadersVisible = false;
            this.DGV_repo.RowHeadersWidth = 72;
            this.DGV_repo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DGV_repo.Size = new System.Drawing.Size(420, 264);
            this.DGV_repo.TabIndex = 1;
            this.DGV_repo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_repo_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 9;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 400;
            // 
            // BT_move_back
            // 
            this.BT_move_back.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_move_back.Location = new System.Drawing.Point(12, 14);
            this.BT_move_back.Name = "BT_move_back";
            this.BT_move_back.Size = new System.Drawing.Size(39, 23);
            this.BT_move_back.TabIndex = 2;
            this.BT_move_back.Text = "<—";
            this.BT_move_back.UseVisualStyleBackColor = true;
            this.BT_move_back.Click += new System.EventHandler(this.BT_move_back_Click);
            // 
            // DGV_process_files
            // 
            this.DGV_process_files.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_process_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_process_files.ColumnHeadersVisible = false;
            this.DGV_process_files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.DGV_process_files.Location = new System.Drawing.Point(476, 43);
            this.DGV_process_files.Name = "DGV_process_files";
            this.DGV_process_files.RowHeadersVisible = false;
            this.DGV_process_files.RowHeadersWidth = 72;
            this.DGV_process_files.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DGV_process_files.Size = new System.Drawing.Size(421, 264);
            this.DGV_process_files.TabIndex = 3;
            this.DGV_process_files.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_process_files_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 9;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 400;
            // 
            // TB_current_path
            // 
            this.TB_current_path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_current_path.Location = new System.Drawing.Point(57, 11);
            this.TB_current_path.Name = "TB_current_path";
            this.TB_current_path.ReadOnly = true;
            this.TB_current_path.Size = new System.Drawing.Size(375, 26);
            this.TB_current_path.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(909, 349);
            this.Controls.Add(this.TB_current_path);
            this.Controls.Add(this.DGV_process_files);
            this.Controls.Add(this.BT_move_back);
            this.Controls.Add(this.DGV_repo);
            this.Controls.Add(this.BT_process_files);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DGV_repo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_process_files)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_process_files;
        private System.Windows.Forms.DataGridView DGV_repo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button BT_move_back;
        private System.Windows.Forms.DataGridView DGV_process_files;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox TB_current_path;
    }
}

