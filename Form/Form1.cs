using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //getting the value of the key endpointUri
        private static readonly string endPointUri = ConfigurationManager.AppSettings["EndpointUri"];
        //getting the value of the key primary key
        private static readonly string primaryKey = ConfigurationManager.AppSettings["primaryKey"];
        //getting the number of maxTimeout and converting it to int because its a number
        private static readonly int MaxTimeoutForCloudActivities  = Convert.ToInt32(ConfigurationManager.AppSettings["MaxTimeoutForCloudActivities"]);
        private static readonly string importExportFolder = ConfigurationManager.AppSettings["ImportExportFolder"];
        private static readonly string PartitionKey = ConfigurationManager.AppSettings["PartitionKey"];
        
        private CloudDataAndActivities CloudDataAndActivities;

        private bool cloudDataBasesSuccessfullyRetrived;
        private bool cloudTablesSuccessfullyRetrived;
        private System.IO.DirectoryInfo dirForImportExport;

        public Form1()
        {
            InitializeComponent();
        }

        //function that creates a directory for the current path of the importexport and shows the full name of the directory 
        private void CreateImportExportDirectory()
        {//if it doesn't create for whatever reason the user will see a message of the error
            try
            {//creating the  path and putting it to string
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, importExportFolder);
                //creating directory in the specified path
                dirForImportExport = System.IO.Directory.CreateDirectory(path);
                //showing the full name of the directory in the textBox
                textBox_ImportExportDir.Text = dirForImportExport.FullName;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to create the import export folder, brcause:\n " + ex.Message, "Failed to create import-export directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //if the directory was not created the textbox will include an empty string
                textBox_ImportExportDir.Text = string.Empty;
                //giving the value null to the directory since nothing was created
                dirForImportExport = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CloudDataAndActivities = new CloudDataAndActivities(endPointUri, primaryKey);

            //Set the connection string data upon the screen
            textBox_AzureAccountEndPointUri.Text = endPointUri;
            textBox_AzureAccountPrimaryKey.Text = primaryKey;

            CreateImportExportDirectory();
        }

        //function that is created for the button(Create cloud cosmos)
        private void button_CreateCloudCosmosDBClient_Click(object sender, EventArgs e)
        {//when pressing on the button we create a cloud cosmos DB
            //The following if is now un-needed:
            if (CloudDataAndActivities.IsCosmosDBClientCreated)
            {//if cosmos client is already created then we will see this message
                MessageBox.Show("COSMOS DB Client already created.", "Cosmos Client already created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    //if the code reached this place than there is no cosmos client
                    //creating a cosmos client
                    CloudDataAndActivities.CreateCosmosClient();
                    MessageBox.Show("Cosmos DB Client was successfully created", "Client Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //after creating a cosmos client we disable the button
                    button_CreateCloudCosmosDBClient.Enabled = false;

                    //We have cosmos client so we can get the DBs and Tables information
                    getCloudDataBasesAndTables();
                }
                catch (Exception ex)
                {//MessageBox.Show("the message", "The message title", MessageBoxButtons.Ok, MessageBoxIcon.Error);
                    MessageBox.Show("Cosmos DB Creation failed because:\n"+ ex.Message, "Cosmos Client creation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //the button remains active
                }
            }
        }

        //getting the databases and tables from the cloud account
        private void getCloudDataBasesAndTables()
        {
            // stage1: get the databases from the cloud
            CloudDataAndActivities.GetDataBases(MaxTimeoutForCloudActivities, ref cloudDataBasesSuccessfullyRetrived);
            // stage2: get the containers from the cloud
            CloudDataAndActivities.getCloudTables(MaxTimeoutForCloudActivities, ref cloudTablesSuccessfullyRetrived);
        }

        //this function checks if the user clicks on another tab except the first tab before creating a cosmos client 
        private void tabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if we are selecting a tab that is not the first tabpage
            if (e.TabPage != this.tabs.TabPages[0])
            {
                //cosmos client אם לחצתי על לשונית אחרת לפני שיצרתי 
                if (!CloudDataAndActivities.IsCosmosDBClientCreated)   
                {
                    MessageBox.Show("Please create a cosmos client first, and only then the cloud activities will be enabled", "Cosmos Client was not Created Yet", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;//canceling the event
                }
                //if the client was not able to get the database and tables then there is no need to enter the other tabs
                else if ((!cloudDataBasesSuccessfullyRetrived) || (!cloudTablesSuccessfullyRetrived))
                    {
                   MessageBox.Show("There were problems to retrieve data from the cloud.\nTherefore, it is not possible to navigate to the other tabs right now.", "problems in reading DBs / Tables from Cloud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   e.Cancel = true;
                }
                //if we select the Import tab page and the directory is empty
                else if ((e.TabPage.Name.Contains("Import"))&&(dirForImportExport == null))
                {
                    MessageBox.Show("There was a failure in createing the import-export folder.\nThis means that there is no option for import-export activitise at the moment","No import/export folder", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    e.Cancel = true;
                }
            }
        }

        //this function activates the function that creates database and table in cloud once the user clicks on the button
        private async void btn_CreateUserDataInCloud_Click(object sender, EventArgs e)
        { //the database and table will be named to what the user has gave 
            string dataBaseName = textBox_DatabaseNameFromUser.Text;
            string tableName = textBox_TableNameFromUser.Text;
            await CreateDatabaseAndTableInCloud(dataBaseName, tableName);

        }

        //creating database and table in the cloud
        private async Task CreateDatabaseAndTableInCloud(string dataBaseName, string tableName)
        {//if the database was created this variable will get the database
            Microsoft.Azure.Cosmos.Database createdDB = null;

            #region Database Creation

            //Database Creation 
            //checking if the user entered a database name
            if (!String.IsNullOrEmpty(dataBaseName))
            {
                try
                {
                    //Create the database in the cloud
                    Microsoft.Azure.Cosmos.DatabaseResponse databaseResponse = await CloudDataAndActivities.CreateDatabaseAsync(dataBaseName);
                    //getting the database name
                    createdDB = databaseResponse.Database;
                    //getting the database status code
                    System.Net.HttpStatusCode createDataBaseStatusCode = databaseResponse.StatusCode;
                    //if status code was created
                    if (createDataBaseStatusCode == System.Net.HttpStatusCode.Created)
                    {
                        MessageBox.Show("Database '" + dataBaseName + "' was successfully created in your cloud account.", "Database was created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if statusCode was ok or accepter but not created which means that the database already exists
                    else if ((createDataBaseStatusCode == System.Net.HttpStatusCode.OK) || (createDataBaseStatusCode == System.Net.HttpStatusCode.Accepted))
                    {
                        MessageBox.Show("Database '" + dataBaseName + "' was not created in your cloud account, because it is already exists.", "Database was not created", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Database '" + dataBaseName + "' was not created in your cloud account, and the process ended with the following status code: " + createDataBaseStatusCode, "Database was not created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database was not created. The process ended with the following error:\n" + ex.Message, "Database was not created", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }


            #endregion
            //creating table in the database
            #region Table ragion
            if (!String.IsNullOrEmpty(tableName))
            {
                try
                {
                    // creat the new container in the cloud
                    System.Net.HttpStatusCode createContainerStatusCode = await CloudDataAndActivities.CreateContainerAsync(createdDB, tableName, PartitionKey);
                    //if table was created successfully
                    if (createContainerStatusCode == System.Net.HttpStatusCode.Created)
                    {
                        MessageBox.Show("Table '  " + tableName + "' was succfull crated in ypur cloud account ,within the ", "table was created ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if table already exists
                    else if ((createContainerStatusCode == System.Net.HttpStatusCode.OK) || (createContainerStatusCode == System.Net.HttpStatusCode.Accepted))
                    {
                        MessageBox.Show("Table ' " + tableName + "' was not created in your cloud account ,because it is already exists", "Table was not created ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        MessageBox.Show("Table ' " + tableName + "' was not created in your cloud account ,and the process ended with the following srarus code : " + createContainerStatusCode, "Table was not created ", MessageBoxButtons.OK);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("table" + tableName + " was not created . The proecss ended with the following error:\n" + ex.Message, "table was not created ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            #endregion
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //a function that filters the comboBox incase there was tables in it then we pass the new filtered tables that are related to a certain database
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the db name that was selected 
            if ( comboBox_CloudDatabases.SelectedItem!= null)
            {
                CloudDataAndActivities.DataBaseName = ((Models.DataBase)comboBox_CloudDatabases.SelectedItem).DataBaseId;
            }
            // present only the table wich belong to the selected database
            filtertablelistselected(CloudDataAndActivities.DataBaseName);
        }

        //refreshing the databases once the user clicks on the refresh button and showing them in the dropdown list
        private void btn_rfreshDatabasesList_Click(object sender, EventArgs e)
        {
            getCloudDataBasesAndTables();
            //refreshing the databases once the user clicks on the refresh button and showing them in the dropdown list            comboBox_CloudDatabases.DataSource = null;
            comboBox_CloudDatabases.Items.Clear();
            // set the relevant datasource into the dropdownlist
            comboBox_CloudDatabases.DataSource = CloudDataAndActivities.CloudDataBases;
            comboBox_CloudDatabases.DisplayMember = "DataBaseId";
            // after refreshing the database list no database is currently selected
            CloudDataAndActivities.DataBaseName = String.Empty;
            MessageBox.Show("Refresh suceeded", "refresh succeeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //function that triggers the deleteing database function once the user clicks on the delete button and the selected db will be deleted from the cosmosClient
        private async void btn_SelectedDatabase_Click(object sender, EventArgs e)
        {
            string dbForDelete = ((Models.DataBase)comboBox_CloudDatabases.SelectedItem).DataBaseId;
            try
            {
                // from here i will trigger the deleted function
                // delete the database which is currently selected upon the screen
                await CloudDataAndActivities.DeleteDatabaseAsync(dbForDelete);
                MessageBox.Show("database" + dbForDelete + "was deleted", "delete succeeded", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("database was not deleted because of the following exception:\n" + ex.Message);

            }
            MessageBox.Show("the selected DB:" + dbForDelete);
        }

        //a button that once its clicked it triggers this functions and refreshes the tables that are inside a specific data base
        private void btn_refreshTableList_Click(object sender, EventArgs e)
        {
            getCloudDataBasesAndTables(); // get the most updatated DB and table list

            comboBox_cloudTables.DataSource = null;
            comboBox_cloudTables.Items.Clear();

            comboBox_cloudTables.DataSource = CloudDataAndActivities.CloudTables;
            comboBox_cloudTables.DisplayMember = "TableName";
            MessageBox.Show("refresh table was done");

            // if the user press the refresh button then he wants to see the table that belong to the selected DB
            if (comboBox_CloudDatabases.DataSource != null)
            {
                string selectedDB = ((Models.DataBase)comboBox_CloudDatabases.SelectedItem).DataBaseId;
                filtertablelistselected(selectedDB);
            }
    }

        //if the user clicks on the delete table button after selecting a table it will trigger this event and a table from a certain database will be deleted
        private async void btn_deleteSelectedTable_Click(object sender, EventArgs e)
        {
            //getting the table name as a string
            string tableToDelete = ((Models.Table)comboBox_cloudTables.SelectedItem).TableName;
            //getting the database id of the table we want to delete as a string
            string dbForDelete = ((Models.Table)comboBox_cloudTables.SelectedItem).DataBaseId;
            //using the function to delete a table by passing the database name of the deleted table and the table name as parameters
            await CloudDataAndActivities.DeleteContainerAsync(dbForDelete, tableToDelete);
            //we need to check the return code of the above function, we need to check if no exception was thrown 
            MessageBox.Show("selected : table: " + tableToDelete + "\n in DB " + dbForDelete+" this table was deleted ");
        }

        //this function filters all the tables that are related to a certain database and ignores the other tables
        //setting a default value for databaseId incase the user didn't pass any value into the parameter
        private void filtertablelistselected(string dbid="")
        {

            // stage 1 : clear the current table list
            if(comboBox_cloudTables.Items != null) 
            {
                comboBox_cloudTables.DataSource = null;
                comboBox_cloudTables.Items.Clear();

            }

            //stage2: scan all the tables and choose the tables that belong to the DB
            foreach (Models.Table table in CloudDataAndActivities.CloudTables)
            {
                // skip the table wich dosent not relate to the input DB 
                if (!table.DataBaseId.Equals(dbid))
                {
                    continue;
                }
                // if the code come to this place' then we have a table that its DB equal to the input DB
                comboBox_cloudTables.Items.Add(table);
                comboBox_cloudTables.DisplayMember = "TableName";
            }
        }

        private async void btn_updatecloud_Click(object sender, EventArgs e)
        {
            //the current text on the tab
            string studentdataasjson = richTextBox_studentdataasjson.Text;
            //converting the string to a list
            List<Models.Student> currentstudentontab = Models.Student.ConvertStudentDataFromStringToList(studentdataasjson);
            // assumption : we have a single choice - we do not perform any validation (as we shuld)
            string selectedactivity = checkedListBox_activitytype.CheckedItems[0].ToString();
            try
            {
                //if the user chose insert then the list of students and the activity will be passed to the updating function 
                if (selectedactivity.Contains("insert"))
                    await CloudDataAndActivities.updatestudentdataintocloudasync(currentstudentontab, CloudDataAndActivities.RowStatus.New);
                //if the user chose Modify then the list of students and the activity will be passed to the updating function 
                else if (selectedactivity.Contains("modify"))
                    await CloudDataAndActivities.updatestudentdataintocloudasync(currentstudentontab, CloudDataAndActivities.RowStatus.Modify);
                //if the user chose delete then the list of students and the activity will be passed to the updating function 
                else if (selectedactivity.Contains("deleted"))
                    await CloudDataAndActivities.updatestudentdataintocloudasync(currentstudentontab, CloudDataAndActivities.RowStatus.Delete);
                //after the activity was done a message will appear on the users screen
                MessageBox.Show("activity was done (" + selectedactivity + ")");
            }
            catch (Exception ex)
            {//if in any case there was an error , the user will be able to see whats wrong on his screen 
                MessageBox.Show("the following exception was thrown:\n\n\n" + ex.Message);
            }

        }

        private void comboBox_cloudTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the table name is not null
            if (comboBox_cloudTables.SelectedItem != null)
            {
                // get the db name that was selected 
                CloudDataAndActivities.TableName = ((Models.Table)comboBox_cloudTables.SelectedItem).TableName;
            }

        }
    }
}


    

