using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaiKhoan : db
    {
        private int PK_iMaTK { get; set; }
        private string sUsername{ get; set; }
        private string sPassword { get; set; }
        private int FK_iMaQuyen { get; set; }
        private string sTenQuyen { get; set; }

        public bool Get_TaiKhoan(string sUsername, string sPassword)
        {
            SqlConnection conn = base.Conn();
            SqlCommand cmd = new SqlCommand("SP_LayTKTheoID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sUsername", sUsername);
            conn.Open();
            SqlDataReader dar = cmd.ExecuteReader();
            if (dar.HasRows)
            {
                while (dar.Read())
                {
                    if(sPassword == dar["sPassword"].ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}