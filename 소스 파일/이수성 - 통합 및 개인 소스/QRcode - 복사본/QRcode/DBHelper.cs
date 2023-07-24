using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QRcode
{
    public class DBHelper
    {
        private static SqlConnection conn = null;
        public static string DBConnString { get; private set; }

        public static bool bDBConnCheck = false;

        private static int errorBoxCount = 0;

        public  DBHelper() { }

        public static SqlConnection DBConn
        {
            get
            {
                if(!ConnectToDB())
                {
                    return null;
                }
                return conn;
            }
        }


        public static bool ConnectToDB()
        {
           if(conn == null) 
            {
                DBConnString = string.Format(
                    "Data Source = DESKTOP-8GHEHCV; Initial Catalog = {1}; Integrated Security={2}; Timeout=3",
                        "local", "MYDB", "SSPI");
                
                conn = new SqlConnection(DBConnString);
            }

           try
            {
                if(!IsDBConnected)
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

            } catch(SqlException e) 
            {
                errorBoxCount++;
                if(errorBoxCount == 1)
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
                if(conn.State != System.Data.ConnectionState.Open)
                {
                    return false;

                }
                return true;
            }

        }

        public static void Close()
        {
            if(IsDBConnected)
                DBConn.Close();
        }
    }
}
