using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuestionPaper_Genration
{
    public partial class BtnLogin : Form
    {
        public BtnLogin()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLoginSelect.Text == "<--Select Login Type-->")
                {
                    MessageBox.Show("Select Login Type.");
                }
                else
                {
                    if (CmbLoginSelect.Text == "Admin")
                    {
                        if (txtusername.Text == "" || txtpassword.Text == "")
                        {
                            MessageBox.Show("Enter Uesername or Password.");
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("Select * from Login where Username=@Username and Password=@Password", DtConnection.Con);
                            DtConnection.Con.Open();
                            cmd.Parameters.AddWithValue("@Username", txtusername.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString().Trim());
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            int q = Convert.ToInt32(cmd.ExecuteScalar());
                            if (q > 0)
                            {
                                DtConnection.Type = "Admin";
                                MDIParent Main = new MDIParent();
                                this.Hide();
                                Main.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password!");
                            }
                        }
                    }
                    else if (CmbLoginSelect.Text == "Faculty")
                    {
                        if (txtusername.Text == "" || txtpassword.Text == "")
                        {
                            MessageBox.Show("Enter Uesername or Password.");
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("Select * from Faculty_Master where EmailId=@EmailId and Password=@Password", DtConnection.Con);
                            DtConnection.Con.Open();
                            cmd.Parameters.AddWithValue("@EmailId", txtusername.Text.ToString().Trim());
                            cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString().Trim());
                            SqlDataAdapter adp = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            int q = Convert.ToInt32(cmd.ExecuteScalar());
                            if (q > 0)
                            {
                                DtConnection.Type = "Faculty";
                                DtConnection.FId = dt.Rows[0]["FId"].ToString();
                                DtConnection.SubId = dt.Rows[0]["SubId"].ToString();
                                //MDIParent Main = new MDIParent();
                                this.Hide();
                                //Main.Show();
                                ManageQuestion MQ = new ManageQuestion();
                                MQ.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password!");
                            }
                        }
                    }
                }
                DtConnection.Con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Load(object sender, EventArgs e)
        {
            CmbLoginSelect.SelectedText = "<--Select Login Type-->";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
