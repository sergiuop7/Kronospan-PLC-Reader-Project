namespace Kronospan_PLC_Reader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timerReadPLC = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Disconnect_Selected_PLC = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.listView_ConnectedPLCs = new System.Windows.Forms.ListView();
            this.label_ConnectStatus = new System.Windows.Forms.Label();
            this.comboBox_CPU_Type = new System.Windows.Forms.ComboBox();
            this.button_Connect_PLC = new System.Windows.Forms.Button();
            this.textBox_Slot = new System.Windows.Forms.TextBox();
            this.textBox_Rack = new System.Windows.Forms.TextBox();
            this.textBox_IP_Address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_UM = new System.Windows.Forms.TextBox();
            this.comboBox_DataType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.listView_DB_Locations = new System.Windows.Forms.ListView();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Location = new System.Windows.Forms.TextBox();
            this.textBox_DB = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label_displayInterval = new System.Windows.Forms.Label();
            this.button_setInterval = new System.Windows.Forms.Button();
            this.textBox_timeInterval = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.button_generateCSV = new System.Windows.Forms.Button();
            this.button_generateReport = new System.Windows.Forms.Button();
            this.textBox_toSecond = new System.Windows.Forms.TextBox();
            this.textBox_toMinute = new System.Windows.Forms.TextBox();
            this.textBox_toHour = new System.Windows.Forms.TextBox();
            this.textBox_toDay = new System.Windows.Forms.TextBox();
            this.textBox_toMonth = new System.Windows.Forms.TextBox();
            this.textBox_toYear = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_fromSecond = new System.Windows.Forms.TextBox();
            this.textBox_fromMinute = new System.Windows.Forms.TextBox();
            this.textBox_fromHour = new System.Windows.Forms.TextBox();
            this.textBox_fromDay = new System.Windows.Forms.TextBox();
            this.textBox_fromMonth = new System.Windows.Forms.TextBox();
            this.textBox_fromYear = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView_PLCValues = new System.Windows.Forms.DataGridView();
            this.column_PLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_UM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCreateChart = new System.Windows.Forms.Button();
            this.textBoxItemName = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PLCValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerReadPLC
            // 
            this.timerReadPLC.Enabled = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Disconnect_Selected_PLC);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.listView_ConnectedPLCs);
            this.groupBox1.Controls.Add(this.label_ConnectStatus);
            this.groupBox1.Controls.Add(this.comboBox_CPU_Type);
            this.groupBox1.Controls.Add(this.button_Connect_PLC);
            this.groupBox1.Controls.Add(this.textBox_Slot);
            this.groupBox1.Controls.Add(this.textBox_Rack);
            this.groupBox1.Controls.Add(this.textBox_IP_Address);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(43, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PLC Connection";
            // 
            // button_Disconnect_Selected_PLC
            // 
            this.button_Disconnect_Selected_PLC.Location = new System.Drawing.Point(202, 159);
            this.button_Disconnect_Selected_PLC.Name = "button_Disconnect_Selected_PLC";
            this.button_Disconnect_Selected_PLC.Size = new System.Drawing.Size(146, 23);
            this.button_Disconnect_Selected_PLC.TabIndex = 12;
            this.button_Disconnect_Selected_PLC.Text = "Disconnect selected PLC";
            this.button_Disconnect_Selected_PLC.UseVisualStyleBackColor = true;
            this.button_Disconnect_Selected_PLC.Click += new System.EventHandler(this.button_Disconnect_Selected_PLC_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Connected PLC\'s";
            // 
            // listView_ConnectedPLCs
            // 
            this.listView_ConnectedPLCs.HideSelection = false;
            this.listView_ConnectedPLCs.Location = new System.Drawing.Point(202, 38);
            this.listView_ConnectedPLCs.Name = "listView_ConnectedPLCs";
            this.listView_ConnectedPLCs.Size = new System.Drawing.Size(146, 108);
            this.listView_ConnectedPLCs.TabIndex = 10;
            this.listView_ConnectedPLCs.UseCompatibleStateImageBehavior = false;
            // 
            // label_ConnectStatus
            // 
            this.label_ConnectStatus.AutoSize = true;
            this.label_ConnectStatus.Location = new System.Drawing.Point(15, 164);
            this.label_ConnectStatus.Name = "label_ConnectStatus";
            this.label_ConnectStatus.Size = new System.Drawing.Size(78, 13);
            this.label_ConnectStatus.TabIndex = 2;
            this.label_ConnectStatus.Text = "Not connected";
            // 
            // comboBox_CPU_Type
            // 
            this.comboBox_CPU_Type.FormattingEnabled = true;
            this.comboBox_CPU_Type.Location = new System.Drawing.Point(86, 38);
            this.comboBox_CPU_Type.Name = "comboBox_CPU_Type";
            this.comboBox_CPU_Type.Size = new System.Drawing.Size(110, 21);
            this.comboBox_CPU_Type.TabIndex = 9;
            // 
            // button_Connect_PLC
            // 
            this.button_Connect_PLC.Location = new System.Drawing.Point(99, 159);
            this.button_Connect_PLC.Name = "button_Connect_PLC";
            this.button_Connect_PLC.Size = new System.Drawing.Size(75, 23);
            this.button_Connect_PLC.TabIndex = 7;
            this.button_Connect_PLC.Text = "Connect";
            this.button_Connect_PLC.UseVisualStyleBackColor = true;
            this.button_Connect_PLC.Click += new System.EventHandler(this.button_Connect_PLC_Click);
            // 
            // textBox_Slot
            // 
            this.textBox_Slot.Location = new System.Drawing.Point(86, 126);
            this.textBox_Slot.Name = "textBox_Slot";
            this.textBox_Slot.Size = new System.Drawing.Size(110, 20);
            this.textBox_Slot.TabIndex = 6;
            this.textBox_Slot.Text = "1";
            // 
            // textBox_Rack
            // 
            this.textBox_Rack.Location = new System.Drawing.Point(86, 97);
            this.textBox_Rack.Name = "textBox_Rack";
            this.textBox_Rack.Size = new System.Drawing.Size(110, 20);
            this.textBox_Rack.TabIndex = 5;
            this.textBox_Rack.Text = "0";
            // 
            // textBox_IP_Address
            // 
            this.textBox_IP_Address.Location = new System.Drawing.Point(86, 68);
            this.textBox_IP_Address.Name = "textBox_IP_Address";
            this.textBox_IP_Address.Size = new System.Drawing.Size(110, 20);
            this.textBox_IP_Address.TabIndex = 4;
            this.textBox_IP_Address.Text = "192.168.0.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Slot:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rack:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CPU Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxItemName);
            this.groupBox2.Controls.Add(this.buttonCreateChart);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.textBox_UM);
            this.groupBox2.Controls.Add(this.comboBox_DataType);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_Name);
            this.groupBox2.Controls.Add(this.listView_DB_Locations);
            this.groupBox2.Controls.Add(this.button_Remove);
            this.groupBox2.Controls.Add(this.button_Add);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_Location);
            this.groupBox2.Controls.Add(this.textBox_DB);
            this.groupBox2.Location = new System.Drawing.Point(43, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 355);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Locations";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 109);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 13);
            this.label25.TabIndex = 12;
            this.label25.Text = "UM:";
            // 
            // textBox_UM
            // 
            this.textBox_UM.Location = new System.Drawing.Point(68, 107);
            this.textBox_UM.Name = "textBox_UM";
            this.textBox_UM.Size = new System.Drawing.Size(100, 20);
            this.textBox_UM.TabIndex = 11;
            // 
            // comboBox_DataType
            // 
            this.comboBox_DataType.FormattingEnabled = true;
            this.comboBox_DataType.Location = new System.Drawing.Point(68, 81);
            this.comboBox_DataType.Name = "comboBox_DataType";
            this.comboBox_DataType.Size = new System.Drawing.Size(100, 21);
            this.comboBox_DataType.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Name:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(68, 132);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 7;
            // 
            // listView_DB_Locations
            // 
            this.listView_DB_Locations.HideSelection = false;
            this.listView_DB_Locations.Location = new System.Drawing.Point(180, 31);
            this.listView_DB_Locations.Name = "listView_DB_Locations";
            this.listView_DB_Locations.Size = new System.Drawing.Size(163, 318);
            this.listView_DB_Locations.TabIndex = 6;
            this.listView_DB_Locations.UseCompatibleStateImageBehavior = false;
            this.listView_DB_Locations.SelectedIndexChanged += new System.EventHandler(this.listView_DB_Locations_SelectedIndexChanged);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(93, 159);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 5;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(16, 159);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Offset:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "DB:";
            // 
            // textBox_Location
            // 
            this.textBox_Location.Location = new System.Drawing.Point(68, 56);
            this.textBox_Location.Name = "textBox_Location";
            this.textBox_Location.Size = new System.Drawing.Size(100, 20);
            this.textBox_Location.TabIndex = 1;
            // 
            // textBox_DB
            // 
            this.textBox_DB.Location = new System.Drawing.Point(68, 31);
            this.textBox_DB.Name = "textBox_DB";
            this.textBox_DB.Size = new System.Drawing.Size(100, 20);
            this.textBox_DB.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label_displayInterval);
            this.groupBox3.Controls.Add(this.button_setInterval);
            this.groupBox3.Controls.Add(this.textBox_timeInterval);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.button_generateCSV);
            this.groupBox3.Controls.Add(this.button_generateReport);
            this.groupBox3.Controls.Add(this.textBox_toSecond);
            this.groupBox3.Controls.Add(this.textBox_toMinute);
            this.groupBox3.Controls.Add(this.textBox_toHour);
            this.groupBox3.Controls.Add(this.textBox_toDay);
            this.groupBox3.Controls.Add(this.textBox_toMonth);
            this.groupBox3.Controls.Add(this.textBox_toYear);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBox_fromSecond);
            this.groupBox3.Controls.Add(this.textBox_fromMinute);
            this.groupBox3.Controls.Add(this.textBox_fromHour);
            this.groupBox3.Controls.Add(this.textBox_fromDay);
            this.groupBox3.Controls.Add(this.textBox_fromMonth);
            this.groupBox3.Controls.Add(this.textBox_fromYear);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dataGridView_PLCValues);
            this.groupBox3.Location = new System.Drawing.Point(427, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(710, 556);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display Locations";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(680, 474);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(24, 13);
            this.label28.TabIndex = 34;
            this.label28.Text = "sec";
            // 
            // label_displayInterval
            // 
            this.label_displayInterval.AutoSize = true;
            this.label_displayInterval.Location = new System.Drawing.Point(550, 526);
            this.label_displayInterval.Name = "label_displayInterval";
            this.label_displayInterval.Size = new System.Drawing.Size(133, 13);
            this.label_displayInterval.TabIndex = 33;
            this.label_displayInterval.Text = "Current interval: 5 seconds";
            // 
            // button_setInterval
            // 
            this.button_setInterval.Location = new System.Drawing.Point(585, 496);
            this.button_setInterval.Name = "button_setInterval";
            this.button_setInterval.Size = new System.Drawing.Size(75, 23);
            this.button_setInterval.TabIndex = 32;
            this.button_setInterval.Text = "Set";
            this.button_setInterval.UseVisualStyleBackColor = true;
            this.button_setInterval.Click += new System.EventHandler(this.button_setInterval_Click);
            // 
            // textBox_timeInterval
            // 
            this.textBox_timeInterval.Location = new System.Drawing.Point(574, 471);
            this.textBox_timeInterval.Name = "textBox_timeInterval";
            this.textBox_timeInterval.Size = new System.Drawing.Size(100, 20);
            this.textBox_timeInterval.TabIndex = 31;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(580, 455);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(94, 13);
            this.label26.TabIndex = 30;
            this.label26.Text = "Save to DB every:";
            // 
            // button_generateCSV
            // 
            this.button_generateCSV.Location = new System.Drawing.Point(462, 455);
            this.button_generateCSV.Name = "button_generateCSV";
            this.button_generateCSV.Size = new System.Drawing.Size(85, 87);
            this.button_generateCSV.TabIndex = 29;
            this.button_generateCSV.Text = "Generate CSV";
            this.button_generateCSV.UseVisualStyleBackColor = true;
            this.button_generateCSV.Click += new System.EventHandler(this.button_generateCSV_Click);
            // 
            // button_generateReport
            // 
            this.button_generateReport.Location = new System.Drawing.Point(357, 455);
            this.button_generateReport.Name = "button_generateReport";
            this.button_generateReport.Size = new System.Drawing.Size(85, 87);
            this.button_generateReport.TabIndex = 28;
            this.button_generateReport.Text = "Generate PDF";
            this.button_generateReport.UseVisualStyleBackColor = true;
            this.button_generateReport.Click += new System.EventHandler(this.button_generateReport_Click);
            // 
            // textBox_toSecond
            // 
            this.textBox_toSecond.Location = new System.Drawing.Point(287, 522);
            this.textBox_toSecond.Name = "textBox_toSecond";
            this.textBox_toSecond.Size = new System.Drawing.Size(31, 20);
            this.textBox_toSecond.TabIndex = 27;
            this.textBox_toSecond.Text = "00";
            // 
            // textBox_toMinute
            // 
            this.textBox_toMinute.Location = new System.Drawing.Point(239, 522);
            this.textBox_toMinute.Name = "textBox_toMinute";
            this.textBox_toMinute.Size = new System.Drawing.Size(31, 20);
            this.textBox_toMinute.TabIndex = 26;
            this.textBox_toMinute.Text = "00";
            // 
            // textBox_toHour
            // 
            this.textBox_toHour.Location = new System.Drawing.Point(195, 522);
            this.textBox_toHour.Name = "textBox_toHour";
            this.textBox_toHour.Size = new System.Drawing.Size(31, 20);
            this.textBox_toHour.TabIndex = 25;
            this.textBox_toHour.Text = "12";
            // 
            // textBox_toDay
            // 
            this.textBox_toDay.Location = new System.Drawing.Point(145, 522);
            this.textBox_toDay.Name = "textBox_toDay";
            this.textBox_toDay.Size = new System.Drawing.Size(31, 20);
            this.textBox_toDay.TabIndex = 24;
            this.textBox_toDay.Text = "1";
            // 
            // textBox_toMonth
            // 
            this.textBox_toMonth.Location = new System.Drawing.Point(99, 522);
            this.textBox_toMonth.Name = "textBox_toMonth";
            this.textBox_toMonth.Size = new System.Drawing.Size(31, 20);
            this.textBox_toMonth.TabIndex = 23;
            this.textBox_toMonth.Text = "1";
            // 
            // textBox_toYear
            // 
            this.textBox_toYear.Location = new System.Drawing.Point(38, 522);
            this.textBox_toYear.Name = "textBox_toYear";
            this.textBox_toYear.Size = new System.Drawing.Size(47, 20);
            this.textBox_toYear.TabIndex = 22;
            this.textBox_toYear.Text = "2024";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(284, 506);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "second";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(236, 506);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "minute";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(196, 506);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 13);
            this.label21.TabIndex = 19;
            this.label21.Text = "hour";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(147, 506);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "day";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(97, 506);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "month";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(47, 506);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 13);
            this.label24.TabIndex = 16;
            this.label24.Text = "year";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 526);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "To:";
            // 
            // textBox_fromSecond
            // 
            this.textBox_fromSecond.Location = new System.Drawing.Point(287, 471);
            this.textBox_fromSecond.Name = "textBox_fromSecond";
            this.textBox_fromSecond.Size = new System.Drawing.Size(31, 20);
            this.textBox_fromSecond.TabIndex = 14;
            this.textBox_fromSecond.Text = "00";
            // 
            // textBox_fromMinute
            // 
            this.textBox_fromMinute.Location = new System.Drawing.Point(239, 471);
            this.textBox_fromMinute.Name = "textBox_fromMinute";
            this.textBox_fromMinute.Size = new System.Drawing.Size(31, 20);
            this.textBox_fromMinute.TabIndex = 13;
            this.textBox_fromMinute.Text = "00";
            // 
            // textBox_fromHour
            // 
            this.textBox_fromHour.Location = new System.Drawing.Point(195, 471);
            this.textBox_fromHour.Name = "textBox_fromHour";
            this.textBox_fromHour.Size = new System.Drawing.Size(31, 20);
            this.textBox_fromHour.TabIndex = 12;
            this.textBox_fromHour.Text = "12";
            // 
            // textBox_fromDay
            // 
            this.textBox_fromDay.Location = new System.Drawing.Point(145, 471);
            this.textBox_fromDay.Name = "textBox_fromDay";
            this.textBox_fromDay.Size = new System.Drawing.Size(31, 20);
            this.textBox_fromDay.TabIndex = 11;
            this.textBox_fromDay.Text = "1";
            // 
            // textBox_fromMonth
            // 
            this.textBox_fromMonth.Location = new System.Drawing.Point(99, 471);
            this.textBox_fromMonth.Name = "textBox_fromMonth";
            this.textBox_fromMonth.Size = new System.Drawing.Size(31, 20);
            this.textBox_fromMonth.TabIndex = 10;
            this.textBox_fromMonth.Text = "1";
            // 
            // textBox_fromYear
            // 
            this.textBox_fromYear.Location = new System.Drawing.Point(38, 471);
            this.textBox_fromYear.Name = "textBox_fromYear";
            this.textBox_fromYear.Size = new System.Drawing.Size(47, 20);
            this.textBox_fromYear.TabIndex = 9;
            this.textBox_fromYear.Text = "2022";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(284, 455);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "second";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(236, 455);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "minute";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 455);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "hour";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(147, 455);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "day";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 455);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "month";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 455);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "year";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 474);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "From:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Generate PDF Report";
            // 
            // dataGridView_PLCValues
            // 
            this.dataGridView_PLCValues.AllowUserToAddRows = false;
            this.dataGridView_PLCValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PLCValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_PLC,
            this.column_Name,
            this.column_DB,
            this.column_Offset,
            this.column_DataType,
            this.column_Value,
            this.column_UM});
            this.dataGridView_PLCValues.Location = new System.Drawing.Point(6, 13);
            this.dataGridView_PLCValues.Name = "dataGridView_PLCValues";
            this.dataGridView_PLCValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PLCValues.Size = new System.Drawing.Size(698, 423);
            this.dataGridView_PLCValues.TabIndex = 0;
            // 
            // column_PLC
            // 
            this.column_PLC.HeaderText = "PLC";
            this.column_PLC.Name = "column_PLC";
            // 
            // column_Name
            // 
            this.column_Name.HeaderText = "Name";
            this.column_Name.Name = "column_Name";
            // 
            // column_DB
            // 
            this.column_DB.HeaderText = "DB";
            this.column_DB.Name = "column_DB";
            // 
            // column_Offset
            // 
            this.column_Offset.HeaderText = "Offset";
            this.column_Offset.Name = "column_Offset";
            // 
            // column_DataType
            // 
            this.column_DataType.HeaderText = "Data Type";
            this.column_DataType.Name = "column_DataType";
            // 
            // column_Value
            // 
            this.column_Value.HeaderText = "Value";
            this.column_Value.Name = "column_Value";
            // 
            // column_UM
            // 
            this.column_UM.HeaderText = "UM";
            this.column_UM.Name = "column_UM";
            // 
            // buttonCreateChart
            // 
            this.buttonCreateChart.Location = new System.Drawing.Point(16, 305);
            this.buttonCreateChart.Name = "buttonCreateChart";
            this.buttonCreateChart.Size = new System.Drawing.Size(107, 33);
            this.buttonCreateChart.TabIndex = 13;
            this.buttonCreateChart.Text = "Create Graph";
            this.buttonCreateChart.UseVisualStyleBackColor = true;
            this.buttonCreateChart.Click += new System.EventHandler(this.buttonCreateChart_Click);
            // 
            // textBoxItemName
            // 
            this.textBoxItemName.Location = new System.Drawing.Point(16, 279);
            this.textBoxItemName.Name = "textBoxItemName";
            this.textBoxItemName.Size = new System.Drawing.Size(107, 20);
            this.textBoxItemName.TabIndex = 14;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(43, 594);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1094, 246);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 859);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PLCValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerReadPLC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_ConnectStatus;
        private System.Windows.Forms.ComboBox comboBox_CPU_Type;
        private System.Windows.Forms.Button button_Connect_PLC;
        private System.Windows.Forms.TextBox textBox_Slot;
        private System.Windows.Forms.TextBox textBox_Rack;
        private System.Windows.Forms.TextBox textBox_IP_Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_DB_Locations;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Location;
        private System.Windows.Forms.TextBox textBox_DB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_PLCValues;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.ComboBox comboBox_DataType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView_ConnectedPLCs;
        private System.Windows.Forms.Button button_Disconnect_Selected_PLC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_generateReport;
        private System.Windows.Forms.TextBox textBox_toSecond;
        private System.Windows.Forms.TextBox textBox_toMinute;
        private System.Windows.Forms.TextBox textBox_toHour;
        private System.Windows.Forms.TextBox textBox_toDay;
        private System.Windows.Forms.TextBox textBox_toMonth;
        private System.Windows.Forms.TextBox textBox_toYear;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_fromSecond;
        private System.Windows.Forms.TextBox textBox_fromMinute;
        private System.Windows.Forms.TextBox textBox_fromHour;
        private System.Windows.Forms.TextBox textBox_fromDay;
        private System.Windows.Forms.TextBox textBox_fromMonth;
        private System.Windows.Forms.TextBox textBox_fromYear;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_UM;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_PLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_UM;
        private System.Windows.Forms.Button button_generateCSV;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label_displayInterval;
        private System.Windows.Forms.Button button_setInterval;
        private System.Windows.Forms.TextBox textBox_timeInterval;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxItemName;
        private System.Windows.Forms.Button buttonCreateChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

