using System;

    // Tugas Aljabar Linear
    // Kelompok 26
    // Yakub Sulvi Pratama - NIM 220401010186
    // Muhammad Nasiruddin Al Albani - NIM 230401010137

class MatrixOperations
{
    const int MAX_SIZE = 10;

    static void InputMatrix(int[,] matrix, int rows, int cols)
    {
        Console.WriteLine("Masukkan elemen matriks:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write($"Baris {i + 1}, Kolom {j + 1}: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matriks yang dimasukkan:");
        for (int i = 0; i < rows; ++i)
        {
            Console.Write("| ");
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine("|");
        }
    }

    static void DisplayMatrix(int[,] matrix, int rows, int cols)
    {
        Console.WriteLine("Matriks:");
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void AddMatrix(int[,] A, int[,] B, int[,] result, int rows, int cols)
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                result[i, j] = A[i, j] + B[i, j];
            }
        }
    }

    static void SubtractMatrix(int[,] A, int[,] B, int[,] result, int rows, int cols)
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                result[i, j] = A[i, j] - B[i, j];
            }
        }
    }

    static int Determinant(int[,] matrix, int size)
    {
        if (size == 1)
        {
            return matrix[0, 0];
        }
        else if (size == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            int det = 0;
            for (int i = 0; i < size; ++i)
            {
                int[,] submatrix = new int[MAX_SIZE, MAX_SIZE];
                for (int j = 1; j < size; ++j)
                {
                    for (int k = 0; k < size; ++k)
                    {
                        if (k < i)
                        {
                            submatrix[j - 1, k] = matrix[j, k];
                        }
                        else if (k > i)
                        {
                            submatrix[j - 1, k - 1] = matrix[j, k];
                        }
                    }
                }
                det += (int)Math.Pow(-1, i) * matrix[0, i] * Determinant(submatrix, size - 1);
            }
            return det;
        }
    }

    static void Main()
    {
        int choice;
        char repeat;

        do
        {
            Console.WriteLine("Tugas Aljabar Linear");
            Console.WriteLine("Yakub Sulvi Pratama              | NIM 220401010186");
            Console.WriteLine("Muhammad Nasiruddin Al Albani    | NIM 230401010137");
            Console.WriteLine("Kelompok 26");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Pilih operasi matriks:");
            Console.WriteLine("1. Penjumlahan");
            Console.WriteLine("2. Pengurangan");
            Console.WriteLine("3. Determinan");
            Console.Write("Pilihan: ");
            choice = int.Parse(Console.ReadLine());

            int rows, cols;
            Console.Write("Masukkan jumlah baris matriks: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Masukkan jumlah kolom matriks: ");
            cols = int.Parse(Console.ReadLine());

            int[,] matrixA = new int[MAX_SIZE, MAX_SIZE];
            int[,] matrixB = new int[MAX_SIZE, MAX_SIZE];
            int[,] result = new int[MAX_SIZE, MAX_SIZE];

            Console.WriteLine("Matriks A:");
            InputMatrix(matrixA, rows, cols);
            Console.WriteLine("Matriks B:");
            InputMatrix(matrixB, rows, cols);

            switch (choice)
            {
                case 1:
                    AddMatrix(matrixA, matrixB, result, rows, cols);
                    Console.WriteLine("Hasil Penjumlahan:");
                    DisplayMatrix(result, rows, cols);
                    break;
                case 2:
                    SubtractMatrix(matrixA, matrixB, result, rows, cols);
                    Console.WriteLine("Hasil Pengurangan:");
                    DisplayMatrix(result, rows, cols);
                    break;
                case 3:
                    if (rows != cols)
                    {
                        Console.WriteLine("Determinan hanya dapat dihitung untuk matriks persegi.");
                    }
                    else
                    {
                        Console.WriteLine($"Determinan Matriks A: {Determinant(matrixA, rows)}");
                        Console.WriteLine($"Determinan Matriks B: {Determinant(matrixB, rows)}");
                    }
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }

            Console.Write("Apakah ingin mengulang penghitungan? (y/n): ");
            repeat = char.Parse(Console.ReadLine());

        } while (repeat == 'y' || repeat == 'Y');
    }
}
