using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank.Recursion
{
    public static class SimplifiedChessEngineSolver
    {
        public static Dictionary<char,int> CharToIntIndex = new Dictionary<char, int>()
        {
            {'A', 0},
            {'B', 1},
            {'C', 2},
            {'D', 3}
        };

        public static string simplifiedChessEngine(char[][] whites, char[][] blacks, int moves)
        {
            var whiteState = CreateState(whites);
            var blackState = CreateState(blacks);
            var ifWhite = true;
            var result = FindThePath(whiteState, blackState, 1, ref ifWhite);

            return result ? "YES" : "NO";

        }

        private static char _emptyChar = '\0';

        public static class Pieces
        {
            public const char Q = 'Q';
            public const char N = 'N';
            public const char B = 'B';
            public const char R = 'R';
        }

        public static bool FindThePath(char[,] turn, char[,] noTurn, int moves, ref bool ifWhite)
        {
            var result = false;
            if (moves < 0)
                return false;
            if (moves == 0)
            {
                var wqi = -1;
                var wqj = -1;
                FindQueen(turn, out wqi, out wqj);

                var bqi = -1;
                var bqj = -1;
                FindQueen(noTurn, out bqi, out bqj);

                if (wqi == bqi || wqj == bqj)
                {
                    if (ifWhite)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            //var turn = ifWhiteTurn ? whites : blacks;
            //var notTurn = ifWhiteTurn ? blacks : whites;

            return Process(turn, noTurn, moves, ref ifWhite);
            
        }

        private static bool Process(char[,] turn, char[,] noTurn, int moves, ref bool ifWhite)
        {
            var result = false;
            for (int i = 0; i < turn.GetLength(0); i++)
            {
                for (int j = 0; j < turn.GetLength(0); j++)
                {
                    var current = turn[i, j];
                    if (current == _emptyChar)
                    {
                        continue;
                    }

                    if (current == Pieces.Q)
                    {
                        for (int k = -1 * _boardSize; k < _boardSize; k++)
                        {
                            if (k == 0 || i + k > _boardSize || i + k < -1 * _boardSize) continue;
                            result = MoveVertical(turn, noTurn, moves, i, k, j, current, ref ifWhite);
                            if (result)
                                return result;
                            MoveDiagonal(turn, noTurn, moves, i, k, j, current, ref ifWhite);
                            if (result)
                                return result;
                        }
                    }

                    if (current == Pieces.R)
                    {
                        for (int k = -1 * _boardSize; k < _boardSize; k++)
                        {
                            if (k == 0) continue;
                            result = MoveVertical(turn, noTurn, moves, i, k, j, current, ref ifWhite);
                            if (result)
                                return result;
                        }
                    }

                    if (current == Pieces.B)
                    {
                        for (int k = -1 * _boardSize; k < _boardSize; k++)
                        {
                            if (k == 0) continue;
                            result = MoveDiagonal(turn, noTurn, moves, i, k, j, current, ref ifWhite);
                            if (result)
                                return result;
                        }
                    }

                    if (current == Pieces.N)
                    {
                        result = MoveNight(turn, noTurn, moves, i, j, ref ifWhite);
                        if (result)
                            return result;
                    }
                }
            }

            return false;
        }

        private static bool MoveNight(char[,] turni, char[,] noTurni, int moves, int i, int j, ref bool ifWhite)
        {
            ifWhite = !ifWhite;
            bool result;
            var piece = Pieces.N;

            var turn = turni.Clone() as char[,];
            var noTurn = noTurni.Clone() as char[,];

            turn[i, j] = _emptyChar;


            turn[i + 1, j + 2] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];

            turn[i, j] = _emptyChar;
            turn[i + 1, j - 2] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[i - 1, j - 2] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;


            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[i - 1, j + 2] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[j + 2, i + 1] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[j - 2, i + 1] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[j - 2, i - 1] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;

            turn = turni.Clone() as char[,];
            noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            turn[j + 2, i - 1] = piece;
            result = FindThePath(turn, noTurn, moves - 1, ref ifWhite);
            if (result)
                return result;
            return false;
        }

        private static bool MoveDiagonal(char[,] turni, char[,] noTurni, int moves, int i, int k, int j, char piece, ref bool ifWhite)
        {
            ifWhite = !ifWhite;
            var turn = turni.Clone() as char[,];
            var noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            bool result = false;
            if (i + k < _boardSize && i + k > -1 * _boardSize && j + k < _boardSize && j + k > -1 * _boardSize)
            {
                //diagonal
                turn[i + k, j + k] = piece;
                result = FindThePath(noTurn, turn, moves - 1, ref ifWhite);
            }

            return result;
        }

        private static bool MoveVertical(char[,] turni, char[,] noTurni, int moves, int i, int k, int j, char piece, ref bool ifWhite)
        {
            ifWhite = !ifWhite;
            var turn = turni.Clone() as char[,];
            var noTurn = noTurni.Clone() as char[,];
            turn[i, j] = _emptyChar;
            bool result = false;
            if (i + k < _boardSize && i + k > -1 * _boardSize)
            {
                // vertical
                turn[i + k, j] = piece;
                result = FindThePath(noTurn, turn, moves - 1, ref ifWhite);
            }

            return result;
        }

        private static void FindQueen(char[,] board, out int qi, out int qj)
        {
            qi = -1;
            qj = -1;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i, j] == Pieces.Q)
                    {
                        qi = i;
                        qj = j;
                        break;
                    }
                }
            }
        }
        private static int _boardSize = 4;

        private static char[,] CreateState(char[][] whites)
        {
            var flatted = whites.Select(x => new {val = x[0], iind = CharToIntIndex[x[1]], jind = int.Parse(x[2].ToString()) -1});
            var board = new char[_boardSize, _boardSize];
            foreach (var item in flatted)
            {
                board[item.iind, item.jind] = item.val;
            }

            return board;
        }
    }
}
