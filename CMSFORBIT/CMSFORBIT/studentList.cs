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
    public partial class studentList : Form
    {
        public studentList()
        {
            InitializeComponent();
            loadData();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                manageStudent ms = new manageStudent(this);
                ms.btnSave.Enabled = false;
                ms.btnUpdate.Enabled = true;
                ms.txtRegistrationNo.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                ms.txtRegistrationNo.Enabled = false;
                ms.txtStudentName.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                ms.txtAddress.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                ms.txtTelephone.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                ms.comboStatus.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                ms.ShowDialog();
            }else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string connection = "server=localhost; database=project; user=root; password=";
                    MySqlConnection con = new MySqlConnection(connection);
                    con.Open();

                    string query = "DELETE FROM student WHERE reg_no = @reg";
                    MySqlCommand cmd = new MySqlCommand(query,con);
                    cmd.Parameters.AddWithValue("@reg", dataGridView1[0, e.RowIndex].Value.ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Student Deleted Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            manageStudent ms = new manageStudent(this);
            ms.ShowDialog();
        }

        public void loadData()
        {
            dataGridView1.Rows.Clear();
            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);
            try
            {
                con.Open();
                string query = "SELECT * from student";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["reg_no"], dr["name"], dr["place"], dr["tel"], dr["status"]);
                }
            }catch(Exception ex)
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
