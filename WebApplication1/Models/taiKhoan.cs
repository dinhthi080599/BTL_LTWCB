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
        public DataRow Get_Account(string sUsername, string sPassword)
        {
            using (SqlConnection conn = base.Conn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_check_login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", sUsername);
                    cmd.Parameters.AddWithValue("@password", sPassword);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    DataRow dtr = null;
                    if (dt.Rows.Count > 0)
                    {
                        dtr = dt.Rows[0];
                    }
                    return dtr;
                    
                }
            }
        }
        public bool Update_Password(string pass, string username)
        {
            pass = MD5.Encrypt(pass);
            using (SqlConnection conn = base.Conn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_password", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    return dt.Rows.Count > 0;
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
        #endregion
    }
    public class ListAccount : db
    {
        #region Parameters
        private static ListAccount lst;
        List<TaiKhoan> lstAccs = new List<TaiKhoan>();
        #endregion
        internal static ListAccount Lst { get => lst != null ? lst : new ListAccount(); private set => lst = value; }
        #region Methods
        public List<TaiKhoan> GetListAccounts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from v_list_accounts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        TaiKhoan tk = new TaiKhoan(item);
                        lstAccs.Add(tk);
                    }
                }
            }
            return lstAccs;
        }
        #endregion
    }
}