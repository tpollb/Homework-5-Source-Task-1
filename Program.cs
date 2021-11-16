using System;

namespace Homework_4_Source_Task_3._1
{
    class Program
    {
        /// <summary>
        /// Метод генерации симметричной матрицы (двумерный массив)
        /// </summary>
        /// <param name="MatrixSize">Сторона матрицы</param>
        /// <param name="MinNumber">Минимальное число для генерации заполнения</param>
        /// <param name="MaxNumber">Максимальное число для генерации заполнения</param>
        /// <returns></returns>
        static int[,] GenerateRandomSymmetricMatrix(int MatrixSize, int MatrixSize1, int MinNumber, int MaxNumber)
        {
            var Rand = new Random();
            int[,] matrix = new int [MatrixSize, MatrixSize1];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize1; j++)
                {
                    matrix[i, j] = Rand.Next(MinNumber, MaxNumber);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Метод вывода матрицы (двумерного массива) на экран
        /// </summary>
        /// <param name="Source">Исходная матрица. Двумерный массив</param>
        static void DisplayMatrix(int[,] Source)
        {
            Console.WriteLine();
            int n = Source.GetLength(0);
            int m = Source.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{Source[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="Source">Исходная матрица, двумерный массив</param>
        /// <param name="Number">Число на которое необходимо умножить матрицу</param>
        /// <returns></returns>
        static int[,] MatrixMultiplicationByNumber(int[,] Source, int Number)
        {
            int n = Source.GetLength(0);
            int m = Source.GetLength(1);

            int[,] MultMatrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    MultMatrix[i, j] = Source[i, j] * Number;
                }
            }
            return MultMatrix;
        }

        /// <summary>
        /// Метод сложения 2х матриц
        /// </summary>
        /// <param name="Source">Исходная иатрица 1. Двумерный массив</param>
        /// <param name="Source1">Исходная иатрица 2. Двумерный массив</param>
        /// <returns></returns>
        static int[,] SumOfMatrices(int[,] Source, int[,] Source1)
        {
            int n1 = Source1.GetLength(0);
            int m1 = Source1.GetLength(1);

            int[,] SumMatrix = new int[n1, m1];
            
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m1; j++)
                    {
                        SumMatrix[i, j] = Source[i, j] + Source1[i, j];
                    }
                }
            
            return SumMatrix;
        }

        /// <summary>
        /// Метод умножения 2х матриц
        /// </summary>
        /// <param name="Source">Исходная иатрица 1. Двумерный массив</param>
        /// <param name="Source1">Исходная иатрица 2. Двумерный массив</param>
        /// <returns></returns>
        static int[,] MatrixMultiplication(int[,] Source, int[,] Source1)
        {
            int n = Source.GetLength(0);
            int m1 = Source1.GetLength(1);

            int[,] MultMatrix = new int[m1, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    MultMatrix[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        MultMatrix[i, j] += Source[i, k] * Source1[k, j];
                    }
                }
            }
            return MultMatrix;
        }




        static void Main(string[] args)
        {
            
            int n = -256;
            int MatrixSize = 1;
            int MatrixSize1 = 1;
            int MinNuber = 0;
            int MaxNuber = 20;
            bool successfullyParsed = default;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Тема 5. Домашнее задание.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.1. Создать метод, умножающий матрицу на число.\n");
            Console.ResetColor();

            //генерация матрицы 1
            while ((MatrixSize < 2 || MatrixSize > 255) & successfullyParsed == false)
            {
                Console.WriteLine("Введите количество строк матрицы 1 от 2 до 255: ");
                successfullyParsed = int.TryParse(Console.ReadLine(), out MatrixSize);
            }
            successfullyParsed = false;

            while ((MatrixSize1 < 2 || MatrixSize1 > 255) & successfullyParsed == false)
            {
                Console.WriteLine("Введите количество столбцов матрицы 1 от 2 до 255: ");
                successfullyParsed = int.TryParse(Console.ReadLine(), out MatrixSize1);
            }
            successfullyParsed = false;

            int[,] matrix = GenerateRandomSymmetricMatrix(MatrixSize, MatrixSize1, MinNuber, MaxNuber);

            MatrixSize = 1;
            MatrixSize1 = 1;

            //генерация матрицы 2
            while ((MatrixSize < 2 || MatrixSize > 255) & successfullyParsed == false)
            {
                Console.WriteLine("Введите количество строк матрицы 2 от 2 до 255: ");
                successfullyParsed = int.TryParse(Console.ReadLine(), out MatrixSize);
            }
            successfullyParsed = false;

            while ((MatrixSize1 < 2 || MatrixSize1 > 255) & successfullyParsed == false)
            {
                Console.WriteLine("Введите количество столбцов матрицы 2 от 2 до 255: ");
                successfullyParsed = int.TryParse(Console.ReadLine(), out MatrixSize1);
            }
            successfullyParsed = false;

            int[,] matrix1 = GenerateRandomSymmetricMatrix(MatrixSize, MatrixSize1, MinNuber, MaxNuber);

            //вывод исходных матриц
            Console.WriteLine($"Наша матрица 1:");
            DisplayMatrix(matrix);
            Console.WriteLine($"Наша матрица 2:");
            DisplayMatrix(matrix1);

            //умнодение матрицы на число
            while (successfullyParsed == false)
            {
                Console.WriteLine("Введите множитель: ");
                successfullyParsed = int.TryParse(Console.ReadLine(), out n);
            }
            
            int[,] MultMatrix = MatrixMultiplicationByNumber(matrix, n);

            Console.WriteLine($"Результат умножения матрицы 1 на число:");
            DisplayMatrix(MultMatrix);

            Console.WriteLine($"Для продолжения нажмите любую клавишу:\n");
            Console.ReadLine();

            //сложение 2х матриц
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.2. Создать метод, складывающий 2 матрицы.\n");
            Console.ResetColor();

            
            if (matrix.GetLength(0) != matrix1.GetLength(0) || matrix.GetLength(1) != matrix1.GetLength(1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Сложение не возможно. Матрицы разной размерности.\n");
            } else
            {
                int[,] SumMatrix = SumOfMatrices(matrix, matrix1);
                Console.WriteLine($"Сумма наших матриц:\n");
                DisplayMatrix(SumMatrix);
            }

            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.3. Создать метод, умножающий 2 матрицы.\n");
            Console.ResetColor();

            if ((matrix.GetUpperBound(0) + 1 != matrix1.GetUpperBound(1) + 1) || (matrix.GetUpperBound(1) + 1 != matrix1.GetUpperBound(0) + 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Умножение не возможно.\n");
            } else
            {
                int[,] MultMatrix1 = MatrixMultiplication(matrix, matrix1);
                Console.WriteLine($"Произведение наших матриц:\n");
                DisplayMatrix(MultMatrix1);
            }

            Console.ReadKey();
        }
    }
}
