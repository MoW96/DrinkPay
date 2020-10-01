﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DrinkPay
{
    public static class clsDB
    {
        // Datenbankverbindung herstellen
        public static SqlConnection Get_DB_Connection()
        {
            string cn_String = DrinkPay.Properties.Settings.Default.connection_String;
            SqlConnection cn_connection = new SqlConnection(cn_String);

            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
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
            SqlConnection cn_connection = Get_DB_Connection();

            DataSet dataSet = new DataSet();
            var dataAdapter = new SqlDataAdapter(SQLText, cn_connection);

            dataAdapter.Fill(dataSet);

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
                            return dataSet.Tables[0].Rows[0]["Gesamtbetrag"].ToString();
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
            string cn_String = DrinkPay.Properties.Settings.Default.connection_String;

            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed)
            {
                cn_connection.Close();
            }
        }
    }
}