


using System.ComponentModel.Design;
using System.Text;

namespace HackerRankAlgorithm.Recursion
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/simplified-chess-engine/problem?isFullScreen=true
    /// </summary>
    public static class SimplifiedChessEngineSolver
    {
        

        public static string simplifiedChessEngine(char[][] whites, char[][] blacks, int moves)
        {
            var whiteList = ConvertArraysToLists<char>(whites);
            var blackList = ConvertArraysToLists<char>(blacks);
            var maxMoveCount = moves;

            var chessManager = new ChessManager ();

            var visitedRepository = new ChessStateRepository();


            var initialState = new ChessState()
            {
                CurrentTurn = 'W',
                BlackPositions = new ChessManager.TwoWayPositionDictionary(blackList),
                WhitePositions = new ChessManager.TwoWayPositionDictionary(whiteList),
                MoveCount = 0,
            };
            
            var queue = new Queue<ChessState>();
            queue.Enqueue(initialState);

            while (queue.Any())
            {
                
                var current = queue.Dequeue();
                
                if (current.MoveCount > maxMoveCount + 1)
                {
                    continue;
                }

                if (visitedRepository.CheckIfExist(current))
                {
                    continue;
                }


                //todo: check no queeen for white too
                if (chessManager.CheckNoQueenForBlack(current))
                {
                    return YesAnswer;
                }

                if (!visitedRepository.TryAdd(current))
                {
                    continue;
                }


                var allPossibleMoves = chessManager.GetAllNextMoves(current);
                //var ss = allPossibleMoves[0].WhitePositions.ToString();
                foreach (var possibleMove in allPossibleMoves)
                {
                    queue.Enqueue(possibleMove);
                }
            }

            return NoAnswer;
        }


        private const string YesAnswer = "YES";
        private const string NoAnswer = "NO";
        private static List<List<T>> ConvertArraysToLists<T>(T[][] inputArray)
        {
            var result = inputArray.Select(x => x.Select(y => y).ToList()).ToList();
            return result;
        }
    }

    public class ChessStateRepository
    {
        private List<ChessState> _states = new List<ChessState>();
        private bool CheckIfEqual(ChessState stateA, ChessState stateB)
        {
            //todo: should I check turn too?
            if (!stateA.WhitePositions.IfEqual(stateB.WhitePositions))
            {
                return false;
            }
            if (!stateA.BlackPositions.IfEqual(stateB.BlackPositions))
            {
                return false;
            }

            return true;
        }


        //todo: what the fuck, expensive
        public bool TryAdd(ChessState current)
        {
            if (CheckIfExist(current))
                return false;
            _states.Add(current);
            return true;
        }

        public bool CheckIfExist(ChessState current)
        {
            foreach (var state in _states)
            {
                if (CheckIfEqual(current, state))
                {
                    return true;
                }
            }


            return false;
        }
    }

    public class ChessState 
    {
        public int MoveCount { get; set; }
        public char CurrentTurn { get; set; } // White (W) or Black (B)

        public ChessManager.TwoWayPositionDictionary WhitePositions { get; set; } =
            new ChessManager.TwoWayPositionDictionary();

        public ChessManager.TwoWayPositionDictionary BlackPositions { get; set; } = new ChessManager.TwoWayPositionDictionary();

        public ChessManager.TwoWayPositionDictionary GetPositionsByTurn()
        {
            return CurrentTurn == 'W' ? WhitePositions : BlackPositions;
        }

        //todo: fucking expensive
        //todo: how about clone!!!
        public ChessState Copy()
        {
            var chessState = new ChessState();

            chessState.MoveCount = MoveCount;
            chessState.CurrentTurn = CurrentTurn;
            chessState.WhitePositions = WhitePositions.Copy();
            chessState.BlackPositions = BlackPositions.Copy();

            return chessState;

        }

        public void SwitchTurn()
        {
            if (CurrentTurn == 'W')
            {
                CurrentTurn = 'B';
            }
            else
            {
                CurrentTurn = 'W';
            }

            MoveCount++;
        }

    }
    public class ChessManager
    {

        private readonly PieceMoverCalculator _moverCalculator = new PieceMoverCalculator();


        public List<ChessState> GetAllNextMoves(ChessState current)
        {
            var allNextStates = new List<ChessState>();
            var currentTurnPositions = current.GetPositionsByTurn();

            foreach (var pieceToPosition in currentTurnPositions.GetPieceToPosition())
            {
                var piece = pieceToPosition.Key;
                foreach (var currentPosition in pieceToPosition.Value)
                {
                    var nextMoveCandidates = _moverCalculator.CalculateAllMoves(piece, currentPosition);
                    foreach (var nextMoveCandidate in nextMoveCandidates)
                    {
                        //todo: how about overlapping with other pieces with other person s turn!!!
                        if (currentTurnPositions.CanMove(piece, nextMoveCandidate))
                        {   
                            //todo: copy is expensive
                            var newState = current.Copy();
                            //todo: what the fuck you are doing!!!
                            var newStatePositions =  newState.GetPositionsByTurn();
                            newStatePositions.TryMove(piece, currentPosition, nextMoveCandidate);
                            newState.SwitchTurn();
                            allNextStates.Add(newState);
                        }
                    }
                }

            }

            return allNextStates;
        }

        public bool CheckNoQueenForBlack(ChessState current)
        {
            var positions = current.BlackPositions;
            //var positions = current.GetPositionsByTurn();
            return !positions.GetPositionsForPiece('Q').Any();

        }

        class PieceMoverCalculator
        {
            public List<PiecePosition> CalculateAllMoves(char pieceName, PiecePosition currentPosition)
            {
                var resultPositions = new List<PiecePosition>();

                var row = currentPosition.Row;
                var col = currentPosition.Column;


                switch (pieceName)
                {
                    case 'Q':
                        AddVerticalHorizontalMoves(row, col, resultPositions);
                        AddDiagonalMoves(row, col, resultPositions);
                        break;
                    case 'N':
                        AddLMoves(resultPositions, row, col);
                        break;
                    case 'B':
                        AddDiagonalMoves(row, col, resultPositions);
                        break;
                    case 'R':
                        AddDiagonalMoves(row, col, resultPositions);
                        break;
                    default:
                        throw new Exception($"unknown piece: {pieceName}");

                }

                return resultPositions;

            }

            private static void AddLMoves(List<PiecePosition> resultPositions, int row, int col)
            {
                resultPositions.Add(new PiecePosition(row + 1, col + 2));
                resultPositions.Add(new PiecePosition(row - 1, col - 2));
                resultPositions.Add(new PiecePosition(row + 1, col - 2));
                resultPositions.Add(new PiecePosition(row - 1, col + 2));

                resultPositions.Add(new PiecePosition(row + 2, col + 1));
                resultPositions.Add(new PiecePosition(row - 2, col - 1));
                resultPositions.Add(new PiecePosition(row + 2, col - 1));
                resultPositions.Add(new PiecePosition(row - 2, col + 1));
            }

            private static void AddDiagonalMoves(int row, int col, List<PiecePosition> resultPositions)
            {
                //diagonal moves
                for (int i = -4; i <= +4; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    var nDiagOne = new PiecePosition(row + i, col + i);
                    resultPositions.Add(nDiagOne);
                }
            }

            private static void AddVerticalHorizontalMoves(int row, int col, List<PiecePosition> resultPositions)
            {
                // left right moves
                for (int i = -4; i <= +4; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }
                    var nRowPosition = new PiecePosition(row + i, col);
                    var nColPosition = new PiecePosition(row, col + i);
                    resultPositions.Add(nRowPosition);
                    resultPositions.Add(nColPosition);
                }
            }
        }

        public class TwoWayPositionDictionary
        {
            private readonly Dictionary<char, List<PiecePosition>> _pieceToPositionMapping = new Dictionary<char, List<PiecePosition>>();
            private readonly Dictionary<PiecePosition, List<char>> _positionToPieceMapping = new Dictionary<PiecePosition, List<char>>();

            public TwoWayPositionDictionary()
            {
            }
            public TwoWayPositionDictionary(Dictionary<char, List<PiecePosition>> pieceToPositionMapping,
                Dictionary<PiecePosition, List<char>> positionToPieceMapping)
            {
                _pieceToPositionMapping = pieceToPositionMapping;
                _positionToPieceMapping = positionToPieceMapping;
            }
            public TwoWayPositionDictionary(List<List<char>> poses)
            {
                var columnChartToIndMappting = new Dictionary<char, int>()
                {
                    {'A',0},
                    {'B',1},
                    {'C',2},
                    {'D',3},
                };

                var positionList = poses.Select((r, rInd) =>
                    new
                    {
                        RowInd = int.Parse($"{r[2]}") - 1,
                        ColInd = columnChartToIndMappting[r[1]],
                        Val = r[0],
                    }
                );

                _pieceToPositionMapping = positionList.GroupBy(x => x.Val)
                    .ToDictionary(x => x.Key, y => 
                        y.Select(x => new PiecePosition(x.RowInd, x.ColInd)).ToList()
                        );


                _positionToPieceMapping = positionList.GroupBy(x => new PiecePosition(x.RowInd, x.ColInd))
                    .ToDictionary(x => x.Key, y => 
                        y.Select(x => x.Val).ToList()
                        );
            }


            public bool CanMove(char piece, PiecePosition position)
            {
                //off the board
                if (position.Row > 3 || position.Column > 3 || position.Row < 0 || position.Column < 0)
                    return false;
                // overlap with other pieces
                if (_positionToPieceMapping.TryGetValue(position, out var _))
                    return false;

                return true;

            }

            public bool TryMove(char piece, PiecePosition source, PiecePosition destination)
            {
                //todo: again can move!!!
                if (CanMove(piece, destination))
                {


                    if (_positionToPieceMapping.TryGetValue(source, out var src))
                        _positionToPieceMapping[source].Remove(piece);

                    if (!_positionToPieceMapping.TryGetValue(destination, out var dest))
                    {
                        _positionToPieceMapping.Add(destination, new List<char>());
                    } 
                    _positionToPieceMapping[destination].Add(piece);



                    if (_pieceToPositionMapping.TryGetValue(piece, out var srcPi))
                        _pieceToPositionMapping[piece].Remove(source);

                    if (!_pieceToPositionMapping.TryGetValue(piece, out var destPi))
                    {
                        _pieceToPositionMapping.Add(piece, new List<PiecePosition>());
                    }
                    _pieceToPositionMapping[piece].Add(destination);

                    
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public Dictionary<char, List<PiecePosition>> GetPieceToPosition()
            {
                //todo: dangerous
                return _pieceToPositionMapping;
            }

            public List<PiecePosition> GetPositionsForPiece(char piece)
            {
                return _pieceToPositionMapping[piece];
            }

            public TwoWayPositionDictionary Copy()
            {
                var piToPos = _pieceToPositionMapping.Select(x =>
                    new KeyValuePair<char, List<PiecePosition>>(x.Key,
                        x.Value.Select(v =>
                            new PiecePosition(v.Row, v.Column)
                        ).ToList()
                    )).ToDictionary(x => x.Key, y => y.Value);

                var posTopi = _positionToPieceMapping.Select(x =>
                    new KeyValuePair<PiecePosition, List<char>>(x.Key,
                        x.Value.ToList()
                    )).ToDictionary(x => x.Key, y => y.Value);

                var result = new TwoWayPositionDictionary(piToPos, posTopi);
                return result;
            }

            public bool IfEqual(TwoWayPositionDictionary destPositions)
            {

                var sourcePiToPos = this.GetPieceToPosition();
                var destPi2Pos = destPositions.GetPieceToPosition();

                foreach (var sourcePiToPo in sourcePiToPos)
                {
                    if (!destPi2Pos.TryGetValue(sourcePiToPo.Key, out var destPos))
                    {
                        return false;
                    }

                    foreach (var srcPo in sourcePiToPo.Value)
                    {
                        if (!destPos.Any(x => x.Equals(srcPo)))
                        {
                            return false;
                        }
                    }
                }

                return true;

            }

            public override string ToString()
            {
                var result = new StringBuilder();
                foreach (var piTpo in _pieceToPositionMapping)
                {
                    var row = $"{piTpo.Key}";
                    //var pi = piTpo.Key;
                    foreach (var po in piTpo.Value)
                    {
                        row =  $"{row}:{po.Row},{po.Column}";
                    }

                    result.AppendLine($"{piTpo.Key} -> {row} -- ");
                }

                return result.ToString();
            }
        }

        public class PiecePosition : IEquatable<PiecePosition>
        {
            public PiecePosition(int row, int column)
            {
                this.Row = row; 
                this.Column = column;
            }
            public int Row { get; set; }
            public int Column { get; set; }

            public bool Equals(PiecePosition? other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Row == other.Row && Column == other.Column;
            }

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((PiecePosition)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Row, Column);
            }
        }

    }
}
