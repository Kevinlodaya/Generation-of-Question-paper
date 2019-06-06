using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace QuestionPaper_Genration
{
    public partial class ReportViewer : Form
    {
        int QSetNo;
        public ReportViewer(int SetNo)
        {
            InitializeComponent();
            QSetNo = SetNo;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            //ReportDocument rd = new ReportDocument();
            //rd.Load(@"E:\Nivruti kore\QuestionPaper_Genration\QuestionPaper_Genration\CrystalReport1.rpt");
            //rd.SetParameterValue("@SetNo",QSetNo);
            //crystalReportViewer1.ReportSource = rd;
            //crystalReportViewer1.Refresh();
            //rd.Refresh();

            ReportDocument rptDoc = new ReportDocument();
            string rptPath = @"G:\Proj 18-19\QuestionPaper_Genration\CrystalReport2.rpt";
            rptDoc.Load(rptPath);
            rptDoc.SetParameterValue("@SetNo", QSetNo);
            crystalReportViewer1.ReportSource = rptDoc;
            crystalReportViewer1.Refresh();
        }


    }
}
