using System.Windows.Forms;

namespace PetShelter
{
    partial class PetForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridPets = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddPet = new System.Windows.Forms.Button();
            this.btnDeletePet = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPets)).BeginInit();
            this.SuspendLayout();

            this.dataGridPets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPets.Location = new System.Drawing.Point(20, 60);
            this.dataGridPets.Name = "dataGridPets";
            this.dataGridPets.RowHeadersWidth = 62;
            this.dataGridPets.Size = new System.Drawing.Size(1140, 400);
            this.dataGridPets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridPets.TabIndex = 0;
            this.dataGridPets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Колонки растягиваются

            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 20);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(70, 20);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Всего: 0";
            this.lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            int btnY = 480;

            this.btnAddPet.Location = new System.Drawing.Point(20, 480);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(180, 35);
            this.btnAddPet.TabIndex = 3;
            this.btnAddPet.Text = "Добавить питомца";
            this.btnAddPet.UseVisualStyleBackColor = true;
            this.btnAddPet.Click += new System.EventHandler(this.btnAddPet_Click);
            this.btnAddPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnDeletePet.Location = new System.Drawing.Point(220, 480);
            this.btnDeletePet.Name = "btnDeletePet";
            this.btnDeletePet.Size = new System.Drawing.Size(180, 35);
            this.btnDeletePet.TabIndex = 4;
            this.btnDeletePet.Text = "Удалить питомца";
            this.btnDeletePet.UseVisualStyleBackColor = true;
            this.btnDeletePet.Click += new System.EventHandler(this.btnDeletePet_Click);
            this.btnDeletePet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnSaveReport.Location = new System.Drawing.Point(420, 480);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(180, 35);
            this.btnSaveReport.TabIndex = 5;
            this.btnSaveReport.Text = "Сохранить отчет";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            this.btnSaveReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnClose.Location = new System.Drawing.Point(1040, 480);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 540);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.btnDeletePet);
            this.Controls.Add(this.btnAddPet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dataGridPets);
            this.Name = "PetForm";
            this.Text = "Список питомцев";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized; // ← НА ВЕСЬ ЭКРАН
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridPets;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.Button btnDeletePet;
        private System.Windows.Forms.Button btnSaveReport;
    }
}