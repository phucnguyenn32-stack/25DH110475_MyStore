using System;
namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap3
{
    public class MangSinhVien
    {
        private SinhVien[] a;

        public SinhVien[] A
        {
            get { return a; }
            set { a = value; }
        }
        public MangSinhVien()
        {
        }
        public MangSinhVien(int n)
        {
            a = new SinhVien[n];
        }

        public bool KiemTraSize(int n)
        {
            return n > 0 && n <= 1000000;
        }
        public bool TonTai(string maSo)
        {
            if (a == null)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null && a[i].MaSo == maSo)
                    return true;
            }

            return false;
        }

        public void NhapMang()
        {
            int n;

            while (true)
            {
                Console.Write("Nhap so luong sinh vien: ");

                if (int.TryParse(Console.ReadLine(), out n)
                    && KiemTraSize(n))
                {
                    break;
                }

                Console.WriteLine(
                    "So luong sinh vien khong hop le!"
                );
            }

            a = new SinhVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "===== SINH VIEN THU " + (i + 1) + " ====="
                );

                while (true)
                {
                    SinhVien sv = new SinhVien();
                    sv.Nhap();

                    if (TonTai(sv.MaSo))
                    {
                        Console.WriteLine(
                            "MSSV da ton tai! Vui long nhap lai sinh vien nay."
                        );
                    }
                    else
                    {
                        a[i] = sv;
                        break;
                    }
                }
            }
        }

        public void XuatMang()
        {
            if (a == null)
            {
                Console.WriteLine("Mang sinh vien chua duoc tao.");
                return;
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "===== SINH VIEN THU " + (i + 1) + " ====="
                );

                a[i].Xuat();
            }
        }

        public void SelectionSortMaSo()
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (string.Compare(a[j].MaSo, a[min].MaSo) < 0)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    SinhVien temp = a[i];
                    a[i] = a[min];
                    a[min] = temp;
                }
            }
        }

        public void InsertionSortDiemTB()
        {
            for (int i = 1; i < a.Length; i++)
            {
                SinhVien x = a[i];
                int j = i - 1;

                while (j >= 0 && a[j].DiemTB < x.DiemTB)
                {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = x;
            }
        }
    }
}