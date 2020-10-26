using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows;

namespace DrinkPay
{
    public static class clsDB
    {
        public static SqlConnection findDBConnectionString()
        {
            var sqlConBuilder = new SqlConnectionStringBuilder();
            sqlConBuilder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            sqlConBuilder.AttachDBFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB.mdf");
            sqlConBuilder.IntegratedSecurity = true;
            var sqlCon = new SqlConnection(sqlConBuilder.ToString());

            return sqlCon;
        }

        // Datenbankverbindung herstellen
        public static SqlConnection Get_DB_Connection()
        {
            MessageBox.Show("036: Get_DB_Connection");
            // Properties: DrinkPay.Properties.Settings.Default.connection_String;
            SqlConnection cn_connection = findDBConnectionString();

            if (cn_connection.State != ConnectionState.Open)
            {
                MessageBox.Show("037:  Get_DB_Connection");
                cn_connection.Open();
                MessageBox.Show("038:  Get_DB_Connection");
            }

            return cn_connection;
        }

        // DB-Tabelle suchen
        public static DataTable Get_DataTable(string SQLText)
        {
            SqlConnection cn_connection = Get_DB_Connection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQLText, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static string Get_String(string SQLText, string Type)
        {
            MessageBox.Show("032: Get_String");
            SqlConnection cn_connection = Get_DB_Connection();
            MessageBox.Show("033: Get_String");
            DataSet dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter(SQLText, cn_connection);

            dataAdapter.Fill(dataSet);
            MessageBox.Show("034: Get_String");
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                if (Type.Equals("User"))
                {
                    return dataSet.Tables[0].Rows[0]["Username"].ToString();
                }
                else
                {
                    if (Type.Equals("Passwort"))
                    {
                        return dataSet.Tables[0].Rows[0]["Passwort"].ToString();
                    }
                    else
                    {
                        if (Type.Equals("Mail"))
                        {
                            return dataSet.Tables[0].Rows[0]["MailAdresse"].ToString();
                        }
                        else
                        {
                            if (Type.Equals("Gesamtbetrag"))
                            {
                                return dataSet.Tables[0].Rows[0]["Gesamtbetrag"].ToString();
                            }
                            else
                            {
                                return dataSet.Tables[0].Rows[0]["isAdmin"].ToString();
                            }
                        }
                    }
                }
            }
        }

        public static String get_db_string_sum(String SQLText)
        {

            // funktioniert nicht
            SqlConnection cn_connection = Get_DB_Connection();

            DataSet dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter(SQLText, cn_connection);

            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows[0]["Gesamtanzahl"].ToString().Equals(""))
            {
                return "0";
            }
            else
            {
                return dataSet.Tables[0].Rows[0]["Gesamtanzahl"].ToString();
            }
        }

        // Ausführen
        public static void Execute_SQL(string SQLText)
        {
            SqlConnection cn_connection = Get_DB_Connection();

            SqlCommand cmd_Command = new SqlCommand(SQLText, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        // Schließen
        public static void Close_DB_Connection()
        {
            SqlConnection cn_connection = findDBConnectionString();
            if (cn_connection.State != ConnectionState.Closed)
            {
                cn_connection.Close();
            }
        }
    }
}