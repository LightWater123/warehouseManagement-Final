using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace warehouseManagement
{
    public partial class Admin : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=inventorymain");
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // DELETE
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                var cellValue = dataGridView1.SelectedRows[0].Cells["ID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int productId))
                {
                    string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
                    string query = "DELETE FROM inventoryrecord1 WHERE ID=@ID";
                    string selectQuery = "SELECT * FROM inventoryrecord1";

                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@ID", productId);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Item deleted successfully", "Update");
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBox3.Text = "";

                            dataGridView1.Rows.RemoveAt(rowIndex);

                            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                            {
                                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCmd))
                                {
                                    DataTable dataTable = new DataTable();
                                    dataAdapter.Fill(dataTable);
                                    dataGridView1.DataSource = dataTable;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please select a valid row.", "Update");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Notice");
            }
        }

        // UPDATE
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                var cellValue = dataGridView1.SelectedRows[0].Cells["ID"].Value;

                if (cellValue != null && int.TryParse(cellValue.ToString(), out int productId))
                {
                    string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
                    string updateQuery = "UPDATE inventoryrecord1 SET ProductName=@ProductName, Quantity=@Quantity, Price=@Price WHERE ID=@ID";
                    string selectQuery = "SELECT * FROM inventoryrecord1";

                    try
                    {
                        using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            using (MySqlCommand cmd = new MySqlCommand(updateQuery, con))
                            {
                                cmd.Parameters.AddWithValue("@ProductName", this.textBox1.Text);
                                cmd.Parameters.AddWithValue("@Quantity", this.textBox2.Text);
                                cmd.Parameters.AddWithValue("@Price", this.textBox3.Text);
                                cmd.Parameters.AddWithValue("@ID", productId);

                                con.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Item updated successfully", "Update");
                                this.textBox1.Text = "";
                                this.textBox2.Text = "";
                                this.textBox3.Text = "";

                                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, con))
                                {
                                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(selectCmd))
                                    {
                                        DataTable dataTable = new DataTable();
                                        dataAdapter.Fill(dataTable);
                                        dataGridView1.DataSource = dataTable;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Update");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ID. Please select a valid row.", "Update");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "Notice");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // ADD
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string insertQuery = "INSERT INTO inventoryrecord1 (ProductName, Quantity, Price) VALUES (@ProductName, @Quantity, @Price)";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {




                using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ProductName", this.textBox1.Text);
                    cmd.Parameters.AddWithValue("@Quantity", this.textBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", this.textBox3.Text);

                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully", "Update");
                }

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }


            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // MANAGE USERS
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage mag = new Manage();
            mag.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // DISPLAY
        private void button2_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=inventorymain";
            string selectQuery = "SELECT * FROM inventoryrecord1";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = new MySqlCommand(selectQuery, con))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        // SIGN OUT

        private void SignOut()
        {

            DialogResult result = MessageBox.Show("Do you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                // Back to login
                Login loginForm = new Login();
                loginForm.Show();

                // Close customer planel
                this.Close();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            SignOut();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
