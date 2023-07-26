using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Main
{
    internal class DBHelperQRcode
    {
        private static SqlConnection conn = null;
        public static string DBConnString { get; private set; }

        public static bool bDBConnCheck = false;

        private static int errorBoxCount = 0;

        public DBHelperQRcode() { }

        public static SqlConnection DBConn
        {
            get
            {
                if (!ConnectToDB())
                {
                    return null;
                }
                return conn;
            }
        }


        public static bool ConnectToDB()
        {
            if (conn == null)
            {
                string dataSource = "KB-PC";//KB-PC
                string db = "MYDB";
                string security = "SSPI";
                DBConnString = string.Format(
                    $"Data Source = {dataSource}; Initial Catalog = {db}; Integrated Security={security}; Timeout=30");

                conn = new SqlConnection(DBConnString);
            }

            try
            {
                if (!IsDBConnected)
                {
                    conn.Open();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        bDBConnCheck = true;
                    }
                    else
                    {
                        bDBConnCheck = false;
                    }
                }

            }
            catch (SqlException e)
            {
                errorBoxCount++;
                if (errorBoxCount == 1)
                {
                    MessageBox.Show(e.Message, "DBHelper - ConnectToDB()");
                }
                return false;
            }
            return true;
        }

        public static bool IsDBConnected
        {
            get
            {
                bool state = true;

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    state = false;
                }

                return state;
            }
        }

    

    public static void Close()
        {
            if (IsDBConnected)
                DBConn.Close();
        }
    }
}