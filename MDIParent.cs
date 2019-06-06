using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionPaper_Genration
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        private int xpos = 0, ypos = 0;
        public string mode = "Left-to-Right";
        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFaculty f = new AddFaculty();
            f.MdiParent = this;
            f.Show();
        }

        private void addQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageQuestion MQ = new ManageQuestion();
            MQ.MdiParent = this;
            MQ.Show();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BtnLogin L = new BtnLogin();
            L.Show();
        }

        private void genrateQuestionpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenrateQuestionPaper GP = new GenrateQuestionPaper();
            GP.MdiParent = this;
            GP.Show();
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            //xpos = label1.Location.X;
            //ypos = label1.Location.Y;
            //mode = "Left-to-Right";
            //timer1.Start();
            //xpos = label1.Location.X;
            //ypos = label1.Location.Y;
            //mode = "Right-to-Left";
            //timer1.Start();
           // genrateQuestionpaperToolStripMenuItem.Visible = false;
        }

        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void questionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void viewQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewQuestions VQ = new ViewQuestions();
            VQ.MdiParent = this;
            VQ.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (mode == "Left-to-Right")
            //{
            //    if (this.Width == xpos)
            //    {
            //        this.label1.Location = new System.Drawing.Point(0, ypos);
            //        xpos = 0;

            //    }
            //    else
            //    {
            //        this.label1.Location = new System.Drawing.Point(xpos, ypos);
            //        xpos += 2;
            //    }
            //}
            //else if (mode == "Right-to-Left")
            //{
            //    if (xpos == 0)
            //    {
            //        this.label1.Location = new System.Drawing.Point(this.Width, ypos);
            //        xpos = this.Width;
            //    }
            //    else
            //    {
            //        this.label1.Location = new System.Drawing.Point(xpos, ypos);
            //        xpos -= 2;
            //    }
            //}
        }
        //
    }
}
