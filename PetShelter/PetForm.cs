using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PetShelter.Model.Core;

namespace PetShelter
{
    public partial class PetForm : Form
    {
        private List<Pet> pets;
        private List<Shelter> shelters;
        private Shelter currentShelter;  // текущий приют для добавления

        public PetForm(List<Pet> pets, List<Shelter> shelters, Shelter selectedShelter = null)
        {
            InitializeComponent();
            this.pets = pets;
            this.shelters = shelters;
            this.currentShelter = selectedShelter ?? shelters.FirstOrDefault();
            DisplayPets();
        }

        private void DisplayPets()
        {
            dataGridPets.Columns.Clear();
            dataGridPets.AutoGenerateColumns = false;
            dataGridPets.ReadOnly = true;
            dataGridPets.AllowUserToAddRows = false;
            dataGridPets.AllowUserToDeleteRows = false;
            dataGridPets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridPets.Columns.Add("Name", "Кличка");
            dataGridPets.Columns.Add("Type", "Тип");
            dataGridPets.Columns.Add("Age", "Возраст");
            dataGridPets.Columns.Add("Weight", "Вес");
            dataGridPets.Columns.Add("Claustrophobic", "Клаустрофобия");
            dataGridPets.Columns.Add("Details", "Детали");

            foreach (var pet in pets)
            {
                string type = pet.GetType().Name;
                string claustrophobic = pet.IsClaustrophobic ? "Да" : "Нет";
                dataGridPets.Rows.Add(pet.Name, type, pet.Age, pet.Weight, claustrophobic, pet.ToString());
            }

            lblCount.Text = $"Всего: {pets.Count}";
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            var addForm = new AddPetForm(currentShelter);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Обновить список
                RefreshPets();
            }
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
                // Найти приют, где живёт питомец, и удалить оттуда
                foreach (var shelter in shelters)
                {
                    shelter.RemovePet(petToDelete);
                }
                RefreshPets();
            }
        }

        private void RefreshPets()
        {
            // Пересобрать список питомцев из всех приютов
            pets.Clear();
            foreach (var shelter in shelters)
            {
                pets.AddRange(shelter.GetPets());
            }
            DisplayPets();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}