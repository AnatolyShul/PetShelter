using System.Windows.Forms;

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

            int leftPanelWidth = 320;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите приют:";
            this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.comboShelters.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboShelters.FormattingEnabled = true;
            this.comboShelters.Location = new System.Drawing.Point(30, 55);
            this.comboShelters.Name = "comboShelters";
            this.comboShelters.Size = new System.Drawing.Size(leftPanelWidth - 60, 28);
            this.comboShelters.TabIndex = 0;
            this.comboShelters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип животного:";
            this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.comboPetType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboPetType.FormattingEnabled = true;
            this.comboPetType.Location = new System.Drawing.Point(30, 125);
            this.comboPetType.Name = "comboPetType";
            this.comboPetType.Size = new System.Drawing.Size(leftPanelWidth - 60, 28);
            this.comboPetType.TabIndex = 1;
            this.comboPetType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Формат данных:";
            this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.comboFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboFormat.FormattingEnabled = true;
            this.comboFormat.Location = new System.Drawing.Point(30, 195);
            this.comboFormat.Name = "comboFormat";
            this.comboFormat.Size = new System.Drawing.Size(leftPanelWidth - 60, 28);
            this.comboFormat.TabIndex = 2;
            this.comboFormat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.checkOpenArea.AutoSize = true;
            this.checkOpenArea.Location = new System.Drawing.Point(30, 250);
            this.checkOpenArea.Name = "checkOpenArea";
            this.checkOpenArea.Size = new System.Drawing.Size(269, 24);
            this.checkOpenArea.TabIndex = 6;
            this.checkOpenArea.Text = "Только с открытой площадкой";
            this.checkOpenArea.UseVisualStyleBackColor = true;
            this.checkOpenArea.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.checkClaustrophobic.AutoSize = true;
            this.checkClaustrophobic.Location = new System.Drawing.Point(30, 290);
            this.checkClaustrophobic.Name = "checkClaustrophobic";
            this.checkClaustrophobic.Size = new System.Drawing.Size(241, 24);
            this.checkClaustrophobic.TabIndex = 7;
            this.checkClaustrophobic.Text = "Показать клаустрофобных";
            this.checkClaustrophobic.UseVisualStyleBackColor = true;
            this.checkClaustrophobic.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.btnShowPets.Location = new System.Drawing.Point(30, 400);
            this.btnShowPets.Name = "btnShowPets";
            this.btnShowPets.Size = new System.Drawing.Size(200, 40);
            this.btnShowPets.TabIndex = 3;
            this.btnShowPets.Text = "Показать питомцев";
            this.btnShowPets.UseVisualStyleBackColor = true;
            this.btnShowPets.Click += new System.EventHandler(this.btnShowPets_Click);
            this.btnShowPets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnGenerate.Location = new System.Drawing.Point(250, 400);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Сгенерировать данные";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnSave.Location = new System.Drawing.Point(30, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.btnLoad.Location = new System.Drawing.Point(250, 460);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 40);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(700, 500);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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