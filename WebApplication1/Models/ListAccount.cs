using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ListAccount : db
    {
        #region Parameters
        List<TaiKhoan> lstAccs = new List<TaiKhoan>();
        #endregion
        #region Methods
        public List<TaiKhoan> GetListAccounts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from v_list_accounts";
                using (SqlCommand cmd = new SqlCommand(query,conn))
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