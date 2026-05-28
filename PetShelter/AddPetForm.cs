using System;
using System.Windows.Forms;
using PetShelter.Model.Core;

namespace PetShelter
{
    public partial class AddPetForm : Form
    {
        private Shelter targetShelter;
        public Pet CreatedPet { get; private set; }

        public AddPetForm(Shelter shelter)
        {
            if (shelter == null)
                throw new ArgumentNullException(nameof(shelter));
            InitializeComponent();
            targetShelter = shelter;
            SetupForm();
        }

        private void SetupForm()
        {
            comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboType.Items.AddRange(new object[] { "Кошка", "Собака", "Кролик", "Попугай", "Обезьяна" });
            comboType.SelectedIndex = 0;

            numAge.Minimum = 0;
            numAge.Maximum = 50;
            numWeight.Minimum = 0;
            numWeight.Maximum = 500;
            numWeight.DecimalPlaces = 1;

            comboType.SelectedIndexChanged += comboType_SelectedIndexChanged;
            comboType_SelectedIndexChanged(null, null);
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSpecific.Controls.Clear();

            switch (comboType.SelectedIndex)
            {
                case 0:
                    AddSpecificCheck("Домашняя", "checkIndoor");
                    AddSpecificCheck("Дружелюбная", "checkFriendly");
                    break;
                case 1:
                    AddSpecificCheck("Дрессирована", "checkTrained");
                    AddSpecificCheck("Сторожевая", "checkGuard");
                    break;
                case 2:
                    AddSpecificCheck("Приучен к лотку", "checkLitter");
                    AddSpecificCheck("Длинношерстный", "checkLongHaired");
                    break;
                case 3:
                    AddSpecificCheck("Умеет говорить", "checkCanTalk");
                    AddSpecificCheck("Поет", "checkIsSinging");
                    break;
                case 4:
                    AddSpecificCheck("Длиннохвостый", "checkLongTailed");
                    AddSpecificCheck("Социальный", "checkSocial");
                    break;
            }
        }

        private void AddSpecificCheck(string label, string name)
        {
            var chk = new CheckBox { Text = label, Name = name, Top = panelSpecific.Controls.Count * 30, Left = 0, Width = 270 };
            panelSpecific.Controls.Add(chk);
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
                    case 0:
                        newPet = new Cat(name, age, weight, isClaustrophobic,
                            GetCheck("checkIndoor"), GetCheck("checkFriendly"));
                        break;
                    case 1:
                        newPet = new Dog(name, age, weight, isClaustrophobic,
                            GetCheck("checkTrained"), GetCheck("checkGuard"));
                        break;
                    case 2:
                        newPet = new Rabbit(name, age, weight, isClaustrophobic,
                            GetCheck("checkLitter"), GetCheck("checkLongHaired"));
                        break;
                    case 3:
                        newPet = new Parrot(name, age, weight, isClaustrophobic,
                            GetCheck("checkCanTalk"), GetCheck("checkIsSinging"));
                        break;
                    case 4:
                        newPet = new Monkey(name, age, weight, isClaustrophobic,
                            GetCheck("checkLongTailed"), GetCheck("checkSocial"));
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

        private bool GetCheck(string name)
        {
            var control = panelSpecific.Controls.Find(name, true);
            if (control.Length > 0 && control[0] is CheckBox chk)
                return chk.Checked;
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}