using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fruit
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Fruit.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader rd = null;

        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void update_grid()
        {
            //conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=testdb.accdb");
        
            conn.Open();

            cmd.CommandText = "SELECT * FROM Fruits";
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;

            //MessageBox.Show(dt.Rows.Count.ToString());
            //MessageBox.Show(dt.Rows[5][1].ToString());

            //MessageBox.Show(dt.Rows[5]["friend_name"].ToString());


            conn.Close();

        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtLoad_Click(object sender, EventArgs e)
        {
            update_grid();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            conn.Open();

            

            cmd.CommandText = "SELECT * FROM Fruits WHERE ID="+ Convert.ToInt32(textBoxID.Text) + "";
            //MessageBox.Show(cmd.CommandText);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;

            count = dt.Rows.Count;
            if(count==0)
            {

                cmd.CommandText = "INSERT INTO Fruits(ID,Name,Price,Quantity) VALUES (" + Convert.ToInt32(textBoxID.Text) + ",'" + textBoxName.Text + "','" + Convert.ToDouble(textBoxPrice.Text) + "','" + Convert.ToInt32(textBoxQuantity.Text) + "')";
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
            else
            {

                MessageBox.Show("Cannot create duplicate data");
            }



            conn.Close();
            update_grid();


        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd.CommandText = "UPDATE Fruits SET Fruits.Name = '" + textBoxName.Text + "', Fruits.Price = '" + Convert.ToDouble(textBoxPrice.Text) + "', Fruits.Quantity = '" + Convert.ToInt32(textBoxQuantity.Text) + "' WHERE(((Fruits.ID) = " + Convert.ToInt32(textBoxID.Text) + "))";

            //MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
            update_grid();
        }

        private void BtDel_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (dataGridView1.SelectedCells != null)
            {


                cmd.CommandText = "DELETE FROM Fruits WHERE ID="
                    + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value+"";
                //MessageBox.Show(cmd.CommandText);
                cmd.ExecuteNonQuery();


            }
            conn.Close();
            update_grid();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmd.Connection = conn;
            conn.Open();



            cmd.CommandText = "SELECT * FROM Category";
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                comboBox1.Items.Add((string)rd["Category"]);

            }


                conn.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxPrice.Text = row.Cells[2].Value.ToString();
                textBoxQuantity.Text = row.Cells[3].Value.ToString();

            }
            
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            textBoxQuantity.Text = "";
            textBoxID.Focus();
        }
    }
}
