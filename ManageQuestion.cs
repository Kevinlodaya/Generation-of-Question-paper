using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace QuestionPaper_Genration
{
    public partial class ManageQuestion : Form
    {

        public ManageQuestion()
        {
            InitializeComponent();
        }

        public static int Currentrow = 0;
        public static string FId;
        public static string SubId;
        public DataTable DtShowData = new DataTable();
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblQid.Text == "")
                {
                    if (DtConnection.Type == "Faculty")
                    {
                        if (cmbLevel.Text == "--Select Level--")
                        {
                            MessageBox.Show("Select Level.");
                            return;
                        }
                        else if (cmbmarks.Text == "")
                        {
                            MessageBox.Show("Select Mark.");
                            return;
                        }
                        else if (txtquestion.Text == "")
                        {
                            MessageBox.Show("Enter Question.");
                            return;
                        }
                        else
                        {
                            DtConnection.Con.Close();
                            SqlCommand cmd = new SqlCommand("insert into QuestionBank values(@QuestionName, @LId, @SubId, @FId, @QsId)", DtConnection.Con);
                            DtConnection.Con.Open();
                            cmd.Parameters.AddWithValue("@FId", DtConnection.FId);
                            cmd.Parameters.AddWithValue("@LId", cmbLevel.SelectedValue);
                            cmd.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                            cmd.Parameters.AddWithValue("@QsId", cmbmarks.SelectedValue);
                            cmd.Parameters.AddWithValue("@QuestionName", txtquestion.Text.ToString().Trim());
                            cmd.ExecuteNonQuery();
                            txtquestion.Text = "";
                            DtConnection.Con.Close();
                            MessageBox.Show("Question Added Successfully.");
                        }
                    }
                    else
                        if (DtConnection.Type == "Admin")
                        {
                            if (cmbfaculty.Text == "--Select Faculty--")
                            {
                                MessageBox.Show("Select Faculty.");
                                return;
                            }
                            else if (cmbsubject.Text == "--Select Subject--")
                            {
                                MessageBox.Show("Select Subject.");
                                return;
                            }
                            else if (cmbLevel.Text == "--Select Level--")
                            {
                                MessageBox.Show("Select Level.");
                                return;
                            }
                            else if (cmbmarks.Text == "")
                            {
                                MessageBox.Show("Select Mark.");
                                return;
                            }
                            else if (txtquestion.Text == "")
                            {
                                MessageBox.Show("Enter Question.");
                                return;
                            }
                            else
                            {
                                DtConnection.Con.Close();
                                SqlCommand cmd = new SqlCommand("insert into QuestionBank values(@QuestionName, @LId, @SubId, @FId, @QsId)", DtConnection.Con);
                                DtConnection.Con.Open();
                                cmd.Parameters.AddWithValue("@FId", cmbfaculty.SelectedValue);
                                cmd.Parameters.AddWithValue("@LId", cmbLevel.SelectedValue);
                                cmd.Parameters.AddWithValue("@SubId", cmbsubject.SelectedValue);
                                cmd.Parameters.AddWithValue("@QsId", cmbmarks.SelectedValue);
                                cmd.Parameters.AddWithValue("@QuestionName", txtquestion.Text.ToString().Trim());
                                cmd.ExecuteNonQuery();
                                txtquestion.Text = "";
                                DtConnection.Con.Close();
                                MessageBox.Show("Question Added Successfully.");
                            }
                        }
                }
                else
                {
                    if (DtConnection.Type == "Admin")
                    {
                        DtConnection.Con.Open();
                        SqlCommand cmd = new SqlCommand("update QuestionBank set QuestionName='" + txtquestion.Text.ToString() + "', LId='" + cmbLevel.SelectedValue + "', SubId='" + cmbsubject.SelectedValue + "', FId='" + cmbfaculty.SelectedValue + "', QsId='" + cmbmarks.SelectedValue + "' where QId='" + lblQid.Text + "'", DtConnection.Con);
                        // SqlCommand cmd = new SqlCommand("update QuestionBank set QuestionName=@QuestionName, LId=@LId, SubId=@SubId, FId=@FId, QsId=@QsId where QId=@QId", DtConnection.Con);
                        //cmd.Parameters.AddWithValue("@FId", cmbfaculty.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@LId", cmbLevel.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@SubId", cmbsubject.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@QsId", cmbmarks.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@QuestionName", txtquestion.Text.ToString().Trim());
                        //cmd.Parameters.AddWithValue("@QId", lblQid);
                        cmd.ExecuteNonQuery();
                        DtConnection.Con.Close();
                    }
                    else
                        if (DtConnection.Type == "Faculty")
                        {
                            DtConnection.Con.Open();
                            SqlCommand cmd = new SqlCommand("update QuestionBank set QuestionName='" + txtquestion.Text.ToString() + "', LId='" + cmbLevel.SelectedValue + "', SubId='" + DtConnection.SubId + "', FId='" + DtConnection.FId + "', QsId='" + cmbmarks.SelectedValue + "' where QId='" + lblQid.Text + "'", DtConnection.Con);
                            //cmd.Parameters.AddWithValue("@FId", DtConnection.FId);
                            //cmd.Parameters.AddWithValue("@LId", cmbLevel.SelectedValue);
                            //cmd.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                            //cmd.Parameters.AddWithValue("@QsId", cmbmarks.SelectedValue);
                            //cmd.Parameters.AddWithValue("@QuestionName", txtquestion.Text.ToString().Trim());
                            //cmd.Parameters.AddWithValue("@QId", lblQid);
                            cmd.ExecuteNonQuery();
                            DtConnection.Con.Close();
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ManageQuestion_Load(object sender, EventArgs e)
        {
            if (DtConnection.Type == "Admin")
            {
                cmbfaculty.Enabled = true;
                cmbsubject.Enabled = true;
               // button2.Visible = false;
                //button1.Visible = false;
                groupBox1.Visible = false;

            }
            else if (DtConnection.Type == "Faculty")
            {
                cmbfaculty.Enabled = false;
                cmbsubject.Enabled = false;
               // button2.Visible = true;
               // button1.Visible = true;
                groupBox1.Visible = true;
            }

            try
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

                DtConnection.Con.Close();
                SqlCommand cmd1 = new SqlCommand("select * from Level_Master", DtConnection.Con);
                DtConnection.Con.Open();
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                DataRow row1 = dt1.NewRow();
                row1["LId"] = 0;
                row1["LevelName"] = "--Select Level--";
                dt1.Rows.InsertAt(row1, 0);
                cmbLevel.DataSource = dt1;
                cmbLevel.DisplayMember = "LevelName";
                cmbLevel.ValueMember = "LId";
                DtConnection.Con.Close();



                DtConnection.Con.Close();
                SqlCommand cmd3 = new SqlCommand("select * from QuestionSection", DtConnection.Con);
                DtConnection.Con.Open();
                SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                cmbmarks.DataSource = dt3;
                cmbmarks.DisplayMember = "Marks";
                cmbmarks.ValueMember = "QsId";
                DtConnection.Con.Close();

                BtnFirst.Visible = false;
                BtnLast.Visible = false;
                BtnOneBack.Visible = false;
                BtnOneNext.Visible = false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ShowData()
        {
            if (DtConnection.Type == "Faculty")
            {
                try
                {
                    lblQid.Text = DtShowData.Rows[Currentrow]["QId"].ToString();
                    txtquestion.Text = DtShowData.Rows[Currentrow]["QuestionName"].ToString();
                    DtConnection.FId = DtShowData.Rows[Currentrow]["FId"].ToString();
                    cmbLevel.SelectedValue = DtShowData.Rows[Currentrow]["LId"].ToString();
                    cmbmarks.SelectedValue = DtShowData.Rows[Currentrow]["QsId"].ToString();
                    DtConnection.SubId = DtShowData.Rows[Currentrow]["SubId"].ToString();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (DtConnection.Type == "Admin")
            {

                lblQid.Text = DtShowData.Rows[Currentrow]["QId"].ToString();
                txtquestion.Text = DtShowData.Rows[Currentrow]["QuestionName"].ToString();
                cmbfaculty.SelectedValue = DtShowData.Rows[Currentrow]["FId"].ToString();
                cmbLevel.SelectedValue = DtShowData.Rows[Currentrow]["LId"].ToString();
                cmbmarks.SelectedValue = DtShowData.Rows[Currentrow]["QsId"].ToString();
                cmbsubject.SelectedValue = DtShowData.Rows[Currentrow]["SubId"].ToString();
            }
        }
        private void BtnOneBack_Click(object sender, EventArgs e)
        {
            if (Currentrow == 0)
            {
                Currentrow = 0;
                ShowData();
            }
            else
            {
                Currentrow = Currentrow - 1;
                ShowData();
            }
        }
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            Currentrow = 0;
            ShowData();
        }
        private void BtnOneNext_Click(object sender, EventArgs e)
        {
            if (Currentrow == DtShowData.Rows.Count - 1)
            {
                Currentrow = DtShowData.Rows.Count - 1;
                ShowData();
            }
            else
            {
                Currentrow = Currentrow + 1;
                ShowData();
            }
        }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            Currentrow = DtShowData.Rows.Count - 1;
            ShowData();

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            cmbfaculty.Enabled = false;
            cmbsubject.Enabled = false;
            DtShowData.Clear();
            if (DtConnection.Type == "Admin")
            {
                DtConnection.Con.Close();
                SqlDataAdapter adp = new SqlDataAdapter("select * from QuestionBank where SubId='" + cmbsubject .SelectedValue+ "' order by QId", 
                    DtConnection.Con);

                adp.Fill(DtShowData);
                if (DtShowData.Rows.Count > 0)
                {
                    BtnDelete.Enabled = true;
                    BtnFirst.Visible = true;
                    BtnLast.Visible = true;
                    BtnOneBack.Visible = true;
                    BtnOneNext.Visible = true;
                    ShowData();
                }
                else
                {
                    BtnDelete.Enabled = false;
                    BtnFirst.Visible = false;
                    BtnLast.Visible = false;
                    BtnOneBack.Visible = false;
                    BtnOneNext.Visible = false;
                }
            }
            else if (DtConnection.Type == "Faculty")
            {
                DtConnection.Con.Close();
                SqlDataAdapter adp = new SqlDataAdapter("select * from QuestionBank where FId='" + DtConnection.FId + "' and SubId='" + DtConnection.SubId + "' order by QId", DtConnection.Con);
                adp.Fill(DtShowData);
                if (DtShowData.Rows.Count > 0)
                {
                    BtnDelete.Enabled = true;
                    BtnFirst.Visible = true;
                    BtnLast.Visible = true;
                    BtnOneBack.Visible = true;
                    BtnOneNext.Visible = true;
                    ShowData();
                }
                else
                {
                    BtnDelete.Enabled = false;
                    BtnFirst.Visible = false;
                    BtnLast.Visible = false;
                    BtnOneBack.Visible = false;
                    BtnOneNext.Visible = false;
                }
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DtConnection.Con.Close();
                SqlCommand cmd = new SqlCommand("Delete from QuestionBank where QId=@QId", DtConnection.Con);
                DtConnection.Con.Open();
                cmd.Parameters.AddWithValue("@QId", lblQid.Text);
                cmd.ExecuteNonQuery();
                DtConnection.Con.Close();
                MessageBox.Show("Record Deleted!");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Btnclear_Click(object sender, EventArgs e)
        {
            cmbfaculty.Enabled = true;
            cmbsubject.Enabled = true;
            txtquestion.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ViewQuestions q = new ViewQuestions();
            q.Show();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenrateQuestionPaper GQP = new GenrateQuestionPaper();
            GQP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BtnLogin L = new BtnLogin();
            L.Show();
            


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
