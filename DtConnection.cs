using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;


namespace QuestionPaper_Genration
{
    public class DtConnection
    {
        public static string FId;
        public static string SubId;
        public static string Type;
        public static int SetNo;
        public static SqlConnection Con = new SqlConnection("Data Source=DESKTOP-ILH2S6P;initial catalog=QuestionPaperGenrationNew;integrated security=True");
    }
}
