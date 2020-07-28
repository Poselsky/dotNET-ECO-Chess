using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(Position p, ChessColor b)
                : base(p, b) { }

        public override Position[][] PossibleTurns()
        {
            return new Position[][]
            {
                Position.RepeatMove((oneTurn) => oneTurn.Forward(Color).ToRight(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                Position.RepeatMove((oneTurn) => oneTurn.Backwards(Color).ToRight(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                Position.RepeatMove((oneTurn) => oneTurn.Forward(Color).ToLeft(Color)).Where(pos => pos.IsOnBoard()).ToArray(),
                Position.RepeatMove((oneTurn) => oneTurn.Backwards(Color).ToLeft(Color)).Where(pos => pos.IsOnBoard()).ToArray()
            };
        }
    }
}
