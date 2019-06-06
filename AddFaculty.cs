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
using System.Text.RegularExpressions;

namespace QuestionPaper_Genration
{
    public partial class AddFaculty : Form
    {
        public AddFaculty()
        {
            InitializeComponent();
        }

        private void AddFaculty_Load(object sender, EventArgs e)
        {
            try
            {
                DtConnection.Con.Close();
                SqlCommand cmd = new SqlCommand("select SubId, SubName from dbo.Subject_Master", DtConnection.Con);
                DtConnection.Con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataRow row = dt.NewRow();
                row["SubId"] = 0;
                row["SubName"] = "--Select Subject--";
                dt.Rows.InsertAt(row, 0);
                ddlsubject.DataSource = dt;
                ddlsubject.ValueMember = "SubId";
                ddlsubject.DisplayMember = "SubName";
                DtConnection.Con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtfacultyname.Text == "")
                {
                    MessageBox.Show("Enter Faculty Name.");
                    return;
                }
                if (txtphoneno.Text == "")
                {
                    MessageBox.Show("Enter Your Phoneno.");
                    return;
                }
                if (txtemailid.Text == "")
                {
                    MessageBox.Show("Enter your EmailId.");
                    return;
                }
                if (txtpassword.Text == "")
                {
                    MessageBox.Show("Enter your Password.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("Insert into Faculty_Master(FacultyName, PhoneNo, EmailId, SubId,Password) values(@FacultyName, @PhoneNo, @EmailId, @SubId,@Password)", DtConnection.Con);
                DtConnection.Con.Open();
                cmd.Parameters.AddWithValue("@FacultyName", txtfacultyname.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@SubId", ddlsubject.SelectedValue);
                cmd.Parameters.AddWithValue("@EmailId", txtemailid.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@PhoneNo", txtphoneno.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text.ToString().Trim());
                cmd.ExecuteNonQuery();
                txtphoneno.Text = "";
                txtfacultyname.Text = "";
                txtemailid.Text = "";
                txtpassword.Text = "";
                DtConnection.Con.Close();

                MessageBox.Show("Data Inserted Successfully.");
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtphoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtemailid_Validating(object sender, CancelEventArgs e)
        {
            if (!isEmail(txtemailid.Text))
            {
                MessageBox.Show("EmailID Invalid.");
                txtemailid.Focus();
                return;
            }
        }
        public static bool isEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public static bool isPhone(string inputphone)
        {
            Regex re = new Regex(@"^(\([0-9]{3}\)|[0-9]{3}-)[0-9]{3}-[0-9]{4}|(\([0-9]{3}\)|[0-9]{3})[0-9]{3}[0-9]{4}$");
            if (re.IsMatch(inputphone))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        private void txtphoneno_Validating(object sender, CancelEventArgs e)
        {
            if (!isPhone(txtphoneno.Text))
            {
                MessageBox.Show("Invalid Phone Number.");
                txtphoneno.Focus();
                return;
            }
        }
    }
}
