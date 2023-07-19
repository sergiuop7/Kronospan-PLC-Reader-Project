using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using S7.Net.Types;
using System.Data.SQLite;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;
using iText.IO.Image;
using iText.IO.Font;
using iText.Kernel.Font;
using SysDateTime = System.DateTime;
using iText.Kernel.Geom;
using iText.Layout.Borders;
using iText.IO.Font.Constants;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kronospan_PLC_Reader
{


    public partial class Form1 : Form
    {
        #region Declarations
        private Plc plc;
        private List<PlcInfo> plcs = new List<PlcInfo>();
        private int saveDataIntervalMilliseconds = 5000; // Add this line to store the interval value for saveDataTimer
        private const string LocationsFileName = "locations.txt";
        #endregion

        #region PLC Communication and Display
        public class PlcInfo
        {
            public Plc PlcInstance { get; set; }
            public string PlcName { get; set; }
            public System.Windows.Forms.Timer Timer { get; set; }

            public PlcInfo(Plc plcInstance, string plcName, System.Windows.Forms.Timer timer)
            {
                PlcInstance = plcInstance;
                PlcName = plcName;
                Timer = timer;
            }
        }

        private void button_Connect_PLC_Click(object sender, EventArgs e)
        {
            string cpuType = comboBox_CPU_Type.SelectedItem.ToString();
            string ipAddress = textBox_IP_Address.Text;
            int rack = int.Parse(textBox_Rack.Text);
            int slot = int.Parse(textBox_Slot.Text);

            plc = new Plc((CpuType)Enum.Parse(typeof(CpuType), cpuType), ipAddress, (short)rack, (short)slot);
 
            try
            {
                plc.Open();
                if (plc.IsConnected)
            {
                label_ConnectStatus.Text = "Connected";
                label_ConnectStatus.ForeColor = System.Drawing.Color.Green;

                string plcName = $"PLC {plcs.Count + 1}";

                System.Windows.Forms.Timer newTimer = new System.Windows.Forms.Timer();
                newTimer.Interval = 1000; // 1 second interval
                newTimer.Tick += (s, ev) => Timer_TickForPlc(plc, plcName);
                newTimer.Start();

                plcs.Add(new PlcInfo(plc, plcName, newTimer));

                ListViewItem item = new ListViewItem(plcName);
                item.SubItems.Add(ipAddress);
                listView_ConnectedPLCs.Items.Add(item);
            }
            else
            {
                label_ConnectStatus.Text = "Not Connected";
                label_ConnectStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
            catch (Exception ex)
            {
                label_ConnectStatus.Text = "Error";
                label_ConnectStatus.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Failed to connect to the PLC: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Timers.Timer saveDataTimer;

        private void Timer_TickForPlc(Plc plc, string plcName)
        {
            if (plc != null && plc.IsConnected)
            {
                if (saveDataTimer == null)
                {
                    saveDataTimer = new System.Timers.Timer(saveDataIntervalMilliseconds); // Use the updated interval value
                    saveDataTimer.Elapsed += (s, e) => {
                        saveDataTimer.Enabled = false; // Disable the timer
                        SaveAllDataToDatabase(plc, plcName);
                        saveDataTimer.Enabled = true; // Re-enable the timer 
                    };
                    saveDataTimer.Start();
                }

                foreach (ListViewItem item in listView_DB_Locations.Items)
                {
                    int db = int.Parse(item.SubItems[1].Text);
                    int startByteAdr = int.Parse(item.SubItems[2].Text);
                    string dataType = item.SubItems[3].Text;
                    string unitOfMeasurement = item.SubItems[4].Text;
                    VarType varType = (VarType)Enum.Parse(typeof(VarType), dataType);

                    object valueRead;

                    try
                    {
                        switch (dataType)
                        {
                            case "Real":
                                valueRead = plc.Read(DataType.DataBlock, db, startByteAdr, VarType.Real, 1);
                                break;
                            case "Int":
                                valueRead = plc.Read(DataType.DataBlock, db, startByteAdr, VarType.Int, 1);
                                break;
                            default:
                                valueRead = null;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        valueRead = null;
                        Console.WriteLine($"Error reading data from PLC: {ex.Message}");
                    }

                    // Get the name part from the item's text
                    string nameOnly = item.Text.Split('-')[0];

                    // Find the existing row with the same PLC name and address
                    int rowIndex = -1;
                    for (int i = 0; i < dataGridView_PLCValues.Rows.Count; i++)
                    {
                        if (dataGridView_PLCValues.Rows[i].Cells[0].Value.ToString() == plcName &&
                            dataGridView_PLCValues.Rows[i].Cells[2].Value.ToString() == $"DB{db}" &&
                            dataGridView_PLCValues.Rows[i].Cells[3].Value.ToString() == $"{startByteAdr}")
                        {
                            rowIndex = i;
                            break;
                        }
                    }

                    // If a row with the same PLC name and address is found, update the row
                    if (rowIndex != -1)
                    {
                        if (valueRead != null)
                        {
                            dataGridView_PLCValues.Rows[rowIndex].Cells[5].Value = $"{valueRead}";
                            dataGridView_PLCValues.Rows[rowIndex].Cells[6].Value = unitOfMeasurement; // Add this line
                        }
                        else
                        {
                            dataGridView_PLCValues.Rows[rowIndex].Cells[5].Value = "Error: Unable to read data";
                            dataGridView_PLCValues.Rows[rowIndex].Cells[6].Value = unitOfMeasurement; // Add this line
                        }
                    }
                    // If no row with the same PLC name and address is found, add a new row
                    else
                    {
                        if (valueRead != null)
                        {
                            dataGridView_PLCValues.Rows.Add(plcName, nameOnly, $"DB{db}", $"{startByteAdr}", dataType, $"{valueRead}", unitOfMeasurement); // Modify this line
                        }
                        else
                        {
                            dataGridView_PLCValues.Rows.Add(plcName, nameOnly, $"DB{db}", $"{startByteAdr}", dataType, "Error: Unable to read data", unitOfMeasurement); // Modify this line
                        }
                    }
                }
            }
            else
            {
                saveDataTimer?.Stop();
                saveDataTimer = null;
            }
        }

        private void button_Disconnect_Selected_PLC_Click(object sender, EventArgs e)
        {
            if (listView_ConnectedPLCs.SelectedItems.Count > 0)
            {
                string selectedPlcName = listView_ConnectedPLCs.SelectedItems[0].Text;
                PlcInfo selectedPlcInfo = plcs.Find(p => p.PlcName == selectedPlcName);

                if (selectedPlcInfo != null)
                {
                    if (selectedPlcInfo.PlcInstance.IsConnected)
                    {
                        // Stop and dispose of the timer associated with the disconnected PLC
                        selectedPlcInfo.Timer.Stop();
                        selectedPlcInfo.Timer.Dispose();

                        selectedPlcInfo.PlcInstance.Close();
                        plcs.Remove(selectedPlcInfo);
                        listView_ConnectedPLCs.Items.Remove(listView_ConnectedPLCs.SelectedItems[0]);

                        // Remove the rows in dataGridView_PLCValues associated with the disconnected PLC.
                        for (int i = dataGridView_PLCValues.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dataGridView_PLCValues.Rows[i].Cells[0].Value.ToString() == selectedPlcName)
                            {
                                dataGridView_PLCValues.Rows.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a PLC to disconnect.");
            }
        }

        private void UpdateDataGridView(string plcName, string itemName, string db, string startByteAdr, string dataType, string valueRead, string unitOfMeasurement)
        {
            foreach (DataGridViewRow row in dataGridView_PLCValues.Rows)
            {
                if (row.Cells[0].Value.ToString() == plcName && row.Cells[1].Value.ToString() == itemName)
                {
                    row.Cells[5].Value = valueRead;
                    return;
                }
            }

            dataGridView_PLCValues.Rows.Add(plcName, itemName, db, startByteAdr, dataType, valueRead, unitOfMeasurement);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_DB.Text, out int db) && int.TryParse(textBox_Location.Text, out int location) && !string.IsNullOrEmpty(textBox_Name.Text))
            {
                string name = textBox_Name.Text;
                string dataType = comboBox_DataType.SelectedItem.ToString();
                string unitOfMeasurement = textBox_UM.Text;

                ListViewItem item = new ListViewItem($"{name}-{dataType}-DB{db}.{location}");
                item.SubItems.Add(db.ToString());
                item.SubItems.Add(location.ToString());
                item.SubItems.Add(dataType);
                item.SubItems.Add(unitOfMeasurement);

                listView_DB_Locations.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Please enter valid Name, DB, Location, Data Type, and Unit of Measurement values.");
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listView_DB_Locations.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_DB_Locations.SelectedItems[0];

                // Get the name part from the selectedItem's text
                string nameOnly = selectedItem.Text.Split('-')[0];

                // Remove related rows from dataGridView_PLCValues
                for (int i = dataGridView_PLCValues.Rows.Count - 1; i >= 0; i--)
                {
                    if (dataGridView_PLCValues.Rows[i].Cells[1].Value.ToString() == nameOnly)
                    {
                        dataGridView_PLCValues.Rows.RemoveAt(i);
                    }
                }

                // Remove the selected item from listView_DB_Locations
                listView_DB_Locations.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        #endregion

        #region Reports Generation
        private void GeneratePdfReport(SysDateTime startTime, SysDateTime endTime)
        {
            ImageData imageData1 = GetImageDataFromResource("ShipD.png");
            ImageData imageData2 = GetImageDataFromResource("KronospanLogo.png");

            string connectionString = "Data Source=PLCValues.db;Version=3;";
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = @"SELECT Timestamp, ItemName, ValueRead, UnitOfMeasurement FROM PLCValues WHERE Timestamp >= @StartTime AND Timestamp <= @EndTime";


                using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@StartTime", startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    selectCommand.Parameters.AddWithValue("@EndTime", endTime.ToString("yyyy-MM-dd HH:mm:ss"));

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Pivot the data table
            DataTable pivotedDataTable = new DataTable();
            pivotedDataTable.Columns.Add("Timestamp");
            Dictionary<string, string> itemUnits = new Dictionary<string, string>(); // Add this line
            var itemNames = dataTable.AsEnumerable().Select(row => row.Field<string>("ItemName")).Distinct().ToList();
            foreach (var itemName in itemNames)
            {
                pivotedDataTable.Columns.Add(itemName);
                string unitOfMeasurement = dataTable.AsEnumerable().First(row => row.Field<string>("ItemName") == itemName).Field<string>("UnitOfMeasurement"); // Add this line
                itemUnits.Add(itemName, unitOfMeasurement); // Add this line
            }

            var groupedRows = dataTable.AsEnumerable().GroupBy(row => row.Field<string>("Timestamp"));
            foreach (var group in groupedRows)
            {
                DataRow newRow = pivotedDataTable.NewRow();
                newRow["Timestamp"] = group.Key;
                foreach (DataRow row in group)
                {
                    newRow[row.Field<string>("ItemName")] = row.Field<string>("ValueRead");
                }
                pivotedDataTable.Rows.Add(newRow);
            }

            // Set the PDF file name and path
            string fileName = $"PLCValues_{startTime.ToString("yyyyMMddHHmmss")}_{endTime.ToString("yyyyMMddHHmmss")}.pdf";
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Create the PDF
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf, PageSize.A4.Rotate());

            Image image1 = new Image(imageData1);
            Image image2 = new Image(imageData2);

            // Scale the images
            float newWidth1 = 150;
            float newHeight1 = (newWidth1 / imageData1.GetWidth()) * imageData1.GetHeight();
            float newWidth2 = 150;
            float newHeight2 = (newWidth2 / imageData2.GetWidth()) * imageData2.GetHeight();

            image1.SetWidth(newWidth1).SetHeight(newHeight1);
            image2.SetWidth(newWidth2).SetHeight(newHeight2);

            image1.SetFixedPosition(1, 36, 515); // Top-left corner
            image2.SetFixedPosition(1, 670, 505); // Top-right corner



            float[] columnWidths = Enumerable.Repeat(100f / pivotedDataTable.Columns.Count, pivotedDataTable.Columns.Count).ToArray();
            Table table = new Table(UnitValue.CreatePercentArray(columnWidths));

            // Calculate the height of the images plus some margin
            float marginTop = Math.Max(newHeight1, newHeight2) - 58;

            string titleText = $"{startTime.ToString("yyyy-MM-dd HH:mm:ss")} - {endTime.ToString("yyyy-MM-dd HH:mm:ss")}";
            PdfFont boldFont = PdfFontFactory.CreateFont(FontProgramFactory.CreateFont(StandardFonts.HELVETICA_BOLD));
            Paragraph title = new Paragraph(titleText).SetFont(boldFont).SetFontSize(14);

            // Add the title to the document
            title.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            title.SetMarginTop(Math.Max(newHeight1, newHeight2) - 50); // Adjust the vertical position of the title
            document.Add(title);


            //document.Add(image1);
            document.Add(image2);

            // Set the margin to the table
            table.SetMarginTop(marginTop);
            // Add table headers
            for (int i = 0; i < pivotedDataTable.Columns.Count; i++)
            {
                Cell cell = new Cell(1, 1).Add(new Paragraph(pivotedDataTable.Columns[i].ColumnName));
                cell.SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY);
                table.AddCell(cell);
            }


            // Add units of measurement row
            for (int i = 0; i < pivotedDataTable.Columns.Count; i++)
            {
                if (i == 0)
                {
                    table.AddCell(new Cell(1, 1).Add(new Paragraph("")));
                }
                else
                {
                    string itemName = pivotedDataTable.Columns[i].ColumnName;
                    string unitOfMeasurement = itemUnits[itemName];
                    table.AddCell(new Cell(1, 1).Add(new Paragraph(unitOfMeasurement)));
                }
            }


            // Add table data
            for (int i = 0; i < pivotedDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < pivotedDataTable.Columns.Count; j++)
                {
                    table.AddCell(new Cell().Add(new Paragraph(pivotedDataTable.Rows[i][j].ToString())));
                }
            }

            document.Add(table);
            document.Close();

            MessageBox.Show($"PDF file has been created at {filePath}", "PDF Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ImageData GetImageDataFromResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = $"Kronospan_PLC_Reader.Resources.{resourceName}";

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found in the assembly.");
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ImageDataFactory.Create(ms.ToArray());
                }
            }
        }

            private void button_generateReport_Click(object sender, EventArgs e)
            {
                int fromYear = int.Parse(textBox_fromYear.Text);
                int fromMonth = int.Parse(textBox_fromMonth.Text);
                int fromDay = int.Parse(textBox_fromDay.Text);
                int fromHour = int.Parse(textBox_fromHour.Text);
                int fromMinute = int.Parse(textBox_fromMinute.Text);
                int fromSecond = int.Parse(textBox_fromSecond.Text);

                int toYear = int.Parse(textBox_toYear.Text);
                int toMonth = int.Parse(textBox_toMonth.Text);
                int toDay = int.Parse(textBox_toDay.Text);
                int toHour = int.Parse(textBox_toHour.Text);
                int toMinute = int.Parse(textBox_toMinute.Text);
                int toSecond = int.Parse(textBox_toSecond.Text);

                SysDateTime startTime = new SysDateTime(fromYear, fromMonth, fromDay, fromHour, fromMinute, fromSecond);
                SysDateTime endTime = new SysDateTime(toYear, toMonth, toDay, toHour, toMinute, toSecond);
                GeneratePdfReport(startTime, endTime);

            }

        private void button_generateCSV_Click(object sender, EventArgs e)
        {
            int fromYear = int.Parse(textBox_fromYear.Text);
            int fromMonth = int.Parse(textBox_fromMonth.Text);
            int fromDay = int.Parse(textBox_fromDay.Text);
            int fromHour = int.Parse(textBox_fromHour.Text);
            int fromMinute = int.Parse(textBox_fromMinute.Text);
            int fromSecond = int.Parse(textBox_fromSecond.Text);

            int toYear = int.Parse(textBox_toYear.Text);
            int toMonth = int.Parse(textBox_toMonth.Text);
            int toDay = int.Parse(textBox_toDay.Text);
            int toHour = int.Parse(textBox_toHour.Text);
            int toMinute = int.Parse(textBox_toMinute.Text);
            int toSecond = int.Parse(textBox_toSecond.Text);

            SysDateTime startTime = new SysDateTime(fromYear, fromMonth, fromDay, fromHour, fromMinute, fromSecond);
            SysDateTime endTime = new SysDateTime(toYear, toMonth, toDay, toHour, toMinute, toSecond);

            GenerateCSVReport(startTime, endTime);
        }

        private void GenerateCSVReport(SysDateTime startTime, SysDateTime endTime)
        {
            string connectionString = "Data Source=PLCValues.db;Version=3;";
            DataTable dataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = @"SELECT Timestamp, ItemName, ValueRead, UnitOfMeasurement FROM PLCValues WHERE Timestamp >= @StartTime AND Timestamp <= @EndTime";

                using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@StartTime", startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    selectCommand.Parameters.AddWithValue("@EndTime", endTime.ToString("yyyy-MM-dd HH:mm:ss"));

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Pivot the data table
            DataTable pivotedDataTable = new DataTable();
            pivotedDataTable.Columns.Add("Timestamp");
            Dictionary<string, string> itemUnits = new Dictionary<string, string>();
            var itemNames = dataTable.AsEnumerable().Select(row => row.Field<string>("ItemName")).Distinct().ToList();
            foreach (var itemName in itemNames)
            {
                pivotedDataTable.Columns.Add(itemName);
                string unitOfMeasurement = dataTable.AsEnumerable().First(row => row.Field<string>("ItemName") == itemName).Field<string>("UnitOfMeasurement");
                itemUnits.Add(itemName, unitOfMeasurement);
            }

            var groupedRows = dataTable.AsEnumerable().GroupBy(row => row.Field<string>("Timestamp"));
            foreach (var group in groupedRows)
            {
                DataRow newRow = pivotedDataTable.NewRow();
                newRow["Timestamp"] = group.Key;
                foreach (DataRow row in group)
                {
                    newRow[row.Field<string>("ItemName")] = row.Field<string>("ValueRead");
                }
                pivotedDataTable.Rows.Add(newRow);
            }

            // Set the CSV file name and path
            string fileName = $"PLCValues_{startTime.ToString("yyyyMMddHHmmss")}_{endTime.ToString("yyyyMMddHHmmss")}.csv";
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            // Write the CSV file
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Write the header row
                IEnumerable<string> headerValues = pivotedDataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sw.WriteLine(string.Join(",", headerValues));

                // Write the units of measurement row
                bool first = true;
                foreach (var itemName in itemNames)
                {
                    if (first)
                    {
                        sw.Write(" ," + itemUnits[itemName]);
                        first = false;
                    }
                    else
                    {
                        sw.Write("," + itemUnits[itemName]);
                    }
                }
                sw.WriteLine();

                // Write the data rows
                foreach (DataRow row in pivotedDataTable.Rows)
                {
                    IEnumerable<string> fieldValues = row.ItemArray.Select(field => field.ToString());
                    sw.WriteLine(string.Join(",", fieldValues));
                }
            }

            // Notify the user that the CSV file has been created
            MessageBox.Show($"CSV file has been created at {filePath}", "CSV Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Databases

        private void CreateDataTable()
        {
            string connectionString = "Data Source=PLCValues.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS PLCValues (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PLCName TEXT NOT NULL,
                    ItemName TEXT NOT NULL,
                    DB TEXT NOT NULL,
                    StartByteAdr TEXT NOT NULL,
                    DataType TEXT NOT NULL,
                    ValueRead TEXT NOT NULL,
                    UnitOfMeasurement TEXT NOT NULL,
                    Timestamp TEXT NOT NULL
                 );";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void listView_DB_Locations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_DB_Locations.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView_DB_Locations.SelectedItems[0];

                textBox_Name.Text = selectedItem.Text.Split('-')[0];
                textBox_DB.Text = selectedItem.SubItems[1].Text;
                textBox_Location.Text = selectedItem.SubItems[2].Text;
                comboBox_DataType.SelectedItem = selectedItem.SubItems[3].Text;
                textBox_UM.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void CreateDatabaseFile()
        {
            string databaseFileName = "PLCValues.db";
            if (!File.Exists(databaseFileName))
            {
                SQLiteConnection.CreateFile(databaseFileName);
            }
        }

        private void SaveDataToDatabase(string plcName, string itemName, string db, string startByteAdr, string dataType, string valueRead, string unitOfMeasurement)
        {
            string connectionString = "Data Source=PLCValues.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string insertQuery = @"INSERT INTO PLCValues (PLCName, ItemName, DB, StartByteAdr, DataType, ValueRead, UnitOfMeasurement, Timestamp) 
                       VALUES (@PLCName, @ItemName, @DB, @StartByteAdr, @DataType, @ValueRead, @UnitOfMeasurement, @Timestamp)";


                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@PLCName", plcName);
                    insertCommand.Parameters.AddWithValue("@ItemName", itemName);
                    insertCommand.Parameters.AddWithValue("@DB", db);
                    insertCommand.Parameters.AddWithValue("@StartByteAdr", startByteAdr);
                    insertCommand.Parameters.AddWithValue("@DataType", dataType);
                    insertCommand.Parameters.AddWithValue("@ValueRead", valueRead);
                    insertCommand.Parameters.AddWithValue("@UnitOfMeasurement", unitOfMeasurement);
                    insertCommand.Parameters.AddWithValue("@Timestamp", timestamp);

                    insertCommand.ExecuteNonQuery();
                }
            }
        }

        private void SaveAllDataToDatabase(Plc plc, string plcName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SaveAllDataToDatabase(plc, plcName)));
                return;
            }

            foreach (ListViewItem item in listView_DB_Locations.Items)
            {
                int db = int.Parse(item.SubItems[1].Text);
                int startByteAdr = int.Parse(item.SubItems[2].Text);
                string dataType = item.SubItems[3].Text;
                string unitOfMeasurement = item.SubItems[4].Text;
                VarType varType = (VarType)Enum.Parse(typeof(VarType), dataType);

                object valueRead;

                try
                {
                    switch (dataType)
                    {
                        case "Real":
                            valueRead = plc.Read(DataType.DataBlock, db, startByteAdr, VarType.Real, 1);
                            break;
                        case "Int":
                            valueRead = plc.Read(DataType.DataBlock, db, startByteAdr, VarType.Int, 1);
                            break;
                        default:
                            valueRead = null;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    valueRead = null;
                    Console.WriteLine($"Error reading data from PLC: {ex.Message}");
                }

                // Get the name part from the item's text
                string nameOnly = item.Text.Split('-')[0];

                // Save data to the database
                SaveDataToDatabase(plcName, nameOnly, $"DB{db}", $"{startByteAdr}", dataType, valueRead?.ToString(), unitOfMeasurement);
            }
        }

        private List<(SysDateTime Timestamp, double Value)> FetchTimeAndValueData(string itemName)
        {
            List<(SysDateTime Timestamp, double Value)> data = new List<(SysDateTime Timestamp, double Value)>();

            string connectionString = "Data Source=PLCValues.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = $"SELECT Timestamp, ValueRead FROM PLCValues WHERE ItemName = @itemName ORDER BY Timestamp";

                using (SQLiteCommand command = new SQLiteCommand(selectDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@itemName", itemName);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SysDateTime timestamp = SysDateTime.Parse(reader["Timestamp"].ToString());
                            double value = double.Parse(reader["ValueRead"].ToString());

                            data.Add((timestamp, value));
                        }
                    }
                }
            }

            return data;
        }

        #endregion

        #region Initializations and QOL functions
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeConnectedPLCsListView();
            CreateDatabaseFile();
            CreateDataTable();
        }
        private void SaveLocationsToFile()
        {
            using (StreamWriter writer = new StreamWriter(LocationsFileName))
            {
                foreach (ListViewItem item in listView_DB_Locations.Items)
                {
                    writer.WriteLine(string.Join(",", item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text)));
                }
            }
        }

        private void LoadLocationsFromFile()
        {
            if (File.Exists(LocationsFileName))
            {
                using (StreamReader reader = new StreamReader(LocationsFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        ListViewItem newItem = new ListViewItem(parts[0]);
                        for (int i = 1; i < parts.Length; i++)
                        {
                            newItem.SubItems.Add(parts[i]);
                        }

                        listView_DB_Locations.Items.Add(newItem);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLocationsFromFile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLocationsToFile();
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?",
                                          "Exit Confirmation",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Cancel the closing event if the user selects 'No'
                e.Cancel = true;
            }
        }

        private void InitializeComboBox()
        {
            comboBox_CPU_Type.Items.Add("S71500");
            comboBox_CPU_Type.Items.Add("S71200");
            comboBox_CPU_Type.SelectedIndex = 0;
            listView_DB_Locations.View = View.Details;
            listView_DB_Locations.FullRowSelect = true;
            listView_DB_Locations.Columns.Add("Name", listView_DB_Locations.Width - 20, System.Windows.Forms.HorizontalAlignment.Left);

            comboBox_DataType.Items.Add("Real");
            comboBox_DataType.Items.Add("Int");
            comboBox_DataType.SelectedIndex = 0;
        }

        private void InitializeConnectedPLCsListView()
        {
            listView_ConnectedPLCs.View = View.Details;
            listView_ConnectedPLCs.FullRowSelect = true;
            listView_ConnectedPLCs.Columns.Add("PLC Name", listView_ConnectedPLCs.Width / 2, System.Windows.Forms.HorizontalAlignment.Left);
            listView_ConnectedPLCs.Columns.Add("IP Address", listView_ConnectedPLCs.Width / 2, System.Windows.Forms.HorizontalAlignment.Left);
        }

        private void button_setInterval_Click(object sender, EventArgs e)
        {
            double intervalInSeconds;

            if (double.TryParse(textBox_timeInterval.Text, out intervalInSeconds) && intervalInSeconds > 0)
            {
                saveDataIntervalMilliseconds = (int)(intervalInSeconds * 1000); // Update the saveDataTimer interval value

                if (saveDataTimer != null)
                {
                    saveDataTimer.Interval = saveDataIntervalMilliseconds; // Update the saveDataTimer's Interval directly
                }

                label_displayInterval.Text = $"Current interval: {intervalInSeconds} seconds";
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number value for the interval.", "Invalid Interval", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Graphs
        private void buttonCreateChart_Click(object sender, EventArgs e)
        {
            string itemName = textBoxItemName.Text;

            if (string.IsNullOrWhiteSpace(itemName))
            {
                MessageBox.Show("Please enter an ItemName.");
                return;
            }

            string connectionString = "Data Source=PLCValues.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectDataQuery = $"SELECT Timestamp, ValueRead FROM PLCValues WHERE ItemName = @itemName ORDER BY Timestamp";
                using (SQLiteCommand command = new SQLiteCommand(selectDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@itemName", itemName);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            CreateChart(dataTable);
                        }
                        else
                        {
                            MessageBox.Show("No data found for the specified ItemName.");
                        }
                    }
                }
            }
        }

        private void CreateChart(DataTable dataTable)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Timestamp";
            chart1.ChartAreas[0].AxisY.Title = "ValueRead";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // Set the Y-axis to auto-scale based on the data points
            chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisY.Maximum = double.NaN;

            // Set the X-axis to auto-scale based on the data points
            chart1.ChartAreas[0].AxisX.Minimum = double.NaN;
            chart1.ChartAreas[0].AxisX.Maximum = double.NaN;

            Series series = new Series
            {
                Name = "ValueRead",
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            };

            chart1.Series.Add(series);

            foreach (DataRow row in dataTable.Rows)
            {
                SysDateTime timestamp = SysDateTime.Parse(row["Timestamp"].ToString());
                double valueRead = double.Parse(row["ValueRead"].ToString());
                series.Points.AddXY(timestamp, valueRead);
            }

            // Force the chart to recalculate the axis scale
            chart1.ChartAreas[0].RecalculateAxesScale();
        }


        #endregion

    }
}
