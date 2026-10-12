using System;

namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap3
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
        public void InterchangeSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
        public long InterchangeSortMinhHoa()
        {
            long soLanHoanVi = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                        soLanHoanVi++;

                        Console.WriteLine("\nSau lan hoan vi thu " + soLanHoanVi + ":");
                        Xuat();
                    }
                }
            }

            return soLanHoanVi;
        }
        public void BubbleSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public long BubbleSortMinhHoa()
        {
            long soLanHoanVi = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        soLanHoanVi++;

                        Console.WriteLine("\nSau lan hoan vi thu " + soLanHoanVi + ":");
                        Xuat();
                    }
                }
            }

            return soLanHoanVi;
        }
        public void SelectionSort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }
        public long SelectionSortMinhHoa()
        {
            long soLanHoanVi = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }

                if (min != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                    soLanHoanVi++;
                    Console.WriteLine("\nSau lan hoan vi thu " + soLanHoanVi + ":");
                    Xuat();
                }
            }

            return soLanHoanVi;
        }
        public void InsertionSort()
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = x;
            }
        }
        public long InsertionSortMinhHoa()
        {
            long soLanGan = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int x = arr[i];

                int j = i - 1;

                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    soLanGan++;

                    Console.WriteLine("\nSau phep gan thu " + soLanGan + ":");
                    Xuat();

                    j--;
                }

                arr[j + 1] = x;
                soLanGan++;

                Console.WriteLine("\nSau phep gan thu " + soLanGan + ":");
                Xuat();
            }

            return soLanGan;
        }
        public void QuickSort(int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }

                while (arr[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(left, j);
            }

            if (i < right)
            {
                QuickSort(i, right);
            }
        }
        public void HeapSort()
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(n, i);
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                Heapify(n, largest);
            }
        }
        public void MergeSort(int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(left, mid);
                MergeSort(mid + 1, right);

                Merge(left, mid, right);
            }
        }

        private void Merge(int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iLeft = 0;
            int iRight = 0;
            int k = left;

            while (iLeft < n1 && iRight < n2)
            {
                if (L[iLeft] <= R[iRight])
                {
                    arr[k] = L[iLeft];
                    iLeft++;
                }
                else
                {
                    arr[k] = R[iRight];
                    iRight++;
                }

                k++;
            }

            while (iLeft < n1)
            {
                arr[k] = L[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                arr[k] = R[iRight];
                iRight++;
                k++;
            }
        }
        public void ShellSort()
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int x = arr[i];
                    int j = i;

                    while (j >= gap && arr[j - gap] > x)
                    {
                        arr[j] = arr[j - gap];
                        j -= gap;
                    }

                    arr[j] = x;
                }
            }
        }
        public int ShellSortDemPhepGan()
        {
            int dem = 0;
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int x = arr[i];
                    int j = i;

                    while (j >= gap && arr[j - gap] > x)
                    {
                        arr[j] = arr[j - gap];
                        dem++;
                        j -= gap;
                    }

                    arr[j] = x;
                    dem++;
                }
            }

            return dem;
        }
        public int ShakerSortDemPhepGan()
        {
            int dem = 0;
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        dem += 3;
                    }
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        dem += 3;
                    }
                }

                left++;
            }

            return dem;
        }
        public void ShakerSort()
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }

                right--;
                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }
                }

                left++;
            }
        }
    }
}