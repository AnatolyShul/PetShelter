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

            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(150, 20);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(200, 28);
            this.comboType.TabIndex = 0;

            this.txtName.Location = new System.Drawing.Point(150, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 1;

            this.numAge.Location = new System.Drawing.Point(150, 100);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(200, 26);
            this.numAge.TabIndex = 2;

            this.numWeight.Location = new System.Drawing.Point(150, 140);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(200, 26);
            this.numWeight.TabIndex = 3;

            this.checkClaustrophobic.AutoSize = true;
            this.checkClaustrophobic.Location = new System.Drawing.Point(150, 180);
            this.checkClaustrophobic.Name = "checkClaustrophobic";
            this.checkClaustrophobic.Size = new System.Drawing.Size(200, 24);
            this.checkClaustrophobic.TabIndex = 4;
            this.checkClaustrophobic.Text = "Клаустрофобный";
            this.checkClaustrophobic.UseVisualStyleBackColor = true;

            this.panelSpecific.Location = new System.Drawing.Point(20, 220);
            this.panelSpecific.Name = "panelSpecific";
            this.panelSpecific.Size = new System.Drawing.Size(360, 100);
            this.panelSpecific.TabIndex = 5;

            this.btnSave.Location = new System.Drawing.Point(20, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(200, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Тип:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Кличка:";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Возраст:";

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Вес:";

            this.ClientSize = new System.Drawing.Size(400, 400);
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