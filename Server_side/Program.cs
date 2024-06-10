using System;
using System.Configuration;
using System.Data.SQLite;
using System.Net.Sockets;

namespace Server_side
{
    internal static class Program
    {
        public static Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static Properties.Settings mySettings = new Properties.Settings();
        public static Configuration myConfigs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static string serverDBPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Database.db");
        public static SQLiteConnection SQLConnector = new SQLiteConnection($@"Data Source={serverDBPath};Version=3;");
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CreateDatabaseAndTable();
            Intro intro = new Intro();
            _ = new DarkModeCS(intro);
            Application.Run(intro);
        }

        private static void CreateDatabaseAndTable()
        {
            bool dbExists = File.Exists(serverDBPath);

            if (!dbExists)
            {
                SQLiteConnection.CreateFile(serverDBPath);
            }

            SQLConnector = new SQLiteConnection($@"Data Source={serverDBPath};Version=3;");

            try
            {
                SQLConnector.Open();

                string tableCreationQuery = @"
                    CREATE TABLE IF NOT EXISTS user (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL UNIQUE,
                        password TEXT NOT NULL
                    )";

                using (SQLiteCommand cmd = new SQLiteCommand(tableCreationQuery, SQLConnector))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating database or table: " + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SQLConnector.Close();
            }
        }
    }
}