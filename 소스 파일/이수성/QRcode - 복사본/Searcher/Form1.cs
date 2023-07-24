using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searcher
{
    public partial class Form1 : Form
    {
        private DataTable data_table = null;
        public Form1()
        {
            // 
        InitializeComponent();

            try
            {
                lock(DBHelper.DBConn)
                {
                    if(!DBHelper.IsDBConnected)
                    {
                        MessageBox.Show("DB연결을 확인하세요");
                        return;
                    }
                    else
                    {
                        //DB연결되고 난 후
                        SqlDataAdapter adapter = new SqlDataAdapter("Select *From MyProduct", DBHelper.DBConn);
                        data_table = new DataTable();

                        try
                        {
                            adapter.Fill(data_table);
                            dataGridView1.DataSource = data_table;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "읽어오는데 실패했습니다.");
                            
                        }
                        DBHelper.Close();
                    }
                }

            }
            catch (ArgumentNullException ane)
            {

                MessageBox.Show(ane.Message, "DataGridView_Load Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (data_table == null)
                    return;

                string searchText = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    // 검색어가 비어있으면 원래 데이터를 모두 표시합니다.
                    dataGridView1.DataSource = data_table;
                }
                else
                {
                    // DataView를 이용하여 검색어를 포함하는 행들을 필터링합니다.
                    DataView dv = data_table.DefaultView;
                    dv.RowFilter = $"img_prod_nm LIKE '%{searchText}%' OR item_cd LIKE '%{searchText}%'";
                    dataGridView1.DataSource = dv.ToTable();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}
