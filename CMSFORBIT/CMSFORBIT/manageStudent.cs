using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSFORBIT
{
    public partial class manageStudent : Form
    {
        studentList formS;
        public manageStudent(studentList sl)
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            comboStatus.Text = "Active";
            formS = sl;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);
            try
            {
                if (txtAddress.Text!="" && txtRegistrationNo.Text!="" && txtStudentName.Text!="" && txtTelephone.Text!="" && comboStatus.Text!="")
                {
                    con.Open();
                    string query = "INSERT INTO student (reg_no,name,tel,place,status) VALUES(@reg, @name, @tel, @place, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@reg", txtRegistrationNo.Text);
                    cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
                    cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                    cmd.Parameters.AddWithValue("@place", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@status", comboStatus.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Registration Successfully Completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearData();
                    formS.loadData();
                }
                else
                {
                    MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            }

        public void clearData()
        {
            txtRegistrationNo.Text = "";
            txtStudentName.Text = "";
            txtTelephone.Text = "";
            txtAddress.Text = "";
            comboStatus.Text = "Active";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);
            try
            {
                con.Open();

                if (txtAddress.Text != "" && txtStudentName.Text != "" && txtTelephone.Text != "" && comboStatus.Text != "")
                {
                    string query = "UPDATE student SET name = @name, place = @place, tel = @tel, status = @status WHERE reg_no = @reg";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
                    cmd.Parameters.AddWithValue("@place", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                    cmd.Parameters.AddWithValue("@status", comboStatus.Text);
                    cmd.Parameters.AddWithValue("@reg", txtRegistrationNo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Details Updated Successful!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    formS.loadData();
                }
                else
                {
                    MessageBox.Show("All fields are required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                } catch(Exception ex){
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
    }
