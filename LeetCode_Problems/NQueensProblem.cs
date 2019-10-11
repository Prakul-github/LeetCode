using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_Problems
{
    public class NQueensProblem
    {
        // 1 --> Queen is marked
        // 0 --> empty space
        // -1 --> Attacking position

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<int[,]> solutions = GetPossibleSolutions(n);

            IList<IList<string>> formattedSolution = new List<IList<string>>();
                        
            // Cast to required type
            foreach (int[,] solution in solutions)
            {
                IList<string> strSolution = new List<string>();

                for(int row = 0; row < n; row++)
                {
                    StringBuilder strRow = new StringBuilder();
                    for(int col=0; col<n; col++)
                    {
                        if(solution[row, col] == 1)
                            strRow.Append("Q"); 
                        else
                            strRow.Append(".");                        
                    }
                    strSolution.Add(strRow.ToString());
                }

                formattedSolution.Add(strSolution);
            }

            return formattedSolution;
        }

        public IList<int[,]> GetPossibleSolutions(int n)
        {
            List<int[,]> solutions = new List<int[,]>();
           
  //          for(int col = 0; col < n; col++)
            {
                int[,] chessBoard = InitialiseChessBoard(n);

                // Mark the first queen
                chessBoard[0, 0] = 1;
                int[,] solution = MarkNQueens(chessBoard, 0, 0, n, (n*n)-1);

                if (ValidateSolution(solution, n))
                {
                    solutions.Add(solution);
                }
            }

            return solutions;
        }

        private bool ValidateSolution(int[,] chessBoard, int n)
        {
            int sum = 0;
            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if (chessBoard[row, col] == 1)
                    {
                        sum++;
                        break;
                    }
                }
            }

            if (sum == n)
                return true;

            return false;
        }

        private int[,] MarkNQueens(int[,] chessBoard, int currentRow, int currentCol, int n, int spacesLeft)
        {
            if(spacesLeft == 0)
            {
                return chessBoard;
            }
            else
            {
                if(chessBoard[currentRow, currentCol] == 1)
                {
                    chessBoard = MarkAttacks(chessBoard, currentRow, currentCol, n, ref spacesLeft);
                    bool flag = false;

                    for (int col = 1; col < n; col++)
                    {
                        if (chessBoard[(currentRow + 1) % n, (currentCol + col) % n] == 0)
                        {
                            currentRow = (currentRow + 1) % n;
                            currentCol = (currentCol + col) % n;

                            spacesLeft--;
                            chessBoard[currentRow, currentCol] = 1;
                            
                            MarkNQueens(chessBoard, currentRow, currentCol, n, spacesLeft);
                        }
                    }            
                }
            }

            return chessBoard;
        }

        private int[,] MarkAttacks(int[,] chessBoard, int currentRow, int currentCol, int n, ref int spacesLeft)
        {
            int crossedValue = 8;

            for(int iLoop = 1; iLoop < n; iLoop++)
            {
                if(chessBoard[currentRow, (currentCol + iLoop) % n] == 0)
                {
                    spacesLeft--;
                    chessBoard[currentRow, (currentCol + iLoop) % n] = crossedValue;
                }

                if (chessBoard[(currentRow + iLoop) % n, currentCol] == 0)
                {
                    spacesLeft--;
                    chessBoard[(currentRow + iLoop) % n, currentCol] = crossedValue;
                }
                                
                if(currentRow + iLoop < n && currentCol + iLoop < n && chessBoard[currentRow + iLoop, currentCol + iLoop] == 0)
                {
                    spacesLeft--;
                    chessBoard[currentRow + iLoop, currentCol + iLoop] = crossedValue;
                }

                if (currentRow - iLoop >= 0 && currentCol - iLoop >= 0 && chessBoard[currentRow - iLoop, currentCol - iLoop] == 0)
                {
                    spacesLeft--;
                    chessBoard[currentRow - iLoop, currentCol - iLoop] = crossedValue;
                }

                if (currentRow + iLoop < n && currentCol - iLoop >= 0 && chessBoard[currentRow + iLoop, currentCol - iLoop] == 0)
                {
                    spacesLeft--;
                    chessBoard[currentRow + iLoop, currentCol - iLoop] = crossedValue;
                }

                if (currentRow - iLoop >= 0 && currentCol + iLoop < n && chessBoard[currentRow - iLoop, currentCol + iLoop] == 0)
                {
                    spacesLeft--;
                    chessBoard[currentRow - iLoop, currentCol + iLoop] = crossedValue;
                }
            }

            return chessBoard;
        }

        private int[,] InitialiseChessBoard(int n)
        {
            int[,] initialiseChessBoard = new int[n, n];

            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    initialiseChessBoard[row, col] = 0;
                }
            }

            return initialiseChessBoard;
        }
    }
}
