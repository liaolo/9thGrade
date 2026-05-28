using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10thGrade
{
    public class Matrix
    {
        private static Random rnd = new Random();

        public static void RandomGrades(int[,] grades)
        {
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                for (int col = 0; col < grades.GetLength(1); col++)
                {
                    grades[row, col] = rnd.Next(55, 101);
                }
            }
        }
        public static int[,] RandomGrades(int r, int c)
        {
            int[,] grades = new int[r, c];
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                for (int col = 0; col < grades.GetLength(1); col++)
                {
                    grades[row, col] = rnd.Next(55, 101);
                }
            }
            return grades;
        }


        public static void Print(int[,] grades)
        {
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                for (int col = 0; col < grades.GetLength(1); col++)
                {
                    Console.Write(grades[row, col] + "\t");
                }
                Console.WriteLine();
            }
        }

        // ממוצע כללי של כל הציונים בכל המבחנים
        public static double Avrg(int[,] grades)
        {
            int sum = 0;
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                for (int col = 0; col < grades.GetLength(1); col++)
                {
                    sum += grades[row, col];
                }
            }
            return (double)sum / grades.Length;
        }

        // ממוצע ציונים לתלמיד - שורה קבועה
        public static double RowAvrg(int[,] grades, int row)
        {
            int sum = 0;
            for (int col = 0; col < grades.GetLength(1); col++)
            {
                sum += grades[row, col];
            }
            return (double)sum / grades.GetLength(1);
        }

        // ממוצע כיתתי למבחן - עמודה קבועה
        public static double ColAvrg(int[,] grades, int col)
        {
            int sum = 0;
            for (int row = 0; row < grades.GetLength(0); row++)
            {
                sum += grades[row, col];
            }
            return (double)sum / grades.GetLength(0);
        }

        public static int T9a(int[,] arr, int row, int col)
        {
            int SumRow = 0;
            int SumCol = 0;

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                SumRow += arr[row, i];
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                SumCol += arr[i, col];
            }
            if (SumRow == SumCol)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int T9b(int[,] arr)
        {
            int count = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (T9a(arr, row, col) == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        public static void Test()
        {
            //  מערך דו ממדי עם תשע-עשר תלמידים וארבע ציונים לכל תלמיד
            int[,] grd = new int[19, 4];
            Matrix.RandomGrades(grd);
            Console.WriteLine("-------------------------------");
            Matrix.Print(grd);
            Console.WriteLine("-------------------------------");
            Console.WriteLine(Matrix.Avrg(grd));
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Row student #3 avrg is: " + Matrix.RowAvrg(grd, 2));
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Col Test #2 avrg is: " + Matrix.ColAvrg(grd, 1));
        }

    
        



    }
}


