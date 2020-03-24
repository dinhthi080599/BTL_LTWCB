using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccSession : db
    {
        #region Parameters
        private static int pK_iMaTK;
        private static string sUsername;
        private static string sPassword;
        private static int fK_iMaQuyen;
        private static string sTenQuyen;
        #endregion

        #region Initialization
        public static int PK_iMaTK { get => pK_iMaTK; set => pK_iMaTK = value; }
        public static string SUsername { get => sUsername; set => sUsername = value; }
        public static string SPassword { get => sPassword; set => sPassword = value; }
        public static int FK_iMaQuyen { get => fK_iMaQuyen; set => fK_iMaQuyen = value; }
        public static string STenQuyen { get => sTenQuyen; set => sTenQuyen = value; }
        public AccSession() { AccSession.FK_iMaQuyen = 0; }
        #endregion

        #region Methods
        public void SetSession(string sUsername, string sPassword, int fK_iMaQuyen, string sTenQuyen)
        {
            AccSession.PK_iMaTK = pK_iMaTK;
            AccSession.SUsername = sUsername;
            AccSession.SPassword = sPassword;
            AccSession.FK_iMaQuyen = fK_iMaQuyen;
            AccSession.STenQuyen = sTenQuyen;
        }

        public void Clear()
        {
            AccSession.PK_iMaTK = -1;
            AccSession.SUsername = "";
            AccSession.SPassword = "";
            AccSession.FK_iMaQuyen = -1;
            AccSession.STenQuyen = "";
        }

        public bool Check_Account(string sUsername, string sPassword)
        {
            using (SqlConnection conn = base.Conn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_check_login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", sUsername);
                    cmd.Parameters.AddWithValue("@password", MD5.Encrypt(sPassword));
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        SetSession(sUsername, MD5.Encrypt(sPassword), (int)dt.Rows[0]["FK_iMaQuyen"], dt.Rows[0]["sTenQuyen"].ToString());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool Update_Password(string pass)
        {
            pass = MD5.Encrypt(pass);
            using (SqlConnection conn = base.Conn())
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_password", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", sUsername);
                    cmd.Parameters.AddWithValue("@password", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        SetSession(sUsername, pass, (int)dt.Rows[0]["FK_iMaQuyen"], dt.Rows[0]["sTenQuyen"].ToString());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion
    }
}