using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using WarehouseExcel.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace WarehouseExcel
{
    public partial class MainForm : Form
    {
        List<Product> products = new List<Product>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ClearForm();
            string fileName;
            SelectExcelFileForReading(out fileName);
            ReadExcel(fileName);
            products.Sort();
            lblProduct.Text = $"Каталог: {products[0].Catalog}; Категория: {products[0].Category} ({products[0].DateExp}, " +
                $"{products[0].Priority}, {products[0].DateIn})";
        }

        private static void SelectExcelFileForReading(out string fileName)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Title = "Выберите excel файл.";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.ShowDialog();
            fileName = openFileDialog.FileName;
            if (fileName == string.Empty)
            {
                return;
            }
        }

        private void ReadExcel(string fileName)
        {
            var excelApp = new Excel.Application();
            //Открываем книгу.                                                                                                                                                        
            Excel.Workbook workbook = excelApp.Workbooks.Open(fileName, 0, true);
            //Выбираем таблицу(лист).
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            var excelRange = worksheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int columnCount = excelRange.Columns.Count;

            //чтение строк из таблицы
            for (int i = 2; i <= rowCount; i++)
            {
                AddProductToList(excelRange, i);
            }


            workbook.Close(false);
            excelApp.Quit();
        }

        private void AddProductToList(Excel.Range excelRange, int i)
        {
            var product = new Product
            {
                Catalog = excelRange.Cells[i, 1].Text,
                Category = excelRange.Cells[i, 2].Text,
                DateExp = GetDateByText(excelRange.Cells[i, 3].Text, new[] { "dd'.'MM'.'yyyy" }),
                Priority = (excelRange.Cells[i, 4].Text == string.Empty) ? null : Convert.ToInt32(excelRange.Cells[i, 4].Text),
                DateIn = GetDateByText(excelRange.Cells[i, 5].Text, new[] { "dd/MM/yyyy HH:mm" })
            };

            products.Add(product);
        }

        private DateTime? GetDateByText(string text, string[] formats)
        {
            DateTime date;           
            bool isValidDateTime = DateTime.TryParseExact(text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            return (isValidDateTime)? date : null;
        }

        private void ClearForm()
        {
            products.Clear();
            lblProduct.Text = "";
        }
    }
}
