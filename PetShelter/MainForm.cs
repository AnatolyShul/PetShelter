using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PetShelter.Model.Core;
using PetShelter.Model.Data;

namespace PetShelter
{
    public partial class MainForm : Form
    {
        private List<Shelter> shelters;
        private SerializerBase serializer;
        private string dataPath = "shelters.json";

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            shelters = DataGenerator.GenerateData();
            FillShelterCombo();
            SaveData();
            MessageBox.Show("Данные сгенерированы!");
        }
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            // При первом запуске — создать данные
            if (!File.Exists(dataPath))
            {
                shelters = DataGenerator.GenerateData();
                SaveData();
            }
            else
            {
                LoadData();
            }

            FillShelterCombo();
            FillPetTypeCombo();
        }

        private void FillShelterCombo()
        {
            comboShelters.Items.Clear();
            comboShelters.Items.Add("Все приюты");
            foreach (var shelter in shelters)
            {
                comboShelters.Items.Add(shelter.Name);
            }
            comboShelters.SelectedIndex = 0;
        }

        private void FillPetTypeCombo()
        {
            comboPetType.Items.Clear();
            comboPetType.Items.Add("Все");
            comboPetType.Items.Add("Кошка");
            comboPetType.Items.Add("Собака");
            comboPetType.Items.Add("Кролик");
            comboPetType.Items.Add("Попугай");
            comboPetType.Items.Add("Обезьяна");
            comboPetType.SelectedIndex = 0;
        }


        private List<Shelter> GetSelectedShelters()
        {
            if (comboShelters.SelectedIndex == 0)
                return shelters;

            string selectedName = comboShelters.SelectedItem.ToString();
            return shelters.Where(s => s.Name == selectedName).ToList();
        }

        private List<Pet> FilterPets(List<Shelter> selectedShelters)
        {
            var allPets = new List<Pet> ();
            foreach (var shelter in selectedShelters)
            {
                allPets.AddRange(shelter.GetPets());
            }

            // Фильтр по типу
            if (comboPetType.SelectedIndex > 0)
            {
                Type targetType = GetTypeFromCombo();
                allPets = allPets.Where(p => p.GetType() == targetType).ToList();
            }

            // Фильтр по клаустрофобии
            if (checkClaustrophobic.Checked)
            {
                allPets = allPets.Where(p => p.IsClaustrophobic).ToList();
            }

            // Фильтр по открытой площадке (ищем только приюты с открытой площадкой)
            if (checkOpenArea.Checked)
            {
                var openAreaShelters = selectedShelters.Where(s => s.HasOpenArea).ToList();
                allPets = allPets.Where(p => openAreaShelters.Any(s => s.GetPets().Contains(p))).ToList();
            }

            return allPets;
        }

        private Type GetTypeFromCombo()
        {
            switch (comboPetType.SelectedIndex)
            {
                case 1: return typeof(Cat);
                case 2: return typeof(Dog);
                case 3: return typeof(Rabbit);
                case 4: return typeof(Parrot);
                case 5: return typeof(Monkey);
                default: return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Данные сохранены!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            FillShelterCombo();
            MessageBox.Show("Данные загружены!");
        }

        private void SaveData()
        {
            serializer = new JsonDataSerializer(dataPath);
            serializer.Serialize(shelters);
        }

        private void LoadData()
        {
            serializer = new JsonDataSerializer(dataPath);
            shelters = serializer.Deserialize();
        }

        private void btnShowPets_Click(object sender, EventArgs e)
        {
            var selectedShelters = GetSelectedShelters();
            var filteredPets = FilterPets(selectedShelters);

            // Найти текущий приют для добавления
            Shelter current = null;
            if (comboShelters.SelectedIndex > 0)
                current = selectedShelters.FirstOrDefault();
            else
                current = shelters.FirstOrDefault();

            var petForm = new PetForm(filteredPets, shelters, current);
            petForm.ShowDialog();
        }
    }
}