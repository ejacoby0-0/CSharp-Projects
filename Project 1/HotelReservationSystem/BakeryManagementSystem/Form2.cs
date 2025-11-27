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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialising to the connection to the server
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //sql commands to insert data to the tables
            SqlCommand cmd = new SqlCommand("insert into BakeryOrders values(@orderID,@orderDate,@customerID)", con);
            cmd.Parameters.AddWithValue("@orderID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@orderDate", textBox2.Text);
            cmd.Parameters.AddWithValue("@customerID", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //takes the user to the next form 
            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //updates the user information base on the orderID
            SqlCommand cmd = new SqlCommand("update BakeryOrders set orderDate=@orderDate, customerID=@customerID where orderID=@orderID", con);
            cmd.Parameters.AddWithValue("@orderID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@orderDate", textBox2.Text);
            cmd.Parameters.AddWithValue("@customerID", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //Deletes the users information
            SqlCommand cmd = new SqlCommand("delete BakeryOrders where orderID=@orderID", con);
            cmd.Parameters.AddWithValue("@orderID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully deleted");
        }
    }
}
