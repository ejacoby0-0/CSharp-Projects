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

namespace FluffyBakes
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialising to the connection to the server
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //sql commands to insert data to the tables
            SqlCommand cmd = new SqlCommand("insert into BakeryProducts values(@productID,@productName,@productPrice,@category,@stockLevel)", con);
            cmd.Parameters.AddWithValue("@productID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@productName", textBox2.Text);
            cmd.Parameters.AddWithValue("@productPrice", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@category", textBox4.Text);
            cmd.Parameters.AddWithValue("@stockLevel", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //takes the user to the next form 
            Form4 newForm = new Form4();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //updates the user information base on the productID
            SqlCommand cmd = new SqlCommand("update BakeryProducts set productName=@productName, productPrice=@productPrice, category=@category, stockLevel=@stockLevel where productID=@productID", con);
            cmd.Parameters.AddWithValue("@productID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@productName", textBox2.Text);
            cmd.Parameters.AddWithValue("@productPrice", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@category", textBox4.Text);
            cmd.Parameters.AddWithValue("@stockLevel", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //Deletes the users information
            SqlCommand cmd = new SqlCommand("delete BakeryProducts where productID=@productID", con);
            cmd.Parameters.AddWithValue("@productID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully deleted");
        }
    }
}
