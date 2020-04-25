using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Models
{
    public class db
    {
        SqlConnection conn;
        public SqlConnection Conn()
        {
            string connetionString;
            string path = HttpContext.Current.Server.MapPath("~/App_Data/ITNews.mdf");
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path +";Integrated Security=True";
            conn = new SqlConnection(connetionString);
            return conn;
        }
    }
}