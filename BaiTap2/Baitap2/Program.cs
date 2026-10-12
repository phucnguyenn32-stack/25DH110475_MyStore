using System;
using System.Collections.Generic;
using System.Text;

namespace MSSV_25DH110475_NguyenPhucNguyen_BaiTap2
{
    internal class Program
    {
        static void TestConstructor1()
        {
            IntArray obj = new IntArray(20);
            Console.WriteLine("Generated array values:");
            obj.Xuat();
        }
        static void TestConstructor3()
        {
            IntArray obj1 = new IntArray();
            obj1.Nhap();
            Console.WriteLine("Array values:");
            obj1.Xuat();
            IntArray obj2 = new IntArray(obj1);

            Console.WriteLine("\nCopied array values:");
            obj2.Xuat();
        }

        static void Main(string[] args)
        {
            TestConstructor1();
            TestConstructor3();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}