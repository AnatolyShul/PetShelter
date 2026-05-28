namespace PetShelter
{
    partial class MainForm
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
            this.comboShelters = new System.Windows.Forms.ComboBox();
            this.comboPetType = new System.Windows.Forms.ComboBox();
            this.comboFormat = new System.Windows.Forms.ComboBox();
            this.btnShowPets = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.checkOpenArea = new System.Windows.Forms.CheckBox();
            this.checkClaustrophobic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.comboShelters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboShelters.FormattingEnabled = true;
            this.comboShelters.Location = new System.Drawing.Point(200, 30);
            this.comboShelters.Name = "comboShelters";
            this.comboShelters.Size = new System.Drawing.Size(250, 28);
            this.comboShelters.TabIndex = 0;

            this.comboPetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPetType.FormattingEnabled = true;
            this.comboPetType.Location = new System.Drawing.Point(200, 80);
            this.comboPetType.Name = "comboPetType";
            this.comboPetType.Size = new System.Drawing.Size(250, 28);
            this.comboPetType.TabIndex = 1;

            this.comboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFormat.FormattingEnabled = true;
            this.comboFormat.Location = new System.Drawing.Point(200, 130);
            this.comboFormat.Name = "comboFormat";
            this.comboFormat.Size = new System.Drawing.Size(250, 28);
            this.comboFormat.TabIndex = 2;

            this.btnShowPets.Location = new System.Drawing.Point(30, 330);
            this.btnShowPets.Name = "btnShowPets";
            this.btnShowPets.Size = new System.Drawing.Size(200, 40);
            this.btnShowPets.TabIndex = 3;
            this.btnShowPets.Text = "Показать питомцев";
            this.btnShowPets.UseVisualStyleBackColor = true;
            this.btnShowPets.Click += new System.EventHandler(this.btnShowPets_Click);

            this.btnSave.Location = new System.Drawing.Point(30, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnLoad.Location = new System.Drawing.Point(250, 390);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 40);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.checkOpenArea.AutoSize = true;
            this.checkOpenArea.Location = new System.Drawing.Point(30, 230);
            this.checkOpenArea.Name = "checkOpenArea";
            this.checkOpenArea.Size = new System.Drawing.Size(269, 24);
            this.checkOpenArea.TabIndex = 6;
            this.checkOpenArea.Text = "Только с открытой площадкой";
            this.checkOpenArea.UseVisualStyleBackColor = true;

            this.checkClaustrophobic.AutoSize = true;
            this.checkClaustrophobic.Location = new System.Drawing.Point(30, 270);
            this.checkClaustrophobic.Name = "checkClaustrophobic";
            this.checkClaustrophobic.Size = new System.Drawing.Size(241, 24);
            this.checkClaustrophobic.TabIndex = 7;
            this.checkClaustrophobic.Text = "Показать клаустрофобных";
            this.checkClaustrophobic.UseVisualStyleBackColor = true;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите приют:";

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип животного:";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Формат данных:";

            this.btnGenerate.Location = new System.Drawing.Point(250, 330);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Сгенерировать данные";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            this.ClientSize = new System.Drawing.Size(500, 460);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkClaustrophobic);
            this.Controls.Add(this.checkOpenArea);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowPets);
            this.Controls.Add(this.comboFormat);
            this.Controls.Add(this.comboPetType);
            this.Controls.Add(this.comboShelters);
            this.Name = "MainForm";
            this.Text = "PetShelter";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboShelters;
        private System.Windows.Forms.ComboBox comboPetType;
        private System.Windows.Forms.ComboBox comboFormat;
        private System.Windows.Forms.Button btnShowPets;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox checkOpenArea;
        private System.Windows.Forms.CheckBox checkClaustrophobic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
    }
}