using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Topic : db
    {
        #region Parameters
        private int pK_iMaTL;
        private string sTenTheLoai;
        private int iVitri;
        private int iSTT;
        public List<BaiViet> lstNews = new List<BaiViet>();
        #endregion

        #region Initialization
        public int PK_iMaTL { get => pK_iMaTL; set => pK_iMaTL = value; }
        public string STenTheLoai { get => sTenTheLoai; set => sTenTheLoai = value; }
        public int IVitri { get => iVitri; set => iVitri = value; }
        public int ISTT { get => iSTT; set => iSTT = value; }

        public Topic() { }
        public Topic(DataRow dr)
        {
            this.PK_iMaTL = (int)dr["PK_iMaTheLoai"];
            this.STenTheLoai = dr["sTenTheLoai"].ToString();
            this.IVitri = (int)dr["iViTri"];
            this.ISTT = (int)dr["iSTT"];
        }
        #endregion

        #region Methods
        public bool AddTopic(Topic tp)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_insert_topic", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tentp", tp.STenTheLoai);
                    cmd.Parameters.AddWithValue("@vitri", tp.IVitri);
                    cmd.Parameters.AddWithValue("@stt", tp.ISTT);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public bool UpdateTopic(Topic tp)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_update_topic", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@matl", tp.PK_iMaTL);
                    cmd.Parameters.AddWithValue("@tentp", tp.sTenTheLoai);
                    cmd.Parameters.AddWithValue("@vitri", tp.IVitri);
                    cmd.Parameters.AddWithValue("@stt", tp.ISTT);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
        public bool DelTopic(string maTL)
        {
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_DelTopic", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@matl", maTL);
                    return cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
        }
    #endregion
}
    public class LstTopic : db
    {
        #region Parameters
        private static LstTopic lst;
        List<Topic> lstTopic = new List<Topic>();
        #endregion
        internal static LstTopic Lst { get => lst != null ? lst : new LstTopic(); private set => lst = value; }
        #region Methods
        public List<Topic> GetListTopics()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from tbl_theloai order by iSTT, iViTri";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        Topic tp = new Topic(item);
                        lstTopic.Add(tp);
                    }
                }
            }
            return lstTopic;
        }
        #endregion
    }
}