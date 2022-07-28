
namespace WindowsFormsApp1
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab_CloudKeysAndConnection = new System.Windows.Forms.TabPage();
            this.button_CreateCloudCosmosDBClient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_AzureAccountPrimaryKey = new System.Windows.Forms.TextBox();
            this.textBox_AzureAccountEndPointUri = new System.Windows.Forms.TextBox();
            this.tab_DataBasesAndTables = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Query = new System.Windows.Forms.Button();
            this.btn_deleteSelectedTable = new System.Windows.Forms.Button();
            this.btn_refreshTableList = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_cloudTables = new System.Windows.Forms.ComboBox();
            this.btn_SelectedDatabase = new System.Windows.Forms.Button();
            this.btn_rfreshDatabasesList = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_CloudDatabases = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_CreateUserDataInCloud = new System.Windows.Forms.Button();
            this.textBox_TableNameFromUser = new System.Windows.Forms.TextBox();
            this.textBox_DatabaseNameFromUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tab_QueryResultsAsJSON = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_updatecloud = new System.Windows.Forms.Button();
            this.checkedListBox_activitytype = new System.Windows.Forms.CheckedListBox();
            this.richTextBox_studentdataasjson = new System.Windows.Forms.RichTextBox();
            this.tab_ImportExportActivities = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ImportExportDir = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.tab_CloudKeysAndConnection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_DataBasesAndTables.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tab_QueryResultsAsJSON.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tab_ImportExportActivities.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tab_CloudKeysAndConnection);
            this.tabs.Controls.Add(this.tab_DataBasesAndTables);
            this.tabs.Controls.Add(this.tab_QueryResultsAsJSON);
            this.tabs.Controls.Add(this.tab_ImportExportActivities);
            this.tabs.Location = new System.Drawing.Point(16, 13);
            this.tabs.Margin = new System.Windows.Forms.Padding(4);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1067, 909);
            this.tabs.TabIndex = 0;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            this.tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabs_Selecting);
            // 
            // tab_CloudKeysAndConnection
            // 
            this.tab_CloudKeysAndConnection.Controls.Add(this.button_CreateCloudCosmosDBClient);
            this.tab_CloudKeysAndConnection.Controls.Add(this.panel1);
            this.tab_CloudKeysAndConnection.Location = new System.Drawing.Point(4, 25);
            this.tab_CloudKeysAndConnection.Margin = new System.Windows.Forms.Padding(4);
            this.tab_CloudKeysAndConnection.Name = "tab_CloudKeysAndConnection";
            this.tab_CloudKeysAndConnection.Padding = new System.Windows.Forms.Padding(4);
            this.tab_CloudKeysAndConnection.Size = new System.Drawing.Size(1059, 878);
            this.tab_CloudKeysAndConnection.TabIndex = 0;
            this.tab_CloudKeysAndConnection.Text = "Cloud Keys & Cosmos Client Creation ";
            this.tab_CloudKeysAndConnection.UseVisualStyleBackColor = true;
            // 
            // button_CreateCloudCosmosDBClient
            // 
            this.button_CreateCloudCosmosDBClient.Location = new System.Drawing.Point(59, 297);
            this.button_CreateCloudCosmosDBClient.Margin = new System.Windows.Forms.Padding(4);
            this.button_CreateCloudCosmosDBClient.Name = "button_CreateCloudCosmosDBClient";
            this.button_CreateCloudCosmosDBClient.Size = new System.Drawing.Size(447, 28);
            this.button_CreateCloudCosmosDBClient.TabIndex = 1;
            this.button_CreateCloudCosmosDBClient.Text = "Create Cloud Cosmos DB Client";
            this.button_CreateCloudCosmosDBClient.UseVisualStyleBackColor = true;
            this.button_CreateCloudCosmosDBClient.Click += new System.EventHandler(this.button_CreateCloudCosmosDBClient_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(28, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 238);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_AzureAccountPrimaryKey);
            this.groupBox1.Controls.Add(this.textBox_AzureAccountEndPointUri);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(29, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(599, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Azure DB Connection Details (from configuration):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primary Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "End Point Uri:";
            // 
            // textBox_AzureAccountPrimaryKey
            // 
            this.textBox_AzureAccountPrimaryKey.Location = new System.Drawing.Point(141, 108);
            this.textBox_AzureAccountPrimaryKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AzureAccountPrimaryKey.Name = "textBox_AzureAccountPrimaryKey";
            this.textBox_AzureAccountPrimaryKey.ReadOnly = true;
            this.textBox_AzureAccountPrimaryKey.Size = new System.Drawing.Size(401, 22);
            this.textBox_AzureAccountPrimaryKey.TabIndex = 1;
            // 
            // textBox_AzureAccountEndPointUri
            // 
            this.textBox_AzureAccountEndPointUri.Location = new System.Drawing.Point(141, 52);
            this.textBox_AzureAccountEndPointUri.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AzureAccountEndPointUri.Name = "textBox_AzureAccountEndPointUri";
            this.textBox_AzureAccountEndPointUri.ReadOnly = true;
            this.textBox_AzureAccountEndPointUri.Size = new System.Drawing.Size(401, 22);
            this.textBox_AzureAccountEndPointUri.TabIndex = 0;
            // 
            // tab_DataBasesAndTables
            // 
            this.tab_DataBasesAndTables.Controls.Add(this.panel4);
            this.tab_DataBasesAndTables.Controls.Add(this.panel3);
            this.tab_DataBasesAndTables.Location = new System.Drawing.Point(4, 25);
            this.tab_DataBasesAndTables.Margin = new System.Windows.Forms.Padding(4);
            this.tab_DataBasesAndTables.Name = "tab_DataBasesAndTables";
            this.tab_DataBasesAndTables.Padding = new System.Windows.Forms.Padding(4);
            this.tab_DataBasesAndTables.Size = new System.Drawing.Size(1059, 880);
            this.tab_DataBasesAndTables.TabIndex = 1;
            this.tab_DataBasesAndTables.Text = "Cloud DataBases and Tables";
            this.tab_DataBasesAndTables.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btn_Query);
            this.panel4.Controls.Add(this.btn_deleteSelectedTable);
            this.panel4.Controls.Add(this.btn_refreshTableList);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.comboBox_cloudTables);
            this.panel4.Controls.Add(this.btn_SelectedDatabase);
            this.panel4.Controls.Add(this.btn_rfreshDatabasesList);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.comboBox_CloudDatabases);
            this.panel4.Location = new System.Drawing.Point(25, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(716, 190);
            this.panel4.TabIndex = 2;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(143, 127);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(308, 28);
            this.btn_Query.TabIndex = 10;
            this.btn_Query.Text = "Query selected table selected database";
            this.btn_Query.UseVisualStyleBackColor = true;
            // 
            // btn_deleteSelectedTable
            // 
            this.btn_deleteSelectedTable.Location = new System.Drawing.Point(533, 108);
            this.btn_deleteSelectedTable.Name = "btn_deleteSelectedTable";
            this.btn_deleteSelectedTable.Size = new System.Drawing.Size(169, 23);
            this.btn_deleteSelectedTable.TabIndex = 9;
            this.btn_deleteSelectedTable.Text = "delete selected table";
            this.btn_deleteSelectedTable.UseVisualStyleBackColor = true;
            this.btn_deleteSelectedTable.Click += new System.EventHandler(this.btn_deleteSelectedTable_Click);
            // 
            // btn_refreshTableList
            // 
            this.btn_refreshTableList.Location = new System.Drawing.Point(533, 79);
            this.btn_refreshTableList.Name = "btn_refreshTableList";
            this.btn_refreshTableList.Size = new System.Drawing.Size(169, 23);
            this.btn_refreshTableList.TabIndex = 8;
            this.btn_refreshTableList.Text = "refresh table list";
            this.btn_refreshTableList.UseVisualStyleBackColor = true;
            this.btn_refreshTableList.Click += new System.EventHandler(this.btn_refreshTableList_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tables";
            // 
            // comboBox_cloudTables
            // 
            this.comboBox_cloudTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cloudTables.FormattingEnabled = true;
            this.comboBox_cloudTables.Location = new System.Drawing.Point(101, 78);
            this.comboBox_cloudTables.Name = "comboBox_cloudTables";
            this.comboBox_cloudTables.Size = new System.Drawing.Size(412, 24);
            this.comboBox_cloudTables.TabIndex = 6;
            this.comboBox_cloudTables.SelectedIndexChanged += new System.EventHandler(this.comboBox_cloudTables_SelectedIndexChanged);
            // 
            // btn_SelectedDatabase
            // 
            this.btn_SelectedDatabase.Location = new System.Drawing.Point(533, 46);
            this.btn_SelectedDatabase.Name = "btn_SelectedDatabase";
            this.btn_SelectedDatabase.Size = new System.Drawing.Size(169, 23);
            this.btn_SelectedDatabase.TabIndex = 5;
            this.btn_SelectedDatabase.Text = "delete selected database";
            this.btn_SelectedDatabase.UseVisualStyleBackColor = true;
            this.btn_SelectedDatabase.Click += new System.EventHandler(this.btn_SelectedDatabase_Click);
            // 
            // btn_rfreshDatabasesList
            // 
            this.btn_rfreshDatabasesList.Location = new System.Drawing.Point(533, 17);
            this.btn_rfreshDatabasesList.Name = "btn_rfreshDatabasesList";
            this.btn_rfreshDatabasesList.Size = new System.Drawing.Size(169, 23);
            this.btn_rfreshDatabasesList.TabIndex = 4;
            this.btn_rfreshDatabasesList.Text = "refresh databases list";
            this.btn_rfreshDatabasesList.UseVisualStyleBackColor = true;
            this.btn_rfreshDatabasesList.Click += new System.EventHandler(this.btn_rfreshDatabasesList_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Databases";
            // 
            // comboBox_CloudDatabases
            // 
            this.comboBox_CloudDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CloudDatabases.FormattingEnabled = true;
            this.comboBox_CloudDatabases.Location = new System.Drawing.Point(101, 16);
            this.comboBox_CloudDatabases.Name = "comboBox_CloudDatabases";
            this.comboBox_CloudDatabases.Size = new System.Drawing.Size(412, 24);
            this.comboBox_CloudDatabases.TabIndex = 1;
            this.comboBox_CloudDatabases.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btn_CreateUserDataInCloud);
            this.panel3.Controls.Add(this.textBox_TableNameFromUser);
            this.panel3.Controls.Add(this.textBox_DatabaseNameFromUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.ForeColor = System.Drawing.Color.Maroon;
            this.panel3.Location = new System.Drawing.Point(25, 251);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 246);
            this.panel3.TabIndex = 0;
            // 
            // btn_CreateUserDataInCloud
            // 
            this.btn_CreateUserDataInCloud.Location = new System.Drawing.Point(167, 32);
            this.btn_CreateUserDataInCloud.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CreateUserDataInCloud.Name = "btn_CreateUserDataInCloud";
            this.btn_CreateUserDataInCloud.Size = new System.Drawing.Size(193, 28);
            this.btn_CreateUserDataInCloud.TabIndex = 4;
            this.btn_CreateUserDataInCloud.Text = "Create In Cloud";
            this.btn_CreateUserDataInCloud.UseVisualStyleBackColor = true;
            this.btn_CreateUserDataInCloud.Click += new System.EventHandler(this.btn_CreateUserDataInCloud_Click);
            // 
            // textBox_TableNameFromUser
            // 
            this.textBox_TableNameFromUser.Location = new System.Drawing.Point(99, 130);
            this.textBox_TableNameFromUser.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_TableNameFromUser.Name = "textBox_TableNameFromUser";
            this.textBox_TableNameFromUser.Size = new System.Drawing.Size(342, 22);
            this.textBox_TableNameFromUser.TabIndex = 3;
            // 
            // textBox_DatabaseNameFromUser
            // 
            this.textBox_DatabaseNameFromUser.Location = new System.Drawing.Point(99, 82);
            this.textBox_DatabaseNameFromUser.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_DatabaseNameFromUser.Name = "textBox_DatabaseNameFromUser";
            this.textBox_DatabaseNameFromUser.Size = new System.Drawing.Size(342, 22);
            this.textBox_DatabaseNameFromUser.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Table";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Database";
            // 
            // tab_QueryResultsAsJSON
            // 
            this.tab_QueryResultsAsJSON.Controls.Add(this.panel5);
            this.tab_QueryResultsAsJSON.Location = new System.Drawing.Point(4, 25);
            this.tab_QueryResultsAsJSON.Margin = new System.Windows.Forms.Padding(4);
            this.tab_QueryResultsAsJSON.Name = "tab_QueryResultsAsJSON";
            this.tab_QueryResultsAsJSON.Size = new System.Drawing.Size(1059, 880);
            this.tab_QueryResultsAsJSON.TabIndex = 4;
            this.tab_QueryResultsAsJSON.Text = "Query Results as JSON";
            this.tab_QueryResultsAsJSON.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btn_updatecloud);
            this.panel5.Controls.Add(this.checkedListBox_activitytype);
            this.panel5.Controls.Add(this.richTextBox_studentdataasjson);
            this.panel5.Location = new System.Drawing.Point(15, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(677, 473);
            this.panel5.TabIndex = 0;
            // 
            // btn_updatecloud
            // 
            this.btn_updatecloud.Location = new System.Drawing.Point(289, 412);
            this.btn_updatecloud.Name = "btn_updatecloud";
            this.btn_updatecloud.Size = new System.Drawing.Size(336, 31);
            this.btn_updatecloud.TabIndex = 2;
            this.btn_updatecloud.Text = "update cloud according to selected activity";
            this.btn_updatecloud.UseVisualStyleBackColor = true;
            this.btn_updatecloud.Click += new System.EventHandler(this.btn_updatecloud_Click);
            // 
            // checkedListBox_activitytype
            // 
            this.checkedListBox_activitytype.FormattingEnabled = true;
            this.checkedListBox_activitytype.Items.AddRange(new object[] {
            "insert New student into cloud",
            "modify existing student cloud",
            "delete from student cloud"});
            this.checkedListBox_activitytype.Location = new System.Drawing.Point(22, 398);
            this.checkedListBox_activitytype.Name = "checkedListBox_activitytype";
            this.checkedListBox_activitytype.Size = new System.Drawing.Size(209, 55);
            this.checkedListBox_activitytype.TabIndex = 1;
            // 
            // richTextBox_studentdataasjson
            // 
            this.richTextBox_studentdataasjson.Location = new System.Drawing.Point(22, 18);
            this.richTextBox_studentdataasjson.Name = "richTextBox_studentdataasjson";
            this.richTextBox_studentdataasjson.Size = new System.Drawing.Size(637, 374);
            this.richTextBox_studentdataasjson.TabIndex = 0;
            this.richTextBox_studentdataasjson.Text = "";
            // 
            // tab_ImportExportActivities
            // 
            this.tab_ImportExportActivities.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tab_ImportExportActivities.Controls.Add(this.panel2);
            this.tab_ImportExportActivities.Location = new System.Drawing.Point(4, 25);
            this.tab_ImportExportActivities.Margin = new System.Windows.Forms.Padding(4);
            this.tab_ImportExportActivities.Name = "tab_ImportExportActivities";
            this.tab_ImportExportActivities.Size = new System.Drawing.Size(1059, 878);
            this.tab_ImportExportActivities.TabIndex = 5;
            this.tab_ImportExportActivities.Text = "Import/Export";
            this.tab_ImportExportActivities.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(21, 252);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 203);
            this.panel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_ImportExportDir);
            this.groupBox2.Location = new System.Drawing.Point(21, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(622, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose the file for the import export activity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(28, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Import / Export Directory:";
            // 
            // textBox_ImportExportDir
            // 
            this.textBox_ImportExportDir.Location = new System.Drawing.Point(216, 37);
            this.textBox_ImportExportDir.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ImportExportDir.Name = "textBox_ImportExportDir";
            this.textBox_ImportExportDir.ReadOnly = true;
            this.textBox_ImportExportDir.Size = new System.Drawing.Size(362, 22);
            this.textBox_ImportExportDir.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 548);
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Students Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabs.ResumeLayout(false);
            this.tab_CloudKeysAndConnection.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_DataBasesAndTables.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tab_QueryResultsAsJSON.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tab_ImportExportActivities.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab_CloudKeysAndConnection;
        private System.Windows.Forms.TabPage tab_DataBasesAndTables;
        private System.Windows.Forms.TabPage tab_QueryResultsAsJSON;
        private System.Windows.Forms.TabPage tab_ImportExportActivities;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_AzureAccountPrimaryKey;
        private System.Windows.Forms.TextBox textBox_AzureAccountEndPointUri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CreateCloudCosmosDBClient;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ImportExportDir;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_CreateUserDataInCloud;
        private System.Windows.Forms.TextBox textBox_TableNameFromUser;
        private System.Windows.Forms.TextBox textBox_DatabaseNameFromUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox_CloudDatabases;
        private System.Windows.Forms.Button btn_rfreshDatabasesList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_SelectedDatabase;
        private System.Windows.Forms.Button btn_deleteSelectedTable;
        private System.Windows.Forms.Button btn_refreshTableList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_cloudTables;
        private System.Windows.Forms.Button btn_Query;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_updatecloud;
        private System.Windows.Forms.CheckedListBox checkedListBox_activitytype;
        private System.Windows.Forms.RichTextBox richTextBox_studentdataasjson;
    }
}

