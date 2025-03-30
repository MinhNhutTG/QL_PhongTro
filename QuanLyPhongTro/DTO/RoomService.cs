using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.DTO
{
    internal class RoomService
    {
       
            private int id;
            private string maHopDong;
            private string soPhong;
            private string ki;
            private int soDienCu;
            private int soDienMoi;
            private int soNuocCu;
            private int soNuocMoi;
            private decimal giaDien;
            private decimal giaNuoc;
            private DateTime ngayTao;
            private decimal tienMang;
            private string trangThai;
            
            public int ID
            {
                get { return id; }
                set { id = value; }
            }

           public string MaHopDong
            {
                get { return maHopDong; }
                set { maHopDong = value; }
            }
            public string SoPhong
            {
                get { return soPhong; }
                set { soPhong = value; }
            }

            public string Ki
            {
                get { return ki; }
                set { ki = value; }
            }

            public int SoDienCu
            {
                get { return soDienCu; }
                set { soDienCu = value; }
            }

            public int SoDienMoi
            {
                get { return soDienMoi; }
                set { soDienMoi = value; }
            }

            public int SoNuocCu
            {
                get { return soNuocCu; }
                set { soNuocCu = value; }
            }

            public int SoNuocMoi
            {
                get { return soNuocMoi; }
                set { soNuocMoi = value; }
            }

            public decimal GiaDien
            {
                get { return giaDien; }
                set { giaDien = value; }
            }

            public decimal GiaNuoc
            {
                get { return giaNuoc; }
                set { giaNuoc = value; }
            }

            public DateTime NgayTao
            {
                get { return ngayTao; }
                set { ngayTao = value; }
            }

            public decimal TienMang
            {
                get { return tienMang; }
                set { tienMang = value; }
            }
            public string TrangThai
            {
                get { return trangThai; }
                set { trangThai = value; }
            }

    }
}
