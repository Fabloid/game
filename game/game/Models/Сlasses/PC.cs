using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace game.Models.Сlasses
{
    public class PC
    {
        private bool _is_first;

        public char[] Move_PC(char[] arr_moves)
        {
            Data data = new Data();
            int cell = 0;
            Random rand = new Random();
            Is_first_move(arr_moves);
            if (_is_first)
            {
                do
                {
                    cell = rand.Next(9);
                } while (arr_moves[cell] == 'X');
            }
            else
            {
                cell = Is_not_first_move(arr_moves);
                while (arr_moves[cell] == 'X' || arr_moves[cell] == 'O')
                {
                    cell = rand.Next(9);
                }
            }
            data.Add_move(cell+1, 2);
            arr_moves[cell] = 'O';
            return arr_moves;
        }

        private void Is_first_move(char[] arr_moves)
        {
            _is_first = true;
            for (int i = 0; i < arr_moves.Length; i++)
            {
                if (arr_moves[i]=='O')
                {
                    _is_first = false;
                    break;
                }
            }
        }

        private int Is_not_first_move(char[] arr_moves)
        {
            int cell = 0;
            int row = 3;
            int col = 3;
            char[,] temp_arr_moves = new char[row, col];
            for (int i=0;i<row;i++)
            {
                for (int j=0;j<col;j++)
                {
                    temp_arr_moves[i, j] = arr_moves[i * col + j];
                }
            }                        
            
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (temp_arr_moves[i, j] == 'X')
                    {
                        int count_secondary_diagonal = 0, count_main_diagonal = 0, count_horizontal = 0, count_verical = 0;
                        for (int k = 0; k < row; k++)
                        {
                            if (temp_arr_moves[row - k - 1, k] == 'X')
                            {
                                count_secondary_diagonal++;
                            }
                            if (temp_arr_moves[k, k] == 'X')
                            {
                                count_main_diagonal++;
                            }
                            if (temp_arr_moves[i, k] == 'X')
                            {
                                count_horizontal++;
                            }
                            if (temp_arr_moves[k, j] == 'X')
                            {
                                count_verical++;
                            }
                        }

                        for (int k = 0; k < row; k++)
                        {
                            if (count_secondary_diagonal == 2)
                            {
                                if (temp_arr_moves[row - k - 1, k] == ' ')
                                {
                                    cell = (row - k - 1) * col + k;
                                }
                            }
                            if (count_main_diagonal == 2)
                            {
                                if (temp_arr_moves[k, k] == ' ')
                                {
                                    cell = k * col + k;
                                }
                            }
                            if (count_horizontal == 2)
                            {
                                if (temp_arr_moves[i, k] == ' ')
                                {
                                    cell = i * col + k;
                                }
                            }
                            if (count_verical == 2)
                            {
                                if (temp_arr_moves[k, j] == ' ')
                                {
                                    cell = k * col + j;
                                }
                            }
                        }
                    }
                }
            }
            return cell;
        }        

        public string Result_game(char[] arr_moves)
        {
            string result=" ";
            char symbol=' ';
            if (arr_moves[0] == arr_moves[1] && arr_moves[0] == arr_moves[2] && arr_moves[0] != ' ')
                symbol = arr_moves[0];
            if (arr_moves[3] == arr_moves[4] && arr_moves[3] == arr_moves[4] && arr_moves[3] != ' ')
                symbol = arr_moves[3];
            if (arr_moves[6] == arr_moves[7] && arr_moves[7] == arr_moves[8] && arr_moves[6] != ' ')
                symbol = arr_moves[6];
            if (arr_moves[0] == arr_moves[3] && arr_moves[0] == arr_moves[6] && arr_moves[0] != ' ')
                symbol = arr_moves[0];
            if (arr_moves[1] == arr_moves[4] && arr_moves[1] == arr_moves[7] && arr_moves[1] != ' ')
                symbol = arr_moves[1];
            if (arr_moves[2] == arr_moves[5] && arr_moves[2] == arr_moves[8] && arr_moves[2] != ' ')
                symbol = arr_moves[2];
            if (arr_moves[0] == arr_moves[4] && arr_moves[0] == arr_moves[8] && arr_moves[0] != ' ')
                symbol = arr_moves[0];
            if (arr_moves[2] == arr_moves[4] && arr_moves[2] == arr_moves[6] && arr_moves[2] != ' ')
                symbol = arr_moves[2];

            int count = 0;
            for (int i = 0; i < arr_moves.Length; i++)
            {
                if (arr_moves[i] == ' ')
                    count++;
            }
            if (count <= 1)
                result = "Ничья";

            if (symbol == 'X')
                result = "Вы победили";
            if (symbol == 'O')
                result = "Победил ИИ";                       

            return result;
        }
    }
}