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
        private SerializerBase currentSerializer;
        private ReportSerializerBase currentReportSerializer;
        private string jsonPath = "shelters.json";
        private string xmlPath = "shelters.xml";
        private string reportsDir = "Reports";
        private int lastShelterIndex = 0;
        private int lastPetTypeIndex = 0;
        private bool lastOpenAreaChecked = false;
        private bool lastClaustrophobicChecked = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeData();

        }

        private void InitializeData()
        {
            shelters = new List<Shelter>();

            FillShelterCombo();
            FillPetTypeCombo();
            FillFormatCombo();
            RestoreFilters();
        }

        private void SaveFilterState()
        {
            lastShelterIndex = comboShelters.SelectedIndex;
            lastPetTypeIndex = comboPetType.SelectedIndex;
            lastOpenAreaChecked = checkOpenArea.Checked;
            lastClaustrophobicChecked = checkClaustrophobic.Checked;
        }

        private void RestoreFilters()
        {
            if (lastShelterIndex >= 0 && lastShelterIndex < comboShelters.Items.Count)
                comboShelters.SelectedIndex = lastShelterIndex;
            else
                comboShelters.SelectedIndex = 0;

            if (lastPetTypeIndex >= 0 && lastPetTypeIndex < comboPetType.Items.Count)
                comboPetType.SelectedIndex = lastPetTypeIndex;
            else
                comboPetType.SelectedIndex = 0;

            checkOpenArea.Checked = lastOpenAreaChecked;
            checkClaustrophobic.Checked = lastClaustrophobicChecked;
        }

        private void FillShelterCombo()
        {
            comboShelters.Items.Clear();
            comboShelters.Items.Add("Все приюты");
            foreach (var shelter in shelters)
            {
                comboShelters.Items.Add(shelter.Name);
            }
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
        }

        private void FillFormatCombo()
        {
            comboFormat.Items.Clear();
            comboFormat.Items.Add("JSON");
            comboFormat.Items.Add("XML");
            comboFormat.SelectedIndex = 0;
            comboFormat.SelectedIndexChanged += comboFormat_SelectedIndexChanged;
            UpdateSerializers();
        }

        private void UpdateSerializers()
        {
            bool isJson = comboFormat.SelectedIndex == 0;
            string path = isJson ? jsonPath : xmlPath;
            currentSerializer = isJson
                ? (SerializerBase)new JsonDataSerializer(path)
                : new XmlDataSerializer(path);
            currentReportSerializer = ReportSerializerBase.CreateSerializer(reportsDir, isJson);
        }

        private void comboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool newIsJson = comboFormat.SelectedIndex == 0;
                string newPath = newIsJson ? jsonPath : xmlPath;
                var newSerializer = newIsJson
                    ? (SerializerBase)new JsonDataSerializer(newPath)
                    : new XmlDataSerializer(newPath);

                if (shelters != null && shelters.Count > 0)
                {
                    newSerializer.Serialize(shelters);
                }

                CopyReportsToNewFormat(newIsJson);

                UpdateSerializers();

                MessageBox.Show($"Формат изменён на {(newIsJson ? "JSON" : "XML")}. Данные и отчёты скопированы.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка смены формата: {ex.Message}");
            }
        }

        private void CopyReportsToNewFormat(bool newFormatIsJson)
        {
            bool oldFormatIsJson = !newFormatIsJson;

            var oldSerializer = ReportSerializerBase.CreateSerializer(reportsDir, oldFormatIsJson);
            var newSerializer = ReportSerializerBase.CreateSerializer(reportsDir + "_temp", newFormatIsJson);

            foreach (var file in oldSerializer.GetReportFiles())
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                var pets = oldSerializer.LoadReport(fileName);
                newSerializer.SaveReport(fileName, pets);
            }

            foreach (var file in oldSerializer.GetReportFiles())
            {
                File.Delete(file);
            }

            if (Directory.Exists(reportsDir + "_temp"))
            {
                foreach (var file in Directory.GetFiles(reportsDir + "_temp"))
                {
                    string dest = Path.Combine(reportsDir, Path.GetFileName(file));
                    File.Copy(file, dest, true);
                }
                Directory.Delete(reportsDir + "_temp", true);
            }
        }

        private Shelter GetSelectedShelter()
        {
            if (comboShelters.SelectedIndex <= 0 || comboShelters.SelectedIndex >= comboShelters.Items.Count)
                return null;
            string selectedName = comboShelters.SelectedItem.ToString();
            return shelters.FirstOrDefault(s => s.Name == selectedName);
        }

        public List<Shelter> GetSelectedShelters()
        {
            var result = new List<Shelter>();

            if (comboShelters.SelectedIndex == 0)
            {
                if (checkOpenArea.Checked)
                    result = shelters.Where(s => s.HasOpenArea).ToList();
                else
                    result = shelters;
            }
            else
            {
                var single = GetSelectedShelter();
                if (single != null)
                    result = new List<Shelter> { single };
            }

            return result;
        }

        public List<Pet> FilterPets(List<Shelter> selectedShelters)
        {
            var allPets = new List<Pet>();
            foreach (var shelter in selectedShelters)
            {
                allPets.AddRange(shelter.GetPets());
            }

            if (comboPetType.SelectedIndex > 0)
            {
                Type targetType = GetTypeFromCombo();
                allPets = allPets.Where(p => p.GetType() == targetType).ToList();
            }

            if (checkClaustrophobic.Checked)
            {
                allPets = allPets.Where(p => p.IsClaustrophobic).ToList();
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

        private void btnShowPets_Click(object sender, EventArgs e)
        {
            SaveFilterState();
            var selectedShelters = GetSelectedShelters();
            if (selectedShelters.Count == 0)
            {
                MessageBox.Show("Выберите существующий приют!");
                return;
            }
            var filteredPets = FilterPets(selectedShelters);
            var current = GetSelectedShelter();
            bool isJson = comboFormat.SelectedIndex == 0;
            var petForm = new PetForm(filteredPets, shelters, current, this, isJson, reportsDir);
            if (petForm.ShowDialog() == DialogResult.OK)
            {
                SaveData();
                ApplyFiltersAfterChange();
            }
        }

        public void ApplyFiltersAfterChange()
        {
            var selectedShelters = GetSelectedShelters();
            if (selectedShelters.Count == 0)
            {
                comboShelters.SelectedIndex = 0;
                selectedShelters = shelters;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFilterState();
                LoadData();
                FillShelterCombo();
                FillPetTypeCombo();
                RestoreFilters();

                var selectedShelters = GetSelectedShelters();
                var filteredPets = FilterPets(selectedShelters);

                MessageBox.Show($"Данные загружены! Приютов: {shelters.Count}, питомцев: {filteredPets.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFilterState();
            shelters = DataGenerator.GenerateData();
            FillShelterCombo();
            FillPetTypeCombo();
            RestoreFilters();
            SaveData();
            MessageBox.Show("Данные сгенерированы!");
        }

        private void SaveData()
        {
            UpdateSerializers();
            currentSerializer.Serialize(shelters);
        }

        private void LoadData()
        {
            string path = comboFormat.SelectedIndex == 0 ? jsonPath : xmlPath;
            if (!File.Exists(path))
            {
                string otherPath = comboFormat.SelectedIndex == 0 ? xmlPath : jsonPath;
                if (File.Exists(otherPath))
                {
                    var otherSerializer = comboFormat.SelectedIndex == 0
                        ? (SerializerBase)new XmlDataSerializer(otherPath)
                        : new JsonDataSerializer(otherPath);
                    shelters = otherSerializer.Deserialize();
                    SaveData();
                    return;
                }
            }
            UpdateSerializers();
            shelters = currentSerializer.Deserialize();
        }
    }
}