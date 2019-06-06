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
using CrystalDecisions.CrystalReports.Engine;

namespace QuestionPaper_Genration
{
    public partial class GenrateQuestionPaper : Form
    {

        public static string SubId;
        public GenrateQuestionPaper()
        {
            InitializeComponent();
        }
        private void GenrateQuestionPaper_Load(object sender, EventArgs e)
        {
            try
            {
                TxtNoOfQuestionSet.Text = "1";
                NoOFQuestionSet.Visible = false;
                label8.Visible = false;
                cmbsubject.Enabled = true;

                DtConnection.Con.Close();
                SqlCommand cmd = new SqlCommand("select * from Subject_Master", DtConnection.Con);
                DtConnection.Con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataRow row = dt.NewRow();
                row["SubId"] = 0;
                row["SubName"] = "--Select Subject--";
                dt.Rows.InsertAt(row, 0);
                cmbsubject.DataSource = dt;
                cmbsubject.DisplayMember = "SubName";
                cmbsubject.ValueMember = "SubId";
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
                cmblevel.DataSource = dt1;
                cmblevel.DisplayMember = "LevelName";
                cmblevel.ValueMember = "LId";
                DtConnection.Con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Btnsubmit_Click(object sender, EventArgs e)
        {
            TxtNoOfQuestionSet.Text = "1";
            DtConnection.Con.Close();
            DtConnection.Con.Open();
            SqlCommand cmdTruncate = new SqlCommand("Truncate table TempData", DtConnection.Con);
            cmdTruncate.ExecuteNonQuery();
            DtConnection.Con.Close();
            //if (cmbsubject.Text == "--Select Subject--")
            //{
            //    MessageBox.Show("Please Select Subject");
            //    return;
            //}
            //else
            if (cmblevel.Text == "--Select Level--")
            {
                MessageBox.Show("Please Select Level");
                return;
            }
            else
            {
                float avg1 = 0;
                float avg2 = 0;
                float avg3 = 0;
                float avg4 = 0;
                float total = 0;

                try
                {
                    //2 mark Question
                    DtConnection.Con.Open();
                    //SqlCommand cmd = new SqlCommand("select QuestionName,QsId from QuestionBank where QsId=1 and SubId='" + DtConnection.SubId + "' and LId='" + cmblevel.SelectedValue + "' ORDER BY NEWID()", DtConnection.Con);
                    SqlCommand cmd = new SqlCommand(" select Q.QuestionName,Q.QsId,L.Level from QuestionBank Q join Level_Master L on Q.LId=L.LId where Q.QsId=1 and Q.SubId='" + DtConnection.SubId + "'  ORDER BY NEWID()", DtConnection.Con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    int QNo1 = 0;
                    int X;
            
                   if (txtsec1.Text == "")
                    {
                        MessageBox.Show("Section1 is required.");
                        return;
                    }
                    else
                    {

                        if (dt.Rows.Count > 0)
                        {
                            X = (Convert.ToInt32(TxtNoOfQuestionSet.Text) * (Convert.ToInt32(txtsec1.Text)));
                            if (dt.Rows.Count >= X)
                            {
                                for (int j = 0; j < 3; j++)
                                    //for (int j = 0; j < Convert.ToInt32(TxtNoOfQuestionSet.Text); j++)
                                {
                                    float level1 = 0;
                                    float sum1 = 0;
                                    for (int i = 0; i < Convert.ToInt32(txtsec1.Text); i++)
                                    {
                                        level1 = Convert.ToInt32(dt.Rows[i]["Level"]);
                                        SqlCommand cmd1 = new SqlCommand("insert into TempData(QuestionName,LId,SubId,QsId,SetNo) values(@QuestionName,@LId,@SubId,@QsId,@SetNo)", DtConnection.Con);
                                        cmd1.Parameters.AddWithValue("@QuestionName", dt.Rows[QNo1]["QuestionName"].ToString());
                                        cmd1.Parameters.AddWithValue("@LId", dt.Rows[i]["Level"].ToString());
                                        cmd1.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                                        cmd1.Parameters.AddWithValue("@QsId", dt.Rows[i]["QsId"].ToString());
                                        cmd1.Parameters.AddWithValue("@SetNo", j + 1);
                                        cmd1.ExecuteNonQuery();
                                        QNo1++;
                                        sum1 = sum1 + level1;
                                    }
                                    avg1 = sum1 / QNo1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("2 Marks Questions Insufficient.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient Question Of this Subject with Level.");
                            return;
                        }
                    }
                    DtConnection.Con.Close();

                    //3 mark Question
                    //DtConnection.Con.Open();
                    ////SqlCommand cmnd = new SqlCommand("select QuestionName,QsId from QuestionBank where QsId=2 and SubId='" + DtConnection.SubId + "'and LId='" + cmblevel.SelectedValue + "' ORDER BY NEWID()", DtConnection.Con);
                    //SqlCommand cmnd = new SqlCommand(" select Q.QuestionName,Q.QsId,L.Level from QuestionBank Q join Level_Master L on Q.LId=L.LId where Q.QsId=2 and Q.SubId='" + DtConnection.SubId + "'  ORDER BY NEWID()", DtConnection.Con);

                    //SqlDataAdapter adpt = new SqlDataAdapter(cmnd);
                    //DataTable dtr = new DataTable();
                    //adpt.Fill(dtr);
                    //int QNo2 = 0;
                    //int Y;
                    //if (TxtNoOfQuestionSet.Text == "")
                    //{
                    //    TxtNoOfQuestionSet.Text = "1";
                    //}
                    //else if (txtsec2.Text == "")
                    //{
                    //    MessageBox.Show("Section2 is required.");
                    //    return;
                    //}
                    //else
                    //{
                    //    if (dtr.Rows.Count > 0)
                    //    {
                    //        Y = (Convert.ToInt32(TxtNoOfQuestionSet.Text) * (Convert.ToInt32(txtsec2.Text)));
                    //        if (dtr.Rows.Count >= Y)
                    //        {
                    //            for (int j = 0; j < Convert.ToInt32(TxtNoOfQuestionSet.Text); j++)
                    //            {
                    //                float level2 = 0;
                    //                float sum2 = 0;
                    //                for (int i = 0; i < Convert.ToInt32(txtsec2.Text); i++)
                    //                {
                    //                    level2 = Convert.ToInt32(dtr.Rows[i]["Level"]);
                    //                    SqlCommand cmd1 = new SqlCommand("insert into TempData(QuestionName,LId,SubId,QsId,SetNo) values(@QuestionName,@LId,@SubId,@QsId,@SetNo)", DtConnection.Con);
                    //                    cmd1.Parameters.AddWithValue("@QuestionName", dtr.Rows[QNo2]["QuestionName"].ToString());
                    //                    cmd1.Parameters.AddWithValue("@LId", dtr.Rows[i]["Level"].ToString());
                    //                    cmd1.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                    //                    cmd1.Parameters.AddWithValue("@QsId", dtr.Rows[i]["QsId"].ToString());
                    //                    cmd1.Parameters.AddWithValue("@SetNo", j + 1);
                    //                    cmd1.ExecuteNonQuery();
                    //                    QNo2++;
                    //                    sum2 = sum2 + level2;
                    //                }
                    //                avg2 = sum2 / QNo2;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("3 Marks Questions Insufficient.");
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Insufficient Question Of this Subject with Level.");
                    //        return;
                    //    }
                    //} DtConnection.Con.Close();

                    //5 mark
                    DtConnection.Con.Open();
                    //SqlCommand cmd2 = new SqlCommand("select QuestionName,QsId from QuestionBank where QsId=3 and SubId='" + DtConnection.SubId + "'and LId='" + cmblevel.SelectedValue + "' ORDER BY NEWID()", DtConnection.Con);
                    SqlCommand cmd2 = new SqlCommand(" select Q.QuestionName,Q.QsId,L.Level from QuestionBank Q join Level_Master L on Q.LId=L.LId where Q.QsId=3 and Q.SubId='" + DtConnection.SubId + "'  ORDER BY NEWID()", DtConnection.Con);

                    SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    adp2.Fill(dt2);
                    int QNo3 = 0;
                    int Z;
                    if (TxtNoOfQuestionSet.Text == "")
                    {
                        TxtNoOfQuestionSet.Text = "1";
                    }
                    else if (txtsec3.Text == "")
                    {
                        MessageBox.Show("Section3 is required.");
                        return;
                    }
                    else
                    {
                        if (dt2.Rows.Count > 0)
                        {
                            Z = (Convert.ToInt32(TxtNoOfQuestionSet.Text) * (Convert.ToInt32(txtsec3.Text)));
                            if (dt2.Rows.Count >= Z)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    float level3 = 0;
                                    float sum3 = 0;
                                    for (int i = 0; i < Convert.ToInt32(txtsec3.Text); i++)
                                    {
                                        level3 = Convert.ToInt32(dt2.Rows[i]["Level"]);
                                        SqlCommand cmd1 = new SqlCommand("insert into TempData(QuestionName,LId,SubId,QsId,SetNo) values(@QuestionName,@LId,@SubId,@QsId,@SetNo)", DtConnection.Con);
                                        cmd1.Parameters.AddWithValue("@QuestionName", dt2.Rows[QNo3]["QuestionName"].ToString());
                                        cmd1.Parameters.AddWithValue("@LId", dt2.Rows[i]["Level"].ToString());
                                        cmd1.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                                        cmd1.Parameters.AddWithValue("@QsId", dt2.Rows[i]["QsId"].ToString());
                                        cmd1.Parameters.AddWithValue("@SetNo", j + 1);
                                        cmd1.ExecuteNonQuery();
                                        QNo3++;
                                        sum3 = sum3 + level3;
                                    }
                                    avg3 = sum3 / QNo3;
                                }
                            }
                            else
                            {
                                MessageBox.Show("5 Marks Questions Insufficient.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient Question Of this Subject with Level.");
                            return;
                        }
                    } DtConnection.Con.Close();

                    ///8 Marks
                    DtConnection.Con.Open();
                    //SqlCommand cmd4 = new SqlCommand("select QuestionName,QsId from QuestionBank where QsId=4 and SubId='" + DtConnection.SubId + "'and LId='" + cmblevel.SelectedValue + "' ORDER BY NEWID()", DtConnection.Con);
                    SqlCommand cmd4 = new SqlCommand(" select Q.QuestionName,Q.QsId,L.Level from QuestionBank Q join Level_Master L on Q.LId=L.LId where Q.QsId=4 and Q.SubId='" + DtConnection.SubId + "'  ORDER BY NEWID()", DtConnection.Con);
                    SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);
                    DataTable dt4 = new DataTable();
                    adp4.Fill(dt4);
                    int QNo4 = 0;
                    int A;
                    if (TxtNoOfQuestionSet.Text == "")
                    {
                        //TxtNoOfQuestionSet.Text = "1";
                    }
                    else if (txtsec4.Text == "")
                    {
                        //MessageBox.Show("Section4 is required.");
                        //return;
                    }
                    else
                    {
                        if (dt4.Rows.Count > 0)
                        {
                            A = (Convert.ToInt32(TxtNoOfQuestionSet.Text) * (Convert.ToInt32(txtsec4.Text)));
                           // if (dt4.Rows.Count >= A)
                            //{
                            //    for (int j = 0; j < 3; j++)
                            //    {
                            //        float level4 = 0;
                            //        float sum4 = 0;
                            //        for (int i = 0; i < Convert.ToInt32(txtsec4.Text); i++)
                            //        {
                            //            //level4 = Convert.ToInt32(dt4.Rows[i]["Level"]);
                            //            //SqlCommand cmd1 = new SqlCommand("insert into TempData(QuestionName,LId,SubId,QsId,SetNo) values(@QuestionName,@LId,@SubId,@QsId,@SetNo)", DtConnection.Con);
                            //            //cmd1.Parameters.AddWithValue("@QuestionName", dt4.Rows[QNo4]["QuestionName"].ToString());
                            //            //cmd1.Parameters.AddWithValue("@LId", dt4.Rows[i]["Level"].ToString());
                            //            //cmd1.Parameters.AddWithValue("@SubId", DtConnection.SubId);
                            //            //cmd1.Parameters.AddWithValue("@QsId", dt4.Rows[i]["QsId"].ToString());
                            //            //cmd1.Parameters.AddWithValue("@SetNo", j + 1);
                            //            //cmd1.ExecuteNonQuery();
                            //            //QNo4++;
                            //            //sum4 = sum4 + level4;
                            //        }
                            //        avg4 = sum4 / QNo4;
                            //    }
                            //}
                            //else
                            //{
                            //    MessageBox.Show("8 Marks Questions Insufficient.");
                            //    return;
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Insufficient Question Of this Subject with Level].");
                            return;
                        }
                    } DtConnection.Con.Close();
                }
               catch (Exception)
               {
                   throw;
                }

                TxtNoOfQuestionSet.Text = "";
                txtsec1.Text = "";
              //  txtsec2.Text = "";
                txtsec3.Text = "";
                txtsec4.Text = "";
                //      int divide = Convert.ToInt32(txtsec1.Text) + Convert.ToInt32(txtsec2.Text) + Convert.ToInt32(txtsec3.Text) + Convert.ToInt32(txtsec4.Text);
                total = (avg1 + avg3 + avg4) / 3;
                //int levelNo = Convert.ToInt32(Math.Round(total, 0));
                int levelNo =  Convert.ToInt32(cmblevel.SelectedValue);;
                int qlevel = Convert.ToInt32(cmblevel.SelectedValue);

                SqlCommand cmdlevel = new SqlCommand("select level from Level_Master where LId= " + qlevel + "", DtConnection.Con);
                DtConnection.Con.Open();
                SqlDataAdapter adplevel = new SqlDataAdapter(cmdlevel);
                DataTable dtlevel = new DataTable();
                adplevel.Fill(dtlevel);
                int L = Convert.ToInt32(dtlevel.Rows[0]["Level"]);
                DtConnection.Con.Close();
                try
                {
                    if (levelNo <= L || levelNo >= L)
                      // if (levelNo <= L)
                    {
                        DtConnection.Con.Open();
                        SqlDataAdapter Adp = new SqlDataAdapter("select distinct(SetNo) from TempData", DtConnection.Con);
                        DataTable dt = new DataTable();
                        Adp.Fill(dt);
                        // DataRow Row = dt.NewRow();
                        //Row["SetNo"] = 0;
                        //// Row["SetNo"] = "<--Select SetNo-->";
                        // dt.Rows.InsertAt(Row, 0);
                        NoOFQuestionSet.DataSource = dt;
                        NoOFQuestionSet.DisplayMember = "SetNo";
                        NoOFQuestionSet.ValueMember = "SetNo";
                        if (dt.Rows.Count > 0)
                        {
                            NoOFQuestionSet.Visible = true;
                            label8.Visible = true;
                        }
                        DtConnection.Con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid matching ,genrate again.");
                        cmblevel.SelectedText = "";
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                DtConnection.Con.Close();
            }
          }
            

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void TxtNoOfQuestionSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar)))
                e.Handled = true;
        }
        private void TxtNoOfQuestionSet_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void txtsec1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void txtsec2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void txtsec3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void txtsec4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        private void cmblevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void NoOFQuestionSet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string SetNo = NoOFQuestionSet.SelectedValue.ToString();
            ReportViewer RP = new ReportViewer(Convert.ToInt32(SetNo));
            RP.Show();

        }
        private void cmbsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            NoOFQuestionSet.Visible = false;
            label8.Visible = false;
            DtConnection.SubId = cmbsubject.SelectedValue.ToString();

        }

        private void NoOFQuestionSet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



    }
}

