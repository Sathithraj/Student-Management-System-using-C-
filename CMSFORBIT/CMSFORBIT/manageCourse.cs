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
    public partial class manageCourse : Form
    {
        courseList cl_main;
        public manageCourse(courseList cl)
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            cl_main = cl;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourseCode.Text = "";
            txtCourseName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);

            if(txtCourseCode.Text != "" && txtCourseName.Text != "")
            {
                try
                {
                    con.Open();
                    string query = "INSERT into course (ccode,cname) VALUES(@ccode, @cname)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ccode", txtCourseCode.Text);
                    cmd.Parameters.AddWithValue("@cname", txtCourseName.Text);
                    cmd.ExecuteNonQuery();
                    txtCourseCode.Text = "";
                    txtCourseName.Text = "";
                    cl_main.loadData();
                    MessageBox.Show("Course Created Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("All fields are required!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);
            try
            {
                con.Open();
                string query = "UPDATE course SET cname = @cname WHERE ccode = @ccode";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cname",txtCourseName.Text);
                cmd.Parameters.AddWithValue("@ccode", txtCourseCode.Text);
                cmd.ExecuteNonQuery();
                cl_main.loadData();
                this.Dispose();
                MessageBox.Show("Course Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
