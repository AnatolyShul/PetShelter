using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PetShelter.Model.Core;
using PetShelter.Model.Data;

namespace PetShelter
{
    public partial class PetForm : Form
    {
        private List<Pet> pets;
        private List<Shelter> shelters;
        private Shelter currentShelter;
        private MainForm mainForm;
        private bool useJson;
        private string reportsDir;
        private ReportSerializerBase reportSerializer;

        public PetForm(List<Pet> pets, List<Shelter> shelters, Shelter selectedShelter = null,
    MainForm main = null, bool isJson = true, string reportsDirectory = "Reports")
        {
            InitializeComponent();
            this.pets = pets ?? new List<Pet>();
            this.shelters = shelters ?? new List<Shelter>();
            this.currentShelter = selectedShelter;
            this.mainForm = main;
            this.useJson = isJson;
            this.reportsDir = reportsDirectory;
            this.reportSerializer = ReportSerializerBase.CreateSerializer(reportsDir, isJson);
            DisplayPets();
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            btnAddPet.Enabled = currentShelter != null;
        }

        private void DisplayPets()
        {
            dataGridPets.Columns.Clear();
            dataGridPets.AutoGenerateColumns = false;
            dataGridPets.ReadOnly = true;
            dataGridPets.AllowUserToAddRows = false;
            dataGridPets.AllowUserToDeleteRows = false;
            dataGridPets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridPets.Columns.Add(CreateColumn("Index", "№", 40));
            dataGridPets.Columns.Add(CreateColumn("Name", "Кличка", 100));
            dataGridPets.Columns.Add(CreateColumn("Type", "Тип", 80));
            dataGridPets.Columns.Add(CreateColumn("Age", "Возраст", 70));
            dataGridPets.Columns.Add(CreateColumn("Weight", "Вес", 60));
            dataGridPets.Columns.Add(CreateColumn("Claustrophobic", "Клаустрофобия", 110));
            dataGridPets.Columns.Add(CreateColumn("Prop1", "Свойство 1", 200));
            dataGridPets.Columns.Add(CreateColumn("Prop2", "Свойство 2", 200));

            int index = 1;
            foreach (var pet in pets)
            {
                string type = pet.GetType().Name;
                string claustrophobic = pet.IsClaustrophobic ? "Да" : "Нет";
                string prop1 = "";
                string prop2 = "";

                switch (pet)
                {
                    case Cat c:
                        prop1 = "Домашняя: " + (c.IsIndoor ? "да" : "нет");
                        prop2 = "Дружелюбная: " + (c.IsFriendly ? "да" : "нет");
                        break;
                    case Dog d:
                        prop1 = "Дрессирована: " + (d.IsTrained ? "да" : "нет");
                        prop2 = "Сторожевая: " + (d.IsGuardDog ? "да" : "нет");
                        break;
                    case Rabbit r:
                        prop1 = "Приучен к лотку: " + (r.IsLitterTrained ? "да" : "нет");
                        prop2 = "Длинношерстный: " + (r.IsLongHaired ? "да" : "нет");
                        break;
                    case Parrot p:
                        prop1 = "Умеет говорить: " + (p.CanTalk ? "да" : "нет");
                        prop2 = "Поет: " + (p.IsSinging ? "да" : "нет");
                        break;
                    case Monkey m:
                        prop1 = "Длиннохвостый: " + (m.IsLongTailed ? "да" : "нет");
                        prop2 = "Социальный: " + (m.IsSocial ? "да" : "нет");
                        break;
                }

                dataGridPets.Rows.Add(index, pet.Name, type, pet.Age, pet.Weight, claustrophobic, prop1, prop2);
                index++;
            }

            lblCount.Text = $"Всего: {pets.Count}";
        }

        private DataGridViewColumn CreateColumn(string name, string header, int width)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                Width = width,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            if (currentShelter == null)
            {
                MessageBox.Show("Выберите конкретный приют для добавления питомца!");
                return;
            }

            var addForm = new AddPetForm(currentShelter);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshPetsAfterAdd();
            }
        }

        private void RefreshPetsAfterAdd()
        {
            if (mainForm != null)
            {
                mainForm.ApplyFiltersAfterChange();
                var selectedShelters = mainForm.GetSelectedShelters();
                pets = mainForm.FilterPets(selectedShelters);
            }
            else
            {
                pets.Clear();
                foreach (var shelter in shelters)
                {
                    pets.AddRange(shelter.GetPets());
                }
            }
            DisplayPets();
        }

        private void btnDeletePet_Click(object sender, EventArgs e)
        {
            if (dataGridPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите питомца для удаления!");
                return;
            }

            int index = dataGridPets.SelectedRows[0].Index;
            if (index < 0 || index >= pets.Count) return;

            var petToDelete = pets[index];
            var result = MessageBox.Show($"Удалить {petToDelete.Name}?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                foreach (var shelter in shelters)
                {
                    shelter.RemovePet(petToDelete);
                }
                RefreshPetsAfterDelete();
            }
        }

        private void RefreshPetsAfterDelete()
        {
            if (mainForm != null)
            {
                mainForm.ApplyFiltersAfterChange();
                var selectedShelters = mainForm.GetSelectedShelters();
                pets = mainForm.FilterPets(selectedShelters);
            }
            else
            {
                pets.Clear();
                foreach (var shelter in shelters)
                {
                    pets.AddRange(shelter.GetPets());
                }
            }
            DisplayPets();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"Подборка_{pets.Count}_от_{timestamp}";

                reportSerializer.SaveReport(fileName, pets);

                string ext = useJson ? "json" : "xml";
                MessageBox.Show($"Отчет сохранен: {fileName}.{ext}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения отчета: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}