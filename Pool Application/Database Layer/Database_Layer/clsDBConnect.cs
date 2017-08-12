namespace Database_Layer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;

    public class clsDBConnect
    {
        private MySqlConnection dbConn = new MySqlConnection();
        private string strDatabaseName;
        private string strDBPassword;
        private string strDBUserName;
        private string strServerName;

        public clsDBConnect()
        {
            string url = Application.StartupPath.ToString() + @"\ServerConfig.xml";
            XmlTextReader reader = null;
            reader = new XmlTextReader(url);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.LocalName.Equals("ServerName"))
                    {
                        this.strServerName = reader.ReadString();
                    }
                    if (reader.LocalName.Equals("DatabaseName"))
                    {
                        this.strDatabaseName = reader.ReadString();
                    }
                    if (reader.LocalName.Equals("UserId"))
                    {
                        this.strDBUserName = reader.ReadString();
                    }
                    if (reader.LocalName.Equals("PassWord"))
                    {
                        this.strDBPassword = reader.ReadString();
                    }
                }
            }
        }

        private void Conn()
        {
            string str = (((("Data Source=" + this.strServerName) + ";Initial Catalog=" + this.strDatabaseName) + ";User ID=" + this.strDBUserName) + ";Password=" + this.strDBPassword) + ";";
            this.dbConn.ConnectionString = str;
            if (this.dbConn.State == ConnectionState.Open)
            {
                this.dbConn.Close();
            }
            this.dbConn.Open();
        }

        private void Conn(string ServerName, string DatabaseName, string DBUserName, string DBPassword)
        {
            string str = (((("Data Source=" + ServerName) + ";Initial Catalog=" + DatabaseName) + ";User ID=" + DBUserName) + ";Password=" + DBPassword) + ";";
            this.dbConn.ConnectionString = str;
            if (this.dbConn.State == ConnectionState.Open)
            {
                this.dbConn.Close();
            }
            this.dbConn.Open();
        }

        public void DatabaseBackup(string strBackupPath)
        {
            try
            {
                string str = "";
                str = (this.strDatabaseName + "-" + DateTime.Now.ToShortDateString() + ".sql").Replace("/", "-");
                string path = Application.StartupPath.ToString() + "/Database-Backup/" + str;
                string destFileName = strBackupPath + "/" + str;
                StreamWriter writer = new StreamWriter(path);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                string str4 = string.Format("-u{0} -p{1} -h{2} {3}  --routines", new object[] { this.strDBUserName, this.strDBPassword, this.strServerName, this.strDatabaseName });
                startInfo.FileName = Application.StartupPath.ToString() + "/mysqldump.exe";
                startInfo.RedirectStandardInput = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.Arguments = str4;
                startInfo.UseShellExecute = false;
                Process process = Process.Start(startInfo);
                string str5 = process.StandardOutput.ReadToEnd();
                writer.WriteLine(str5);
                process.WaitForExit();
                writer.Close();
                File.Copy(path, destFileName, true);
                MessageBox.Show("Backup Completed", "Pool System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        public void DeleteData(string strTableName, string where_clause)
        {
            MySqlCommand command = new MySqlCommand("sp_delete_data") {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("tblName", strTableName);
            command.Parameters.AddWithValue("search_string", where_clause);
            this.Conn();
            command.Connection = this.dbConn;
            command.ExecuteNonQuery();
            this.dbConn.Close();
        }

        public DataTable Execute(string SpName)
        {
            MySqlCommand selectCommand = new MySqlCommand(SpName);
            this.Conn();
            selectCommand.Connection = this.dbConn;
            selectCommand.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.dbConn.Close();
            return dataTable;
        }

        public DataTable Execute(string SpName, object[,] arrParameter)
        {
            MySqlCommand selectCommand = new MySqlCommand(SpName);
            this.Conn();
            selectCommand.Connection = this.dbConn;
            selectCommand.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i <= (arrParameter.GetLength(0) - 1); i++)
            {
                selectCommand.Parameters.AddWithValue(arrParameter[i, 0].ToString(), arrParameter[i, 1]);
            }
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.dbConn.Close();
            return dataTable;
        }

        public void ExecuteSQL(string SQL)
        {
            MySqlCommand command = new MySqlCommand(SQL) {
                CommandType = CommandType.Text
            };
            this.Conn();
            command.Connection = this.dbConn;
            command.ExecuteNonQuery();
            this.dbConn.Close();
        }

        public void Insert(string SpName, object[,] arrParameter)
        {
            MySqlCommand command = new MySqlCommand(SpName) {
                CommandType = CommandType.StoredProcedure
            };
            for (int i = 0; i <= (arrParameter.GetLength(0) - 1); i++)
            {
                command.Parameters.AddWithValue(arrParameter[i, 0].ToString(), arrParameter[i, 1]);
            }
            this.Conn();
            command.Connection = this.dbConn;
            int num2 = command.ExecuteNonQuery();
            this.dbConn.Close();
        }

        public DataTable SearchData(string strTableName)
        {
            MySqlCommand selectCommand = new MySqlCommand("sp_select_data");
            this.Conn();
            selectCommand.Connection = this.dbConn;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("tblName", strTableName);
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.dbConn.Close();
            return dataTable;
        }

        public DataTable SearchData(string strTableName, string where_clause)
        {
            MySqlCommand selectCommand = new MySqlCommand("sp_search_data");
            this.Conn();
            selectCommand.Connection = this.dbConn;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("tblName", strTableName);
            selectCommand.Parameters.AddWithValue("search_string", where_clause);
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.dbConn.Close();
            return dataTable;
        }

        public DataTable SearchDataWithSQL(string strSQL)
        {
            MySqlCommand selectCommand = new MySqlCommand("sp_search_data_withSQL");
            this.Conn();
            selectCommand.Connection = this.dbConn;
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("SQL_string", strSQL);
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            this.dbConn.Close();
            return dataTable;
        }

        public void UpdateData(string strTableName, string Parameter_Values, string where_clause)
        {
            MySqlCommand command = new MySqlCommand("sp_update_data");
            this.Conn();
            command.Connection = this.dbConn;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("tblName", strTableName);
            command.Parameters.AddWithValue("value_string", Parameter_Values);
            command.Parameters.AddWithValue("search_string", where_clause);
            command.Connection = this.dbConn;
            command.ExecuteNonQuery();
            this.dbConn.Close();
        }
    }
}

