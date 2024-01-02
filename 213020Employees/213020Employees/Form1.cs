using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _213020Employees
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        EmployeeDataSet employeeDataSet = new EmployeeDataSet();

                        adapter.Fill(employeeDataSet, "Employees");
                        dataGridView1.DataSource = employeeDataSet.Tables["Employees"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private string connectionString = "Data Source=DESKTOP-AHPFOMS\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True;Encrypt=False";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            textBox4.Text = textBox4.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("Successfully Saved Info.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeInfo = RetrieveInfo();
                MessageBox.Show("Retrieved Employee Info:\n" + employeeInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string RetrieveInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@EmployeeID", 1);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                            
                                int employeeID = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                string position = reader.GetString(3);
                                decimal salary = reader.GetDecimal(4);
                                return $"EmployeeID: {employeeID}\nFirstName: {firstName}\nLastName: {lastName}\nPosition: {position}\nSalary: {salary}";
                            }
                            else
                            {
                                throw new Exception("Employee not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employee info: " + ex.Message);
            }
        }
    }
}
