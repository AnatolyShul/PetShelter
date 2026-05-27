namespace PetShelter
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
            this.comboShelters = new System.Windows.Forms.ComboBox();
            this.comboPetType = new System.Windows.Forms.ComboBox();
            this.btnShowPets = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.checkOpenArea = new System.Windows.Forms.CheckBox();
            this.checkClaustrophobic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboShelters
            // 
            this.comboShelters.FormattingEnabled = true;
            this.comboShelters.Location = new System.Drawing.Point(354, 141);
            this.comboShelters.Name = "comboShelters";
            this.comboShelters.Size = new System.Drawing.Size(130, 28);
            this.comboShelters.TabIndex = 0;
            // 
            // comboPetType
            // 
            this.comboPetType.FormattingEnabled = true;
            this.comboPetType.Location = new System.Drawing.Point(354, 206);
            this.comboPetType.Name = "comboPetType";
            this.comboPetType.Size = new System.Drawing.Size(130, 28);
            this.comboPetType.TabIndex = 1;
            // 
            // btnShowPets
            // 
            this.btnShowPets.Location = new System.Drawing.Point(211, 420);
            this.btnShowPets.Name = "btnShowPets";
            this.btnShowPets.Size = new System.Drawing.Size(121, 37);
            this.btnShowPets.TabIndex = 2;
            this.btnShowPets.Text = "Показать";
            this.btnShowPets.UseVisualStyleBackColor = true;
            this.btnShowPets.Click += new System.EventHandler(this.btnShowPets_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(211, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 37);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(370, 504);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 37);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // checkOpenArea
            // 
            this.checkOpenArea.AutoSize = true;
            this.checkOpenArea.Location = new System.Drawing.Point(211, 348);
            this.checkOpenArea.Name = "checkOpenArea";
            this.checkOpenArea.Size = new System.Drawing.Size(269, 24);
            this.checkOpenArea.TabIndex = 5;
            this.checkOpenArea.Text = "Только с открытой площадкой";
            this.checkOpenArea.UseVisualStyleBackColor = true;
            // 
            // checkClaustrophobic
            // 
            this.checkClaustrophobic.AutoSize = true;
            this.checkClaustrophobic.Location = new System.Drawing.Point(211, 282);
            this.checkClaustrophobic.Name = "checkClaustrophobic";
            this.checkClaustrophobic.Size = new System.Drawing.Size(241, 24);
            this.checkClaustrophobic.TabIndex = 6;
            this.checkClaustrophobic.Text = "Показать клаустрофобных";
            this.checkClaustrophobic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выберите приют:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Тип животного:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(370, 422);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(229, 35);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Сгенерировать данные";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1094, 683);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkClaustrophobic);
            this.Controls.Add(this.checkOpenArea);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowPets);
            this.Controls.Add(this.comboPetType);
            this.Controls.Add(this.comboShelters);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboShelters;
        private System.Windows.Forms.ComboBox comboPetType;
        private System.Windows.Forms.Button btnShowPets;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox checkOpenArea;
        private System.Windows.Forms.CheckBox checkClaustrophobic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
    }
}

