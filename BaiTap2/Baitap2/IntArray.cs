using System;

namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap2
{
    internal class IntArray
    {
        private int[] arr;

        public int[] Arr
        {
            get { return arr; }
            set { arr = value; }
        }
        public IntArray()
        {
        }
        public IntArray(int k)
        {
            arr = new int[k];

            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(2, 200);
            }
        }
        public IntArray(int[] a)
        {
            arr = new int[a.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = a[i];
            }
        }
        public IntArray(IntArray obj)
        {
            arr = new int[obj.arr.Length];

            for (int i = 0; i < obj.arr.Length; i++)
            {
                arr[i] = obj.arr[i];
            }
        }
        public bool KiemTraKT(int n)
        {
            if (n >= 1 && n <= 10000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Nhap()
        {
            int n;

            while (true)
            {
                Console.Write("Nhap kich thuoc mang, n = ");
                n = int.Parse(Console.ReadLine());

                bool kqKTra = KiemTraKT(n);

                if (kqKTra == true)
                {
                    break;
                }

                Console.WriteLine("Kich thuoc mang khong hop le!");
            }

            Arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap Arr[{i}] = ");
                Arr[i] = int.Parse(Console.ReadLine());
            }
        }
        public void Xuat()
        {
            Console.WriteLine("\n\n-- Mang IntArray: ");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{Arr[i]} ");
            }

            Console.WriteLine();
        }
        public int TimTuanTu(int x)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                if (Arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
        public int TimNhiPhan(int x)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                int mid = (l + r) / 2;

                if (arr[mid] == x)
                {
                    return mid;
                }
                else if (arr[mid] > x)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return -1;
        }
        public int TimViTriMax()
        {
            int max = arr[0];
            int ViTriMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                    ViTriMax = i;
                }
            }
            return ViTriMax;
        }
    }
}