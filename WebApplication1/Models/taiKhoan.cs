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
            conn.Close();
            return false;
        }
        public bool TaoTK(string sUsername, string sPassword)
        {
            // tạo kết nối với csdl
            SqlConnection conn = base.Conn();
            // tạo sql command
            SqlCommand cmd = new SqlCommand("SP_ThemTK", conn);
            // 
            cmd.CommandType = CommandType.StoredProcedure;
            // truyền các parameter cho procedure
            cmd.Parameters.AddWithValue("@sUsername", sUsername);
            cmd.Parameters.AddWithValue("@password", sPassword);
            
            conn.Open(); // mở kết nối với csdl
            // thực thi câu lệnh
            // với những câu truy vấn không trả về dữ liệu (insert, update, delete) 
            // nó sẽ trả về số bản ghi bị tác động (tác động tương đương với được thêm mới, cập nhật hoặc xóa
            int aff = cmd.ExecuteNonQuery();
            if(aff > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}