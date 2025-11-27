using System.Data.SqlClient;

namespace FluffyBakes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Initialising to the connection to the server
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //sql commands to insert data to the tables
            SqlCommand cmd = new SqlCommand("insert into Customers values(@customerID,@customerName,@customerEmail)", con);
            cmd.Parameters.AddWithValue("@customerID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@customerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@customerEmail", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //takes the user to the next form 
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //updates the user information base on the customerID
            SqlCommand cmd = new SqlCommand("update Customers set customerName=@customerName, customerEmail=@customerEmail where customerID=@customerID", con);
            cmd.Parameters.AddWithValue("@customerID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@customerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@customerEmail", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully saved");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3PUAJDU\\SQLEXPRESS;Initial Catalog=FluffyBakes;Integrated Security=True;Encrypt=False");
            con.Open();

            //Deletes the users information
            SqlCommand cmd = new SqlCommand("delete Customers where customerID=@customerID", con);
            cmd.Parameters.AddWithValue("@customerID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully deleted");
        }
    }
}
