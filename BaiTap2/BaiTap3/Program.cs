using System;

namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap3
{
    internal class Program
    {
        static void TestInterchangeSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.InterchangeSort();

            Console.WriteLine("Sau Interchange Sort:");
            arr.Xuat();
        }

        static void TestBubbleSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.BubbleSort();

            Console.WriteLine("Sau Bubble Sort:");
            arr.Xuat();
        }

        static void TestSelectionSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.SelectionSort();

            Console.WriteLine("Sau Selection Sort:");
            arr.Xuat();
        }

        static void TestInsertionSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.InsertionSort();

            Console.WriteLine("Sau Insertion Sort:");
            arr.Xuat();
        }

        static void TestQuickSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.QuickSort(0, arr.Arr.Length - 1);

            Console.WriteLine("Sau Quick Sort:");
            arr.Xuat();
        }
        static void TestHeapSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.HeapSort();

            Console.WriteLine("Sau Heap Sort:");
            arr.Xuat();
        }

        static void TestMergeSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.MergeSort(0, arr.Arr.Length - 1);

            Console.WriteLine("Sau Merge Sort:");
            arr.Xuat();
        }
        static void TestShellSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.ShellSort();

            Console.WriteLine("Sau Shell Sort:");
            arr.Xuat();
        }
        static void TestShakerSort()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("Mang ban dau:");
            arr.Xuat();

            arr.ShakerSort();

            Console.WriteLine("Sau Shaker Sort:");
            arr.Xuat();
        }
        static void TestSelectionSortMaSo()
        {
            MangSinhVien ds = new MangSinhVien();

            Console.WriteLine("NHAP DANH SACH SINH VIEN:");
            ds.NhapMang();

            Console.WriteLine("\nDANH SACH BAN DAU:");
            ds.XuatMang();

            ds.SelectionSortMaSo();

            Console.WriteLine("\nSAU KHI SAP XEP TANG DAN THEO MA SO:");
            ds.XuatMang();
        }

        static void TestInsertionSortDiemTB()
        {
            MangSinhVien ds = new MangSinhVien();

            Console.WriteLine("NHAP DANH SACH SINH VIEN:");
            ds.NhapMang();

            Console.WriteLine("\nDANH SACH BAN DAU:");
            ds.XuatMang();

            ds.InsertionSortDiemTB();

            Console.WriteLine("\nSAU KHI SAP XEP GIAM DAN THEO DIEM TB:");
            ds.XuatMang();
        }
        static void TestThongKe()
        {
            int[] kichThuoc = { 10, 1000, 10000 };

            foreach (int n in kichThuoc)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("N = " + n);
                Console.WriteLine("==============================");

                IntArray arrShell = new IntArray(n);
                IntArray arrShaker = new IntArray(arrShell);

                int ganShell = arrShell.ShellSortDemPhepGan();
                int ganShaker = arrShaker.ShakerSortDemPhepGan();

                Console.WriteLine("Shell Sort  - So phep gan: " + ganShell);
                Console.WriteLine("Shaker Sort - So phep gan: " + ganShaker);
            }
        }
        static void TestInterchangeSortMinhHoa()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("MANG BAN DAU:");
            arr.Xuat();

            long soLan = arr.InterchangeSortMinhHoa();

            Console.WriteLine("\nMANG SAU KHI SAP XEP:");
            arr.Xuat();

            Console.WriteLine("\nTong so lan hoan vi: " + soLan);
        }
        static void TestBubbleSortMinhHoa()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("MANG BAN DAU:");
            arr.Xuat();

            long soLan = arr.BubbleSortMinhHoa();

            Console.WriteLine("\nMANG SAU KHI SAP XEP:");
            arr.Xuat();

            Console.WriteLine("\nTong so lan hoan vi: " + soLan);
        }
        static void TestSelectionSortMinhHoa()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("MANG BAN DAU:");
            arr.Xuat();

            long soLan = arr.SelectionSortMinhHoa();

            Console.WriteLine("\nMANG SAU KHI SAP XEP:");
            arr.Xuat();

            Console.WriteLine("\nTong so lan hoan vi: " + soLan);
        }
        static void TestInsertionSortMinhHoa()
        {
            IntArray arr = new IntArray(10);

            Console.WriteLine("MANG BAN DAU:");
            arr.Xuat();

            long soLan = arr.InsertionSortMinhHoa();

            Console.WriteLine("\nMANG SAU KHI SAP XEP:");
            arr.Xuat();

            Console.WriteLine("\nTong so phep gan: " + soLan);
        }
        static void Main(string[] args)
        {
            int chon;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Interchange Sort");
                Console.WriteLine("2. Bubble Sort");
                Console.WriteLine("3. Selection Sort");
                Console.WriteLine("4. Insertion Sort");
                Console.WriteLine("5. Quick Sort");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("6. Selection Sort - MaSo tang dan");
                Console.WriteLine("7. Insertion Sort - DiemTB giam dan");
                Console.WriteLine("8. Heap Sort");
                Console.WriteLine("9. Merge Sort");
                Console.WriteLine("10. Shell Sort");
                Console.WriteLine("11. Shaker Sort");
                Console.WriteLine("12. Thong ke Shell va Shaker");
                Console.WriteLine("13. Interchange Sort Minh Hoa");
                Console.WriteLine("14. Bubble Sort Minh Hoa");
                Console.WriteLine("15. Selection Sort Minh Hoa");
                Console.WriteLine("16. Insertion Sort Minh Hoa");
                Console.Write("Nhap lua chon: ");

                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        TestInterchangeSort();
                        break;

                    case 2:
                        TestBubbleSort();
                        break;

                    case 3:
                        TestSelectionSort();
                        break;

                    case 4:
                        TestInsertionSort();
                        break;
                    case 5:
                        TestQuickSort();
                        break;
                    case 6:
                        TestSelectionSortMaSo();
                       break;
                    case 7:
                        TestInsertionSortDiemTB();
                        break;
                    case 8:
                        TestHeapSort();
                        break;
                    case 9:
                        TestMergeSort();
                        break;
                    case 10:
                        TestShellSort();
                        break;
                    case 11:
                        TestShakerSort();
                        break;
                    case 12:
                        TestThongKe();
                        break;
                    case 13:
                        TestInterchangeSortMinhHoa();
                        break;
                    case 14:
                        TestBubbleSortMinhHoa();
                        break;
                    case 15:
                        TestSelectionSortMinhHoa();
                        break;
                    case 16:
                        TestInsertionSortMinhHoa();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (chon != 0);
        }
    }
}