namespace Excel2JSON
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.IO;
    using Newtonsoft.Json;
    using OfficeOpenXml;


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string excelFilePath;
        private void btnCalistir_Click(object sender, EventArgs e)
        {
            try
            {
                // EPPlus lisans bağlamını ayarlayın
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Kullanıcının girdiği Excel dosyasının yolunu alın

                if (!File.Exists(excelFilePath))
                {
                    MessageBox.Show("Belirtilen dosya yolu bulunamadı. Lütfen geçerli bir dosya yolu girin.");
                    return;
                }

                // Masaüstü yolunu alın
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string jsonFilePath = Path.Combine(desktopPath, "translation.json");

                // Excel dosyasını okuyun
                FileInfo fileInfo = new FileInfo(excelFilePath);
                Dictionary<string, object> translation = new Dictionary<string, object>();

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    // Worksheet sayısını kontrol edin
                    if (package.Workbook.Worksheets.Count == 0)
                    {
                        MessageBox.Show("Excel dosyasında hiç worksheet bulunamadı.");
                        return;
                    }

                    // İlk worksheet'i seçin
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    int colCount = worksheet.Dimension?.Columns ?? 0;

                    if (rowCount == 0 || colCount == 0)
                    {
                        MessageBox.Show("Worksheet içeriği okunamadı.");
                        return;
                    }

                    // Verileri okuyup organize edin
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string[] keys = worksheet.Cells[row, 1].Text.Split('.');
                        string value = worksheet.Cells[row, 2].Text;

                        AddToDictionary(translation, keys, value);
                    }
                }

                // JSON formatına dönüştürme
                string jsonString = JsonConvert.SerializeObject(new { translation }, Formatting.Indented);

                // JSON dosyasını kaydedin
                File.WriteAllText(jsonFilePath, jsonString);

                MessageBox.Show($"Dönüştürme işlemi tamamlandı. JSON dosyası masaüstüne kaydedildi: {jsonFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        static void AddToDictionary(Dictionary<string, object> dict, string[] keys, string value)
        {
            Dictionary<string, object> currentDict = dict;

            for (int i = 0; i < keys.Length; i++)
            {
                if (i == keys.Length - 1)
                {
                    currentDict[keys[i]] = value;
                }
                else
                {
                    if (!currentDict.ContainsKey(keys[i]))
                    {
                        currentDict[keys[i]] = new Dictionary<string, object>();
                    }

                    currentDict = (Dictionary<string, object>)currentDict[keys[i]];
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Bir Excel Dosyası Seçiniz";
            openFileDialog1.FileName = "Dosya Sec";
            openFileDialog1.Filter = "Excel Dosyaları|*.xls;*.xlsx;*.xlsm|Tüm Dosyalar|*.*";
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }

            excelFilePath = txtPath.Text.Trim();
        }
    }
}
