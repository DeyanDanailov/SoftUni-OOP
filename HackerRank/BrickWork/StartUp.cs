using System;
using System.Collections.Generic;
using System.Linq;

namespace BrickWork
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter even dimensions separated by a single space:");
            try
            {
                int[] dimensions = ParseArrayFromConsole(' ');

                if (dimensions.Length != 2)
                {
                    throw new ArgumentException("Invalid area dimensions!");
                }

                var rows = dimensions[0];
                var cols = dimensions[1];

                CheckDimensions(rows, cols);

                var brickQueue = new Queue<int>();

                for (int i = 1; i <= (rows * cols) / 2; i++) // Creating queue with halves of bricks 
                {                                            // in order to have a correct brick numbers in the output matrix
                    brickQueue.Enqueue(i);
                    brickQueue.Enqueue(i);
                }

                var inputMatrix = new int[rows, cols];

                Console.WriteLine("Please enter every row on a new line:");
                ReadMatrix(rows, cols, inputMatrix);

                var outputMatrix = new int[rows, cols];
                FillOutputMatrix(rows, cols, brickQueue, inputMatrix, outputMatrix);

                Console.WriteLine("Please enter a brick separator:");
                var brickSeparator = Console.ReadLine();
                PrintMatrix(outputMatrix, brickSeparator);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }

        private static void CheckDimensions(int rows, int cols)
        {
            if (rows >= 100 ||
                                cols >= 100 ||
                                rows % 2 != 0 ||
                                cols % 2 != 0 ||
                                rows <= 0 ||
                                cols <= 0)
            {
                throw new ArgumentException("Invalid area dimensions!");
            }
        }

        private static void FillOutputMatrix(int rows, int cols, Queue<int> brickQueue, int[,] inputMatrix, int[,] outputMatrix)
        {
            for (int i = 0; i < rows; i++)                              // Start filling with bricks row by row 
            {                                                           // keeping an eye on the input matrix and the initial bricks
                for (int j = 0; j < cols; j++)
                {
                    if (outputMatrix[i, j] == 0)                        // Check if the cell is not occupied by a brick
                    {
                        outputMatrix[i, j] = brickQueue.Dequeue();      // Put the first part of the brick
                        if (j == cols - 1)                              // Check if we are on the end ot the row
                        {
                            outputMatrix[i + 1, j] = brickQueue.Dequeue(); // Put the brick vertically 
                            continue;                                      // since we are at the last cell of the row
                        }
                        if (inputMatrix[i, j] == inputMatrix[i, j + 1])    // Check how the initial brick is oriented
                        {
                            if (i + 1 < rows && outputMatrix[i + 1, j] == 0)
                            {
                                outputMatrix[i + 1, j] = brickQueue.Dequeue(); // Putting the brick vertically
                            }
                        }
                        else
                        {
                            if (j + 1 < cols && outputMatrix[i, j + 1] == 0)
                            {
                                outputMatrix[i, j + 1] = brickQueue.Dequeue(); // Putting the brick horizontally
                                j++;
                            }

                        }
                    }

                }
            }
        }

        private static void PrintMatrix(int[,] outputMatrix, string brickSeparator)
        {
            Console.WriteLine("--------------------");
            for (int row = 0; row < outputMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < outputMatrix.GetLength(1); col++)
                {
                    if (col == outputMatrix.GetLength(1) - 1)
                    {
                        Console.Write(outputMatrix[row, col]);
                        continue;
                    }
                    if (outputMatrix[row, col] == outputMatrix[row, col + 1])
                    {
                        Console.Write(outputMatrix[row, col] + " ");
                    }
                    else
                    {
                        Console.Write(outputMatrix[row, col] + brickSeparator);
                    }
                }              
                Console.WriteLine();

                //If you need brick separators betweem rows,
                // please uncomment this part. I personally think it is
                // better without them but I wanted to fulfill the assignment

                //for (int col = 0; col < outputMatrix.GetLength(1); col++)       
                //{                                                               
                //    if (col == outputMatrix.GetLength(1) - 1)                   
                //    {                                                           
                //        if (outputMatrix[row, col] == outputMatrix[row + 1, col])
                //        {
                //            if (outputMatrix[row, col]/10 >= 1)                 // Check if the number is between 10 and 100 
                //            {                                                   // or more to put two separators
                //                Console.Write("  ");
                //            }
                //            else
                //            {
                //                Console.Write(" ");
                //            }                           
                //        }
                //        else
                //        {
                //            if (outputMatrix[row, col] / 10 >= 1)               // Check if the number is 10 or more to put two separators
                //            {
                //                Console.Write(brickSeparator + brickSeparator); // If we expect numbers bigger than 100 we should add 
                //            }                                                   // brick separators with 3 and four symbols.
                //            else
                //            {
                //                Console.Write(brickSeparator);
                //            }
                //        }
                //        continue;
                //    }
                //    if (row == outputMatrix.GetLength(0) - 1)
                //    {
                //        return;
                //    }
                //    if (outputMatrix[row, col] == outputMatrix[row + 1, col])
                //    {
                //        if (outputMatrix[row, col] / 10 >= 1)
                //        {
                //            Console.Write("   ");
                //        }
                //        else
                //        {
                //            Console.Write("  ");
                //        }
                //    }
                //    else
                //    {
                //        if (outputMatrix[row, col] / 10 >= 1)
                //        {
                //            Console.Write(brickSeparator + brickSeparator + " ");
                //        }
                //        else
                //        {
                //            Console.Write(brickSeparator + " ");
                //        }
                        
                //    }
                //} 
                //Console.WriteLine();                                          
            }
        }

        private static void ReadMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = ParseArrayFromConsole(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static int[] ParseArrayFromConsole(params char[] splitSymbols)

          => Console.ReadLine()
               .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
    }
}
