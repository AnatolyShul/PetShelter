using System;
using System.Windows.Forms;
using System.Xml.Linq;
using PetShelter.Model.Core;

namespace PetShelter
{
    public partial class AddPetForm : Form
    {
        private Shelter targetShelter;
        public Pet CreatedPet { get; private set; }

        public AddPetForm(Shelter shelter)
        {
            InitializeComponent();
            targetShelter = shelter;
            SetupForm();
        }

        private void SetupForm()
        {
            // Заполнить типы
            comboType.Items.AddRange(new object[] { "Кошка", "Собака", "Кролик", "Попугай", "Обезьяна" });
            comboType.SelectedIndex = 0;

            numAge.Minimum = 0;
            numAge.Maximum = 50;
            numWeight.Minimum = 0;
            numWeight.Maximum = 500;
            numWeight.DecimalPlaces = 1;
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очистить специфичные поля и добавить новые
            panelSpecific.Controls.Clear();

            switch (comboType.SelectedIndex)
            {
                case 0: // Кошка
                    AddSpecificField("Порода", "txtBreed");
                    AddSpecificCheck("Домашняя", "checkIndoor");
                    break;
                case 1: // Собака
                    AddSpecificField("Порода", "txtBreed");
                    AddSpecificCheck("Дрессирована", "checkTrained");
                    break;
                case 2: // Кролик
                    AddSpecificNumeric("Длина ушей (см)", "numEarLength", 0, 50);
                    AddSpecificCheck("Приучен к лотку", "checkLitter");
                    break;
                case 3: // Попугай
                    AddSpecificNumeric("Знает слов", "numWords", 0, 1000);
                    AddSpecificNumeric("Размах крыльев (см)", "numWingspan", 0, 100);
                    break;
                case 4: // Обезьяна
                    AddSpecificField("Вид", "txtSpecies");
                    AddSpecificNumeric("Длина хвоста (см)", "numTail", 0, 100);
                    break;
            }
        }

        private void AddSpecificField(string label, string name)
        {
            var lbl = new Label { Text = label, Top = panelSpecific.Controls.Count * 30, Left = 0 };
            var txt = new TextBox { Name = name, Top = lbl.Top, Left = 120, Width = 150 };
            panelSpecific.Controls.Add(lbl);
            panelSpecific.Controls.Add(txt);
        }

        private void AddSpecificCheck(string label, string name)
        {
            var chk = new CheckBox { Text = label, Name = name, Top = panelSpecific.Controls.Count * 30, Left = 0 };
            panelSpecific.Controls.Add(chk);
        }

        private void AddSpecificNumeric(string label, string name, int min, int max)
        {
            var lbl = new Label { Text = label, Top = panelSpecific.Controls.Count * 30, Left = 0 };
            var num = new NumericUpDown { Name = name, Top = lbl.Top, Left = 120, Minimum = min, Maximum = max };
            panelSpecific.Controls.Add(lbl);
            panelSpecific.Controls.Add(num);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Введите кличку!");
                    return;
                }

                int age = (int)numAge.Value;
                double weight = (double)numWeight.Value;
                bool isClaustrophobic = checkClaustrophobic.Checked;

                Pet newPet = null;

                switch (comboType.SelectedIndex)
                {
                    case 0: // Кошка
                        newPet = new Cat(name, age, weight, isClaustrophobic,
                            GetText("txtBreed"), GetCheck("checkIndoor"));
                        break;
                    case 1: // Собака
                        newPet = new Dog(name, age, weight, isClaustrophobic,
                            GetText("txtBreed"), GetCheck("checkTrained"));
                        break;
                    case 2: // Кролик
                        newPet = new Rabbit(name, age, weight, isClaustrophobic,
                            (int)GetNumeric("numEarLength"), GetCheck("checkLitter"));
                        break;
                    case 3: // Попугай
                        newPet = new Parrot(name, age, weight, isClaustrophobic,
                            (int)GetNumeric("numWords"), (int)GetNumeric("numWingspan"));
                        break;
                    case 4: // Обезьяна
                        newPet = new Monkey(name, age, weight, isClaustrophobic,
                            GetText("txtSpecies"), (int)GetNumeric("numTail"));
                        break;
                }

                targetShelter.AddPet(newPet);
                CreatedPet = newPet;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private string GetText(string name)
        {
            return (panelSpecific.Controls.Find(name, true)[0] as TextBox)?.Text ?? "";
        }

        private bool GetCheck(string name)
        {
            return (panelSpecific.Controls.Find(name, true)[0] as CheckBox)?.Checked ?? false;
        }

        private decimal GetNumeric(string name)
        {
            return (panelSpecific.Controls.Find(name, true)[0] as NumericUpDown)?.Value ?? 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}