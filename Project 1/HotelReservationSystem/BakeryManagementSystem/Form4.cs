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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FluffyBakes
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialising to the connection to the server
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //sql commands to insert data to the tables
            SqlCommand cmd = new SqlCommand("insert into OrderDetails values(@orderDetails,@productID,@orderID,@quantity)", con);
            cmd.Parameters.AddWithValue("@orderDetails", textBox1.Text);
            cmd.Parameters.AddWithValue("@productID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@orderID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //updates the user information base on the orderDetails
            SqlCommand cmd = new SqlCommand("update OrderDetails set productID=@productID, orderID=@orderID, quantity=@quantity where orderDetails=@orderDetails", con);
            cmd.Parameters.AddWithValue("@orderDetails", textBox1.Text);
            cmd.Parameters.AddWithValue("@productID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@orderID", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@quantity", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //Deletes the users information
            SqlCommand cmd = new SqlCommand("delete OrderDetails where orderDetails=@orderDetails", con);
            cmd.Parameters.AddWithValue("@orderDetails", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully deleted");
        }
    }
}
