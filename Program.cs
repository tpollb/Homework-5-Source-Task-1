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
        static int[,] GenerateRandomSymmetricMatrix(int MatrixSize, int MinNumber, int MaxNumber)
        {
            var Rand = new Random();
            int[,] matrix = new int [MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
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
            for (int i = 0; i < Source.GetLength(0); i++)
            {
                for (int j = 0; j < Source.GetLength(1); j++)
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
            int[,] MultMatrix = new int[Source.GetLength(0), Source.GetLength(1)];

            for (int i = 0; i < Source.GetLength(0); i++)
            {
                for (int j = 0; j < Source.GetLength(1); j++)
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
            int[,] SumMatrix = new int[Source1.GetLength(0), Source1.GetLength(1)];

            if (Source.GetLength(0) != Source1.GetLength(0) || Source.GetLength(1) != Source1.GetLength(1))
            {
                Console.WriteLine("Сложение не возможно. Матрицы разной размерности");
            } else
            {
                
                for (int i = 0; i < Source1.GetLength(0); i++)
                {
                    for (int j = 0; j < Source1.GetLength(1); j++)
                    {
                        SumMatrix[i, j] = Source[i, j] + Source1[i, j];
                    }
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
            int[,] MultMatrix = new int[Source1.GetLength(1), Source.GetLength(0)];

            for (int i = 0; i < Source.GetLength(0); i++)
            {
                if ((Source.GetUpperBound(0) + 1 != Source1.GetUpperBound(1) + 1) || (Source.GetUpperBound(1) + 1 != Source1.GetUpperBound(0) + 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Умножение не возможно");
                    break;
                }
                for (int j = 0; j < Source1.GetLength(1); j++)
                {
                    MultMatrix[i, j] = 0;
                    for (int k = 0; k < Source.GetLength(0); k++)
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
            int MinNuber = 0;
            int MaxNuber = 20;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Тема 5. Домашнее задание.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.1. Создать метод, умножающий матрицу на число.\n");
            Console.ResetColor();

            while (MatrixSize < 2 || MatrixSize > 255)
            {
                Console.WriteLine("Введите размерность матрицы от 2 до 255: ");
                MatrixSize = int.Parse(Console.ReadLine());
            }

            int[,] matrix = GenerateRandomSymmetricMatrix(MatrixSize, MinNuber, MaxNuber);
            int[,] matrix1 = GenerateRandomSymmetricMatrix(MatrixSize, MinNuber, MaxNuber);

            Console.WriteLine($"Наша матрица:\n");
            DisplayMatrix(matrix);

            while (n < -255 || n > 255)
            {
                Console.WriteLine("Введите множитель от -255 до 255: ");
                n = int.Parse(Console.ReadLine());
            }

            int[,] MultMatrix = MatrixMultiplicationByNumber(matrix, n);

            Console.WriteLine($"Результат умножения нашей исходной матрицы на число:\n");
            DisplayMatrix(MultMatrix);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.2. Создать метод, складывающий 2 матрицы.\n");
            Console.ResetColor();

            int[,] SumMatrix = SumOfMatrices(matrix, matrix1);
            Console.WriteLine($"Наши матрицы:\n");
            DisplayMatrix(matrix);
            DisplayMatrix(matrix1);
            Console.WriteLine($"Сумма наших матриц:\n");
            DisplayMatrix(SumMatrix);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 1.3. Создать метод, умножающий 2 матрицы.\n");
            Console.ResetColor();

            int[,] MultMatrix1 = MatrixMultiplication(matrix, matrix1);
            Console.WriteLine($"Произведение наших матриц:\n");
            DisplayMatrix(MultMatrix1);

            Console.ReadKey();
        }
    }
}
