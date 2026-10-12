using System.Collections.Generic;
using System.Text;
using System;

namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap3
{ 
    public class SinhVien
    {
        private string maSo;
        private string hoTen;
        private string chuyenNganh;
        private int namSinh;
        private float diemTB;
        private string loai;
        public string MaSo
        {
            get { return maSo; }
            set { maSo = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string ChuyenNganh
        {
            get { return chuyenNganh; }
            set { chuyenNganh = value; }
        }
        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }
        public float DiemTB
        {
            get { return diemTB; }
            set { diemTB = value; }
        }
        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }
        public SinhVien()
        {
        }
        public SinhVien(
            string maSo,
            string hoTen,
            string chuyenNganh,
            int namSinh,
            float diemTB)
        {
            this.maSo = maSo;
            this.hoTen = hoTen;
            this.chuyenNganh = chuyenNganh;
            this.namSinh = namSinh;
            this.diemTB = diemTB;

            XepLoai();
        }
        public SinhVien(SinhVien sv)
        {
            this.maSo = sv.maSo;
            this.hoTen = sv.hoTen;
            this.chuyenNganh = sv.chuyenNganh;
            this.namSinh = sv.namSinh;
            this.diemTB = sv.diemTB;
            this.loai = sv.loai;
        }

        public bool KiemTraNamSinh(int ns)
        {
            int tuoi = DateTime.Now.Year - ns;

            return tuoi >= 17 && tuoi <= 70;
        }
        public bool KiemTraDiemTB(float dtb)
        {
            return dtb >= 0 && dtb <= 10;
        }

        public void Nhap()
        {
            Console.Write("Nhap ma so: ");
            maSo = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();

            Console.Write("Nhap chuyen nganh: ");
            chuyenNganh = Console.ReadLine();
            while (true)
            {
                Console.Write("Nhap nam sinh: ");

                if (int.TryParse(Console.ReadLine(), out int ns)
                    && KiemTraNamSinh(ns))
                {
                    namSinh = ns;
                    break;
                }

                Console.WriteLine(
                    "Nam sinh khong hop le! Vui long nhap lai."
                );
            }
            while (true)
            {
                Console.Write("Nhap diem TB: ");

                if (float.TryParse(Console.ReadLine(), out float dtb)
                    && KiemTraDiemTB(dtb))
                {
                    diemTB = dtb;
                    break;
                }

                Console.WriteLine(
                    "Diem TB khong hop le! Vui long nhap lai."
                );
            }

            XepLoai();
        }
        public void XepLoai()
        {
            if (diemTB < 5)
            {
                loai = "Yeu";
            }
            else if (diemTB < 7)
            {
                loai = "Trung binh";
            }
            else if (diemTB < 8)
            {
                loai = "Kha";
            }
            else
            {
                loai = "Gioi - Xuat sac";
            }
        }
        public void Xuat()
        {
            XepLoai();

            Console.WriteLine("Ma so: " + maSo);
            Console.WriteLine("Ho ten: " + hoTen);
            Console.WriteLine("Chuyen nganh: " + chuyenNganh);
            Console.WriteLine("Nam sinh: " + namSinh);
            Console.WriteLine("Diem TB: " + diemTB);
            Console.WriteLine("Xep loai: " + loai);
        }
    }
}