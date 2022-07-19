using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    public class TicTacToe
    {
        private string[,] board = new string[3, 3];
        private int playCounter = 0;
        private bool draw = false;
        // private List<int> playedmoves = new List<int>();

        public TicTacToe()
        {
            int counter = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.board[i, j] = counter.ToString();
                    counter++;

                }

            }
            LaunchGame();
        }

        public void Restart()
        {
            int counter = 1;
            this.playCounter = 0;
            this.draw = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.board[i, j] = counter.ToString();
                    counter++;

                }

            }
            LaunchGame();
        }

        private void LaunchGame()
        {
            bool gameover = false;


            while (gameover == false)
            {
                int[] player = { 1, 2 };

                foreach (int i in player)
                {
                    GetBoard();
                    PlayerPlay(player[i - 1]);
                    gameover = Checker();

                    if (gameover && draw == false)
                    {
                        GetBoard();
                        Console.WriteLine("Congratulations Player {0} you won!", player[i - 1]);
                        break;
                    }

                    if (gameover && draw == true)
                    {
                        GetBoard();
                        Console.WriteLine("It is a draw!");
                        break;
                    }
                }

            }

            Console.WriteLine("Would you like to play again? Press y or Y to go");

            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
            {
                Console.Clear();
                Restart();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing this game!");
                Console.Read();
            }



        }

        private void PlayerPlay(int playeri)
        {
            Console.WriteLine("Player {0} turn. Select the bracket to play [1-9] :", playeri);
            ValidatePlayerInput(Console.ReadLine(), playeri);

        }

        private void ValidatePlayerInput(string decision, int player)
        {
            int decisionint;
            bool foundmatch = false;

            if (int.TryParse(decision, out decisionint) == false)
            {
                Console.Clear();
                GetBoard();
                Console.WriteLine("Please enter a valid number between 1-9, the decision was {0}", decision);
                PlayerPlay(player);
                return;
            }
            else if (decisionint < 0 || decisionint > 9)
            {
                Console.Clear();
                GetBoard();
                Console.WriteLine("Please enter a valid number between 1-9, the decision was {0}", decision);
                PlayerPlay(player);
                return;
            }

            // Find the play in the array and ignore if the value is not present

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (decision == this.board[i, j])
                    {
                        SetNewPosition(i, j, player);
                        foundmatch = true;
                    }

                }

            }

            if (!foundmatch)
            {
                Console.WriteLine("Please enter a valid play");
                PlayerPlay(player);
                return;

            }

        }

        private void SetNewPosition(int row, int col, int player)
        {
            string play = "";
            if (player == 1)
            {
                play = "X";
            }
            else if (player == 2)
            {
                play = "O";
            }
            else
            {
                throw new Exception("Unkown Player id");
            }

            this.board[row, col] = play;
            this.playCounter++;

        }

        private void GetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + this.board[i, j]);

                }
                Console.WriteLine("|");

            }
        }

        private bool Checker()
        {

            //Horizontal and Vertical checks
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                if (this.board[i, 0] == this.board[i, 1] && this.board[i, 1] == this.board[i, 2])
                    return true;
                if (this.board[0, i] == this.board[1, i] && this.board[1, i] == this.board[2, i])
                    return true;

            }

            //Diagonal
            if (this.board[0, 0] == this.board[1, 1] && this.board[1, 1] == this.board[2, 2])
                return true;
            if (this.board[0, 2] == this.board[1, 1] && this.board[1, 1] == this.board[2, 0])
                return true;
        

            //Draw?

            if (this.playCounter>=9)
            {
                this.draw = true;
                return true;
            }

            return false;
        }

        ~TicTacToe()
        {

        }
    }
}