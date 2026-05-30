using System.Windows.Forms;

namespace PetShelter
{
    partial class AddPetForm
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
            this.comboType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.checkClaustrophobic = new System.Windows.Forms.CheckBox();
            this.panelSpecific = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.SuspendLayout();

            int margin = 30;
            int labelWidth = 120;
            int controlWidth = 250;
            int rowHeight = 45;
            int startY = 30;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(margin, startY);
            this.label1.Name = "label1";
            this.label1.Text = "Тип:";
            this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(margin + labelWidth, startY);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(controlWidth, 28);
            this.comboType.TabIndex = 0;
            this.comboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(margin, startY + rowHeight);
            this.label2.Name = "label2";
            this.label2.Text = "Кличка:";
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.txtName.Location = new System.Drawing.Point(margin + labelWidth, startY + rowHeight);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(controlWidth, 26);
            this.txtName.TabIndex = 1;
            this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(margin, startY + rowHeight * 2);
            this.label3.Name = "label3";
            this.label3.Text = "Возраст:";
            this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.numAge.Location = new System.Drawing.Point(margin + labelWidth, startY + rowHeight * 2);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(controlWidth, 26);
            this.numAge.TabIndex = 2;
            this.numAge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(margin, startY + rowHeight * 3);
            this.label4.Name = "label4";
            this.label4.Text = "Вес:";
            this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.numWeight.Location = new System.Drawing.Point(margin + labelWidth, startY + rowHeight * 3);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(controlWidth, 26);
            this.numWeight.TabIndex = 3;
            this.numWeight.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.checkClaustrophobic.AutoSize = true;
            this.checkClaustrophobic.Location = new System.Drawing.Point(margin + labelWidth, startY + rowHeight * 4);
            this.checkClaustrophobic.Name = "checkClaustrophobic";
            this.checkClaustrophobic.Size = new System.Drawing.Size(200, 24);
            this.checkClaustrophobic.TabIndex = 4;
            this.checkClaustrophobic.Text = "Клаустрофобный";
            this.checkClaustrophobic.UseVisualStyleBackColor = true;
            this.checkClaustrophobic.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.panelSpecific.Location = new System.Drawing.Point(margin, startY + rowHeight * 5);
            this.panelSpecific.Name = "panelSpecific";
            this.panelSpecific.Size = new System.Drawing.Size(labelWidth + controlWidth, 100);
            this.panelSpecific.TabIndex = 5;
            this.panelSpecific.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            this.btnSave.Location = new System.Drawing.Point(margin, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnCancel.Location = new System.Drawing.Point(margin + 180, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 470);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelSpecific);
            this.Controls.Add(this.checkClaustrophobic);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.comboType);
            this.Name = "AddPetForm";
            this.Text = "Добавить питомца";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.CheckBox checkClaustrophobic;
        private System.Windows.Forms.Panel panelSpecific;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}