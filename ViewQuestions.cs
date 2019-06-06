using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuestionPaper_Genration
{

    public partial class ViewQuestions : Form
    {

        public ViewQuestions()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("select Q.QuestionName,F.FacultyName,S.SubName,L.LevelName,QM.Marks from QuestionBank Q join Faculty_Master F On Q.FId=F.FId join Level_Master L on Q.LId=L.LId join QuestionSection QM on Q.QsId=QM.QsId join Subject_Master S on Q.SubId= S.SubId where F.FId='" + DtConnection.FId + "'", DtConnection.Con);
            //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //    DataTable dt = new System.Data.DataTable();
            //    adp.Fill(dt);
            //    dataGridView1.DataSource = dt;

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void ViewQuestions_Load(object sender, EventArgs e)
        {

            DtConnection.Con.Close();
            SqlCommand cmd = new SqlCommand("select distinct * from Faculty_Master", DtConnection.Con);
            DtConnection.Con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataRow row = dt.NewRow();
            row["FId"] = 0;
            row["FacultyName"] = "--Select Faculty--";
            dt.Rows.InsertAt(row, 0);
            cmbfaculty.DataSource = dt;
            cmbfaculty.DisplayMember = "FacultyName";
            cmbfaculty.ValueMember = "FId";
            DtConnection.Con.Close();

            DtConnection.Con.Open();
            SqlCommand cmd2 = new SqlCommand("select * from Subject_Master", DtConnection.Con);

            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            DataRow row2 = dt2.NewRow();
            row2["SubId"] = 0;
            row2["SubName"] = "--Select Subject--";
            dt2.Rows.InsertAt(row2, 0);
            cmbsubject.DataSource = dt2;
            cmbsubject.DisplayMember = "SubName";
            cmbsubject.ValueMember = "SubId";
            DtConnection.Con.Close();

            if (DtConnection.Type == "Faculty")
            {
                SqlCommand cmd1 = new SqlCommand("select Q.QuestionName,F.FacultyName,S.SubName,L.LevelName,QM.Marks from QuestionBank Q join Faculty_Master F On Q.FId=F.FId join Level_Master L on Q.LId=L.LId join QuestionSection QM on Q.QsId=QM.QsId join Subject_Master S on Q.SubId= S.SubId where F.FId='" + DtConnection.FId + "' and S.SubId='" + DtConnection.SubId + "'", DtConnection.Con);
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                cmbfaculty.Visible = false;
                cmbsubject.Visible = false;
                BtnViewQuestionForAdmin.Visible = false;

            }
            if (DtConnection.Type == "Admin")
            {
                //button2.Visible = false;
            }

        }

        private void ViewQuestionForAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbsubject.Text == "--Select Subject--")
                {
                    MessageBox.Show("Select Subject.");
                }
                else if (cmbfaculty.Text == "--Select Faculty--")
                {
                    MessageBox.Show("Select Faculty.");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    DtConnection.Con.Close();
                    SqlCommand cmd = new SqlCommand("select Q.QuestionName,F.FacultyName,S.SubName,L.LevelName,QM.Marks from QuestionBank Q join Faculty_Master F On Q.FId=F.FId join Level_Master L on Q.LId=L.LId join QuestionSection QM on Q.QsId=QM.QsId join Subject_Master S on Q.SubId= S.SubId where F.FId='" + cmbfaculty.SelectedValue + "' and  S.SubId='" + cmbsubject.SelectedValue + "'", DtConnection.Con);
                    DtConnection.Con.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No Data Found.");
                    }

                    DtConnection.Con.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DtConnection.Con.Close();
            SqlCommand cmd2 = new SqlCommand("select * from dbo.Subject_Master where subid in(select SubId from dbo.Faculty_Master where FacultyName=@FacultyName)", DtConnection.Con);
            cmd2.Parameters.AddWithValue("@FacultyName", cmbfaculty.Text);
            DtConnection.Con.Open();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            DataRow row2 = dt2.NewRow();
            row2["SubId"] = 0;
            row2["SubName"] = "--Select Subject--";
            dt2.Rows.InsertAt(row2, 0);
            cmbsubject.DataSource = dt2;
            cmbsubject.DisplayMember = "SubName";
            cmbsubject.ValueMember = "SubId";
            DtConnection.Con.Close();
        }


    }
}
