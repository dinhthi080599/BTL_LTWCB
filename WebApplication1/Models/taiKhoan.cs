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
        #region Parameters
        private int pK_iMaTK;
        private string sUsername;
        private string sPassword;
        private int fK_iMaQuyen;
        private string sTenQuyen;
        #endregion

        #region Initialization
        public int PK_iMaTK { get => pK_iMaTK; set => pK_iMaTK = value; }
        public string SUsername { get => sUsername; set => sUsername = value; }
        public string SPassword { get => sPassword; set => sPassword = value; }
        public int FK_iMaQuyen { get => fK_iMaQuyen; set => fK_iMaQuyen = value; }
        public string STenQuyen { get => sTenQuyen; set => sTenQuyen = value; }
        public TaiKhoan() {}
        public TaiKhoan(DataRow dr)
        {
            this.PK_iMaTK = (int)dr["pK_iMaTK"];
            this.SUsername = dr["sUsername"].ToString();
            this.SPassword = dr["sPassword"].ToString();
            this.FK_iMaQuyen = (int)dr["FK_iMaQuyen"];
            this.STenQuyen = dr["sTenQuyen"].ToString();
        }
        #endregion

        #region Methods
        public bool DelAcc(string maTK)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_DelAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@matk", maTK);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }

        public bool InsAcc(string username, string password, int quyen)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_insert_account", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }

        public bool UpdAcc(string matk, string password, int quyen)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_update_account", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@matk", matk);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@quyen", quyen);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        #endregion
    }
}