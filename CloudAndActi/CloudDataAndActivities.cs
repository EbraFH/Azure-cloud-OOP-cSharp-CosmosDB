using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class CloudDataAndActivities
    {
        //Azure Cosmos DB params for connection string
        private String endPointUri;
        public String EndPointUri
        {
            get
            {
                return endPointUri;
            }
        }

        private String primaryKey;
        public String PrimaryKey
        {
            get
            {
                return primaryKey;
            }
        }

        private bool isCosmosDBClientCreated = false;
        public bool IsCosmosDBClientCreated
        {//checking if we created a CosmosDBClient
            get
            {
                return isCosmosDBClientCreated;
            }
        }

        private Microsoft.Azure.Cosmos.CosmosClient CosmosClient;

        //creating a list that its type is Models.DataBase for cloud dataBase
        //this list will include a collection of databases
        private List<Models.DataBase> cloudDataBases = new List<Models.DataBase>();
        public List<Models.DataBase> CloudDataBases
        {//list that has a value of database(like an array)
         //we are not using set so no one can change our list from the outside
            get
            {
                return cloudDataBases;
            }
        }

        //creating a list that its type is Models.Table that has a collection of cloud tables
        private List<Models.Table> cloudTables = new List<Models.Table>();
        public List<Models.Table> CloudTables
        {//getting the cloudTables 
            get
            {
                return cloudTables;
            }
        }

        //The database Name
        private string dataBaseName;
        //proprety for the dataBaseName
        public string DataBaseName
        {//getting the dataBaseName and we are able to change the name of the dataBase by using the set
            get
            {
                return dataBaseName;
            }
            set
            {//set for the dataBaseName incase the user wants to change the name of the data base
                    dataBaseName = value;
            }
        }

        //The database object itself
        private Microsoft.Azure.Cosmos.Database dataBaseObject = null;
        //proprety for dataBaseObject 
        public Microsoft.Azure.Cosmos.Database DataBaseObject
        {//returning the dataBase that the user selected
            get
            {
                return dataBaseObject;
            }
        }

        //The table Name
        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {//set for the tableName incase the user wants to change the name of the table
                tableName = value;
            }
        }

        //table in the cloud
        //container is like a list that comes from the cloud
        //started as null incase no table was selected
        private Microsoft.Azure.Cosmos.Container container= null;
        public Microsoft.Azure.Cosmos.Container ContainerObject 
        {
            get
            {
                return container;
            }
        }

        //a list that includes students
        private List<Models.Student> studentDataAsList = new List<Models.Student>();
        //proprety for students list
        public List<Models.Student> StudentDataAsList
        {
            get
            {
                return studentDataAsList;
            }
            set
            {
                studentDataAsList = value;
            }
        }

        //starting the variable as an empty string
        private string studentDataAsString = string.Empty;
        public string StudentDataAsString
        {//returning the students data and with set we can change the student data 
            get
            {
                return studentDataAsString;
            }
            set
            {
                studentDataAsString = value;
            }
        }

        public enum RowStatus
        {
            NotModified = 700,//modified a row and the user saved it but nothing was changed in the row
            Modify,//modified a row and didn't delete it (just updated it)
            New,//added a new row
            Delete//delete a row
        }

        //dictionary prevents us from duplications
        //in the dictionary we have student id as a string and the row status
        private Dictionary<string, RowStatus> studentDataAsDictionary = new Dictionary<string, RowStatus>();
        public Dictionary<string, RowStatus> StudentDataAsDictionary
        {
            get
            {
                return studentDataAsDictionary;
            }
            set
            {
                studentDataAsDictionary = value;
            }
        }

        //constructor that has 2 strings endpointUri and primaryKey to start the connection
        public CloudDataAndActivities(string end_point_uri, string primary_key)
        {
            endPointUri = end_point_uri;
            primaryKey = primary_key;
        }

        //creating a cosmos client 
        public void CreateCosmosClient()
        {//using try catch because theres a chance to fail the connection to the azure

            try
            {
                CosmosClient = new Microsoft.Azure.Cosmos.CosmosClient(endPointUri, primaryKey);
            }
            //if the connection was failed the UI will return the exception
            catch (Exception ex)
            {
                isCosmosDBClientCreated = false;
                //throw new exception("write the error you want here"):
                throw ex;
            }
            //if connection was succefull 
            isCosmosDBClientCreated = true;
        }

        //function that creates an un-existed database in the cloud 
        //since we are using async we have to use the await
        //the async returns a task because thats how the async works
        public async Task<Microsoft.Azure.Cosmos.DatabaseResponse> CreateDatabaseAsync(string database_name)
        {
           Microsoft.Azure.Cosmos.DatabaseResponse databaseResponse = await CosmosClient.CreateDatabaseIfNotExistsAsync(database_name);

            return databaseResponse;
        }

        //function that gets 3 parameters  the database , table name and partition key. 
        //creates a table inside the database in the azure cosmos if the table does not exist
        public async Task<System.Net.HttpStatusCode> CreateContainerAsync(Microsoft.Azure.Cosmos.Database databaseObj, string table_name, string partition_key)
        {
            Microsoft.Azure.Cosmos.ContainerResponse result = await databaseObj.CreateContainerIfNotExistsAsync(table_name, partition_key);
            return result.StatusCode;
        }

        // bounos Q - connection by SQL 
        private async Task getDataBasesAsync2()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = endPointUri;
            builder.UserID = primaryKey;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "SELECT name FROM sys.databases ";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        do
                        {
                            Models.DataBase curentDataBase = new Models.DataBase();
                            curentDataBase.DataBaseId = reader.GetString(reader.VisibleFieldCount);
                            cloudDataBases.Add(curentDataBase);
                        }
                        while (reader.Read());
                        //do
                        //{
                        //    System.Collections.IEnumerator itterator = reader.GetEnumerator();
                        //    //read the databases
                        //    while (itterator.MoveNext())
                        //    {
                        //        Models.DataBase curentDataBase = new Models.DataBase();
                        //        curentDataBase = (Models.DataBase)(itterator.Current);
                        //        cloudDataBases.Add(curentDataBase);
                        //    }
                        //}
                        //while (reader.Read());
                    }
                }
            }

        }

        //function that gets the DBs from the cloud
        private async Task  getDataBasesAsync()
        {
            // clear the current list since we are about to get the updated data from cloud
            this.cloudDataBases.Clear();//this list is a type of our database

            // get iterator to loop over the cloude databases
            Microsoft.Azure.Cosmos.FeedIterator< Microsoft.Azure.Cosmos.DatabaseProperties> interator = 
                CosmosClient.GetDatabaseQueryIterator<Microsoft.Azure.Cosmos.DatabaseProperties>();

            do
            {
                //read the databases
                //getting a piece of results(data bases) from the cosmos client and going through each one of them
                //the iterator decides according to his algorithm the amount of database to get each time
                foreach (Microsoft.Azure.Cosmos.DatabaseProperties db in await interator.ReadNextAsync())
                {// (db is like a slot in an array)
                    //creating an object of type DataBase that will be overriden everytime we enter the loop
                    Models.DataBase curentDataBase = new Models.DataBase();
                    //getting the database id that we got from the cloud and putting it in currentDatabase
                    curentDataBase.DataBaseId = db.Id;
                    //adding the current data base to the list 
                    cloudDataBases.Add(curentDataBase);
                }
            }
            //checking if the iterator has more databases
            while (interator.HasMoreResults);
        }

        //function that gets the tables from the databases in the cloud
        private async Task getTablesAsync()
        {
            cloudTables.Clear();

            // scanning all the databases, going through each database in the cloud data bases
            foreach (Models.DataBase database in cloudDataBases)
            {
                //getting database from the cloud 
                Microsoft.Azure.Cosmos.Database currentDatabase = CosmosClient.GetDatabase(database.DataBaseId);
                //ContainerProperties= tables
                //we go to the cosmosClient -> to get an iterator -> we go through each database in the cloud databases -> so the iterator can go through the tables in a single database
                //iterator goes through the tables 
                Microsoft.Azure.Cosmos.FeedIterator<Microsoft.Azure.Cosmos.ContainerProperties> iterator = currentDatabase.GetContainerQueryIterator<Microsoft.Azure.Cosmos.ContainerProperties>();

                do
                {
                    foreach(Microsoft.Azure.Cosmos.ContainerProperties table in await iterator.ReadNextAsync())
                    //going through each table in the next set of the iterator
                    //since iterator.ReadNextAsync is Asnyc then we have to add "await" before it
                    {
                        Models.Table currentTable = new Models.Table();
                        //getting the database id
                        currentTable.DataBaseId = database.DataBaseId;
                        //getting the table id
                        currentTable.TableName = table.Id;
                        //adding the table to the list
                        cloudTables.Add(currentTable);
                    }

                }
                //if there are more tables in the iterator
                while (iterator.HasMoreResults);
            }
        }

        //function that works for a certain amount of time and if its completed in that amount of times it gets the tables in databases from the cloud
        public void getCloudTables(int timeout, ref bool resultStatus)
        {
            Task getTablesTask = Task.Run(async () => //כמו תור מוסיפים בתוך TASK
            {
                await getTablesAsync();
            }
            );
            getTablesTask.Wait(timeout);
            //if the task was not completed in the amount of time
            if (!getTablesTask.IsCompleted)
            {
                resultStatus = false;
                throw new TaskCanceledException("timeout!!! - the tables were not retrieved within" + timeout / 1000);
            }
            // if the code came to this place- then there is a success
            resultStatus = true;

        }

        //function that works for a certain amount of time and if its completed in that amount of times it gets the DB in databases from the cloud
        public void GetDataBases(int timeout, ref bool resultStatus)
        {
            //timeout -> amount of time that we allow the action to keep going (in milliseconds)
            //after the time is out then the action will be stopped with exception
            //ref -> is that a variable that has been created outside the function and once the function is used and the variable has been passed
            //the variable will return with the latest value giving from the function /"every change in function will be saved outside the function"
            //if we call the ref variable without a value then the variable won't be knows as (undefined)
            Task getDatabasesTask = Task.Run(async () =>
               {
                   await getDataBasesAsync();
        }
                );
            //giving the task a specific amount of time in milliseconds to be completed
            getDatabasesTask.Wait(timeout);
            //checking if the task has not been completed
            if (!getDatabasesTask.IsCompleted)
            {
                //giving false that the task was not able to complete in a certain amount of times in milliseconds
                resultStatus = false;
                throw new TaskCanceledException("timeout!!! - the databases were not retrieved within" + timeout / 1000);
    }
             //if the code came to this place- then there is a success
            resultStatus = true;
        }

        //deleting a specified database from the cloud
        public async Task DeleteDatabaseAsync(string id)
        {
            // get the DB from cosmos DB and delete
            await CosmosClient.GetDatabase(id).DeleteAsync();

        }

        // delete the table 'tableSTR' in the DB 'database'
        public async Task DeleteContainerAsync(string db, string tableToDelete)
        {
            // get the cloud DB object according to the input
            Microsoft.Azure.Cosmos.Database database = CosmosClient.GetDatabase(db);
            // within DB (previous row) - get the contauner input (with the name: tableStr)
            Microsoft.Azure.Cosmos.Container Table =  database.GetContainer(tableToDelete);
            // delete the above container
            await Table.DeleteContainerAsync();
        }

        //this function gets a list of students and the activity that wants to be performed (insert,modify,delete) 
        //and then according to the activity that was selected it will be performed on the list and updates the data in the cloud
        public async Task updatestudentdataintocloudasync(List<Models.Student> students, RowStatus activity)
        {
            bool currentstudentexustsincloud = false;
            string currentstudentid;
            container = CosmosClient.GetContainer(DataBaseName, TableName);

            //if there was no table selected then theres no acitivty to be performed
            if (container == null)
                return;

            //going through each student in the list students
            foreach (Models.Student currentstudent in students)
            {
                currentstudentid = currentstudent.id;

                // check if the current student already exists in cloud 
                try
                {//getting the table of the current student if he was found 
                    Microsoft.Azure.Cosmos.ItemResponse<Models.Student> readitemresponse = await container.ReadItemAsync<Models.Student>(currentstudentid, new Microsoft.Azure.Cosmos.PartitionKey(currentstudentid));
                    //student exists/found
                    currentstudentexustsincloud = true;
                }
                catch (Microsoft.Azure.Cosmos.CosmosException ex)
                {//student not found
                    currentstudentexustsincloud = false;
                }

                //if the activity that was selected was New then the student will be added to the database in cloud
                //checking if the student already exists in the cloud
                if (activity== RowStatus.New)
                {
                    //if the student exists then the student will be updated in the cloud
                    if (currentstudentexustsincloud)
                    {
                        await container.ReplaceItemAsync<Models.Student>(currentstudent, currentstudentid,new Microsoft.Azure.Cosmos.PartitionKey(currentstudentid));
                        continue;
                    }
                    else
                    {//if the student does not exists in the cloud then he will be added/inserted 
                        await container.CreateItemAsync<Models.Student>(currentstudent, new Microsoft.Azure.Cosmos.PartitionKey(currentstudentid));
                        continue;
                    }
                }

                //if the activity was delete then the student will be deleted if he exists 
                if (activity == RowStatus.Delete)
                { //deleting a student
                    if (currentstudentexustsincloud)
                    {
                        await container.DeleteItemAsync<Models.Student>(currentstudentid, new Microsoft.Azure.Cosmos.PartitionKey(currentstudentid));
                        continue;
                    }
                    else
                    {
                        // delete is not possible if the student does not exist
                        continue;
                    }
                }

                //modifying the data of the selected student
                if (activity == RowStatus.Modify)
                {
                    if (currentstudentexustsincloud)
                    {
                        await container.ReplaceItemAsync<Models.Student>(currentstudent, currentstudentid, new Microsoft.Azure.Cosmos.PartitionKey(currentstudentid));
                        continue;
                    }
                    else
                    {
                        // modified is not possible
                        continue;
                    }
                }
            }


        }
    
    }

}

