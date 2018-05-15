//knight will move from 1, 0 to like 6, 6 in one move, obviously not WAI(working as intended)
//the tempcol and temprow flip after a work(row, column) seem to happen, ask josh i suppose
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightTour
{
    class KnightTour
    {
        //random number to generate how knight will move
        static Random rng = new Random();

        //the board size of 8 rows and 8 columns
        static bool[,] board = new bool[8, 8];

        //the 8 spots in columns where the knight can move
        static int[] horizontal = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };

        //the 8 spots in rows where the knight can move
        static int[] vertical = new int[] { -1, -2, -2, -1, 1, 2, 2, 1 };

        //starting point for the knight 4, 4
        static int currentRow;
        static int currentColumn;

        static void Main(string[] args)
        {
            currentRow = 4;
            currentColumn = 4;
            //display where knight has gone
            //Console.WriteLine("Column\tRow\tCounter");
            MakeMove(vertical, horizontal);
        }//end main       


        //if move is valid, make it
        public static void MakeMove(int[] vertical, int[] horizontal)
        {
            int counter = 0;
            while (counter < 64)
            {
                if (MovePossible() == true)
                {
                    ++counter;
                    Console.WriteLine($"{currentRow}\t{currentColumn}\t{counter}");
                }
                else if (MovePossible() == false)
                {
                    continue;
                }
            }
            //extra line
            Console.WriteLine();
        }

        //determine where knight moves
        private static bool MovePossible()
        {
            int moveNumber = rng.Next(0, 7);

            //starting point of knight set to true, cant go there again
            board[4, 4] = true;
            bool result = false;

            //variable if knight fails to move, reset back to where it was and try again            
            int tempCol = 0;
            int tempRow = 0;

            //assign temp to last working numbers
            tempCol = currentColumn;
            tempRow = currentRow;

            //Console.WriteLine("TempCol: " + tempCol);
            //Console.WriteLine("TempRow: " + tempRow + "\n");

            // Console.Write($"{tempRow} {tempCol}\t");
            currentRow += vertical[moveNumber];
            currentColumn += horizontal[moveNumber];

            //if knight goes off board, return false, try again
            if (currentColumn < 0 || currentColumn > 7 || currentRow > 7 || currentRow < 0)
            {
                currentColumn = tempCol;
                currentRow = tempRow;
                //Console.Write($"stay");
                return false;
            }
            //if knight is within board, continue
            //if knight hasnt been here before, safe to move
            else if (currentColumn >= 0 && currentColumn < 8 && currentRow >= 0 && currentRow < 8)
            {
                if (Spot() == true)
                {
                    board[currentRow, currentColumn] = true;
                    // Console.Write($"work({currentRow} {currentColumn})");
                    return true;
                }
                //if knight has been here, retry
                else
                {
                    // Console.Write($"retry({currentRow} {currentColumn})");
                    currentColumn = tempCol;
                    currentRow = tempRow;
                    return false;
                }
            }
            return result;
        }

        //if knight has already been to the spot
        private static bool Spot()
        {
            if (board[currentRow, currentColumn] == true)
            {
                return false;
            }

            return true;
        }
    }//end class
}//end namespace

/*

private bool try_move(old_row, old_col, new_row, new_col)
{
    if (out_of_bounds)
        return false
    else if (spot is taken)
        return false
    else if ( (abs(old_row - new_row)) + (abs(old_col - new_col)) != 3)
        return false
    else
        return true

*/

