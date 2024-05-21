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
    public partial class courseList : Form
    {
        public courseList()
        {
            InitializeComponent();
            loadData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            manageCourse mc = new manageCourse(this);
            mc.ShowDialog();
        }

        public void loadData()
        {
            dataGridView1.Rows.Clear();

            string connection = "server=localhost; database=project; user=root; password=";
            MySqlConnection con = new MySqlConnection(connection);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM course",con);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                dataGridView1.Rows.Add(dr["ccode"], dr["cname"], dr["created_at"]);
            }

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                manageCourse mc = new manageCourse(this);
                mc.txtCourseCode.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                mc.txtCourseName.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                mc.btnSave.Enabled = false;
                mc.btnUpdate.Enabled = true;
                mc.txtCourseCode.Enabled = false;
                mc.ShowDialog();
            }
        }
    }
}
