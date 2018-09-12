using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHackerrank
{
    public class QueenAttack2
    {
        public int QueensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            var boardSize = n;
            var queen = new Position() { Row  = r_q-1, Column = c_q-1};

            var result = 0;
            var obstaclesDic = new Dictionary<int, int[]>();

            if (obstacles != null)
            {
                //TODO: Converting 2-d array to dictionary
                obstaclesDic = obstacles
                    .GroupBy(x => x.First())
                    .Select(x => new { Row = x.Key -1, Col = x.Select(y => y[1] -1) })
                    .ToDictionary(x => x.Row, y => y.Col.ToArray());
            }

            
            var boards = new List<BoardCollection<Position>>()
            {
                new BoardCollection<Position>(
                    new RowForwardItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new RowBackwardItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new ColumnForwardItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new ColumnBackwardItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new DiagonalForwardTopItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new DiagonalBackwardDownItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new DiagonalForwardDownItterator<Position>(boardSize, queen.Row, queen.Column)),
                new BoardCollection<Position>(
                    new DiagonalBackwardTopItterator<Position>(boardSize, queen.Row, queen.Column)),

            };

            foreach (var board in boards)
            {
                result += Traverse(board, obstaclesDic);
            }

            return result;
        }

        private static int Traverse(BoardCollection<Position> rowBoard, Dictionary<int, int[]> obstaclesDic)
        {
            var result = 0;
            foreach (var item in rowBoard)
            {
                var box = new Position() {Row = item.Row, Column = item.Column};
                if (obstaclesDic.CheckIfExists(box)) break;
                result++;
            }

            return result;
        }
    }

    public static class DictionaryExtensions
    {
        public static bool CheckIfExists(this Dictionary<int, int[]> obstacles,
            Position obstacle)
        {
            return obstacles.TryGetValue(obstacle.Row, out int[] columns) && columns.Contains(obstacle.Column);
        }
    }

    public class BoardCollection<T> :  IEnumerable<T> where T:Position  
    {
        private readonly IEnumerator<T> _enumrator;

        public BoardCollection(IEnumerator<T> enumerator)
        {
            _enumrator = enumerator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumrator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    //TODO: create a collection and passing on itterators (cant pass on itterator to predefined structures like list)
    public abstract class BoardIterator<T> : IEnumerator<T> where T : Position
    {
        protected readonly int _boardSize;
        protected int _currentRow;
        protected int _currentColumn;
        protected readonly int _startRow;
        protected readonly int _startColumn;
        protected T _current;

        protected BoardIterator(int boardSize, int startRow, int startColumn)
        {
            _boardSize = boardSize;
            _currentRow = startRow;
            _currentColumn = startColumn;
            _startRow = startRow;
            _startColumn = startColumn;
        }

        public abstract bool MoveNext();

        public void Reset()
        {
            _currentRow = _startRow;
            _currentColumn = _startColumn;
        }

        public T Current => (T) new Position(){Column = _currentColumn, Row = _currentRow};

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }
    }

    public class RowForwardItterator<T> : BoardIterator<T> where T:Position
    {
        public RowForwardItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentRow + 1 < _boardSize)
            {
                _currentRow++;
                return true;
            }
            return false;
        }
    }

    public class RowBackwardItterator<T> : BoardIterator<T> where T : Position
    {
        public RowBackwardItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentRow - 1 >= 0)
            {
                _currentRow--;
                return true;
            }
            return false;
        }
    }


    public class ColumnForwardItterator<T> : BoardIterator<T> where T : Position
    {
        public ColumnForwardItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentColumn + 1 < _boardSize)
            {
                _currentColumn++;
                return true;
            }
            return false;
        }
    }

    public class ColumnBackwardItterator<T> : BoardIterator<T> where T : Position
    {
        public ColumnBackwardItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentColumn - 1 >= 0)
            {
                _currentColumn--;
                return true;
            }
            return false;
        }
    }
    public class DiagonalForwardTopItterator<T> : BoardIterator<T> where T : Position
    {
        public DiagonalForwardTopItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentColumn + 1 < _boardSize && _currentRow + 1 < _boardSize)
            {
                _currentColumn++;
                _currentRow++;
                return true;
            }
            return false;
        }
    }

    public class DiagonalBackwardDownItterator<T> : BoardIterator<T> where T : Position
    {
        public DiagonalBackwardDownItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentColumn - 1 >= 0 && _currentRow - 1 >= 0)
            {
                _currentColumn--;
                _currentRow--;
                return true;
            }
            return false;
        }
    }


    public class DiagonalBackwardTopItterator<T> : BoardIterator<T> where T : Position
    {
        public DiagonalBackwardTopItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentRow - 1 >= 0 && _currentColumn + 1 < _boardSize)
            {
                _currentColumn++;
                _currentRow--;
                return true;
            }
            return false;
        }
    }


    public class DiagonalForwardDownItterator<T> : BoardIterator<T> where T : Position
    {
        public DiagonalForwardDownItterator(int boardSize, int startRow, int startColumn) : base(boardSize, startRow, startColumn)
        { }

        public override bool MoveNext()
        {
            if (_currentColumn - 1 >= 0 && _currentRow + 1 < _boardSize)
            {
                _currentRow++;
                _currentColumn--;
                return true;
            }
            return false;
        }
    }
}
