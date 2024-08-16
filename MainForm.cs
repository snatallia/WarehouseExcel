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

            try
            {
                string fileName;
                SelectExcelFileForReading(out fileName);
                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }
                ClearForm();
                ReadExcel(fileName);
                GridViewInit();
                products.Sort();
                lblProduct.Text = $"Менее приоритетный товар: Каталог: {products[0].Catalog}; Категория: {products[0].Category}";
            }
            catch (Exception ex)
            {
                lblProduct.Text = ex.Message;
            }
        }

        //инициализация данными таблицы на форме
        private void GridViewInit()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = true;
            dgvProducts.DataSource = products.ToArray();
        }

        //выбор excel файла
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

        //чтение excel файла
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

            //чтение строк из таблицы, начиная со второй
            for (int i = 2; i <= rowCount; i++)
            {
                AddProductToList(excelRange, i);
            }
            
            //завершаем работу с excel
            workbook.Close(false);
            excelApp.Quit();
        }

        //создание списка продуктов
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

        //чтения даты в зависимости от формата
        private DateTime? GetDateByText(string text, string[] formats)
        {
            DateTime date;           
            bool isValidDateTime = DateTime.TryParseExact(text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            return (isValidDateTime)? date : null;
        }

        //очистка данных
        private void ClearForm()
        {
            products.Clear();
            lblProduct.Text = string.Empty;
        }
    }
}
