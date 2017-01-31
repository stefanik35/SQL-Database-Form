using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Assign3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void executeButton_Click(object sender, EventArgs ea)
        {
            //get rid of anything that can be in the output listbox
            outListBox.Items.Clear();
            int to_pad = 10;

            SqlConnection conn = null;

            //construct the connection object and open the connection
            try
            {
                string connString = "server=10.158.56.48;uid=net2;pwd=dtbz2;database=notebase2;";

                //construct the connection
                conn = new SqlConnection(connString);

                //open it
                conn.Open();

                //fetch the query from the textbox
                string query = sqlInputBox.Text;

                //split the query into substrings based on whitespace
                Char delimiter = ' ';
                String[] substrings = query.Split(delimiter);

                //if the first word in the query is SELECT
                if (substrings[0].ToUpper() == "SELECT")
                {
                    //construct the command
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //execute the command and receive the query results
                    SqlDataReader selectReader = cmd.ExecuteReader();

                    //create an empty string to hold the query result
                    string result = "";

                    //get the column names and write them to the screen
                    var col = Enumerable.Range(0, selectReader.FieldCount).Select(selectReader.GetName).ToList();

                    if (col[0] != "")
                    {
                        //print the column names -- if there are any
                        for (int i = 0; i < col.Count; i++)
                        {
                            if (i != col.Count - 1)
                                result = result + col[i].PadRight(to_pad);
                            else
                                result = result + col[i];
                        }

                        outListBox.Items.Add(result);
                        result = "";
                    }
                    else
                    {
                        result = "Answer";
                        outListBox.Items.Add(result);
                        result = "";
                    }

                    //while there are still results from the query
                    while (selectReader.Read() != false)
                    {
                        //get the tuple
                        IDataRecord selectRecord = (IDataRecord)selectReader;

                        //add each item in the tuple to the result string
                        for (int i = 0; i < selectRecord.FieldCount; i++)
                        {
                            if (i != selectReader.FieldCount - 1)
                                result = result + (selectRecord[i].ToString().PadRight(to_pad));
                            else
                                result = result + (selectRecord[i].ToString());
                        }

                        //print the result in the listbox
                        outListBox.Items.Add(result);

                        //clear the result string
                        result = "";
                    }

                    //close the reader
                    selectReader.Close();

                }
                //if the first word in the query is INSERT
                else if (substrings[0].ToUpper() == "INSERT")
                {
                    //construct the command
                    SqlCommand cmd = new SqlCommand(query, conn);

                    //execute the command
                    cmd.ExecuteNonQuery();

                    //print success message
                    outListBox.Items.Add("Item successfully inserted");
                }
                else
                {
                    //print error message
                    outListBox.Items.Add("ERROR: Input SQL command is invalid.  Valid commands are SELECT and INSERT.  Other commands NYI.");
                }
            }
            catch (Exception e)
            {
                //if exception occurs print an error message in the output listbox
                outListBox.Items.Add("ERROR: " + e.Message);
            }
            finally
            {
                //close the connection when done
                conn.Close();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //clear the listbox
            outListBox.Items.Clear();

            //clear the sql box
            sqlInputBox.Clear();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //exit the form
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //connection string
            string connString = "server=10.158.56.48;uid=net2;pwd=dtbz2;database=notebase2;";

            //set up the form's initial state
            removeTablesIfExists(connString);
            createTables(connString);
            readFileIntoDB(connString, "Room.txt");
            readFileIntoDB(connString, "Office.txt");
            readFileIntoDB(connString, "Class.txt");
            getDBSchema(connString);
        }

        private void createTables(string connString)
        {
            //make sure the tables do not exist already in the db
            string query = "";

            SqlConnection conn = null;

            try
            {
                //construct the connection
                conn = new SqlConnection(connString);

                //open it
                conn.Open();

                //construct the command
                SqlCommand cmd = new SqlCommand(query, conn);

                //Create the Office table 
                query = "CREATE TABLE OfficeTable (Teacher varchar(20),Office int,PRIMARY KEY (Teacher));";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                //Create the Room Table
                query = "CREATE TABLE RoomTable (Room int,Capacity int,Smart char(1),PRIMARY KEY (Room));";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                //Create the Class Table with foreign key constraints
                query = "CREATE TABLE ClassTable (Class int, Section int, Teacher varchar(20), Room int," +
                    "Time varchar(5), Days varchar(5), Enrollment int,PRIMARY KEY (Room, Time, Days)" +
                    ",FOREIGN KEY (Room) REFERENCES RoomTable(Room),FOREIGN KEY (Teacher)" +
                    "REFERENCES OfficeTable(Teacher));";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //if exception occurs print an error message and exit
                Console.WriteLine("ERROR: " + e.Message);
                Application.Exit();
            }
            finally
            {
                //close the connection
                conn.Close();
            }
        }

        private void removeTablesIfExists(string connString)
        {
            SqlConnection conn = null;

            //construct the connection object and open the connection
            try
            {
                //construct the connection
                conn = new SqlConnection(connString);

                //open it
                conn.Open();

                //construct the first query to drop Class if it exists
                string queryA = "IF OBJECT_ID('dbo.";
                string queryB = "', 'U') IS NOT NULL DROP TABLE dbo.";
                string table = "ClassTable";
                string query = queryA + table + queryB + table + ";";

                //construct the command
                SqlCommand cmd = new SqlCommand(query, conn);

                //execute the command
                cmd.ExecuteNonQuery();

                //create the second query to drop Office if it exists
                table = "OfficeTable";
                query = queryA + table + queryB + table + ";";

                //execute the command
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                //create the third query to drop Room if it exists
                table = "RoomTable";
                query = queryA + table + queryB + table + ";";

                //execute the command
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                //if exception occurs print an error message and exit
                Console.WriteLine("ERROR: " + e.Message);
                Application.Exit();
            }
            finally
            {
                //close the connection when done
                conn.Close();
            }
        }

        private static void readFileIntoDB(string connString, string fileName)
        {
            try
            {
                //create a new StreamReader object to read from the file that was passed into the function
                using (StreamReader inFile = new StreamReader(fileName))
                {
                    //get a new variable to hold the line read from the file
                    string fileLine;

                    //read the first line
                    fileLine = inFile.ReadLine();

                    //while there are still unread lines in the file
                    while (fileLine != null)
                    {
                        SqlConnection conn = null;

                        //construct the connection object and open the connection
                        try
                        {
                            //construct the connection
                            conn = new SqlConnection(connString);

                            //open it
                            conn.Open();

                            //construct the query
                            string query = constructInsertQuery(fileName, fileLine);

                            //construct the command
                            SqlCommand cmd = new SqlCommand(query, conn);

                            //execute the command
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            //if exception occurs print an error message
                            Console.WriteLine("ERROR: " + e.Message);
                        }
                        finally
                        {
                            //close the connection when done
                            conn.Close();
                        }

                        //read the next line
                        fileLine = inFile.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                //if exception occurs print an error message and exit
                Console.WriteLine("ERROR: " + e.Message);
                Application.Exit();
            }
        }

        private static string constructInsertQuery(string fileName, string fileLine)
        {
            //create an emptry string to hold the query
            string query = "";

            //specify the delimiter
            Char delimiter = ',';

            //construct the insert query by splitting the input line and adding each element to the query string
            //each file has a different format and thus a different method of constructing the query
            if (fileName == "Room.txt")
            {
                String[] substrings = fileLine.Split(delimiter);

                query = "INSERT INTO RoomTable VALUES (" + substrings[0] + "," + substrings[1] + ",'" + substrings[2] + "');";

                return query;
            }
            else if (fileName == "Office.txt")
            {
                String[] substrings = fileLine.Split(delimiter);

                query = "INSERT INTO OfficeTable VALUES ('" + substrings[0] + "'," + substrings[1] + ");";

                return query;
            }
            else if (fileName == "Class.txt")
            {
                String[] substrings = fileLine.Split(delimiter);

                query = "INSERT INTO ClassTable VALUES (" + substrings[0] + "," + substrings[1] + ",'" +
                    substrings[2] + "'," + substrings[3] + ",'" + substrings[4] + "','" +
                    substrings[5] + "'," + substrings[6] + ");";

                return query;
            }
            else
            {
                //return the blank query if a different file name is passed
                return query;
            }
        }

        private void getDBSchema(string connString)
        {
            SqlConnection conn = null;

            //construct the connection object and open the connection
            try
            {
                //construct the connection
                conn = new SqlConnection(connString);

                //open it
                conn.Open();

                //get the schema
                DataTable table = conn.GetSchema("Tables");

                //display the data in the list box
                displayData(table);
            }
            catch (Exception e)
            {
                //if exception occurs print an error message and exit
                Console.WriteLine("ERROR: " + e.Message);
                Application.Exit();
            }
            finally
            {
                //close the connection when done
                conn.Close();
            }
        }

        private void displayData(System.Data.DataTable table)
        {
            //print each table name in the database schema in the listbox
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    //print only the table name, and only the three tables we are interested in
                    //the second condition is necessary because there are many additional tables from previous semesters in this database
                    if (col.ColumnName == "TABLE_NAME" && ((string)row[col] == "RoomTable" || (string)row[col] == "OfficeTable" || (string)row[col] == "ClassTable"))
                    {
                        tablesListb.Items.Add(row[col]);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sqlInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
