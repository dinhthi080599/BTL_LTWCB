using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaiViet : db
    {
        #region Parameters
        int mabv;
        string tenbv;
        string motangan;
        string motadai;
        string noidung;
        string linkanh;
        string trangthai;
        int matl;
        int matk;
        #endregion
        #region Initialization
        public int Mabv { get => mabv; set => mabv = value; }
        public string Tenbv { get => tenbv; set => tenbv = value; }
        public string Motangan { get => motangan; set => motangan = value; }
        public string Motadai { get => motadai; set => motadai = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public string Linkanh { get => linkanh; set => linkanh = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public int Matl { get => matl; set => matl = value; }
        public int Matk { get => matk; set => matk = value; }
        public BaiViet() { }
        public BaiViet(DataRow dr)
        {
            Mabv = (int)dr["PK_iMaBaiViet"];
            Tenbv = dr["sTenBaiViet"].ToString();
            Motangan = dr["sMoTaNgan"].ToString();
            Motadai = dr["sMoTaDai"].ToString();
            Noidung = dr["sNoiDung"].ToString();
            Linkanh = dr["sAnh"].ToString();
            Trangthai = dr["sTrangThai"].ToString();
            Matl = (int)dr["FK_iMaTheLoai"];
            Matk = (int)dr["FK_iMaTKTHem"];
        }
        #endregion
    }
    public class LstBaiViet : db
    {
        #region Parameters
        private static LstBaiViet lst;
        List<BaiViet> lstBaiViet = new List<BaiViet>();
        #endregion
        internal static LstBaiViet Lst { get => lst != null ? lst : new LstBaiViet(); private set => lst = value; }
        #region Methods
        public List<BaiViet> GetAllBaiViet()
        {
            lstBaiViet.Clear();
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from tbl_baiviet where sTrangThai = N'Đã duyệt' order by PK_iMaBaiViet desc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        BaiViet tp = new BaiViet(item);
                        lstBaiViet.Add(tp);
                    }
                }
            }
            return lstBaiViet;
        }
        public List<BaiViet> GetNewsInTopic(int matl)
        {
            lstBaiViet.Clear();
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from tbl_baiviet where FK_iMaTheLoai = "+matl+" and sTrangThai like N'Đã duyệt' order by PK_iMaBaiViet desc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        BaiViet tp = new BaiViet(item);
                        lstBaiViet.Add(tp);
                    }
                }
            }
            return lstBaiViet;
        }
        public List<BaiViet> SearchResultBaiViet(string keyword)
        {
            lstBaiViet.Clear();
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select * from tbl_baiviet where sTenBaiViet like N'%" + keyword + "%' or sNoiDung like N'%" + keyword + "%' or sMoTaNgan like N'%" + keyword + "%' or sMoTaDai like N'%" + keyword + "%' and sTrangThai like N'Đã duyệt' order by PK_iMaBaiViet desc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        BaiViet tp = new BaiViet(item);
                        lstBaiViet.Add(tp);
                    }
                }
            }
            return lstBaiViet;
        }
        public List<BaiViet> GetHotNews()
        {
            lstBaiViet.Clear();
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                conn.Open();
                string query = "select top 4 * from tbl_baiviet where sTrangThai = N'Đã duyệt' order by PK_iMaBaiViet desc";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        BaiViet tp = new BaiViet(item);
                        lstBaiViet.Add(tp);
                    }
                }
            }
            return lstBaiViet;
        }
        public BaiViet GetNew(string mabv)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = base.Conn())
            {
                BaiViet bv = new BaiViet();
                conn.Open();
                string query = "select top 1 * from tbl_baiviet where sTrangThai = N'Đã duyệt' and PK_iMaBaiViet = " + mabv;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow item in dt.Rows)
                    {
                        bv = new BaiViet(item);
                    }
                    return bv;
                }
            }
        }
        #endregion
    }
}